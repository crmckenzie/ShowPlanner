using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPA.Repository;

namespace ShowPlanner.Data
{
    public interface IDatabase
    {
        IRepository NewRepository();
    }
}
