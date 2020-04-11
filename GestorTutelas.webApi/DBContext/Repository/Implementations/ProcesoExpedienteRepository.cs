

using System;
using GestorTutelas.webApi.DBContext.Entity;
using GestorTutelas.webApi.DBContext.Infraestructure;

namespace GestorTutelas.webApi.DBContext.Repository.Implementations
{
    public class ProcesoExpedienteRepository : Repository<ProcesoExpedienteEntity,ApiDbContext>
    {
        private ApiDbContext _context;

        //Add any additional repository methods other than the generic ones (GetAll, Get, Delete, Add)
        public ProcesoExpedienteRepository(ApiDbContext context) : base(context)
        {
           
        }
    }
}
