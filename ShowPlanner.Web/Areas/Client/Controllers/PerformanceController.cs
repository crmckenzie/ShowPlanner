using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowPlanner.Commands.Performances;
using ShowPlanner.Services;

namespace ShowPlanner.Web.Areas.Client.Controllers
{
    public class PerformanceController : Controller, IPerformanceService
    {
        private readonly IPerformanceCommands _performanceCommands;

        public PerformanceController(IPerformanceCommands performanceCommands)
        {
            _performanceCommands = performanceCommands;
        }

        // if there is an additional viewmodel layer, these methods should do the conversion.
        public QueryResponse<PerformanceDetail> Query(QueryPerformanceRequest request)
        {
            using (var command = _performanceCommands.Query())
            {
                var results = command.Execute(request);
                return results;
            }
        }
    }
}
