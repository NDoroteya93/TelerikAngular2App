using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Owin.ResourceAuthorization;

namespace TelerikAngular2.Api.Helpers
{
    public class AuthorizationManager : ResourceAuthorizationManager
    {
        public override Task<bool> CheckAccessAsync(ResourceAuthorizationContext context)
        {
            switch (context.Resource.First().Value)
            {
                case "ExpenseGroup":
                    return AuthorizeExpenseGroup(context);
                default:
                    return Nok();
            }
        }

        private Task<bool> AuthorizeExpenseGroup(ResourceAuthorizationContext context)
        {
            switch (context.Action.First().Value)
            {
                case "Read":
                    // to be able to read an expensegroups from the API, the user must be in the
                    // WebReadUser role or MobileReadUser role
                    return
                        Eval(context.Principal.HasClaim("role", "MobileReadUser")
                        || (context.Principal.HasClaim("role", "WebReadUser")));

                default:
                    return Nok();
            }
        }
    }
}