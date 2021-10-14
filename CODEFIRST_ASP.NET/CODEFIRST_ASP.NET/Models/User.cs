using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CODEFIRST_ASP.NET.Models
{
    public class User
    {
        [Key]
        [MaxLength(10, ErrorMessage = "Maximum 10 characters are allowed")]
        [Display(Name = "User No.")]
        public string UserID { get; set; }

        [Display(Name = "Username")]
        public string Name { get; set; }
        public string Password { get; set; }

        [MaxLength(1000, ErrorMessage = "Maximum 1000 characters are allowed")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Create Date")]
        public DateTime Create { get; set; }
        public string CreatedBy { get; set; }
        public virtual ICollection<Role> Role { get; set; }
    }
}