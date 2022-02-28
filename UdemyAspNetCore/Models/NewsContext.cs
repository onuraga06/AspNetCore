using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAspNetCore.Models
{
    public static class NewsContext
    {
        public static List<News> List = new()
        {
            new News { Title="Başlık 1" },
            new News { Title="Başlık 2" }
        };
    }
}
