using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_tin_học_năm_3_15_11_2025_thầy_đeo
{
    internal class User
    {
        public string Name { get; set; }
        public string HomeTown { get; set; }
        public string School { get; set; }

        public User(string name, string homeTown, string school)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ten khong duoc de trong!");

            if (string.IsNullOrWhiteSpace(homeTown))
                throw new ArgumentException("Que quan khong duoc để trống!");

            if (string.IsNullOrWhiteSpace(school))
                throw new ArgumentException("Truong hoc khong duoc de trong!");

            Name = name.Trim();
            HomeTown = homeTown.Trim();
            School = school.Trim();
        }

        public override string ToString()
        {
            return "Ten: {Name} - Que: {HomeTown} - Truong: {School}";
        }
    }
}
