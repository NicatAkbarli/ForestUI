using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forest.Models
{
    public class Comment : BaseEntity
    {
        public string Message { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }

    }
}