using System.Data.Entity;

namespace ShowPlanner.Data.Orm
{
    public interface IEntityMappingConfiguration
    {
        void Configure(DbModelBuilder modelBuilder);
    }
}