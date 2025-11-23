using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án__mới_23_22_2025
{
    internal class Friend
    {
        private Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        private UserManager userManager;

        public Friend(UserManager um)
        {
            userManager = um;
        }
        //Them nguoi dung
        public void ThemNguoiDung(string name)
        {
            if (userManager.GetNguoiDung(name) == null)
            {
                Console.WriteLine("Nguoi dung chua ton tai !");
                return;
            }

            if (!graph.ContainsKey(name))
            {
                graph[name] = new List<string>();
                Console.WriteLine("Da them {name} vao do thi!");
            }
            else
            {
                Console.WriteLine("User da ton tai trong do thi!");
            }
        }
        //Tao quan he ban be
        public void TaoMoiQuanHeBanBe(string a, string b)
        {
            if (!graph.ContainsKey(a) || !graph.ContainsKey(b))
            {
                Console.WriteLine("Mot trong hai nguoi dung chua co trong do thi!");
                return;
            }

            if (!graph[a].Contains(b))
            {
                graph[a].Add(b);
                graph[b].Add(a);
                Console.WriteLine("{a} va {b} da tro thanh ban be!");
            }
            else
            {
                Console.WriteLine("Hai nguoi nay da la ban be!");
            }
        }
        // Huy moi quan he ban be
        public void HuyMoiQuanHeBanBe(string a, string b)
        {
            if (!graph.ContainsKey(a) || !graph.ContainsKey(b))
            {
                Console.WriteLine("Mot trong hai user khong ton tai trong do thi!");
                return;
            }

            if (graph[a].Contains(b))
            {
                graph[a].Remove(b);
                graph[b].Remove(a);
                Console.WriteLine($"Da huy quan he ban be giua {a} va {b}!");
            }
            else
            {
                Console.WriteLine("Hai user khong phai ban be!");
            }
        }

        //Xoa nguoi dung
        public void XoaNguoiDung(string name)
        {
            if (!graph.ContainsKey(name))
            {
                Console.WriteLine("Nguoi dung khong ton tai !");
                return;
            }

            foreach (var list in graph.Values)
            {
                list.Remove(name);
            }

            graph.Remove(name);
            Console.WriteLine("Da xoa {name} !");
        }
        //Tim ban chung
        public void TimBanChung(string a, string b)
        {
            if (!graph.ContainsKey(a) || !graph.ContainsKey(b))
            {
                Console.WriteLine("Mot trong hai nguoi dung khong ton tai!");
                return;
            }

            var mutual = graph[a].Intersect(graph[b]).ToList();

            Console.WriteLine("Ban chung giua {a} va {b}:");

            if (mutual.Count > 0)
                Console.WriteLine(" => " + string.Join(", ", mutual));
            else
                Console.WriteLine("Khong co ban chung.");
        }
        //Goi y ket ban
        public void GoiYKetBan(string name)
        {
            if (!graph.ContainsKey(name))
            {
                Console.WriteLine("Nguoi dung khong ton tai!");
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

            Console.WriteLine($"\nGoi y ket ban cho {name}:");

            if (suggestions.Count > 0)
                Console.WriteLine(" => " + string.Join(", ", suggestions));
            else
                Console.WriteLine("Khong co goi y nao.");
        }

        public void HienThiDoThiBanBe()
        {
            Console.WriteLine("\n===== DO THI BAN BE =====");

            foreach (var kvp in graph)
            {
                Console.WriteLine($"{kvp.Key}: {(kvp.Value.Count == 0 ? "(khong co ban)" : string.Join(", ", kvp.Value))}");
            }
        }
    }
}
