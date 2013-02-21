using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowPlanner.Builders
{
    public interface IBuilder<in TInput, out TOutput>
    {
        TOutput Build(TInput input);
    }
}
