using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crypto
{
    public class MainItems
    {
        public OperationWithAccount OperationWithAccount { get; set; }
        public OperationWithNotecase OperationWithNotecase { get; set; }
        public List<Currency> currencies { get; set; }
        public List<Icon> icons { get; set; }
        public List<SetCurrencyAndIcon> setCurrencyAndIcons { get; set; }

        public SetCurrencyAndIcon setCurrencyAndIcon { get; set; }

        public MainItems()
        {
            try
            {
                currencies = new List<Currency>();
                icons = new List<Icon>();
                setCurrencyAndIcon= new SetCurrencyAndIcon();
                setCurrencyAndIcons = new List<SetCurrencyAndIcon>();
                OperationWithAccount = new OperationWithAccount();
                OperationWithNotecase = new OperationWithNotecase();
                currencies = AdapterDataAPi.Get_currency_list().FindAll(s=>s.type_is_crypto==1&&s.price_usd!=null).
                OrderBy(s => s.price_usd).Reverse().ToList(); ;
                icons = AdapterDataAPi.Get_icon_list(25);
                setCurrencyAndIcons = setCurrencyAndIcon.GetSetIconCurrency(currencies, icons);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

       
    }
}
