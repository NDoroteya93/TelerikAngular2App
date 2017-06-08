using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAngular2.Data.Common.Models;

namespace TelerikAngular2.Data.Models
{
    public class VisitedPlace: BaseModel<Guid>
    {
        public VisitedPlace()
        {
            Images = new List<Image>();
        }

        public string Name { get; set; }

        public float Lat { get; set; }

        public float Lng { get; set; }

        public bool Draggable { get; set; }

        public string Description { get; set; }

        public bool? IsOpen { get; set; }

        public bool IsVisited { get; set; }

        public bool IsSaved { get; set; }

        public virtual User user { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
