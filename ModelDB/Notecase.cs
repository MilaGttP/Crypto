using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class Notecase
    {
        public int? Id { get; set; }
        public int  ?Id_account { get; set; }
        public string? E_wallet { get; set; }
        public Decimal ?Sum { get; set; }
        public Notecase(int ?id_account, string? e_wallet, Decimal sum)
        {
            Id_account = id_account;
            E_wallet = e_wallet;
            Sum = sum;
        }
        public Notecase()
        {
            E_wallet = null;
            Sum = 0;
        }
    }
}
