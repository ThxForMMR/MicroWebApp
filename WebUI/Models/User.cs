using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebUI.Models
{
    public class User : IdentityUser
    {
        public long? DistrcitId { get; set; }
        public long? AreaId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
