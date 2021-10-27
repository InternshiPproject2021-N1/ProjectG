using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudMVCAdoApp.Models
{
    public class Project
    {
        [Key]
        [MaxLength(10, ErrorMessage = "Maximum 10 characters are allowed")]
        [Display(Name = "Project No.")]
        public int ProjectID { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum 100 characters are allowed")]
        public string Name { get; set; }
        public int TeamSize { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public ProjectStatus? Status { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Create Date")]
        public DateTime Create { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
    }
}

public enum ProjectStatus
{
    New,
    InProgress,
    Close
}