using BtapBuoi3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtapBuoi3.Interfaces
{
    public interface IEmployeeCrud
    {
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(string id);
    }
}
