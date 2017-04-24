using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Info.Models
{
    public class Article
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public App App { get; set; }
        public User UserID { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public String Title { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public String Description { get; set; }
        [Required]
        [StringLength(120, MinimumLength = 3)]
        public String Content { get; set; }
        [Required]
        public int Like { get; set; }
    }
}
