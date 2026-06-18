using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTapBuoi2.Bai1
{
    internal class Student
    {
        public string Name { get; set; }
        public double DiemToan { get; set; }
        public double DiemVan { get; set; }
        public double DiemAnh { get; set; }
        public DateTime NgaySinh { get; set; }
        public double DiemTrungBinh => (DiemToan + DiemVan + DiemAnh) / 3.0;
        public string XepLoai()
        {
            double dtb = DiemTrungBinh;
            if (dtb >= 8.0) return "Giỏi";
            else if (dtb >= 6.5) return "khá";
            else if (dtb >= 5) return "Trung bình";
            return "Yếu";
        }
    }
    class Program
    {
        static double NhapDiem(string tenMon)
        {
            double diem;
            while (true)
            {
                Console.WriteLine($" Nhập điểm {tenMon}: ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out diem) && diem >= 0 && diem <= 10)
                    return diem;
                Console.WriteLine("Điểm không hợp lệ! Vui lòng nhập lại điểm trong khoảng 0 đến 10");
            }
        }
        public static void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var ds = new List<Student>();
            Console.WriteLine("Nhập thông tin sinh viên");
            Console.Write("Nhập số sinh viên: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                Console.Write("Số ko hợp lệ. Vui lòng nhập lại");
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n Sinh viên số {i+1}");
                var sv  = new Student();
                Console.Write(" Họ tên: ");
                sv.Name = Console.ReadLine();
                sv.DiemToan = NhapDiem("Toán");
                sv.DiemVan = NhapDiem("Văn");
                sv.DiemAnh = NhapDiem("Anh");
                DateTime ngaySinh;
                while (true)
                {
                    Console.Write("Ngày sinh (dd/MM/yyyy): ");
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy",
                        null, System.Globalization.DateTimeStyles.None, out ngaySinh))
                    {
                        sv.NgaySinh = ngaySinh;
                        break;
                    }
                    Console.WriteLine("Ngày không hợp lệ! Nhập theo định dạng dd/MM/yyyy.");
                }

                ds.Add(sv);

            }
            Console.WriteLine("| {0,-20} | {1,-10} | {2,-8} | {3,-8} | {4,-8} | {5,-7} | {6,-10} |",
                "Họ tên", "Ngày sinh", "Toán", "Văn", "Anh", "ĐTB", "Xếp loại");

            foreach (var sv in ds)
            {
                Console.WriteLine("| {0,-20} | {1,-10} | {2,-8:F1} | {3,-8:F1} | {4,-8:F1} | {5,-7:F2} | {6,-10} |",
                    sv.Name,
                    sv.NgaySinh.ToString("dd/MM/yyyy"),
                    sv.DiemToan,
                    sv.DiemVan,
                    sv.DiemAnh,
                    sv.DiemTrungBinh,
                    sv.XepLoai());
            }
        }
    }
}
