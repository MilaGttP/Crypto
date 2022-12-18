using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Crypto
{
    public static class AdapterDataAPi
    {
        private static ApiRestClient apiRestClient = new ApiRestClient();
        //метод для отримання списку всіх валют
        public static List<Currency> Get_currency_list()
        {
            List<Currency> currencyList = new List<Currency>();
            var res = apiRestClient.List_AssetsAsync();
            return res.Result;
        }
        //метод для отримання списку зображень всіх валют
        public static List<Icon> Get_icon_list(int size)
        {
            List<Icon> icons = new List<Icon>();
            icons = apiRestClient.List_Assets_Icons(32);
            return icons;
        }
        //метод для визначення курсу базової валюти <baseId> до валюти <quoteId> 
        public static Exchangerate Get_exchangerate(string baseId, string quoteId)
        {
            var res = apiRestClient.Exchange_rates_get_specific_rateAsync(baseId, quoteId);
            return res.Result;
        }
        //метод для визначення курсу базової валюти <baseId> до інших
        public static ExchangeCurrentrate Get_all_exchangerate(string baseId, bool invert = false)
        {
            var res = apiRestClient.Exchange_rates_get_all_current_ratesAsync(baseId, invert = false);
            return res.Result;
        }
    }
}


