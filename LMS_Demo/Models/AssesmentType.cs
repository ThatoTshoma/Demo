

namespace LMS_Demo.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class AssesmentType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AssesmentType()
        {
            this.Assesments = new HashSet<Assesment>();
        }
        [Key]
        public int SysId { get; set; }
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assesment> Assesments { get; set; }
    }
}