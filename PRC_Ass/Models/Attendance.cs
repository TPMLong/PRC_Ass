using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PRC_Ass.Models
{
    public class Attendance
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime DateTimeTick { get; set; }
    }
}
