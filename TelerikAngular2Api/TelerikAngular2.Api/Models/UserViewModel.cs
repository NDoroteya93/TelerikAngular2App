using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TelerikAngular2.Data.Models;

namespace TelerikAngular2.Api.Models
{
    public class UserViewModel
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public static Expression<Func<User, UserViewModel>> FromUser
        {
            get
            {
                return user => new UserViewModel()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email, 
                };
            }
        }
    }
}