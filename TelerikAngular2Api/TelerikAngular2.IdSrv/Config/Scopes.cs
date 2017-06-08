using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelerikAngular2.IdSrv.Config
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            var scopes = new List<Scope>
                {
 
                    // identity scopes

                    StandardScopes.OpenId,
            StandardScopes.Profile,
            StandardScopes.Email,
            StandardScopes.Roles,
            StandardScopes.ProfileAlwaysInclude,
            StandardScopes.OfflineAccess,
                    new Scope
                    {
                        Enabled = true,
                        Name = "roles",
                        DisplayName = "Roles",
                        Description = "The roles you belong to.",
                        Type = ScopeType.Identity,
                        Claims = new List<ScopeClaim>
                        {
                            new ScopeClaim("role"),
                            new ScopeClaim("given_name"),
                            new ScopeClaim("family_name",  alwaysInclude: true),
                            new ScopeClaim("email")
                        }
                    },
                    new Scope
                    {
                        Name = "telerikangular2api",
                        DisplayName = "TelerikAngular2 API Scope",
                        Type = ScopeType.Resource,
                        //Emphasize = false,
                         Enabled = true,
                        Emphasize = true,
                Claims = new List<ScopeClaim>
                {
                    new ScopeClaim("name", alwaysInclude: true),
                    new ScopeClaim("given_name", alwaysInclude: true),
                    new ScopeClaim("family_name", alwaysInclude: true),
                    new ScopeClaim("email", alwaysInclude: true),
                    new ScopeClaim("role", alwaysInclude: true),
                    new ScopeClaim("website", alwaysInclude: true),
                }

                    },


                 };

            return scopes;
        }
    }
}