using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTerritoryAPI.Models
{
    public class City : Territory
    {
        public string CityName { get; set; }
        public string CityType { get; set; }
        public string CityCategory { get; set; }
        public long DistrictId { get; set; }
        public long? SpotId { get; set; }
    }
}
