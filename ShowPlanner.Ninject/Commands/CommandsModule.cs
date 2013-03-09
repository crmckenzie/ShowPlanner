using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using ShowPlanner.Commands;
using ShowPlanner.Commands.Performances;
using ShowPlanner.Ninject.Commands.Performances;
using ShowPlanner.Services;

namespace ShowPlanner.Ninject.Commands
{
    public class CommandsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICommandBuilder>().To<CommandBuilder>();

            Bind<ICommand<QueryPerformanceRequest, QueryResponse<PerformanceDetail>>>()
                .To<QueryPerformanceCommand>();

            Bind<IPerformanceCommands>().To<PerformanceCommands>();


        }
    }
}
