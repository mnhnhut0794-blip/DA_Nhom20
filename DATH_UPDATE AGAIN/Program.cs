using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án__mới_23_22_2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserManager um = new UserManager();
            Friend fg = new Friend(um);

            int choice;

            do
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Them nguoi dung");
                Console.WriteLine("2. Them nguoi dung vao do thi");
                Console.WriteLine("3. Tao quan he ban be");
                Console.WriteLine("4. Huy quan he ban be");
                Console.WriteLine("5. Xoa nguoi dung khoi do thi");
                Console.WriteLine("6. Xoa nguoi dung ");
                Console.WriteLine("7. Tim ban chung");
                Console.WriteLine("8. Goi y ket ban");
                Console.WriteLine("9. Xem danh sach user");
                Console.WriteLine("10. Xem do thi ban be");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon: ");

                if (!int.TryParse(Console.ReadLine(), out choice)) choice = -1;
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.Write("Ten: ");
                        string name = Console.ReadLine();

                        Console.Write("Ngay sinh: ");
                        string birth = Console.ReadLine();

                        Console.Write("SDT: ");
                        string phone = Console.ReadLine();

                        Console.Write("Dia chi: ");
                        string address = Console.ReadLine();

                        um.AddNguoiDung(name, birth, phone, address);
                        break;

                    case 2:
                        Console.Write("Nhap ten nguoi dung: ");
                        fg.ThemNguoiDung(Console.ReadLine());
                        break;

                    case 3:
                        Console.Write("Nguoi dung 1: ");
                        string a = Console.ReadLine();
                        Console.Write("Nguoi dung 2: ");
                        string b = Console.ReadLine();
                        fg.TaoMoiQuanHeBanBe(a, b);
                        break;
                    case 4:
                        Console.Write("Nguoi dung 1: ");
                        a = Console.ReadLine();
                        Console.Write("Nguoi dung 2: ");
                        b = Console.ReadLine();
                        fg.HuyMoiQuanHeBanBe(a, b);
                        break;
                    case 5:
                        Console.Write("Nhap nguoi dung muon xoa khoi do thi: ");
                        fg.XoaNguoiDung(Console.ReadLine());
                        break;
                    case 6:
                        Console.Write("Nhap nguoi dung muon xoa : ");
                        um.RemoveNguoiDung(Console.ReadLine());
                        break;
                    case 7:
                        Console.Write("Nguoi dung 1: ");
                        a = Console.ReadLine();
                        Console.Write("Nguoi dung 2: ");
                        b = Console.ReadLine();
                        fg.TimBanChung(a, b);
                        break;
                    case 8:
                        Console.Write("Nhap nguoi dung: ");
                        fg.GoiYKetBan(Console.ReadLine());
                        break;

                    case 9:
                        um.HienThiDSNguoiDung();
                        break;
                    case 10:
                        fg.HienThiDoThiBanBe();
                        break;
                    case 0:
                        Console.WriteLine("Thoat chuong trinh.");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

            } while (choice != 0);
        }
    }
}
