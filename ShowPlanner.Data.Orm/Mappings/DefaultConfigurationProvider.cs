using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowPlanner.Data.Orm.Mappings
{
    public class DefaultConfigurationProvider : IConfigurationProvider
    {
        public IEnumerable<IEntityMappingConfiguration> GetAll()
        {
            return new IEntityMappingConfiguration[]
                       {
                           new RegisterEntitiesConfiguration(), 
                       };
        }
    }
}
