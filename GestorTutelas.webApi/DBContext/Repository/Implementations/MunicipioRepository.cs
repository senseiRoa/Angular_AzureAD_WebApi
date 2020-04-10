

using System;
using GestorTutelas.webApi.DBContext.Entity;
using GestorTutelas.webApi.DBContext.Infraestructure;

namespace GestorTutelas.webApi.DBContext.Repository.Implementations
{
    public class MunicipioRepository : Repository<MunicipioEntity,ApiDbContext>
    {
        private ApiDbContext _context;

        //Add any additional repository methods other than the generic ones (GetAll, GetById, Delete, Add)
        public MunicipioRepository(ApiDbContext context) : base(context)
        {
           
        }
    }
}
