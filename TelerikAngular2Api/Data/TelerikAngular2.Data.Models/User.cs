using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAngular2.Data.Common.Models;

namespace TelerikAngular2.Data.Models
{
    public class User : BaseModel<Guid>
    {
        public User()
        {
            VisitedPlaces = new List<VisitedPlace>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public virtual ICollection<VisitedPlace> VisitedPlaces { get; set; }

    }
}
