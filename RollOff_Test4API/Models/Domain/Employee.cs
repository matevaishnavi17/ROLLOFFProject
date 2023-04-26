using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff_Test4API.Models.Domain
{
    public class Employee
    {


        [Key]
        public int GlobalGroupID { get; set; }

        public int? EmployeeNo { get; set; }
        public string? Name { get; set; }
        public string? LocalGrade { get; set; }
        public string? MainClient { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime? JoiningDate { get; set; }
        public int? ProjectCode { get; set; }
        public string? ProjectName { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }
        public string? PeopleManager { get; set; }
        public string? Practice { get; set; }
        public string? PSPName { get; set; }
        public string? NewGlobalPractice { get; set; }
        public string? OfficeCity { get; set; }
        public string? Country { get; set; }

    }
}
