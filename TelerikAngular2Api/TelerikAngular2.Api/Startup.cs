using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using IdentityServer3.AccessTokenValidation;
using TelerikAngular2.Api.Helpers;
using TelerikAngular2.Constants;

[assembly: OwinStartupAttribute(typeof(TelerikAngular2.Api.Startup))]

namespace TelerikAngular2.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseResourceAuthorization(new AuthorizationManager());

            app.UseIdentityServerBearerTokenAuthentication(new
            IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = TelerikAngular2Constants.IdSrv,
                RequiredScopes = new[] { "telerikangular2api" }
            });

            app.UseWebApi(WebApiConfig.Register());
        }
    }
}