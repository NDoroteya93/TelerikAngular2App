using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TelerikAngular2.Data.Models;

namespace TelerikAngular2.Api.Models
{
    public class VisitedPlaceViewModel
    {
        public Guid Id { get; set; }

        public string Label { get; set; }

        public float Lat { get; set; }

        public float Lng { get; set; }

        public string Description { get; set; }

        public bool isVisited { get; set; }

        public bool IsSaved { get; set; }

        public DateTime CreatedOn { get; set; }

        public static Expression<Func<VisitedPlace, VisitedPlaceViewModel>> FromVisitedPlaces
        {
            get
            {
                return visitedPlace => new VisitedPlaceViewModel()
                {
                    Id = visitedPlace.Id,
                    Label = visitedPlace.Name,
                    Lat = visitedPlace.Lat,
                    Lng = visitedPlace.Lng,
                    Description = visitedPlace.Description,
                    isVisited = visitedPlace.IsVisited,
                    IsSaved = visitedPlace.IsSaved,
                    CreatedOn = visitedPlace.CreatedOn
                };
            }
        }
    }
}