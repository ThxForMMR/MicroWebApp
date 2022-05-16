using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class House : Territory
    {
        public string HouseNumber { get; set; }
        public string Information { get; set; }
        public long StreetId { get; set; }
        public long? SpotId { get; set; }
    }
}
