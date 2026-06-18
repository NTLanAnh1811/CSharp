using BtapBuoi3.Interfaces;
using BtapBuoi3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtapBuoi3
{
    public class EmployeeService : IEmployeeCrud, IEmployeeSearch, IEmployeeStatistic
    {
        private readonly IEmployeeRepository repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            this.repository = repository;
        }
        public void Add(Employee employee)
        {
            repository.Add(employee);
        }
        public void Update(Employee employee)
        {
            repository.Update(employee);
        }
        public void Delete(string id)
        {
            repository.Delete(id);
        }
        public Employee FindById(string id)
        {
            return repository.GetById(id);
        }
        public List<Employee> FindByName(string keyword)
        {
            return repository.GetAll()
                .Where(e => e.FullName.ToLower()
                .Contains(keyword.ToLower())).ToList();
        }
        public double GetTotalSalary()
        {
            return repository.GetAll()
                .Sum(e => e.CalculateSalary());
        }
        public Dictionary<string, int> CountByType()
        {
            return repository.GetAll()
                .GroupBy(e => e.GetType().FullName)
                .ToDictionary(g => g.Key, g => g.Count());
        }
        public Employee GetHighestSalaryEmployee()
        {
            return repository.GetAll()
                .OrderByDescending(e => e.CalculateSalary())
                .FirstOrDefault();
        }
        public List<Employee> SortBySalaryDesc()
        {
            return repository.GetAll()
                .OrderByDescending(e => e.CalculateSalary())
                .ToList();
        }
        public List<Employee> GetAll()
        {
            return repository.GetAll();
        }
    }
}
