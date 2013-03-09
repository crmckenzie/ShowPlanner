using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ShowPlanner.Commands.Performances;
using ShowPlanner.Services;

namespace ShowPlanner.Web.Areas.Client.Controllers
{
    public class PerformanceController : ApiController, IPerformanceService
    {
        private readonly IPerformanceCommands _performanceCommands;

        public PerformanceController(IPerformanceCommands performanceCommands)
        {
            _performanceCommands = performanceCommands;
        }

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
