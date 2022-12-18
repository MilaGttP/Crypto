using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class TooManyRequestsException : CoinApiException
    {
        public TooManyRequestsException()
        {
        }

        public TooManyRequestsException(string message)
            : base(message)
        {
        }

        public TooManyRequestsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
