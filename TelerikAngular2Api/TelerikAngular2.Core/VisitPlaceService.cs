using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAngular2.Core.Interfaces;
using TelerikAngular2.Data.Common;
using TelerikAngular2.Data.Models;

namespace TelerikAngular2.Core
{
    public class VisitPlaceService : IVisitPlaceService
    {
        private readonly IDbRepository<VisitedPlace> repository;
        private readonly IDbRepository<Image> repositoryImage;
        public VisitPlaceService(IDbRepository<VisitedPlace> repository, IDbRepository<Image> repositoryImage)
        {
            this.repository = repository;
            this.repositoryImage = repositoryImage;
        }

        public IEnumerable<VisitedPlace> GetAllPlaces(User user)
        {
            return this.repository.All().Where(i => i.user.Id == user.Id && i.IsVisited == false);
        }

        public IEnumerable<VisitedPlace> GetWishList(User user)
        {
            return this.repository.All().Where(i => i.user.Id == user.Id && i.IsVisited == true);
        }

        public void DeletePlace(Guid placeId)
        {
            if (placeId != null)
            {
                var placeToDelete = this.repository.GetById(placeId);
                if (placeToDelete != null)
                {
                    this.repositoryImage.All().Where(i => i.VisitedPlace.Id == placeToDelete.Id).ToList().ForEach( i=>
                    {
                        this.repositoryImage.HardDelete(i);
                        this.repositoryImage.Save();
                    });
                    this.repository.HardDelete(placeToDelete);
                    this.repository.Save();
                }
            }
        }

        public void SavePlace(VisitedPlace placeToSave, User user)
        {
            
            var place = this.repository.GetById(placeToSave.Id);
            if (place == null)
            {
                placeToSave.user = user;
                this.repository.Add(placeToSave);
                this.repository.Save();
            }
            else
            {
                place.Name = placeToSave.Name;
                place.Description = placeToSave.Description;
                place.IsVisited = placeToSave.IsVisited;
                this.repository.Update(place);
                this.repository.Save();
            }
        }

        public void UpdatePlace(VisitedPlace dataToUpdate)
        {
            if (dataToUpdate != null)
            {
                this.repository.Update(dataToUpdate);
                this.repository.Save();
            }
        }
    }
}
