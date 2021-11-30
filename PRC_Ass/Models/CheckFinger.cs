using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PRC_Ass.Models
{
    public class CheckFinger
    {
        [Key]
        public Guid Id { get; set; }
        public Nullable<Guid> FingerScanMachineId { get; set; }
        public Guid EmployeeId { get; set; }
        public System.DateTime DateTime { get; set; }
        public Nullable<int> Mode { get; set; }
        public bool Active { get; set; }
        public Guid StoreId { get; set; }
        public string MachineNumber { get; set; }
        public string EmpEnrollNumber { get; set; } //TimestampAttribute + mnv
        public Nullable<bool> IsUpdated { get; set; }
        public Nullable<Guid> BrandId { get; set; }
        public string LogCode { get; set; }


    }
}
