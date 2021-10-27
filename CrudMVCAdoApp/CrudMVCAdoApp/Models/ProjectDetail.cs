using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudMVCAdoApp.Models
{
    public class ProjectDetail
    {
        [Key]
        [Display(Name = "Employee No.")]
        public int EmpID { get; set; }

        [Display(Name = "Project No.")]
        public int ProjectID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}