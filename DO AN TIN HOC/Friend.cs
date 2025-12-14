using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1

{
    internal class Friend
    {
        private List<User> users = new List<User>();
        //Tìm người dùng
        private User FindUser(string name)
        {
            return users.FirstOrDefault(u => u.Username == name);
        }
        //Thêm tên người dùng
        public void themNguoiDung(string ten)
        {
            if (FindUser(ten) != null)
            {
                Console.WriteLine("Nguoi dung da ton tai!");
                return;
            }

            users.Add(new User(ten));
            Console.WriteLine("Da them nguoi dung: " + ten);
        }
        //Xóa tên người dùng
        public void xoaNguoiDung(string ten)
        {
            User u = FindUser(ten);
            if (u == null)
            {
                Console.WriteLine("Khong tim thay nguoi dung!");
                return;
            }

            foreach (var user in users)
            {
                user.Friends.Remove(ten);
            }

            users.Remove(u);
            Console.WriteLine("Da xoa nguoi dung: " + ten);
        }
        //Sửa tên người dùng
        public bool suaNguoiDung(string oldName, string newName)
        {
            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName))
                return false;

            User u = FindUser(oldName);
            if (u == null) return false;

            if (FindUser(newName) != null) return false;

            u.Username = newName;

            foreach (var user in users)
            {
                for (int i = 0; i < user.Friends.Count; i++)
                {
                    if (user.Friends[i] == oldName)
                        user.Friends[i] = newName;
                }
            }

            return true;
        }
        //Tạo mối quan hệ bạn bè
        public void taoMoiQuanHeBanBe(string a, string b)
        {
            User ua = FindUser(a);
            User ub = FindUser(b);

            if (ua == null || ub == null)
            {
                Console.WriteLine("Mot trong hai nguoi dung khong ton tai!");
                return;
            }

            if (!ua.Friends.Contains(b))
            {
                ua.Friends.Add(b);
                ub.Friends.Add(a);
                Console.WriteLine(a + " va " + b + " da tro thanh ban be!");
            }
            else
            {
                Console.WriteLine("Hai nguoi nay da la ban!");
            }
        }
        //Hủy mối quan hệ bạn bè
        public void huyMoiQuanHeBanBe(string a, string b)
        {
            User ua = FindUser(a);
            User ub = FindUser(b);

            if (ua != null && ua.Friends.Contains(b))
            {
                ua.Friends.Remove(b);
                ub.Friends.Remove(a);
                Console.WriteLine(a + " va " + b + " khong con la ban be.");
            }
            else
            {
                Console.WriteLine("Ho khong co quan he ban be!");
            }
        }
        //Sửa mối quan hệ bạn bè
        public bool suaMQHBB(string user, string oldFriend, string newFriend)
        {
            User u = FindUser(user);
            User newF = FindUser(newFriend);

            if (u == null || newF == null || !u.Friends.Contains(oldFriend))
                return false;

            u.Friends.Remove(oldFriend);

            User oldF = FindUser(oldFriend);
            oldF?.Friends.Remove(user);

            u.Friends.Add(newFriend);
            newF.Friends.Add(user);

            return true;
        }
        //Tìm bạn chung
        public void timBanChung(string a, string b)
        {
            
            User ua = FindUser(a);
            User ub = FindUser(b);

            if (ua == null || ub == null)
            {
                Console.WriteLine("Mot trong hai nguoi dung khong ton tai!");
                return;
            }

            List<string> banChung = new List<string>();

            foreach (string friend in ua.Friends)
            {
                if (ub.Friends.Contains(friend))
                {
                    banChung.Add(friend);
                }
            }

            Console.WriteLine("Ban chung giua " + a + " va " + b + ":");

            if (banChung.Count > 0)
            {
                Console.WriteLine("==> " + string.Join(", ", banChung));
            }
            else
            {
                Console.WriteLine("Khong co ban chung.");
            }
        }
        //Gợi ý kết bạn
        public void goiYKetBan(string ten)
        {
            User u = FindUser(ten);
            if (u == null)
            {
                Console.WriteLine("Nguoi dung khong ton tai!");
                return;
            }

            HashSet<string> suggestions = new HashSet<string>();

            foreach (var f in u.Friends)
            {
                User friend = FindUser(f);
                if (friend == null) continue;

                foreach (var fof in friend.Friends)
                {
                    if (fof != ten && !u.Friends.Contains(fof))
                        suggestions.Add(fof);
                }
            }

            Console.WriteLine("Goi y ket ban cho " + ten + ":");
            if (suggestions.Count > 0)
                Console.WriteLine("==> " + string.Join(", ", suggestions));
            else
                Console.WriteLine("Khong co goi y nao.");
        }
        //Hiển thị danh sách bạn bè
        public void hienThi()
        {
            Console.WriteLine("\nDanh sach nguoi dung va ban be:");
            foreach (var u in users)
            {
                Console.WriteLine("- " + u.Username + " : " + string.Join(", ", u.Friends));
            }
        }
        //Lưu danh sách bạn bè
        public bool luuFile(string tenFile)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(tenFile))
                {
                    foreach (var u in users)
                    {
                        string line = u.Username + ":" + string.Join(",", u.Friends);
                        writer.WriteLine(line);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Đọc danh sách bạn bè
        public bool docFile(string file)
        {
            try
            {
                users.Clear();
                foreach (var line in File.ReadAllLines(file))
                {
                    var parts = line.Split(':');
                    User u = new User(parts[0]);

                    if (parts.Length > 1 && parts[1] != "")
                        u.Friends.AddRange(parts[1].Split(','));

                    users.Add(u);
                }
                return true;
            }
            catch { 
                return false; 
            }
        }
    }
}
