

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Materials
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Materials()
        {
            this.MaterialProduct = new HashSet<MaterialProduct>();
            this.Supply = new HashSet<Supply>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaterialTypeId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialProduct> MaterialProduct { get; set; }
        public virtual MaterialType MaterialType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supply> Supply { get; set; }
    }
}
