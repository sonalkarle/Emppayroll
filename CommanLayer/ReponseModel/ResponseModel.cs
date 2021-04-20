using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace CommonLayer.ResponseModel
{
    public class EmployeeModel
    {
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        public string ProfileImage { get; set; }
        public string Gender { get; set; }
        public long Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string[] Department { get; set; }
        public string Notes { get; set; }

    }
}