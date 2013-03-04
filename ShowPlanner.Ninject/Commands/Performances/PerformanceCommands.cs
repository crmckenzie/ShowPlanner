using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowPlanner.Commands;
using ShowPlanner.Commands.Performances;
using ShowPlanner.Services;

namespace ShowPlanner.Ninject.Commands.Performances
{
    public class PerformanceCommands : IPerformanceCommands
    {
        private readonly ICommandBuilder _commandBuilder;

        public PerformanceCommands(ICommandBuilder commandBuilder )
        {
            _commandBuilder = commandBuilder;
        }

        public ICommand<QueryPerformanceRequest, QueryResponse<PerformanceDetail>> Query()
        {
            var result = _commandBuilder
                .Requires<QueryPerformanceRequest>()
                .RespondsWith<QueryResponse<PerformanceDetail>>()
                .WithRequestValidation()
                .WithPerformanceLogging()
                .Build()
                ;

            return result;
        }
    }
}
