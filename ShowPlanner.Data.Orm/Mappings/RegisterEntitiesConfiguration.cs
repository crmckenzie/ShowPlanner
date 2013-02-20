using System.Data.Entity;
using ShowPlanner.Data.Models;

namespace ShowPlanner.Data.Orm.Mappings
{
    public class RegisterEntitiesConfiguration : IEntityMappingConfiguration
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<Performance>();
            modelBuilder.Entity<Performer>();
            modelBuilder.Entity<Show>();
            modelBuilder.Entity<Stage>();
            modelBuilder.Entity<Ticket>();
            modelBuilder.Entity<Venue>();
        }
    }
}