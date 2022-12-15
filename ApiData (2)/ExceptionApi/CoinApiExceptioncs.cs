using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class CoinApiException : Exception
    {
        public CoinApiException()
        {
        }

        public CoinApiException(string message)
            : base(message)
        {
        }

        public CoinApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
