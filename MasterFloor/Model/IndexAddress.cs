

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class IndexAddress
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IndexAddress()
        {
            this.House = new HashSet<House>();
            this.Partner = new HashSet<Partner>();
        }
    
        public int Id { get; set; }
        public string Number { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<House> House { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Partner> Partner { get; set; }
    }
}
