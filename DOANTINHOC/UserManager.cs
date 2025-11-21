using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_tin_học_năm_3_15_11_2025_thầy_đeo
{
    internal class UserManager
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();

        public bool AddUser(string name, string home, string school)
        {
            if (users.ContainsKey(name))
            {
                Console.WriteLine(" Nguoi dung da ton tai!");
                return false;
            }

            try
            {
                users[name] = new User(name, home, school);
                Console.WriteLine(" Them user thanh cong!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Loi: " + ex.Message);
                return false;
            }
        }

        public User GetUser(string name)
        {
            return users.ContainsKey(name) ? users[name] : null;
        }

        public void ShowUsers()
        {
            Console.WriteLine("\nDanh sach nguoi dung:");
            foreach (var u in users.Values)
            {
                Console.WriteLine("==> " + u);
            }
            Console.WriteLine();
        }
    }
}
