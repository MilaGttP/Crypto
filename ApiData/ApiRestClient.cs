using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Crypto
{
    public class ApiRestClient
    {
        private string apikey;
        public string DateFormat => "yyyy-MM-ddTHH:mm:ss.fff";
        private string WebUrl = "https://rest.coinapi.io";

        public ApiRestClient(bool sandbox = true)
        {
            this.apikey = "C0970770-22A5-4628-B691-6AE79D26815A";
            if (sandbox)
            {
                WebUrl = "https://rest-sandbox.coinapi.io";
            }
            this.WebUrl = WebUrl.TrimEnd('/');
        }

        public ApiRestClient(string apikey, string url)
        {
            this.apikey = apikey;
            this.WebUrl = url.TrimEnd('/');
        }

        private async Task<T> GetData<T>(string url)
        {
            try
            {
                using (var handler = new HttpClientHandler())
                {
                    handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                    using (var client = new HttpClient(handler, false))
                    {
                        client.DefaultRequestHeaders.Add("X-CoinAPI-Key", this.apikey);

                        HttpResponseMessage response = await client.GetAsync(WebUrl + url).ConfigureAwait(false);

                        if (!response.IsSuccessStatusCode)
                            await RaiseError(response).ConfigureAwait(false);

                        return await Deserialize<T>(response).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception e)
            {
                throw new CoinApiException("Unexpected error", e);
            }
        }
        //метод для отримання списку зображень валют 
        public List<Icon> List_Assets_Icons(int sizeIcon)
        {
            try
            {
                using (var client = new RestClient("https://rest.coinapi.io"))
                {
                    return  DeserializeIcon(client, sizeIcon);
                }
            }
            catch (Exception e)
            {
                throw new CoinApiException("Unexpected error", e);
            }
        }

        private static async Task RaiseError(HttpResponseMessage response)
        {
            var message = (await Deserialize<ErrorMessage>(response).ConfigureAwait(false)).message;

            switch ((int)response.StatusCode)
            {
                case 400:
                    throw new BadRequestException(message);
                case 401:
                    throw new UnauthorizedException(message);
                case 403:
                    throw new ForbiddenException(message);
                case 429:
                    throw new TooManyRequestsException(message);
                case 550:
                    throw new NoDataException(message);
                default:
                    throw new CoinApiException(message);
            }
        }

        private List<Icon> DeserializeIcon(RestClient client, int iconSize)
        {
            List<Icon> icons = new List<Icon>();
            try
            {
                var request = new RestRequest(ApiEndpointUrls.Assests_Icons(iconSize));
                request.AddHeader("X-CoinAPI-Key", "C0970770-22A5-4628-B691-6AE79D26815A");
                RestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string jsonStr = response.Content;
                    icons = JsonConvert.DeserializeObject<List<Icon>>(jsonStr);
                }
            }
            catch (Exception e)
            {
                throw new CoinApiException("Unexpected error", e);
            }
            return icons;
        }
        private static async Task<T> Deserialize<T>(HttpResponseMessage responseMessage)
        {
            var responseString = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            var data = JsonConvert.DeserializeObject<T>(responseString);
            return data;
        }
        //метод для отримання списку всіх валют
        public Task<List<Currency>> List_AssetsAsync()
        {
            return GetData<List<Currency>>(ApiEndpointUrls.Assets());
        }
        //метод для визначення курсу базової валюти <baseId> до валюти <quoteId>
        public Task<Exchangerate> Exchange_rates_get_specific_rateAsync(string baseId, string quoteId)
        {
            var url = ApiEndpointUrls.ExchangeRateSpecific(baseId, quoteId);
            return GetData<Exchangerate>(url);
        }

        //метод для визначення курсу базової валюти <baseId> до інших
        public Task<ExchangeCurrentrate> Exchange_rates_get_all_current_ratesAsync(string baseId, bool invert = false)
        {
            var url = ApiEndpointUrls.ExchangeRate(baseId, invert);
            return GetData<ExchangeCurrentrate>(url);
        }
    }
    
}
    
