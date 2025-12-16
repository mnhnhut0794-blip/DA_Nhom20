using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class User
    {
        private string _name;
        private List<string> Friend;
        public string Username { 
            get { return this._name; }
            set { this._name = value; } 
        }
        public List<string> Friends { 
            get { return this.Friend; } 
            set { this.Friend = value; }
        }
        public User()
        {
            Username = "";
            Friends = new List<string>();
        }
        public User(string username)
        {
            Username = username;
            Friends = new List<string>();
        }
    }
}
