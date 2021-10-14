using System;
using System.ComponentModel.DataAnnotations;

namespace CODEFIRST_ASP.NET.Models
{
    public class Contract
    {
        [Key]
        [MaxLength(10, ErrorMessage = "Maximum 10 characters are allowed")]
        [Display(Name = "Contract No.")]
        public string ContractID { get; set; }
        public string Contents { get; set; }
        public string ContractType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Sign Date")]
        public DateTime SignDate { get; set; }
        public string EmpID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Create Date")]
        public DateTime Create { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public virtual Employee Employee { get; set; }
    }
}