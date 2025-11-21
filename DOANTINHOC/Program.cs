using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_tin_học_năm_3_15_11_2025_thầy_đeo
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
                Console.WriteLine("\n===== MENU QUAN LY MOI QUAN HE BAN BE =====");
                Console.WriteLine("1. Them nguoi dung");
                Console.WriteLine("2. Xoa nguoi dung");
                Console.WriteLine("3. Tao quan he ban be");
                Console.WriteLine("4. Huy quan he ban be");
                Console.WriteLine("5. Tim ban chung");
                Console.WriteLine("6. Goi y ket ban");
                Console.WriteLine("7. Xem toan bo danh sach");
                Console.WriteLine("0. Thoat");
                Console.WriteLine("===========================================");
                Console.Write("<_> Chon chuc nang: ");

                if (!int.TryParse(Console.ReadLine(), out choice)) choice = -1;
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.Write("Nhap ten nguoi dung: ");
                        fg.AddUser(Console.ReadLine());
                        break;
                    case 2:
                        Console.Write("Nhap ten nguoi dung can xoa: ");
                        fg.RemoveUser(Console.ReadLine());
                        break;
                    case 3:
                        Console.Write("Nhap ten nguoi thu nhat: ");
                        string a = Console.ReadLine();
                        Console.Write("Nhap ten nguoi thu hai: ");
                        string b = Console.ReadLine();
                        fg.AddFriendship(a, b);
                        break;
                    case 4:
                        Console.Write("Nhap ten nguoi thu nhat: ");
                        a = Console.ReadLine();
                        Console.Write("Nhap ten nguoi thu hai: ");
                        b = Console.ReadLine();
                        fg.RemoveFriendship(a, b);
                        break;
                    case 5:
                        Console.Write("Nhap ten nguoi thu nhat: ");
                        a = Console.ReadLine();
                        Console.Write("Nhap ten nguoi thu hai: ");
                        b = Console.ReadLine();
                        fg.FindMutualFriends(a, b);
                        break;
                    case 6:
                        Console.Write("Nhap ten nguoi can goi y: ");
                        fg.SuggestFriends(Console.ReadLine());
                        break;
                    case 7:
                        fg.ShowAll();
                        break;
                    case 0:
                        Console.WriteLine(" Thoat chuong trinh. ");
                        break;
                    default:
                        Console.WriteLine(" Lua chon khong hop le! ");
                        break;
                }

            } while (choice != 0);
        }
    }
}
