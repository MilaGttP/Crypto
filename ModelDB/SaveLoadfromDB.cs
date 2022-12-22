using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Crypto
{
    public static class SaveLoadfromDB
    {

        //метод щоб додати акаунт в БД
        public static void AddAccountDB(Accounts accounts)
        {
            try
            {
                using (CryptoCurrencyDB currencyDB = new CryptoCurrencyDB())
                {
                    currencyDB.Accounts.Add(accounts);
                    currencyDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //метод, щоб додати дії з покупки валюти до БД
        //викликати метод - SaveLoadfromDB.AddHistoryDB(history).Wait();
        public static void AddHistoryDB(HistoryAccount history)
        {
            try
            {
                using (CryptoCurrencyDB currencyDB = new CryptoCurrencyDB())
                {
                    currencyDB.HistoryAccount.Add(history);
                    currencyDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //метод, щоб додати інформацію про гаманець користувача в БД
        //викликати метод - SaveLoadfromDB.AddWalletDB(wallet).Wait();
        public static void AddWalletDB(Notecase wallet)
        {
            try
            {
                using (CryptoCurrencyDB currencyDB = new CryptoCurrencyDB())
                {
                    currencyDB.Notecase.Add(wallet);
                    currencyDB.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //метод для отримання операцій конкретного аккаунту за Id
        //Отримати результат- List<History> history = new List<History>();
        //var tmp = SaveLoadfromDB.GetAccountHistory(1);
        //history = tmp.Result;
        public static List<HistoryAccount> GetAccountHistory(int IdUser)
        {
            List<HistoryAccount> history = new List<HistoryAccount>();
            try
            {
                using (CryptoCurrencyDB currencyDB = new CryptoCurrencyDB())
                {
                    history = (from lst in currencyDB.HistoryAccount
                               where lst.Id_account == IdUser
                               orderby lst.Transaction_date
                               select lst).ToList<HistoryAccount>();
                }
                if (history.Count == 0)
                {
                    throw new Exception("Record not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return history;
        }
        //метод для перевірки наявності акаунту в БД за ел.адресою
        public static Accounts GetAccount(string EmailUser)
        {
            Accounts account = new Accounts();
            try
            {
                using (CryptoCurrencyDB currencyDB = new CryptoCurrencyDB())
                {
                    account = (from lst in currencyDB.Accounts
                               where lst.Email == EmailUser
                               select lst).FirstOrDefaultAsync<Accounts>().Result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return account;
        }

        //метод для пошуку гаманця користувача в бд
        public static Notecase GetAccountWallet(int ?IdUser)
        {
            Notecase wallet = new Notecase();
            try
            {
                using (CryptoCurrencyDB currencyDB = new CryptoCurrencyDB())
                {
                    wallet = (from lst in currencyDB.Notecase
                              where lst.Id_account == IdUser
                              select lst).FirstOrDefault<Notecase>();
                }
                if (wallet == null)
                {

                    throw new Exception("Record not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return wallet;
        }

        //метод для зміни суми гаманця в БД
        public static void UpdateWallet(int? id, decimal ?totalSum)
        {
            try
            {
                using (CryptoCurrencyDB currencyDB = new CryptoCurrencyDB())
                {
                    var tmp = currencyDB.Notecase.Where(s => s.Id == id).FirstOrDefault();

                    if (tmp != null)
                    {
                        tmp.Sum = totalSum;
                        currencyDB.Entry(tmp).State = EntityState.Modified;
                        currencyDB.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //метод для зміни паролю для акаунту
        public static void UpdatePassword(string emailUser, string newPassword)
        {
            try
            {
                using (CryptoCurrencyDB currencyDB = new CryptoCurrencyDB())
                {
                    var tmp = currencyDB.Accounts.Where(s => s.Email == emailUser).FirstOrDefault();

                    if (tmp != null)
                    {
                        tmp.Password = newPassword;
                        currencyDB.Entry(tmp).State = EntityState.Modified;
                        currencyDB.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
