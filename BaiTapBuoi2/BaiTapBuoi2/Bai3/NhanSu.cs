using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiTapBuoi2.Bai3
{
    abstract class Employee
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public double BaseSalary { get; set; }

        public abstract double CalculateSalary();
        public abstract string LoaiNhanVien { get; }

        public override string ToString()
        {
            return $"{Id,-8} | {FullName,-20} | {LoaiNhanVien,-12} | Lương: {CalculateSalary(),12:N0} VNĐ";
        }
    }

    class FullTimeEmployee : Employee
    {
        public double Bonus { get; set; }
        public override string LoaiNhanVien => "Full-time";
        public override double CalculateSalary() => BaseSalary + Bonus;
    }

    class PartTimeEmployee : Employee
    {
        public double WorkingHours { get; set; }
        public double HourlyRate { get; set; }
        public override string LoaiNhanVien => "Part-time";
        public override double CalculateSalary() => WorkingHours * HourlyRate;
    }

    class InternEmployee : Employee
    {
        public double Allowance { get; set; }
        public override string LoaiNhanVien => "Intern";
        public override double CalculateSalary() => Allowance;
    }

    class EmployeeService
    {
        private List<Employee> employees = new List<Employee>();

        private bool IsValidId(string id) =>
            !string.IsNullOrWhiteSpace(id) &&
            id.StartsWith("NV") &&
            !employees.Any(e => e.Id == id);

        private double NhapDuong(string label)
        {
            double val;
            while (true)
            {
                Console.Write(label);
                if (double.TryParse(Console.ReadLine(), out val) && val >= 0) return val;
                Console.WriteLine("Giá trị không hợp lệ (>= 0)!");
            }
        }

        public void ThemNhanVien()
        {
            Console.WriteLine("\n--- THÊM NHÂN VIÊN ---");
            Console.WriteLine("  Loại nhân viên:");
            Console.WriteLine("  1. Full-time");
            Console.WriteLine("  2. Part-time");
            Console.WriteLine("  3. Intern");
            Console.Write("  Chọn loại: ");
            string loai = Console.ReadLine();

            if (loai != "1" && loai != "2" && loai != "3")
            {
                Console.WriteLine("Loại không hợp lệ!");
                return;
            }

            string id;
            while (true)
            {
                Console.Write("Mã nhân viên (VD NV01): ");
                id = Console.ReadLine()?.Trim().ToUpper() ?? "";
                if (!id.StartsWith("NV")) { Console.WriteLine("Mã phải bắt đầu bằng 'NV'!"); continue; }
                if (employees.Any(e => e.Id == id)) { Console.WriteLine("Mã đã tồn tại!"); continue; }
                break;
            }

            string name;
            while (true)
            {
                Console.Write("Họ tên: ");
                name = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrEmpty(name)) break;
                Console.WriteLine("Họ tên không được rỗng!");
            }

            double baseSalary = NhapDuong("Lương cơ bản: ");

            switch (loai)
            {
                case "1":
                    employees.Add(new FullTimeEmployee
                    {
                        Id = id,
                        FullName = name,
                        BaseSalary = baseSalary,
                        Bonus = NhapDuong("Thưởng (Bonus): ")
                    });
                    break;
                case "2":
                    employees.Add(new PartTimeEmployee
                    {
                        Id = id,
                        FullName = name,
                        BaseSalary = baseSalary,
                        WorkingHours = NhapDuong("Số giờ làm: "),
                        HourlyRate = NhapDuong("Tiền công/giờ: ")
                    });
                    break;
                case "3":
                    employees.Add(new InternEmployee
                    {
                        Id = id,
                        FullName = name,
                        BaseSalary = baseSalary,
                        Allowance = NhapDuong("  Trợ cấp: ")
                    });
                    break;
            }

            Console.WriteLine("Thêm nhân viên thành công!");
        }

        public void HienThiDanhSach(IEnumerable<Employee> list = null)
        {
            var src = list ?? employees;
            Console.WriteLine("\n--- DANH SÁCH NHÂN VIÊN ---");
            if (!src.Any()) { Console.WriteLine("  (Chưa có nhân viên nào)"); return; }
            Console.WriteLine($"  {"Mã",-8} | {"Họ tên",-20} | {"Loại",-12} | {"Lương thực nhận",20}");
            Console.WriteLine("  " + new string('-', 70));
            foreach (var e in src)
                Console.WriteLine("  " + e);
        }

        public void TimTheoMa()
        {
            Console.Write("\nNhập mã nhân viên: ");
            string id = Console.ReadLine()?.Trim().ToUpper();
            var e = employees.FirstOrDefault(x => x.Id == id);
            if (e == null) Console.WriteLine("Không tìm thấy!");
            else Console.WriteLine("  " + e);
        }
        public void TimTheoTen()
        {
            Console.Write("\nNhập tên tìm kiếm: ");
            string kw = Console.ReadLine()?.Trim().ToLower() ?? "";
            var result = employees.Where(e => e.FullName.ToLower().Contains(kw)).ToList();
            HienThiDanhSach(result);
            if (!result.Any()) Console.WriteLine("Không tìm thấy.");
        }

        public void TinhTongLuong()
        {
            double total = employees.Sum(e => e.CalculateSalary());
            Console.WriteLine($"\nTổng lương phải trả: {total:N0} VNĐ");
        }

        public void TimLuongCaoNhat()
        {
            if (!employees.Any()) { Console.WriteLine("Danh sách trống."); return; }
            var e = employees.OrderByDescending(x => x.CalculateSalary()).First();
            Console.WriteLine("\nNhân viên lương cao nhất:");
            Console.WriteLine("  " + e);
        }

        public void SapXepTheoLuong()
        {
            HienThiDanhSach(employees.OrderByDescending(e => e.CalculateSalary()));
        }

        public void ThongKeTheoLoai()
        {
            Console.WriteLine("\nThống kê nhân viên theo loại:");
            var groups = employees.GroupBy(e => e.LoaiNhanVien);
            foreach (var g in groups)
                Console.WriteLine($"  - {g.Key}: {g.Count()} người");
            Console.WriteLine($"Tổng cộng: {employees.Count} nhân viên");
        }
        public void CapNhatNhanVien()
        {
            Console.Write("\nNhập mã nhân viên cần cập nhật: ");
            string id = Console.ReadLine()?.Trim().ToUpper();
            var e = employees.FirstOrDefault(x => x.Id == id);
            if (e == null) { Console.WriteLine("Không tìm thấy!"); return; }

            Console.Write($"Họ tên mới ({e.FullName}): ");
            string name = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(name)) e.FullName = name;

            double newBase = NhapDuong($"Lương cơ bản mới ({e.BaseSalary:N0}): ");
            e.BaseSalary = newBase;

            if (e is FullTimeEmployee ft)
            {
                ft.Bonus = NhapDuong($"Thưởng mới ({ft.Bonus:N0}): ");
            }
            else if (e is PartTimeEmployee pt)
            {
                pt.WorkingHours = NhapDuong($"Số giờ làm mới ({pt.WorkingHours}): ");
                pt.HourlyRate = NhapDuong($"Tiền công/giờ mới ({pt.HourlyRate:N0}): ");
            }
            else if (e is InternEmployee intern)
            {
                intern.Allowance = NhapDuong($"Trợ cấp mới ({intern.Allowance:N0}): ");
            }

            Console.WriteLine("Cập nhật thành công!");
        }

        public void XoaNhanVien()
        {
            Console.Write("\nNhập mã nhân viên cần xóa: ");
            string id = Console.ReadLine()?.Trim().ToUpper();
            var e = employees.FirstOrDefault(x => x.Id == id);
            if (e == null) { Console.WriteLine("Không tìm thấy!"); return; }
            employees.Remove(e);
            Console.WriteLine($"Đã xóa nhân viên {e.FullName}.");
        }

        public void LoadDuLieuMau()
        {
            employees.AddRange(new Employee[]
            {
                new FullTimeEmployee  { Id="NV01", FullName="Nguyễn Văn A", BaseSalary=10000000, Bonus=2000000 },
                new PartTimeEmployee  { Id="NV02", FullName="Trần Thị B",   BaseSalary=0, WorkingHours=80, HourlyRate=50000 },
                new InternEmployee    { Id="NV03", FullName="Lê Văn C",     BaseSalary=0, Allowance=3000000 }
            });
            Console.WriteLine("Đã tải dữ liệu mẫu (NV01, NV02, NV03).");
        }
    }

    class Program
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var service = new EmployeeService();
            service.LoadDuLieuMau();

            while (true)
            {
                Console.WriteLine("\n===== QUẢN LÝ NHÂN SỰ =====");
                Console.WriteLine(" 1. Thêm nhân viên");
                Console.WriteLine(" 2. Hiển thị danh sách nhân viên");
                Console.WriteLine(" 3. Tìm nhân viên theo mã");
                Console.WriteLine(" 4. Tìm nhân viên theo tên");
                Console.WriteLine(" 5. Tính tổng lương phải trả");
                Console.WriteLine(" 6. Tìm nhân viên có lương cao nhất");
                Console.WriteLine(" 7. Sắp xếp nhân viên theo lương giảm dần");
                Console.WriteLine(" 8. Thống kê số lượng nhân viên theo loại");
                Console.WriteLine(" 9. Cập nhật thông tin nhân viên");
                Console.WriteLine("10. Xóa nhân viên");
                Console.WriteLine(" 0. Thoát");
                Console.Write("Chọn chức năng: ");

                switch (Console.ReadLine()?.Trim())
                {
                    case "1": service.ThemNhanVien(); break;
                    case "2": service.HienThiDanhSach(); break;
                    case "3": service.TimTheoMa(); break;
                    case "4": service.TimTheoTen(); break;
                    case "5": service.TinhTongLuong(); break;
                    case "6": service.TimLuongCaoNhat(); break;
                    case "7": service.SapXepTheoLuong(); break;
                    case "8": service.ThongKeTheoLoai(); break;
                    case "9": service.CapNhatNhanVien(); break;
                    case "10": service.XoaNhanVien(); break;
                    case "0":
                        Console.WriteLine("Tạm biệt!");
                        return;
                    default:
                        Console.WriteLine("Chức năng không hợp lệ, vui lòng chọn lại!");
                        break;
                }
            }
        }
    }
}