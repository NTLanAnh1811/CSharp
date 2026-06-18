using BtapBuoi3.Interfaces;
using BtapBuoi3.Models;
using System;
using System.Collections.Generic;

namespace BtapBuoi3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEmployeeRepository repository = new EmployeeRepository();
            EmployeeService service = new EmployeeService(repository);

            while (true)
            {
                Console.Clear();

                Console.WriteLine("===== QUAN LY NHAN VIEN =====");
                Console.WriteLine("1. Them nhan vien");
                Console.WriteLine("2. Hien thi danh sach nhan vien");
                Console.WriteLine("3. Tim nhan vien theo ma");
                Console.WriteLine("4. Tim nhan vien theo ten");
                Console.WriteLine("5. Tinh tong luong");
                Console.WriteLine("6. Tim nhan vien co luong cao nhat");
                Console.WriteLine("7. Sap xep nhan vien theo luong giam dan");
                Console.WriteLine("8. Thong ke so luong nhan vien theo loai");
                Console.WriteLine("9. Cap nhat thong tin nhan vien");
                Console.WriteLine("10. Xoa nhan vien");
                Console.WriteLine("0. Thoat");

                Console.Write("\nNhap lua chon: ");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Nhap lai: ");
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            AddEmployee(service);
                            break;

                        case 2:
                            ShowAll(service);
                            break;

                        case 3:
                            FindById(service);
                            break;

                        case 4:
                            FindByName(service);
                            break;

                        case 5:
                            Console.WriteLine("Tong luong: " + service.GetTotalSalary());
                            break;

                        case 6:
                            ShowHighestSalary(service);
                            break;

                        case 7:
                            SortSalary(service);
                            break;

                        case 8:
                            Statistics(service);
                            break;

                        case 9:
                            Console.WriteLine("Chuc nang cap nhat chua hoan thien.");
                            break;

                        case 10:
                            DeleteEmployee(service);
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("Lua chon khong hop le!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Loi: " + ex.Message);
                }

                Console.WriteLine("\nNhan phim bat ky de tiep tuc...");
                Console.ReadKey();
            }
        }

        static void AddEmployee(EmployeeService service)
        {
            Console.WriteLine("1. FullTime");
            Console.WriteLine("2. PartTime");
            Console.WriteLine("3. Intern");

            int type;
            int.TryParse(Console.ReadLine(), out type);

            string id = EmployeeIdGenerator.GenerateId();

            Console.Write("Ho ten: ");
            string name = Console.ReadLine();

            if (!EmployeeValidator.ValidateName(name))
            {
                Console.WriteLine("Ten khong hop le!");
                return;
            }

            switch (type)
            {
                case 1:
                    Console.Write("Luong co ban: ");
                    double baseSalary = double.Parse(Console.ReadLine());

                    Console.Write("Thuong: ");
                    double bonus = double.Parse(Console.ReadLine());

                    service.Add(
                        new FullTimeEmployee(
                            id,
                            name,
                            baseSalary,
                            bonus));
                    break;

                case 2:
                    Console.Write("So gio lam: ");
                    double hours = double.Parse(Console.ReadLine());

                    Console.Write("Luong theo gio: ");
                    double rate = double.Parse(Console.ReadLine());

                    service.Add(
                        new PartTimeEmployee(
                            id,
                            name,
                            hours,
                            rate));
                    break;

                case 3:
                    Console.Write("Tro cap: ");
                    double allowance = double.Parse(Console.ReadLine());

                    service.Add(
                        new InternEmployee(
                            id,
                            name,
                            allowance));
                    break;

                default:
                    Console.WriteLine("Loai khong hop le!");
                    return;
            }

            Console.WriteLine("Them thanh cong!");
        }

        static void ShowAll(EmployeeService service)
        {
            List<Employee> employees = service.GetAll();

            if (employees.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }

            foreach (Employee emp in employees)
            {
                Console.WriteLine(
                    $"{emp.Id} - {emp.FullName} - {emp.GetType().Name} - {emp.CalculateSalary()}");
            }
        }

        static void FindById(EmployeeService service)
        {
            Console.Write("Nhap ma: ");
            string id = Console.ReadLine();

            Employee emp = service.FindById(id);

            if (emp == null)
            {
                Console.WriteLine("Khong tim thay!");
                return;
            }

            Console.WriteLine(
                $"{emp.Id} - {emp.FullName} - {emp.CalculateSalary()}");
        }

        static void FindByName(EmployeeService service)
        {
            Console.Write("Nhap ten: ");
            string keyword = Console.ReadLine();

            List<Employee> result = service.FindByName(keyword);

            foreach (Employee emp in result)
            {
                Console.WriteLine(
                    $"{emp.Id} - {emp.FullName} - {emp.CalculateSalary()}");
            }
        }

        static void ShowHighestSalary(EmployeeService service)
        {
            Employee emp = service.GetHighestSalaryEmployee();

            if (emp == null)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }

            Console.WriteLine(
                $"{emp.Id} - {emp.FullName} - {emp.CalculateSalary()}");
        }

        static void SortSalary(EmployeeService service)
        {
            List<Employee> employees = service.SortBySalaryDesc();

            foreach (Employee emp in employees)
            {
                Console.WriteLine(
                    $"{emp.Id} - {emp.FullName} - {emp.CalculateSalary()}");
            }
        }

        static void Statistics(EmployeeService service)
        {
            Dictionary<string, int> data =
                service.CountByType();

            foreach (var item in data)
            {
                Console.WriteLine(
                    item.Key + ": " + item.Value);
            }
        }

        static void DeleteEmployee(EmployeeService service)
        {
            Console.Write("Nhap ma can xoa: ");
            string id = Console.ReadLine();

            service.Delete(id);

            Console.WriteLine("Da xoa!");
        }
    }
}
