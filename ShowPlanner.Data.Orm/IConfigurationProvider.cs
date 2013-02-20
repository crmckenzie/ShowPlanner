using System.Collections.Generic;

namespace ShowPlanner.Data.Orm
{
    public interface IConfigurationProvider
    {
        IEnumerable<IEntityMappingConfiguration> GetAll();
    }
}