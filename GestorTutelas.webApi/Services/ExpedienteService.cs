using GestorTutelas.webApi.DBContext;
using GestorTutelas.webApi.DBContext.Entity;
using GestorTutelas.webApi.DBContext.Enums;
using GestorTutelas.webApi.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GestorTutelas.webApi.Services
{
    public class ExpedienteService
    {
        private ApiDbContext ApiDbContext;
        public ExpedienteService(ApiDbContext apiDbContext)
        {
            ApiDbContext = apiDbContext;
        }

        public const string SISTEMA = "Sistema";

        public bool guardarExpediente(RegistroExpedienteFormModel registroExpendienteFormModel)
        {
            var radicado = false;
            try
            {
                Dictionary<string, Guid> roles = new Dictionary<string, Guid>() {
                    { "Accionante", Guid.Parse("a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a11") },
                    { "Accionado", Guid.Parse("a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a12" )},
                    { "Involucrado", Guid.Parse("a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a13" )}
                };

                // Getting Image
                var file_ = registroExpendienteFormModel.File_;
                // Saving Image on Server
                if (file_.Length > 0)
                {
                    var filePath = Path.Combine("C://uploads", file_.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file_.CopyTo(fileStream);
                    }
                    try
                    {

                        var r = registroExpendienteFormModel.registroExpediente();
                        List<PersonaEntity> personas = new List<PersonaEntity>();

                        //roles["accionante"]
                        var accionante = getPersona(r.Accionante);
                        PersonaEntity accionado = getPersona(r.Accionado);
                        List<PersonaEntity> intervinientes = r.Intervinientes.Count > 0 ? r.Intervinientes.Select(i => getPersona(i)).ToList() : null;

                        // guardar personas

                        // crear personas rol
                        var intervinientesRol = new List<PersonaRolEntity>();
                        if (intervinientes != null)
                        {
                             intervinientesRol = intervinientes.Select(i => getPersonaRol(roles["Intervinientes"], i.Id)).ToList();
                        }
                        
                        intervinientesRol.Add(getPersonaRol(roles["Accionante"], accionante.Id));
                        intervinientesRol.Add(getPersonaRol(roles["Accionado"], accionado.Id));
                        //guardar personasRol

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
                            usuarioModifica = string.Empty

                        };
                        //guardar expediente

                        // crear proceso expediente

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

                        //guardar personas expediente

                        //crear archivo expediente

                        //guardar archivo expediente

                        //commit transaction
                        radicado = true;
                    }
                    catch (Exception)
                    {

                        //rollback transaction
                    }

                    //  this._PersonaRepository.Insert(new PersonaEntity { Nombres = nombre, IdMunicipioResidencia = 1 });
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
