using System;
using ShowPlanner.Services;

namespace ShowPlanner.Commands.Performances
{
    public interface IPerformanceCommands
    {
        ICommand<QueryPerformanceRequest, QueryResponse<PerformanceDetail>> Query();
    }
}