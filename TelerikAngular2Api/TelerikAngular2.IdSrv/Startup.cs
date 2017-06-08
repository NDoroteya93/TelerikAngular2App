using System;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;
using TelerikAngular2.Constants;
using TelerikAngular2.IdSrv.Config;
using System.Collections.Generic;
using IdentityServer3.Core.Services.InMemory;
using System.Security.Cryptography.X509Certificates;
using System.Web.Helpers;
using System.IdentityModel.Tokens.Jwt;
using IdentityManager.Configuration;
using TelerikAngular2.IdSrv.IdMgr;

[assembly: OwinStartupAttribute(typeof(TelerikAngular2.IdSrv.Startup))]
namespace TelerikAngular2.IdSrv
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AntiForgeryConfig.UniqueClaimTypeIdentifier = IdentityServer3.Core.Constants.ClaimTypes.Subject;
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();

            app.Map("/admin", adminApp =>
            {
                var factory = new IdentityManagerServiceFactory();
                factory.ConfigureSimpleIdentityManagerService("AspId");
                //factory.ConfigureCustomIdentityManagerServiceWithIntKeys("AspId_CustomPK");

                adminApp.UseIdentityManager(new IdentityManagerOptions()
                {
                    Factory = factory
                });
            });

            app.Map("/identity", idsrvApp =>
            {
                var idSvrFactory = Factory.Configure();
                idSvrFactory.ConfigureUserService("AspId");

                idsrvApp.UseIdentityServer(new IdentityServerOptions
                {
                    SiteName = "Embedded IdentityServer",
                    IssuerUri = TelerikAngular2Constants.IdSrvIssuerUri,
                    //SigningCertificate = LoadCertificate.Load(),
                    Factory = idSvrFactory,
                    SigningCertificate = LoadCertificate(),

                    //Factory = new IdentityServerServiceFactory()
                    //        .UseInMemoryClients(Clients.Get())
                    //        .UseInMemoryScopes(Scopes.Get())
                    //        .UseInMemoryUsers(Users.Get()),

                    //AuthenticationOptions = new AuthenticationOptions
                    //{
                    //    IdentityProviders = ConfigureIdentityProviders
                    //}

                });
            });
        }

        private void ConfigureIdentityProviders(IAppBuilder arg1, string arg2)
        {
            throw new NotImplementedException();
        }

        X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\bin\idsrv3test.pfx",
                AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}
