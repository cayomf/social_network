using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaoDeQueijo2.Models
{
    public class FeedViewModel
    {
        List<Post> Posts { get; set; }
        List<Share> Shares { get; set; }
    }
}