using System;

namespace Crypto
{
    public static class ApiEndpointUrls
    {
        public static string Assets() => "/v1/assets";
        public static string Assests_Icons(int iconSize) => ($"/v1/assets/icons/{iconSize}");
        public static string ExchangeRateSpecific(string baseId, string quoteId, string time) => string.Format("/v1/exchangerate/{0}/{1}?time={2}", baseId, quoteId, time);
        public static string ExchangeRateSpecific(string baseId, string quoteId) => string.Format("/v1/exchangerate/{0}/{1}", baseId, quoteId);
        public static string ExchangeRate(string baseId, bool invert) => string.Format("/v1/exchangerate/{0}?invert={1}", baseId, invert);

    }
}

