using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class Accounts
    {
        public int ?Id { get; set; }
        public string ?Name { get; set; }
        public string ?Surname { get; set; }
        public string ?Email { get; set; }
        public string ? Password { get; set; }

        public Accounts( string? name, string? surname, string? email, string? password)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }
        public Accounts() {

            Name = null;
            Surname = null;
            Email = null;
            Password = null;
        }
    }
}
