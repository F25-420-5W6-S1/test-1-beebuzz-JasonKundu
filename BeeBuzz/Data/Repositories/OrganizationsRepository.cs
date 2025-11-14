using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BeeBuzz.Data.Repositories
{
    public class OrganizationsRepository : BeeBuzzGenericGenericRepository<Organizations>, IOrganizationsRepository
    {
        private readonly ILogger<OrganizationsRepository> _specificLogger;

        public OrganizationsRepository(
            ApplicationDbContext db,
            ILogger<BeeBuzzGenericGenericRepository<Organizations>> genericLogger,
            ILogger<OrganizationsRepository> specificLogger)
            : base(db, genericLogger)
        {
            _specificLogger = specificLogger;
        }

        public ICollection<ApplicationUsers> GetAllUsersByOrganizationId(int organizationId)
        {

            try
            {
                _specificLogger.LogInformation("Getting all users for organization: {organizationId}", organizationId);

                var organizations = _dbSet
                    .Where(org => org.OrganizationId == organizationId)
                    .Include(org => org.Users)
                    .ToList();
                List<ApplicationUsers> users = [];
                
                foreach(Organizations org in organizations)
                {
                    users.AddRange(org.Users);
                }
                   
                _specificLogger.LogInformation("Found {Count} users for organization ID: {ProjectId}",
                    users.Count, organizationId);


                    
                return users;
            }
            catch (Exception ex)
            {
                _specificLogger.LogError(ex, "Failed to get users for organization with id : {organizationId}", organizationId);
                throw;
            }

        }

        public ICollection<BeeHives> GetAllBeeHivesByOrganizationId(int organizationId)
        {

            try
            {
                _specificLogger.LogInformation("Getting all BeeHives for organization: {organizationId}", organizationId);

                // get orgs
                var organizations = _dbSet
                    .Where(org => org.OrganizationId == organizationId)
                    .Include(org => org.Users)
                    .ToList();

                // get users 
                List<ApplicationUsers> users = [];
                foreach (Organizations org in organizations)
                {
                    users.AddRange(org.Users);
                }

                List<BeeHives> beeHives = [];

                foreach(ApplicationUsers appUser in users)
                {
                    beeHives.AddRange(appUser.ManagedBeeHives);
                }

                return beeHives;
            }
            catch (Exception ex)
            {
                _specificLogger.LogError(ex, "Failed to get beehives for organization with ID: {organizationId}", organizationId);
                throw;
            }

        }
    }
}
