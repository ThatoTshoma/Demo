using System;
using System.ComponentModel.DataAnnotations;

namespace LMS_Demo.Models
{
    public partial class Message
    {
        [Key]
        public int SysId { get; set; }
        public string From { get; set; }
        public Nullable<int> ToStudents { get; set; }
        public Nullable<int> ToFacilitator { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> SentDate { get; set; }
        public Nullable<int> IsDeleted { get; set; }

        public virtual Student Student { get; set; }
        public virtual Facilitator Facilitator { get; set; }
    }
}