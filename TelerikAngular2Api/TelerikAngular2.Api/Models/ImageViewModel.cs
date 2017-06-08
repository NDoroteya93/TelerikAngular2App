using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TelerikAngular2.Data.Models;

namespace TelerikAngular2.Api.Models
{
    public class ImageViewModel
    {
        public string Name { get; set; }

        public byte[] Photo { get; set; }

        public static Expression<Func<Image, ImageViewModel>> FromVisitedPlaces
        {
            get
            {
                return image => new ImageViewModel()
                {
                    Name = image.Name,
                    Photo = image.Photo
                };
            }
        }
    }
}