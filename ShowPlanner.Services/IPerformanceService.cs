using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowPlanner.Services
{
    public interface IPerformanceService
    {
        QueryResponse<PerformanceDetail> Query(QueryPerformanceRequest request);
    }
}
