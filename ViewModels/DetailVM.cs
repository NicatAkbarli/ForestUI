using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forest.Models;

namespace Forest.ViewModels
{
    public class DetailVM
    {
          public Article Article { get; set; }
    public Article NextPost { get; set; }
    public Article PrevPost { get; set; }
    public List<Article> SimilarPost { get; set; }
    public List<Comment> Comments { get; set; }
    
    }
}