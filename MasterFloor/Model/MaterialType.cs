

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class MaterialType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaterialType()
        {
            this.Materials = new HashSet<Materials>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public double DefectPercent { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Materials> Materials { get; set; }
    }
}
