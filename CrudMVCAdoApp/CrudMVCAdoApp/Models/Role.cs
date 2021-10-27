using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudMVCAdoApp.Models
{
    public class Role
    {
        [Key]
        [MaxLength(10, ErrorMessage = "Maximum 10 characters are allowed")]
        [Display(Name = "Role No.")]
        public int RoleID { get; set; }

        [Display(Name = "Role Name")]
        public string Name { get; set; }

        [MaxLength(1000, ErrorMessage = "Maximum 1000 characters are allowed")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Create Date")]
        public DateTime Create { get; set; }
        public string CreatedBy { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}