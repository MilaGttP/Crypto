using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public  class ChangedRatesMV:BaseViewModel
    {
        private MainItems mainItems { get; set; }
        private BaseViewModel _selectedViewModel { get; set; }
        private ExchangeCurrentrate exchangeCurrentrate { get; set; }
        public ExchangeCurrentrate Exchange
        {
            get
            {
                return exchangeCurrentrate;
            }
            set
            {
                exchangeCurrentrate = value;
                OnPropertyChanged(nameof(Exchange));
            }
        }


    }
}
