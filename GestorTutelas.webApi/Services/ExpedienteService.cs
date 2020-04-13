using GestorTutelas.webApi.DBContext;
using GestorTutelas.webApi.DBContext.Entity;
using GestorTutelas.webApi.DBContext.Enums;
using GestorTutelas.webApi.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace GestorTutelas.webApi.Services
{
    public class ExpedienteService
    {
        private ApiDbContext _ApiDbContext;
        private IFileClient _fileClient;
        public ExpedienteService(ApiDbContext apiDbContext, IFileClient fileClient)
        {
            _ApiDbContext = apiDbContext;
            _fileClient = fileClient;
        }

        public const string SISTEMA = "Sistema";

        public async Task<Boolean> guardarExpediente(RegistroExpedienteFormModel registroExpendienteFormModel)
        {
            var radicado = false;
            try
            {
                Dictionary<string, Guid> roles = new Dictionary<string, Guid>() {
                    { "Accionante", Guid.Parse("a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a11") },
                    { "Accionado", Guid.Parse("a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a12" )},
                    { "Interviniente", Guid.Parse("a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a13" )}
                };

                // Getting Image
                var file_ = registroExpendienteFormModel.File_;
                // Saving Image on Server
                if (file_.Length > 0)
                {
                    var r = registroExpendienteFormModel.registroExpediente();
                    var fileName = $"{r.Especialidad.ToString()}_{r.DerechoFundamental.ToString()}_{file_.FileName}";
                    string extension = Path.GetExtension(file_.FileName);
                    var filestoreName = DateTime.Now.ToString("yyyy_MM_dd");
                    
                    var contentType = file_.ContentType;
                    var tamanho = file_.Length / 1024;

                    using (var fileStream = file_.OpenReadStream())
                    {
                        await _fileClient.SaveFile(filestoreName, fileName, fileStream);

                    }


                    using (var transaction = this._ApiDbContext.Database.BeginTransaction())
                    {
                        try
                        {
                           
                            List<PersonaEntity> personas = new List<PersonaEntity>();


                            var accionante = getPersona(r.Accionante);
                            PersonaEntity accionado = getPersona(r.Accionado);
                            List<PersonaEntity> intervinientes = r.Intervinientes != null && r.Intervinientes.Count > 0 ? r.Intervinientes.Select(i => getPersona(i)).ToList() : null;
                            this._ApiDbContext.Add(accionante);
                            this._ApiDbContext.Add(accionado);
                            if (intervinientes != null)
                            {
                                this._ApiDbContext.AddRange(intervinientes);
                            }
                            this._ApiDbContext.SaveChanges();


                            // crear personas rol
                            var intervinientesRol = new List<PersonaRolEntity>();
                            if (intervinientes != null)
                            {
                                intervinientesRol = intervinientes.Select(i => getPersonaRol(roles["Interviniente"], i.Id)).ToList();
                            }

                            intervinientesRol.Add(getPersonaRol(roles["Accionante"], accionante.Id));
                            intervinientesRol.Add(getPersonaRol(roles["Accionado"], accionado.Id));
                            this._ApiDbContext.AddRange(intervinientesRol);
                            this._ApiDbContext.SaveChanges();

                            // creo expediente
                            var expediente = new ExpedienteDigitalEntity()
                            {
                                Id = Guid.NewGuid(),
                                DerechoFundamental = r.DerechoFundamental,
                                Especialidad = r.Especialidad,
                                EstadoExpediente = EstadoExpedienteParametroEnum.SinAsignar,
                                CodigoRadicado = "pendiente por definir",
                                Estado = EstadoRegistroEnum.Activo,
                                fechaCreacion = DateTime.Now,
                                fechaEdicion = DateTime.Now,
                                FechaRadicado = DateTime.Now,
                                IdMunicipioRadicado = r.IdMunicipioRadicado,
                                UsuarioCrea = SISTEMA,
                                usuarioModifica = string.Empty,
                                TerminosyCondiciones = r.TerminosyCondiciones

                            };
                            this._ApiDbContext.Add(expediente);
                            this._ApiDbContext.SaveChanges();

                            // crear personas expediente

                            var personasExpediente = intervinientesRol.Select(i => new PersonasExpedienteEntity()
                            {
                                Id = Guid.NewGuid(),
                                idPersonaRol = i.Id,
                                idExpediente = expediente.Id,
                                Estado = EstadoRegistroEnum.Activo,
                                UsuarioCrea = SISTEMA,
                                usuarioModifica = string.Empty,
                                fechaCreacion = DateTime.Now,
                                fechaEdicion = DateTime.Now
                            }).ToList();
                            this._ApiDbContext.AddRange(personasExpediente);
                            this._ApiDbContext.SaveChanges();

                            //actualizar archivo expediente
                          var  archivoExpediente = new ArchivoExpedienteEntity()
                            {

                                Id = Guid.NewGuid(),
                                ruta = Path.Combine(filestoreName, fileName),
                                formato = contentType,
                                tamanho = tamanho + "",
                                hash = "",
                                nombreCargado = file_.FileName,
                                nombreAsignado = fileName,
                                TipoArchivo = TipoArchivoParametroEnum.CargadoCiudadano,
                                Estado = EstadoRegistroEnum.Activo,
                                UsuarioCrea = SISTEMA,
                                usuarioModifica = string.Empty,
                                fechaCreacion = DateTime.Now,
                                fechaEdicion = DateTime.Now
                            };
                            archivoExpediente.idExpediente = expediente.Id;
                            this._ApiDbContext.Add(archivoExpediente);
                            this._ApiDbContext.SaveChanges();
                                                       

                            //commit transaction
                            radicado = true;
                            transaction.Commit();

                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("hubo un error guardando el Expediente Digital=>"+ex.Message);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return radicado;
        }
        #region MapEntity

        private PersonaEntity getPersona(PersonaExpedienteModel p)
        {
            PersonaEntity persona = new PersonaEntity
            {
                Id = Guid.NewGuid(),
                Nombres = p.Nombres,
                Apellidos = p.Apellidos,
                Celular = p.Celular,
                Direccion = p.Direccion,
                Documento = p.Documento,
                IdMunicipioResidencia = p.IdMunicipioResidencia,
                Telefono = p.Telefono,
                CorreoElectronico = p.CorreoElectronico,
                TipoDocumento = p.TipoDocumento,
                UsuarioCrea = SISTEMA,
                Estado = EstadoRegistroEnum.Activo,
                fechaCreacion = DateTime.Now,
                fechaEdicion = DateTime.Now,
                usuarioModifica = string.Empty

            };

            return persona;

        }

        private PersonaRolEntity getPersonaRol(Guid IdRol, Guid IdPersona)
        {
            PersonaRolEntity personaRol = new PersonaRolEntity
            {
                Id = Guid.NewGuid(),
                idPersona = IdPersona,
                idRol = IdRol,
                UsuarioCrea = SISTEMA,
                Estado = EstadoRegistroEnum.Activo,
                fechaCreacion = DateTime.Now,
                fechaEdicion = DateTime.Now,
                usuarioModifica = string.Empty

            };

            return personaRol;

        }
        #endregion
    }
}
