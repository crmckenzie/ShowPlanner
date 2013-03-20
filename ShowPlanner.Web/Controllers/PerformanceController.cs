using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowPlanner.Builders;
using ShowPlanner.Commands.Performances;
using ShowPlanner.Services;

namespace ShowPlanner.Web.Controllers
{
    public class PerformanceController : Controller
    {
        private readonly IPerformanceCommands _performanceCommands;
        private readonly IBuild _builder;

        public PerformanceController(IPerformanceCommands performanceCommands, IBuild builder)
        {
            _performanceCommands = performanceCommands;
            _builder = builder;
        }

        //
        // GET: /Performance/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string term)
        {
            using (var command = _performanceCommands.Query())
            {
                var request = _builder
                    .Create<QueryPerformanceRequest>()
                    .From(term)
                    ;
                var results = command.Execute(request);

                var model = _builder
                    .Create<PerformanceSearchResultsViewModel>()
                    .From(results);

                return View(model);
            }       
        }

    }

    public class PerformanceSearchResultsViewModel
    {
    }
}
