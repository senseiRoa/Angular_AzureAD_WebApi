

using System;
using GestorTutelas.webApi.DBContext.Entity;
using GestorTutelas.webApi.DBContext.Infraestructure;

namespace GestorTutelas.webApi.DBContext.Repository.Implementations
{
    public class ExpedienteDigitalRepository : Repository<ExpedienteDigitalEntity,ApiDbContext>
    {
        private ApiDbContext _context;

        //Add any additional repository methods other than the generic ones (GetAll, Get, Delete, Add)
        public ExpedienteDigitalRepository(ApiDbContext context) : base(context)
        {
           
        }
    }
}
