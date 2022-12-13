using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class OperationWithAccount 
    {
        public void Registration(string? name, string? surname, string? email, string? password)
        {
            Accounts account = new Accounts(name, surname, email, password);
            SaveLoadfromDB.AddAccountDB(account);
        }

        public Accounts SignIn(string email)
        {
            return SaveLoadfromDB.GetAccount(email);
        }
    }
}
