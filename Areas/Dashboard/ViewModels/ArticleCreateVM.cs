using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forest.Models;

namespace Forest.Areas.Dashboard.ViewModels
{
    public class ArticleCreateVM
    {
        public List<Category> Categories { get; set; }
        public List<Tag> Tags { get; set; }
    }
}