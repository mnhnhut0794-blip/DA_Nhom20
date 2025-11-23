using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án__mới_23_22_2025
{
    internal class User
    {
        private string m_Name;
        private string m_BirthDate;
        private string m_SDT;
        private string m_Phone;
        public string Name 
        { 
            get { return m_Name; }
            set {  m_Name = value; }
        }
        public string BirthDate
        {
            get { return m_BirthDate; }
            set { m_BirthDate = value; }
        }
        public string Phone
        {
            get { return m_SDT; }
            set { m_SDT = value; }
        }
        public string Address
        {
            get { return m_Phone; }
            set { m_Phone = value; }
        }

        public User(string name, string birth, string phone, string address)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ten khong hop le!");

            Name = name.Trim();
            BirthDate = birth.Trim();
            Phone = phone.Trim();
            Address = address.Trim();
        }

        public override string ToString()
        {
            return $"Ten: {Name} | Ngay sinh: {BirthDate} | SDT: {Phone} | Dia chi: {Address}";
        }
    }
}
