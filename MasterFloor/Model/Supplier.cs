

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            this.Supply = new HashSet<Supply>();
        }
    
        public int Id { get; set; }
        public string FullName { get; set; }
        public int SupplierTypeId { get; set; }
        public string INN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supply> Supply { get; set; }
        public virtual SupplierType SupplierType { get; set; }
    }
}
