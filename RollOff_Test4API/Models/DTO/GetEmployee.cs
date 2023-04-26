using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff_Test4API.Models.DTO
{
    public class GetEmployee
    {

   
        public int GlobalGroupID { get; set; }

        public int? EmployeeNo { get; set; }
        public string? Name { get; set; }
        public string? LocalGrade { get; set; }
       
        [Required]
        public string Email { get; set; }
       
    }
}
