using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using TelerikAngular2.Core.Interfaces;
using TelerikAngular2.Data.Models;
using TelerikAngular2.Data.Common;

namespace TelerikAngular2.Core
{
    public class UserService : IUserService
    {
        private readonly IDbRepository<User> repository;
        public UserService(IDbRepository<User> repository)
        {
            this.repository = repository;
        }

        public Guid CreateUser(Guid userId, string Name, string Email)
        {
            User newUser = new User()
            {
                Id = userId,
                FirstName = Name,
                LastName = Name,
                Email = Email
            };

            this.repository.Add(newUser);
            this.repository.Save();
            return userId;
        }

        public User GetUserById(Guid userId)
        {
            User user = this.repository.GetById(userId);
            if (user == null)
            {

            }
            return user;
        }

        public IQueryable<VisitedPlace> GetVisitedPlaces(Guid userId)
        {
            IQueryable<VisitedPlace> visitedPlaces = null;
            User user = this.repository.GetById(userId);
            if (user != null)
            {
                visitedPlaces = user.VisitedPlaces.AsQueryable();
            }
            return visitedPlaces;
        }
    }
}
