using System;
using ShowPlanner.Logging;

namespace ShowPlanner.Commands
{
    public class PerformanceCommandDecorator<TRequest, TResponse> : CommandDecorator<TRequest, TResponse>
    {
        private readonly ILogProvider _logProvider;

        public PerformanceCommandDecorator(ICommand<TRequest, TResponse> innerCommand, ILogProvider logProvider)
            : base(innerCommand)
        {
            _logProvider = logProvider;
        }

        public override TResponse Execute(TRequest request)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            try
            {
                return base.InnerCommand.Execute(request);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                stopwatch.Stop();
                var innerType = base.GetInnermostCommandType();
                var log = _logProvider.GetLogForType(innerType);
                log.InfoFormat("Executed {0} in {1} milliseconds.", innerType.FullName, stopwatch.ElapsedMilliseconds);
            }
        }
    }
}