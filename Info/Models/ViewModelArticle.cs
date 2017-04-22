using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Info.Models
{
    public class ViewModelArticle
    {        
        public String AppName { get; set; }
        public AppPlatform Platform { get; set; }
        //public User UserID { get; set; }

        public String Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime ReleaseDate { get; set; }

        public String Description { get; set; }

        public String Content { get; set; }

        public int Like { get; set; }

        public Article GetArticle()
        {
            var result = new Article();
            result.Content = this.Content;
            result.Title = Title;
            result.ReleaseDate = ReleaseDate;
            result.Description = Description;
            result.Like = Like;
            return result;
        }
    }
}

