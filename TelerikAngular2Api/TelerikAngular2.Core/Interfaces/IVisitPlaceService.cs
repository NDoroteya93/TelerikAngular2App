using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAngular2.Data.Models;

namespace TelerikAngular2.Core.Interfaces
{
    public interface IVisitPlaceService
    {
        IEnumerable<VisitedPlace> GetAllPlaces(User user);

        IEnumerable<VisitedPlace> GetWishList(User user);

        void SavePlace(VisitedPlace placeToSave, User user);

        void DeletePlace(Guid placeId);

        void UpdatePlace(VisitedPlace dataToUpdate);
    }
}
