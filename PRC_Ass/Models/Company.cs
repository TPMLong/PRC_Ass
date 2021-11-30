using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PRC_Ass.Models
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }
        public String Phone { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public int Status { get; set; }
        public String Code { get; set; }
    }
}
