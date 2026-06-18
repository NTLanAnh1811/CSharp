using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiTapBuoi2.Bai2
{
    internal class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            return $"Mã: {Id,-6} | Tên: {Name,-20} | Loại: {Category,-15} | Giá: {Price,12:N0} | SL: {Quantity,4} | Ngày tạo: {CreatedAt:dd/MM/yyyy}";
        }
    }

    class Program
    {
        static List<Product> products = new List<Product>();

        static string NhapChuoi(string label, bool allowEmpty = false)
        {
            string val;
            do
            {
                Console.Write(label);
                val = Console.ReadLine()?.Trim() ?? "";
                if (!allowEmpty && val == "")
                    Console.WriteLine("Không được để trống!");
            } while (!allowEmpty && val == "");
            return val;
        }

        static double NhapDouble(string label, bool greaterThanZero = true)
        {
            double val;
            while (true)
            {
                Console.Write(label);
                if (double.TryParse(Console.ReadLine(), out val))
                {
                    if (greaterThanZero && val <= 0) { Console.WriteLine("Giá trị phải lớn hơn 0!"); continue; }
                    if (!greaterThanZero && val < 0) { Console.WriteLine("Giá trị không được âm!"); continue; }
                    return val;
                }
                Console.WriteLine("Nhập số không hợp lệ!");
            }
        }

        static int NhapInt(string label)
        {
            int val;
            while (true)
            {
                Console.Write(label);
                if (int.TryParse(Console.ReadLine(), out val) && val >= 0) return val;
                Console.WriteLine("Số lượng không hợp lệ (>= 0)!");
            }
        }

        static void ThemSanPham()
        {
            Console.WriteLine("\nThêm sản phẩm");
            string id;
            while (true)
            {
                id = NhapChuoi("  Mã sản phẩm (VD SP01): ").ToUpper();
                if (!id.StartsWith("SP")) { Console.WriteLine("Mã phải bắt đầu bằng 'SP'!"); continue; }
                if (products.Any(sp => sp.Id == id)) { Console.WriteLine("Mã đã tồn tại!"); continue; }
                break;
            }

            var p = new Product
            {
                Id = id,
                Name = NhapChuoi("  Tên sản phẩm: "),
                Category = NhapChuoi("  Danh mục: "),
                Price = NhapDouble("  Giá (> 0): "),
                Quantity = NhapInt("  Số lượng (>= 0): "),
                CreatedAt = DateTime.Now
            };

            products.Add(p);
            Console.WriteLine("Thêm sản phẩm thành công!");
        }

        static void HienThiDanhSach(IEnumerable<Product> list = null)
        {
            var src = list ?? products;
            Console.WriteLine("\nDanh sách sản phẩm");
            if (!src.Any()) { Console.WriteLine("  (Chưa có sản phẩm nào)"); return; }
            foreach (var p in src) Console.WriteLine("  " + p);
        }

        static void TimTheoTen()
        {
            Console.Write("\n  Nhập từ khóa tìm kiếm: ");
            string keyword = Console.ReadLine()?.Trim().ToLower() ?? "";
            var result = products.Where(p => p.Name.ToLower().Contains(keyword)).ToList();
            HienThiDanhSach(result);
            if (!result.Any()) Console.WriteLine("  Không tìm thấy sản phẩm nào.");
        }

        static void CapNhatSanPham()
        {
            Console.Write("\n  Nhập mã sản phẩm cần cập nhật: ");
            string id = Console.ReadLine()?.Trim().ToUpper();
            var p = products.FirstOrDefault(x => x.Id == id);
            if (p == null) { Console.WriteLine("Không tìm thấy sản phẩm!"); return; }

            Console.WriteLine($"  Đang cập nhật: {p.Name}");
            Console.Write($"  Tên mới ({p.Name}): "); string name = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(name)) p.Name = name;

            Console.Write($"  Danh mục mới ({p.Category}): "); string cat = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(cat)) p.Category = cat;

            p.Price = NhapDouble($"  Giá mới ({p.Price:N0}), nhập 0 để giữ nguyên: ", false);
            if (p.Price <= 0) { /* keep */ }  
            p.Quantity = NhapInt($"  SL mới ({p.Quantity}): ");

            Console.WriteLine("  ✅ Cập nhật thành công!");
        }

        static void XoaSanPham()
        {
            Console.Write("\n  Nhập mã sản phẩm cần xóa: ");
            string id = Console.ReadLine()?.Trim().ToUpper();
            var p = products.FirstOrDefault(x => x.Id == id);
            if (p == null) { Console.WriteLine("  ❌ Không tìm thấy sản phẩm!"); return; }
            products.Remove(p);
            Console.WriteLine($"Đã xóa sản phẩm {p.Name}.");
        }

        static void TinhTongGiaTri()
        {
            double total = products.Sum(p => p.Price * p.Quantity);
            Console.WriteLine($"\nTổng giá trị kho hàng: {total:N0} VNĐ");
        }

        static void SapXepTheoGia()
        {
            HienThiDanhSach(products.OrderBy(p => p.Price));
        }

        static void LocSapHetHang()
        {
            var result = products.Where(p => p.Quantity < 5).ToList();
            Console.WriteLine("\n--- Sản phẩm sắp hết hàng (SL < 5) ---");
            HienThiDanhSach(result);
            if (!result.Any()) Console.WriteLine("  Không có sản phẩm nào sắp hết hàng.");
        }

        static void TimGiaCaoNhat()
        {
            if (!products.Any()) { Console.WriteLine("  Danh sách trống."); return; }
            var p = products.OrderByDescending(x => x.Price).First();
            Console.WriteLine("\nSản phẩm giá cao nhất:");
            Console.WriteLine("  " + p);
        }

        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n==== QUẢN LÝ HÀNG HÓA ====");
                Console.WriteLine("1. Thêm sản phẩm");
                Console.WriteLine("2. Hiển thị danh sách sản phẩm");
                Console.WriteLine("3. Tìm sản phẩm theo tên");
                Console.WriteLine("4. Cập nhật sản phẩm");
                Console.WriteLine("5. Xóa sản phẩm");
                Console.WriteLine("6. Tính tổng giá trị kho hàng");
                Console.WriteLine("7. Sắp xếp sản phẩm theo giá tăng dần");
                Console.WriteLine("8. Lọc sản phẩm sắp hết hàng (SL < 5)");
                Console.WriteLine("9. Tìm sản phẩm có giá cao nhất");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": ThemSanPham(); break;
                    case "2": HienThiDanhSach(); break;
                    case "3": TimTheoTen(); break;
                    case "4": CapNhatSanPham(); break;
                    case "5": XoaSanPham(); break;
                    case "6": TinhTongGiaTri(); break;
                    case "7": SapXepTheoGia(); break;
                    case "8": LocSapHetHang(); break;
                    case "9": TimGiaCaoNhat(); break;
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
