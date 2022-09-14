using System;
using System.ComponentModel.DataAnnotations;

namespace LMS_Demo.Models
{
    public partial class Teach
    {
        [Key]
        public int SysId { get; set; }
        public Nullable<int> TeacherId { get; set; }
        public Nullable<int> CourseId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> YearId { get; set; }
        public Nullable<int> SectionId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Department Department { get; set; }
        public virtual Section Section { get; set; }
        public virtual Year Year { get; set; }
        public virtual Facilitator Facilitator { get; set; }
    }
}