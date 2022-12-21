using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Crypto
{
    public static class OperationWithAccount 
    {
        public static void Registration(string? name, string? surname, string? email, string? password)
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
                MessageBox.Show(ex.Message);
            }

        }
        public static Accounts SignIn(string email, ref Notecase notecase)
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
                MessageBox.Show(ex.Message);
            }
            return accounts;
        }

        public static bool EmailRegex(string email)
        {
            Regex emailRegex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            if (emailRegex.IsMatch(email)) return true;
            return false;
        }

        public static bool PasswordRegex(string pass) 
        {
            Regex passwordRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            if (passwordRegex.IsMatch(pass)) return true;
            else return false;
        }

        public static bool PassRePass(string pass, string repass)
        {
            if (pass == repass) return true;
            else return false;
        }

        public static bool IsPasswordCorrect(Accounts accounts, string? password)
        {
            return (accounts.Password == password) ? true : false;
        }
    }
}
