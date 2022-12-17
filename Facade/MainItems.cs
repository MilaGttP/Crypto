using System;
using System.Collections.Generic;

namespace Crypto
{
    public class MainItems
    {
        public OperationWithAccount OperationWithAccount { get; set; }
        public OperationWithNotecase OperationWithNotecase { get; set; }

        public List<Currency> currencies { get; set; }
        public List<Icon> icons { get; set; }
        public MainItems()
        {
            try
            {
                currencies = new List<Currency>();
                icons = new List<Icon>();
                OperationWithAccount = new OperationWithAccount();
                OperationWithNotecase = new OperationWithNotecase();
                currencies = AdapterDataAPi.Get_currency_list();
                icons = AdapterDataAPi.Get_icon_list(32);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
