using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN_CHÍNH_THỨC_1_12_2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Friend fg = new Friend();

          
            int choice;

            do
            {
                Console.WriteLine("\n===== MENU QUAN LY MOI QUAN HE BAN BE =====");
                Console.WriteLine("1. Them nguoi dung");
                Console.WriteLine("2. Xoa nguoi dung");
                Console.WriteLine("3. Tao quan he ban be");
                Console.WriteLine("4. Huy quan he ban be");
                Console.WriteLine("5. Tim ban chung");
                Console.WriteLine("6. Goi y ket ban");
                Console.WriteLine("7. Xem toan bo danh sach");
                Console.WriteLine("8. Luu du lieu xuong tep");
                Console.WriteLine("9. Sua nguoi dung");
                Console.WriteLine("10. Sua quan he ban be");
                Console.WriteLine("0. Thoat");
                Console.Write(" == Chon chuc nang: ");

                if (!int.TryParse(Console.ReadLine(), out choice)) choice = -1;
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.Write("Nhap ten nguoi dung: ");
                        fg.themNguoiDung(Console.ReadLine());
                        break;
                    case 2:
                        Console.Write("Nhap ten nguoi dung can xoa: ");
                        fg.xoaNguoiDung(Console.ReadLine());
                        break;
                    case 3:
                        Console.Write("Nhap ten nguoi thu nhat: ");
                        string a = Console.ReadLine();
                        Console.Write("Nhap ten nguoi thu hai: ");
                        string b = Console.ReadLine();
                        fg.taoMoiQuanHeBanBe(a, b);
                        break;
                    case 4:
                        Console.Write("Nhap ten nguoi thu nhat: ");
                        a = Console.ReadLine();
                        Console.Write("Nhap ten nguoi thu hai: ");
                        b = Console.ReadLine();
                        fg.huyMoiQuanHeBanBe(a, b);
                        break;
                    case 5:
                        Console.Write("Nhap ten nguoi thu nhat: ");
                        a = Console.ReadLine();
                        Console.Write("Nhap ten nguoi thu hai: ");
                        b = Console.ReadLine();
                        fg.timBanChung(a, b);
                        break;
                    case 6:
                        Console.Write("Nhap ten nguoi can goi y: ");
                        fg.goiYKetBan(Console.ReadLine());
                        break;
                    case 7:
                        fg.ShowAll();
                        break;
                    case 8:
                        //string friendFile = "D:\\Đồ án tin học năm 3 15 11 2025 thầy đeo\fffriends.txt";
                        Console.Write("Nhập đường dẫn file đọc: ");
                        string friendFile = Console.ReadLine();
                        if (fg.luuFile(friendFile))
                            Console.WriteLine(" Ghi file thanh cong !");
                        else
                            Console.WriteLine(" Loi khi ghi file !");
                        break;
                    case 9:
                        Console.Write("Nhap ten cu: ");
                        string oldName = Console.ReadLine();
                        Console.Write("Nhap ten moi: ");
                        string newName = Console.ReadLine();
                        if (fg.EditUser(oldName, newName))
                            Console.WriteLine(" Sua ten thanh cong!");
                        else
                            Console.WriteLine(" Loi khi sua ten (khong ton tai hoac ten moi da co)!");
                        break;

                    case 10:
                        Console.Write("Nhap nguoi can sua quan he: ");
                        string user = Console.ReadLine();

                        Console.Write("Ban cu muon doi (Old Friend): ");
                        string oldF = Console.ReadLine();

                        Console.Write("Ban moi (New Friend): ");
                        string newF = Console.ReadLine();

                        if (fg.EditFriend(user, oldF, newF))
                            Console.WriteLine(" Sua quan he thanh cong!");
                        else
                            Console.WriteLine(" Khong the sua quan he!");
                        break;
                    case 0:
                        Console.WriteLine(" == Thoat chuong trinh.");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

            } while (choice != 0);
        }
    }
}
