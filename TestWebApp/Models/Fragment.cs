using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApp.Models
{
    public class Fragment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DefaultUrl { get; set; }
        public string OpenUrl { get; set; }
        public string EditUrl { get; set; }
        public string DeleteUrl { get; set; }
    }
}