﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using ShowPlanner.Builders;
using ShowPlanner.Commands.Performances;
using ShowPlanner.Services;

namespace ShowPlanner.Web.Areas.Client.Controllers
{
    public class PerformanceController : ApiController, IPerformanceService
    {
        private readonly IPerformanceCommands _performanceCommands;
        private readonly IBuild _builder;

        public PerformanceController(IPerformanceCommands performanceCommands, IBuild builder)
        {
            _performanceCommands = performanceCommands;
            _builder = builder;
        }

        public QueryResponse<PerformanceDetail> Search(string term)
        {
            using (var command = _performanceCommands.Query())
            {
                var request = _builder
                    .Create<QueryPerformanceRequest>()
                    .From(term)
                    ;
                var results = command.Execute(request);
                return results;
            }       
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
