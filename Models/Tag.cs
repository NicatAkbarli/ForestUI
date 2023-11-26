using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forest.Models
{
   public class Tag : BaseEntity
{
    public string TagName { get; set; }
    public List<ArticleTag> ArticleTags { get; set; }
}
}