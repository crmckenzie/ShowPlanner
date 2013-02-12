using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isg.Lib
{
    public interface IBuild<in TInput, out TOutput>
    {
        TOutput Build(TInput input);
    }
}
