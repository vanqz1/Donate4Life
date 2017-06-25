using System;
using System.Linq;

namespace Donate4Life.Services
{
    public class AccountService
    {
        public bool IsUserLoggedIn(int id)
        {
            using (var context = new Donate4LifeEntities1())
            {
                var user = context.Users.FirstOrDefault(s => s.Id == id);

                if (user == null)
                {
                    return false;
                }

                var isLoggedIn = user.Tokens.Any(s=>s.ExpiresOn < DateTime.Now);

                return isLoggedIn;
            } 
        }

        public bool IsUserAdmin(int id)
        {
            using (var context = new Donate4LifeEntities1())
            {
                var user = context.Users.FirstOrDefault(s => s.Id == id);

                if (user == null)
                {
                    return false;
                }

                return user.IsAdmin;
            }
        }
    }
}