using BtapBuoi3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtapBuoi3.Interfaces
{
    public interface IEmployeeSearch
    {
        Employee FindById(string id);
        List<Employee> FindByName(string keyword);
    }
}
