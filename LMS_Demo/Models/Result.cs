using System;
using System.ComponentModel.DataAnnotations;

namespace LMS_Demo.Models
{
    public partial class Result
    {
        [Key]
        public int SysId { get; set; }
        public Nullable<int> AssessmentID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public string Mark { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> IsDeleted { get; set; }

        public virtual Student Student { get; set; }
        public virtual Facilitator Facilitator { get; set; }
        public virtual Assesment Assesment { get; set; }
    }
}