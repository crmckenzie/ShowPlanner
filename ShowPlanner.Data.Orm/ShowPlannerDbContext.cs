using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace ShowPlanner.Data.Orm
{
    public class ShowPlannerDbContext : DbContext
    {
        private readonly IConfigurationProvider _configurationProvider;

        public ObjectContext ObjectContext
        {
            get { return ((IObjectContextAdapter)this).ObjectContext; }
        }

        public ObjectStateManager ObjectStateManager
        {
            get { return this.ObjectContext.ObjectStateManager; }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var configurations = _configurationProvider.GetAll();

            foreach (var configuration in configurations)
            {
                configuration.Configure(modelBuilder);
            }

        }

        public ShowPlannerDbContext(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }
    }
}
