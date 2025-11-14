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

        public ICollection<ApplicationUsers> GetAllUsers(int organizationId)
        {

            try
            {
                _specificLogger.LogInformation("Getting all projects for Hackathon ID: {HackathonId}", hackathonId);

                var organizations = _dbSet
                  .Include(p => p.Users)
                      .ThenInclude(tm => tm.User)
                  .Include(p => p.Organisation)
                  .FirstOrDefault(p => p.Id == id);



                _specificLogger.LogInformation("Found Organizations",
                    organizations.Users.Count, organizationId);

                List<ApplicationUsers> organizationUsers = [];
                foreach( ApplicationUsers user in Organizations)
                {
                    organizationUsers.Append(user);
                }

                return users;
            }
            catch (Exception ex)
            {
                _specificLogger.LogError(ex, "Failed to get projects for Hackathon ID: {HackathonId}", hackathonId);
                throw;
            }

        }
    }
}
