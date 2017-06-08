using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikAngular2.Constants
{
    public class TelerikAngular2Constants
    {
        public const string TelerikAngular2Api = "https://localhost:44309/";
        public const string TelerikAngular2Client = "http://localhost:3000/";
        public const string TelerikAngular2Mobile = "ms-app://s-1-15-2-467734538-4209884262-1311024127-1211083007-3894294004-443087774-3929518054/";

        public const string IdSrvIssuerUri = "https://localhost:44310/embedded";

        public const string IdSrv = "https://localhost:44310/identity";
        public const string IdSrvToken = IdSrv + "/connect/token";
        public const string IdSrvAuthorize = IdSrv + "/connect/authorize";
        public const string IdSrvUserInfo = IdSrv + "/connect/userinfo";
    }
}
