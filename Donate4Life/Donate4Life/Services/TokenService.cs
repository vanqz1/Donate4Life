using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donate4Life.Services
{
    public class TokenService
    {
        public void RemoveTokensByUserId(int userId)
        {
            using (var context = new Donate4LifeEntities1())
            {
                var tokens = context.Tokens.Where(s=>s.UserId == userId);

                foreach (var token in tokens)
                {
                    context.Tokens.Remove(token);
                }

                context.SaveChanges();
            }
        }

        public bool IsUserLogedIn(int userId)
        {
            var id = userId;
            using (var context = new Donate4LifeEntities1())
            {
                var doesUserHasValidToken = context.Tokens.Any(s => s.UserId == userId && s.ExpiresOn > DateTime.Now);

                return doesUserHasValidToken;
            }
        }
    }
}