using Microsoft.EntityFrameworkCore;

namespace Bliss.Data.Context
{
    public class BlissDbContext : DbContext
    {
        public BlissDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}