using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace CODEFIRST_ASP.NET.Models
{
    public class Employee
    {
        [Key]
        [MaxLength(10, ErrorMessage = "Maximum 10 characters are allowed")]
        [Display(Name = "Employee No.")]
        public string EmpID { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum 100 characters are allowed")]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [MaxLength(150, ErrorMessage = "Maximum 100 characters are allowed")]
        public string Address { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum 100 characters are allowed")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Range(18, 100, ErrorMessage = "Age must be greater than 18")]
        public int Age { get; set; }
        public Status? Status { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public int Rank { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Create Date")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Create { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        public virtual ICollection<Contract> Contract { get; set; }
        public virtual ICollection<Project> Project { get; set; }
    }
}

public enum Status
{
    IsWorking,
    NonWorking,
    Close
}