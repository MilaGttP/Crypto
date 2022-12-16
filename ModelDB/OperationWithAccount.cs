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
            try
            {
                Accounts account = new Accounts(name, surname, email, password);
                SaveLoadfromDB.AddAccountDB(account);
                var tmp = SaveLoadfromDB.GetAccount(email);
                Notecase notecase = new Notecase(tmp.Id, email, 0);
                SaveLoadfromDB.AddWalletDB(notecase);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public Accounts SignIn(string email, ref Notecase notecase)
        {
            Accounts accounts = null;
            try
            {
                accounts = SaveLoadfromDB.GetAccount(email);
                Notecase notecase1 = null;
                notecase1 = SaveLoadfromDB.GetAccountWallet(accounts.Id);
                notecase = notecase1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return accounts;
        }

        public bool IsPasswordCorrect(Accounts accounts, string? password)
        {
            return (accounts.Password == password) ? true : false;
        }
    }
}
