using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN_CHÍNH_THỨC_1_12_2025
{
    internal class Friend
    {
        private Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        // Thêm người dùng
        public void themNguoiDung(string ten)
        {
            if (!graph.ContainsKey(ten))
            {
                graph[ten] = new List<string>();
                Console.WriteLine(" Da them nguoi dung: " + ten);
            }
            else
            {
                Console.WriteLine("Nguoi dung da ton tai!");
            }
        }
        // Xóa người dùng
        public void xoaNguoiDung(string ten)
        {
            if (graph.ContainsKey(ten))
            { 
                foreach (var friend in graph[ten])
                {
                    graph[friend].Remove(ten);
                }
                graph.Remove(ten);
                Console.WriteLine(" Da xoa nguoi dung: " + ten);
            }
            else
            {
                Console.WriteLine(" Khong tim thay nguoi dung!");
            }
        }
        //Sửa người dùng
        public bool EditUser(string oldName, string newName)
        {
            if (!graph.ContainsKey(oldName))
                return false;

            if (graph.ContainsKey(newName))
                return false;
            List<string> friends = graph[oldName];
            graph.Remove(oldName);
            graph[newName] = friends;
            foreach (var user in graph.Keys)
            {
                for (int i = 0; i < graph[user].Count; i++)
                {
                    if (graph[user][i] == oldName)
                        graph[user][i] = newName;
                }
            }

            return true;
        }

            // Tạo quan hệ bạn bè
            public void taoMoiQuanHeBanBe(string a, string b)
        {
            if (!graph.ContainsKey(a) || !graph.ContainsKey(b))
            {
                Console.WriteLine(" Mot trong hai nguoi dung khong ton tai!");
                return;
            }

            if (!graph[a].Contains(b))
            {
                graph[a].Add(b);
                graph[b].Add(a);
                Console.WriteLine(a + " va " + b + " da tro thanh ban be!");
            }
            else
            {
                Console.WriteLine(" Hai nguoi nay da la ban!");
            }
        }
        // Hủy quan hệ bạn bè
        public void huyMoiQuanHeBanBe(string a, string b)
        {
            if (graph.ContainsKey(a) && graph[a].Contains(b))
            {
                graph[a].Remove(b);
                graph[b].Remove(a);
                Console.WriteLine( a + " va " + b + " khong con la ban be.");
            }
            else
            {
                Console.WriteLine(" Ho khong co quan he ban be!");
            }
        }
        //Sửa mối quan hệ
        // Tìm bạn chung
        public void timBanChung(string a, string b)
        {
            if (!graph.ContainsKey(a) || !graph.ContainsKey(b))
            {
                Console.WriteLine(" Mot trong hai nguoi dung khong ton tai!");
                return;
            }

            var mutual = graph[a].Intersect(graph[b]).ToList();

            Console.WriteLine(" Ban chung giua " + a + " va " + b + " : ");
            if (mutual.Count > 0)
                Console.WriteLine("==> " + string.Join(", ", mutual));
            else
                Console.WriteLine(" Khong co ban chung.");
        }

        // Gợi ý kết bạn (bạn của bạn)
        public void goiYKetBan(string ten)
        {
            if (!graph.ContainsKey(ten))
            {
                Console.WriteLine(" Nguoi dung khong ton tai!");
                return;
            }

            HashSet<string> suggestions = new HashSet<string>();

            foreach (var friend in graph[ten])
            {
                foreach (var fof in graph[friend])
                {
                    if (fof != ten && !graph[ten].Contains(fof))
                        suggestions.Add(fof);
                }
            }

            Console.WriteLine(" Goi y ket ban cho " + ten + " : ");
            if (suggestions.Count > 0)
                Console.WriteLine("==> " + string.Join(", ", suggestions));
            else
                Console.WriteLine(" Khong co goi y ket ban nao.");
        }

        // Hiển thị danh sách bạn bè
        public void ShowAll()
        {
            Console.WriteLine("\n Danh sach nguoi dung va ban be: ");
            foreach (var kvp in graph)
            {
                Console.WriteLine("- " + kvp.Key + " : " + string.Join(", ", kvp.Value));
            }
            Console.WriteLine();
        } 
        
        // Lưu dữ liệu xuống tập tin
        public bool luuFile(string  tenFile)
        {
            //try
            //{
            //    FileStream fs = new FileStream(tenFile, FileMode.Create);
            //    BinaryFormatter bf = new BinaryFormatter();
            //    bf.Serialize(fs, this);
            //    fs.Close();
            //    return true;

            //}
            //catch (Exception err) { }
            //{
            //    return false;
            //}
            try
            {
                using (StreamWriter writer = new StreamWriter(tenFile))
                {
                    foreach (var user in graph)
                    {
                        string line = user.Key + ":" + string.Join(",", user.Value);
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
        public bool EditFriend(string user, string oldFriend, string newFriend)
        {
            if (!graph.ContainsKey(user)
                || !graph[user].Contains(oldFriend)
                || !graph.ContainsKey(newFriend))
                return false;

            graph[user].Remove(oldFriend);
            graph[oldFriend].Remove(user);

            graph[user].Add(newFriend);
            graph[newFriend].Add(user);

            return true;
        }
    }
}
