using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDAutotests.Entity
{
    public class User
    {
        private string login;
        private string password;

        public User(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

        public string Login { get => login; set => login = value; }

        public string Password { get => password; set => password = value; }
    }
}
