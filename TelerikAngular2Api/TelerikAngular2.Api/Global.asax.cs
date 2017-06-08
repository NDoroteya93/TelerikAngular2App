using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Routing;
using TelerikAngular2.Api.App_Start;

namespace TelerikAngular2.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            // GlobalConfiguration.Configure(WebApiConfig.Register);

           // AutofacApiConfig.RegisterDependencies();
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
    }
}
