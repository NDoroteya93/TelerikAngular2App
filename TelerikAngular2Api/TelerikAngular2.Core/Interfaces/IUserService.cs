using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAngular2.Data.Models;

namespace TelerikAngular2.Core.Interfaces
{
    public interface IUserService
    {
        User GetUserById(Guid userId);

        IQueryable<VisitedPlace> GetVisitedPlaces(Guid userId);

        Guid CreateUser(Guid userId, string Name, string Email);
    }
}
