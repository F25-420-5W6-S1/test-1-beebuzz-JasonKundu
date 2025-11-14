using BeeBuzz.Data.Interfaces;
using BeeBuzz.Data;
using Microsoft.EntityFrameworkCore;
using BeeBuzz.Data.Entities;

namespace BeeBuzz.Data.Repositories
{
    public class BeeBuzzGenericGenericRepository<T> : IBeeBuzzGenericRepository<T> where T : class
    {
        internal readonly ILogger<BeeBuzzGenericGenericRepository<T>> _logger;
        internal readonly ApplicationDbContext _context;
        internal readonly DbSet<T> _dbSet;
        private ApplicationDbContext db;
        private ILogger<BeeBuzzGenericGenericRepository<BeeHives>> genericLogger;

        public BeeBuzzGenericGenericRepository(ApplicationDbContext db, ILogger<BeeBuzzGenericGenericRepository<T>> logger) 
        {
            _logger = logger;
            _context = db;
            _dbSet = _context.Set<T>();
        }

        public BeeBuzzGenericGenericRepository(ApplicationDbContext db, ILogger<BeeBuzzGenericGenericRepository<BeeHives>> genericLogger)
        {
            this.db = db;
            this.genericLogger = genericLogger;
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                _logger.LogInformation("GetAll was called...");

                return _dbSet.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get: {ex}");
                return null;
            }
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
