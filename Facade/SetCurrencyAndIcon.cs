using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Crypto
{
    public class SetCurrencyAndIcon
    {
        public string ?name { get; set; }
        public string? iconUrl { get; set; }
        public decimal? price { get; set; }

        public SetCurrencyAndIcon(string? name, decimal ?price, string? iconURl)
        {
            this.name = name;
            this.price = price;
            this.iconUrl = iconURl; 
        }

        public SetCurrencyAndIcon()
        {
            this.name = null;
            this.price = null;
            this.iconUrl = null;
        }

        public List<SetCurrencyAndIcon> GetSetIconCurrency(List<Currency> currencies,List<Icon> icons)
        {
            List<SetCurrencyAndIcon> currencyList = new List<SetCurrencyAndIcon>();
 
            for(int i=0;i< currencies.Count;i++)
            {
                var tmp = (from k in icons
                          where k.asset_id == currencies[i].asset_id
                          select k).FirstOrDefault();
                if(tmp != null )
                currencyList.Add(new SetCurrencyAndIcon(currencies[i].asset_id, currencies[i].price_usd, tmp.url));
            }
            return currencyList;
        }

        public List<SetCurrencyAndIcon> FilterCurrencyList (List<Currency> currencies, List<Icon> icons, string nameToSearch)
        {
            List<SetCurrencyAndIcon> currencyList = GetSetIconCurrency(currencies, icons);
            List<SetCurrencyAndIcon> filtered = currencyList.Where(source => source.name.StartsWith(nameToSearch.ToUpper())).ToList<SetCurrencyAndIcon>();
            return filtered;
        }
    }
}
