using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAngular2.Data.Common.Models;

namespace TelerikAngular2.Data.Models
{
    public class Image : BaseModel<Guid>
    {

        public string Name { get; set; }

        public byte[] Photo { get; set; }

        public virtual VisitedPlace VisitedPlace {get;set;}
    }
}
