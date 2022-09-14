using System;
using System.ComponentModel.DataAnnotations;

namespace LMS_Demo.Models
{
    public partial class SubmitAssignment
    {
        [Key]
        public int SysId { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> AssesmentId { get; set; }
        public string FilePath { get; set; }
        public Nullable<System.DateTime> SubmissionDate { get; set; }

        public virtual Student Student { get; set; }
        public virtual Assesment Assesment { get; set; }
    }
}