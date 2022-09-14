using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace LMS_Demo.Models
{
    public class SubmitAssignmentModel
    {
        [Key]
        public int SysId { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> AssesmentId { get; set; }
        public string FilePath { get; set; }
        public Nullable<System.DateTime> SubmissionDate { get; set; }

        public HttpPostedFileBase File { get; set; }
        public Assesment Assesment { get; set; }
        public Student Student { get; set; }

    }
}
