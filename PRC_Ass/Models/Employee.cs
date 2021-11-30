using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PRC_Ass.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String Avatar { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public DateTime Birthday { get; set; }
        public String Code { get; set; }
        public int Status { get; set; }
        public decimal TotalPoint { get; set; }
        public Guid EmployeeTypeId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
