using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtapBuoi3.Models
{
    public class FullTimeEmployee : Employee
    {
        public double BaseSalary {  get; set; }
        public double Bonus {  get; set; }
        public FullTimeEmployee(string id, string fullname, double baseSalary, double bonus)
            : base(id, fullname)
        {
            BaseSalary = baseSalary;
            Bonus = bonus;
        }
        public override double CalculateSalary()
        {
            return BaseSalary + Bonus;
        }
    }
}
