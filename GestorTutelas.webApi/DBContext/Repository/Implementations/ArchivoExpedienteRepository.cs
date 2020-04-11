

using System;
using GestorTutelas.webApi.DBContext.Entity;
using GestorTutelas.webApi.DBContext.Infraestructure;

namespace GestorTutelas.webApi.DBContext.Repository.Implementations
{
    public class ArchivoExpedienteRepository : Repository<ArchivoExpedienteEntity,ApiDbContext>
    {
        private ApiDbContext _context;

        //Add any additional repository methods other than the generic ones (GetAll, Get, Delete, Add)
        public ArchivoExpedienteRepository(ApiDbContext context) : base(context)
        {
           
        }
    }
}