﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class NoDataException : CoinApiException
    {
        public NoDataException()
        {
        }

        public NoDataException(string message) : base(message)
        {
        }

        public NoDataException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}