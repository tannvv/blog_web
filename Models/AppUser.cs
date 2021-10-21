using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace blog_web{
    public class AppUser : IdentityUser{
        [Column(TypeName ="nvarchar")]
        [StringLength(400)]
        public int HomeAddress { get; set; }
    }
}