﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class OperationWithNotecase
    {
        public Notecase notecase;
        public OperationWithNotecase()
        {
            this.notecase = new Notecase();
        }
        // метод для поповнення гаманця
        public void FillUPNotecase(decimal Sum, ref Notecase notecase)
        {
            try
            {
               notecase.Sum += Sum;
                SaveLoadfromDB.UpdateWallet(notecase.Id, notecase.Sum);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
      
        // метод для перевірки можливості здійснити покупку
        public bool IsEnoughMoneyOfBalance(decimal? Sum, Notecase notecase)
        {
            Notecase notecase1 = null;
            try
            {
               notecase1 = SaveLoadfromDB.GetAccountWallet(notecase.Id_account);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return (notecase.Sum >= Sum && notecase1.Sum >= Sum) ? true : false;
        }

        //метод для зміни залишку після здійснення покупки
        public void MakePurchaseCoine( decimal ? Sum,  Notecase notecase, string id_assets)
        {
            if (IsEnoughMoneyOfBalance(Sum, notecase))
            {
                notecase.Sum-= Sum;
                SaveLoadfromDB.UpdateWallet(notecase.Id, notecase.Sum);
                
                    HistoryAccount historyAccount = new HistoryAccount(notecase.Id_account, id_assets,
                        DateTime.UtcNow, Sum);
                    SaveLoadfromDB.AddHistoryDB(historyAccount);
            }
        }
    }
}
