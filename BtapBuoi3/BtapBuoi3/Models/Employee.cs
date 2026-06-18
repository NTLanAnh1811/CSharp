using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtapBuoi3.Models
{
    public abstract class Employee
    {
        public string Id { get; set; }
        public string FullName {  get; set; }
        protected Employee(string id, string fullname) {
            Id = id;
            FullName = fullname;
        }
        public abstract double CalculateSalary();
    }
}
