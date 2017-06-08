using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace TelerikAngular2.IdSrv.Config
{
    public class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>() {


                 new InMemoryUser{
                Subject = Guid.Parse("951a965f-1f84-4360-90e4-3f6deac7b9bc").ToString(),
                Username = "admin",
                Password = "admin",
                Claims = new[]
                {
                     new Claim(IdentityServer3.Core.Constants.ClaimTypes.Role, "IdentityManagerAdministrator"),
                    new Claim(IdentityServer3.Core.Constants.ClaimTypes.GivenName, "admin"),
                    new Claim(IdentityServer3.Core.Constants.ClaimTypes.FamilyName, "admin"),
                    new Claim(IdentityServer3.Core.Constants.ClaimTypes.Email, "admin@admin.com"),
                }
            }

           };
        }
    }

}