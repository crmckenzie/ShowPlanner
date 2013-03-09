using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using ShowPlanner.Ninject.Commands;

namespace ShowPlanner.Ninject
{
    public class NinjectConfiguration
    {
        public void Configure(IKernel kernel)
        {
            kernel.Load(new CommandsModule());
        }
    }
}
