using System;
using System.ComponentModel.DataAnnotations;

namespace blog_web
{
    public class Article{

        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Created  { get; set; }
        public string Content { get; set; }
    }
}