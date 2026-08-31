

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SupplierType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SupplierType()
        {
            this.Supplier = new HashSet<Supplier>();
        }
    
        public int Id { get; set; }
        public string NameSupplier { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}
