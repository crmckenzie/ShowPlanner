using System;
using log4net;

namespace ShowPlanner.Logging
{
    public interface ILogProvider
    {
        ILog GetLogForType(Type type);
    }
}