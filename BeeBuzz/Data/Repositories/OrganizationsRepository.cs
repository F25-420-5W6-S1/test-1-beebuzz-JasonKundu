using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Interfaces;

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



        // (from our code as example. Ignore if this is not deleted)
        //public WinnerPositions GetByPosition(string position)
        //{
        //    try
        //    {
        //        _specificLogger.LogInformation("Getting WinnerPosition by position name: {Position}", position);
        //        var winnerPosition = _dbSet
        //            .FirstOrDefault(wp => wp.Position == position);

        //        if (winnerPosition == null)
        //        {
        //            _specificLogger.LogWarning("WinnerPosition '{Position}' not found", position);
        //        }
        //        else
        //        {
        //            _specificLogger.LogInformation("Found WinnerPosition: {Position}", position);
        //        }

        //        return winnerPosition;
        //    }
        //    catch (Exception ex)
        //    {
        //        _specificLogger.LogError(ex, "Failed to get WinnerPosition by position: {Position}", position);
        //        throw;
        //    }
        //}
    }
}
