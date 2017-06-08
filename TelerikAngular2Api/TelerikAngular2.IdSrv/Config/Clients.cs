using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelerikAngular2.Constants;
using static IdentityServer3.Core.Constants;

namespace TelerikAngular2.IdSrv.Config
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
             {
                new Client
                {
                     Enabled = true,
                     ClientId = "spa-demo",
                     ClientName = "spa-demo",
                     Flow = Flows.Implicit,
                     ClientSecrets = new List<Secret> {
                         new Secret("idsrv3test".Sha256())
                     },
                     AccessTokenLifetime = 3600, 
                     AllowAccessToAllScopes = true,
                    LogoutUri = "https://localhost:44310/identity/connect/endsession?id_token={{id_token}}",
                    RedirectUris = new List<string>
                    {
                        TelerikAngular2Constants.TelerikAngular2Client
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        TelerikAngular2Constants.TelerikAngular2Client
                    },
                     AllowedScopes = new List<string>
                     {
                         "openid",
                         "roles",
                         "telerikangular2api"
                     }

                }
             };

        }
    }
}
