using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class HistoryAccount
    {
        public int? Id { get; set; }
        public int ?Id_account { get; set; }
        public string ? Id_assets { get; set; }
        public DateTime? Transaction_date { get; set; }
        public decimal ? Total_amount { get; set; }
        public HistoryAccount(int? id_account, string? id_assets, DateTime? transaction_date, decimal? total_amount)
        {
            Id_account = id_account;
            Id_assets = id_assets;
            Transaction_date = transaction_date;
            Total_amount = total_amount;
        }

        public HistoryAccount()
        {
            Id_assets = null;
            Transaction_date = null;
            Total_amount = null;
        }
    }
}
