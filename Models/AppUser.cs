using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace blog_web{
    public class AppUser : IdentityUser{
        [Column(TypeName ="nvarchar")]
        [StringLength(400)]

        [DisplayName("Địa chỉ")]
        public string? HomeAddress { get; set; }

        [DisplayName("Ngày sinh")]

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
    }
}