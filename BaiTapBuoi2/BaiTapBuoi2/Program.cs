using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("\n===== BÀI TẬP BUỔI 2 =====");
            Console.WriteLine("1. Bài 1 - Xếp loại học sinh");
            Console.WriteLine("2. Bài 2 - Quản lý hàng hóa");
            Console.WriteLine("3. Bài 3 - Quản lý nhân sự");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn bài: ");

            switch (Console.ReadLine())
            {
                case "1": BaiTapBuoi2.Bai1.Program.Run(); break;
                case "2": BaiTapBuoi2.Bai2.Program.Run(); break;
                case "3": BaiTapBuoi2.Bai3.Program.Run(); break;
                case "0": return;
                default: Console.WriteLine("Không hợp lệ!"); break;
            }
        }
    }
}