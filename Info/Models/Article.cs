using System;
using System.Collections.Generic;

namespace Info.Models
{
    public class Article
    {
        public int ID { get; set; }
        public App AppID { get; set; }
        public User UserID { get; set; }
        public String Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String Description { get; set; }
        public String Content { get; set; }
        public uint Like { get; set; }
    }
}
