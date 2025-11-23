using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án__mới_23_22_2025
{
    internal class UserManager
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();

        public bool AddNguoiDung(string name, string birth, string phone, string address)
        {
            if (users.ContainsKey(name))
            {
                Console.WriteLine("Nguoi dung da ton tai!");
                return false;
            }

            users[name] = new User(name, birth, phone, address);
            Console.WriteLine("Them user thanh cong!");
            return true;
        }
        public bool RemoveNguoiDung(string name)
        {
            if (!users.ContainsKey(name))
            {
                Console.WriteLine("Nguoi dung khong ton tai!");
                return false;
            }

            users.Remove(name);
            Console.WriteLine($"Da xoa nguoi dung {name} !");
            return true;
        }
        public User GetNguoiDung(string name)
        {
            return users.ContainsKey(name) ? users[name] : null;
        }

        public void HienThiDSNguoiDung()
        {
            Console.WriteLine("\n===== DANH SACH NGUOI DUNG =====");

            if (users.Count == 0)
            {
                Console.WriteLine("Chua co user nao.");
                return;
            }

            foreach (var u in users.Values)
            {
                Console.WriteLine(" - " + u.ToString());
            }
        }
    } 
}
