using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Info.Models
{
    public enum AppPlatform
    {
        Android,
        Ios
    }
    public class App
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public String Name { get; set; }
        public String Icon { get; set; }
        public AppPlatform Platform { get; set; }
        public String UrlMarket { get; set; }
    }
}
