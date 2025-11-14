
using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Interfaces;

namespace BeeBuzz.Data.Repositories
{
    public class BeeHivesRepository : BeeBuzzGenericGenericRepository<BeeHivesRepository>, IBeeHiveRepository
    {
        private readonly ILogger<BeeHivesRepository> _specificLogger;

        public BeeHivesRepository(
            ApplicationDbContext db,
            ILogger<BeeBuzzGenericGenericRepository<BeeHives>> genericLogger,
            ILogger<BeeHivesRepository> specificLogger)
            : base(db, genericLogger)
        {
            _specificLogger = specificLogger;
        }

        public void Add(BeeHives entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BeeHives entity)
        {
            throw new NotImplementedException();
        }

        public void Update(BeeHives entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<BeeHives> IBeeBuzzGenericRepository<BeeHives>.GetAll()
        {
            throw new NotImplementedException();
        }

        BeeHives IBeeBuzzGenericRepository<BeeHives>.GetById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
