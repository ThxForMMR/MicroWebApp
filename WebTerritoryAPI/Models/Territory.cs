using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTerritoryAPI.Models
{
    public abstract class Territory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
