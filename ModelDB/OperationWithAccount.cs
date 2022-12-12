using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class OperationWithAccount 
    {
        public async Task RegistrationAsync(string? name, string? surname, string? email, string? password)
        {
            Accounts account = new Accounts(name,surname,email, password);
            await SaveLoadfromDB.AddAccountDBAsync(account);
        }

        public async Task<Accounts> SignInAsync(string email)
        {
            return await SaveLoadfromDB.GetAccountAsync(email);
        }
    }
}
