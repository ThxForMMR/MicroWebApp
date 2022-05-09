using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTerritoryAPI.Models
{
    public class District : Territory
    {
        public string DistrictName { get; set; }
        public long AreaId { get; set; }
    }
}
