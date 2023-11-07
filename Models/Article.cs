using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forest.Models
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string  Description { get; set; }
        public string  PhotoUrl { get; set; }
        public string  SeoUrl { get; set; }
        public int View { get; set; }
        public bool IsFutured {get; set;}
        public string UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedDate { get; set; }



    }
}