

using System;
using GestorTutelas.webApi.DBContext.Entity;
using GestorTutelas.webApi.DBContext.Infraestructure;

namespace GestorTutelas.webApi.DBContext.Repository.Implementations
{
    public class ParametroRepository : Repository<ParametroEntity,ApiDbContext>
    {
        private ApiDbContext _context;

        //Add any additional repository methods other than the generic ones (GetAll, GetById, Delete, Add)
        public ParametroRepository(ApiDbContext context) : base(context)
        {
           
        }
    }
}
