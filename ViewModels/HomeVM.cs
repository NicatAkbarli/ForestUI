using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forest.Models;

namespace Forest.ViewModels
{
    public class HomeVM
    {
        public List<Article> Article { get; set; }
        public List<User> User { get; set; }
        public List<Category> Category { get; set; }              
    }
}
