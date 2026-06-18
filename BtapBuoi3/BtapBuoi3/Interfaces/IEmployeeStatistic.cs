using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtapBuoi3.Interfaces
{
    public interface IEmployeeStatistic
    {
        double GetTotalSalary();
        Dictionary<string, int> CountByType();
    }
}
