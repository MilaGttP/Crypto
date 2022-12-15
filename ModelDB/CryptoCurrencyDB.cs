using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class CryptoCurrencyDB: DbContext
    {
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<HistoryAccount> HistoryAccount { get; set; }

        public DbSet<Notecase> Notecase { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SQL8003.site4now.net;Initial Catalog=db_a9158e_cryptodb;User Id=db_a9158e_cryptodb_admin;Password=wervnm7!");
        }
    }
}
