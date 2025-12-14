using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
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
                Console.WriteLine("3. Sua nguoi dung");
                Console.WriteLine("4. Tao quan he ban be");
                Console.WriteLine("5. Huy quan he ban be");
                Console.WriteLine("6. Sua quan he ban be");
                Console.WriteLine("7. Tim ban chung");
                Console.WriteLine("8. Goi y ket ban");
                Console.WriteLine("9. Xem toan bo danh sach");
                Console.WriteLine("10. Luu du lieu xuong tep");
                Console.WriteLine("11. Doc du lieu ");
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
                        Console.Write("Nhap ten cu: ");
                        string oldName = Console.ReadLine();
                        Console.Write("Nhap ten moi: ");
                        string newName = Console.ReadLine();
                        if (fg.suaNguoiDung(oldName, newName))
                            Console.WriteLine(" Sua ten thanh cong!");
                        else
                            Console.WriteLine(" Loi khi sua ten (khong ton tai hoac ten moi da co)!");
                        
                        break;
                    case 4:
                        Console.Write("Nhap ten nguoi thu nhat: ");
                        string a = Console.ReadLine();
                        Console.Write("Nhap ten nguoi thu hai: ");
                        string b = Console.ReadLine();
                        fg.taoMoiQuanHeBanBe(a, b);
                        
                        break;
                    case 5:
                        Console.Write("Nhap ten nguoi thu nhat: ");
                        a = Console.ReadLine();
                        Console.Write("Nhap ten nguoi thu hai: ");
                        b = Console.ReadLine();
                        fg.huyMoiQuanHeBanBe(a, b);               
                        break;
                    case 6:
                        Console.Write("Nhap nguoi can sua quan he: ");
                        string user = Console.ReadLine();

                        Console.Write("Ban cu muon doi: ");
                        string oldF = Console.ReadLine();

                        Console.Write("Ban moi : ");
                        string newF = Console.ReadLine();

                        if (fg.suaMQHBB(user, oldF, newF))
                            Console.WriteLine(" Sua quan he thanh cong!");
                        else
                            Console.WriteLine(" Khong the sua quan he!");

                        break;
                    case 7:
                        Console.Write("Nhap ten nguoi thu nhat: ");
                        a = Console.ReadLine();
                        Console.Write("Nhap ten nguoi thu hai: ");
                        b = Console.ReadLine();
                        fg.timBanChung(a, b);

                        break;
                    case 8:
                        Console.Write("Nhap ten nguoi can goi y: ");
                        fg.goiYKetBan(Console.ReadLine());
                        fg.hienThi();
                        break;
                    case 9:
                        fg.hienThi();
                        break;

                    case 10:
                        //friendFile = "D:\friends.txt";
                        Console.Write("Nhap duong dan file ghi: ");
                        string friendFile = Console.ReadLine();
                        if (fg.luuFile(friendFile))
                            Console.WriteLine(" Ghi file thanh cong !");
                        else
                            Console.WriteLine(" Loi khi ghi file !");
                        break;
                    case 11:
                        //friendFile = "D:\friends.txt";
                        Console.Write("Nhap duong dan file doc: ");
                        string friendDocFile = Console.ReadLine();
                        if (fg.luuFile(friendDocFile))
                        {
                            Console.WriteLine(" Doc file thanh cong !");
                            fg.hienThi();
                        }
                        else
                            Console.WriteLine(" Loi khi doc file !");
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
