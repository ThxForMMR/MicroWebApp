using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class Spot : Territory
    {
        public string SpotName { get; set; }
        public string Information { get; set; }
        public string PhoneNumber { get; set; }
        public string PointX { get; set; }
        public string PointY { get; set; }
        public string Address { get; set; }
        public long DistrictId { get; set; }
        //public long? UserId { get; set; }
        public long? CityId { get; set; }
    }
}
