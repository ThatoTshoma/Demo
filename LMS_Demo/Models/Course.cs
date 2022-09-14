

namespace LMS_Demo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.Teaches = new HashSet<Teach>();
            this.Assesments = new HashSet<Assesment>();
        }
        [Key]

        public int SysId { get; set; }
        public string Name { get; set; }
        public Nullable<int> YearId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> IsDeleted { get; set; }
        public Nullable<int> DepartmentID { get; set; }

        public virtual Department Department { get; set; }
        public virtual Year Year { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teach> Teaches { get; set; }
        public virtual Facilitator Facilitator { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assesment> Assesments { get; set; }
    }
}