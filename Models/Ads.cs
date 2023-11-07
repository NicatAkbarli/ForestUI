using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forest.Models
{
    public class Ads : BaseEntity
    {
        public string PhotoUrl { get; set; }
        public string  RedirectAdress { get; set; }
    }
}