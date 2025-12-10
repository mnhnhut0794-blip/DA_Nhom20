using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN_CHÍNH_THỨC_1_12_2025
{
    internal class User
    {
        private string m_Ten;
        public string Ten { 
            get { return m_Ten; }
            set { m_Ten = value; }
        }
        public User() 
        {
            m_Ten = " ";
        }
        public User(string name)
        {
            m_Ten = name;
        }
    }
}
