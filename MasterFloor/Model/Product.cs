

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.MaterialProduct = new HashSet<MaterialProduct>();
            this.RealizationHistory = new HashSet<RealizationHistory>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public decimal MinCostForPartner { get; set; }
        public int ProductTypeId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialProduct> MaterialProduct { get; set; }
        public virtual ProductType ProductType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RealizationHistory> RealizationHistory { get; set; }
    }
}
