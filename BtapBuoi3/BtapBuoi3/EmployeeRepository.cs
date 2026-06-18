using BtapBuoi3.Interfaces;
using BtapBuoi3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtapBuoi3
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> employees = new List<Employee>();
        public void Add(Employee employee)
        {
            employees.Add(employee);
        }

        public void Delete(string id)
        {
            Employee employee = GetById(id);
            if(employee != null) {
                employees.Remove(employee);
            }
        }

        public List<Employee> GetAll()
        {
            return employees;
        }

        public Employee GetById(string id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Employee employee)
        {
            int index = employees.FindIndex(e => e.Id == employee.Id);
            if (index >= 0)
            {
                employees[index] = employee;
            }
        }
    }
}
