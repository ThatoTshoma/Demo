using System;
using System.ComponentModel.DataAnnotations;

namespace LMS_Demo.Models
{
    public partial class Account
    {
        [Key]
        public int SysId { get; set; }
        public Nullable<int> FacilitatorID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public string Password { get; set; }
        public Nullable<int> RoleID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> IsDeleted { get; set; }
        public string Salt { get; set; }

       // public virtual Role Role { get; set; }
        public virtual Student Student { get; set; }
        public virtual Facilitator Teacher { get; set; }
    }
}