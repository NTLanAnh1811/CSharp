using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtapBuoi3.Models
{
    public class InternEmployee : Employee
    {
        public double Allowance { get; set; }
        public InternEmployee(string id, string fullname, double allowance)
            : base(id, fullname)
        {
            Allowance = allowance;
        }
        public override double CalculateSalary()
        {
            return Allowance;
        }
    }
}
