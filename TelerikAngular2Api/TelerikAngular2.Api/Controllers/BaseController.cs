using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TelerikAngular2.Core.Interfaces;
using TelerikAngular2.Data.Models;

namespace TelerikAngular2.Api.Controllers
{
    public class BaseController : ApiController
    {
        private readonly IUserService userService;

        public BaseController(IUserService userService)
        {
            this.userService = userService;
        }

        public User GetCurrentUser()
        {
            User currentUser;
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            Guid userId = Guid.Parse(claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            string userName = claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName).Value;
            string email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            currentUser = userService.GetUserById(userId);
            if(currentUser == null)
            {
                Guid user = userService.CreateUser(userId, userName, email);
                currentUser = userService.GetUserById(userId);
            }
            return currentUser;
        }
    }
}