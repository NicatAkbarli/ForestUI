using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forest.Models;

namespace Forest.ViewModels
{
    public class HomeVM
    {
        public Article Article { get; set; }
       public List<Article> RecentArticles { get; set; }
    public List<Article> TrendVideos { get; set; }
    public List<Article> PopularPosts { get; set; }
    public Ads SidebarAds { get; set; }
    public Ads InlineAds { get; set; }  
    }
}
