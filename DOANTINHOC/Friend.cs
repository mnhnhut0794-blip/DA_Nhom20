using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_tin_học_năm_3_15_11_2025_thầy_đeo
{
    internal class Friend
    {
        //private Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

        ////  Thêm người dùng
        //public void AddUser(string name)
        //{
        //    if (!graph.ContainsKey(name))
        //    {
        //        graph[name] = new List<string>();
        //        Console.WriteLine(" Da them nguoi dung: {name}");
        //    }
        //    else
        //    {
        //        Console.WriteLine(" Nguoi dung da ton tai!");
        //    }
        //}
        private Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        private UserManager userManager;

        public Friend(UserManager um)
        {
            userManager = um;
        }

        public void AddUser(string name)
        {
            if (userManager.GetUser(name) != null)
            {
                Console.WriteLine(" Khong the them vao Friend vi User chua ton tai trong UserManager!");
                return;
            }

            if (!graph.ContainsKey(name))
            {
                graph[name] = new List<string>();
                Console.WriteLine($" Da them nguoi dung vao Friend: {name}");
            }
            else
            {
                Console.WriteLine("Nguoi dung da co trong Friend!");
            }
        }

        //  Xóa người dùng
        public void RemoveUser(string name)
        {
            if (graph.ContainsKey(name))
            {
                // Xóa người này khỏi danh sách bạn bè của người khác
                foreach (var friend in graph[name])
                {
                    graph[friend].Remove(name);
                }
                graph.Remove(name);
                Console.WriteLine(" Da xoa nguoi dung: {name}");
            }
            else
            {
                Console.WriteLine(" Khong tim thay nguoi dung!");
            }
        }

        //  Tạo quan hệ bạn bè
        public void AddFriendship(string a, string b)
        {
            if (!graph.ContainsKey(a) || !graph.ContainsKey(b))
            {
                Console.WriteLine("Mot trong hai nguoi dung khong ton tai!");
                return;
            }

            if (!graph[a].Contains(b))
            {
                graph[a].Add(b);
                graph[b].Add(a);
                Console.WriteLine(" {a} va {b} da tro thanh ban be!");
            }
            else
            {
                Console.WriteLine("Hai nguoi nay la ban be!");
            }
        }

        // Hủy quan hệ bạn bè
        public void RemoveFriendship(string a, string b)
        {
            if (graph.ContainsKey(a) && graph[a].Contains(b))
            {
                graph[a].Remove(b);
                graph[b].Remove(a);
                Console.WriteLine("{a} va {b} khong con la ban be.");
            }
            else
            {
                Console.WriteLine("Ho khong co moi quan he ban be!");
            }
        }

        // Tìm bạn chung
        public void FindMutualFriends(string a, string b)
        {
            if (!graph.ContainsKey(a) || !graph.ContainsKey(b))
            {
                Console.WriteLine(" Mot trong hai nguoi dung khong ton tai!");
                return;
            }

            var mutual = graph[a].Intersect(graph[b]).ToList();

            Console.WriteLine(" Ban chung giua {a} va {b}: ");
            if (mutual.Count > 0)
                Console.WriteLine(" ==>  " + string.Join(", ", mutual));
            else
                Console.WriteLine(" Khong co ban chung.");
        }

        // Gợi ý kết bạn (bạn của bạn)
        public void SuggestFriends(string name)
        {
            if (!graph.ContainsKey(name))
            {
                Console.WriteLine(" Nguoi dung khong ton tai !");
                return;
            }

            HashSet<string> suggestions = new HashSet<string>();

            foreach (var friend in graph[name])
            {
                foreach (var fof in graph[friend])
                {
                    if (fof != name && !graph[name].Contains(fof))
                        suggestions.Add(fof);
                }
            }

            Console.WriteLine(" Goi y ket ban cho {name}:");
            if (suggestions.Count > 0)
                Console.WriteLine(" ==> " + string.Join(", ", suggestions));
            else
                Console.WriteLine(" Khong co goi y ket ban nao het.");
        }

        //  Hiển thị danh sách bạn bè
        
        public void ShowAll()
        {
            Console.WriteLine("\n Danh sach nguoi dung va ban be:");

            if (graph.Count == 0)
            {
                Console.WriteLine("Danh sach trong!");
                return;
            }

            foreach (var kvp in graph)
            {
                string user = kvp.Key;
                List<string> friends = kvp.Value;

                Console.WriteLine($"- {user}: {(friends.Count > 0 ? string.Join(", ", friends) : "(khong co ban)")}");
            }
        }

    }
}
