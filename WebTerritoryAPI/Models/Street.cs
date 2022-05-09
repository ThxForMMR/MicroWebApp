using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTerritoryAPI.Models
{
    public class Street : Territory
    {
        public string StreetName { get; set; }
        public string StreetType { get; set; }
        public long CityId { get; set; }
    }
}
