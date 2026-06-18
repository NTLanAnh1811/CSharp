using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtapBuoi3.Models
{
    public class PartTimeEmployee : Employee
    {
        public double WorkingHours {  get; set; }
        public double HourlyRate { get; set; }
        public PartTimeEmployee(string id, string fullname, double workingHours, double hourlyRate)
            : base(id, fullname)
        {
            WorkingHours = workingHours;
            HourlyRate = hourlyRate;
        }
        public override double CalculateSalary()
        {
            return WorkingHours * HourlyRate;
        }
    }
}
