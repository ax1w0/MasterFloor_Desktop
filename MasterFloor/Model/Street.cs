

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Street
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Street()
        {
            this.HouseStreet = new HashSet<HouseStreet>();
            this.StreetCity = new HashSet<StreetCity>();
        }
    
        public int Id { get; set; }
        public string NameStreet { get; set; }
        public string House { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HouseStreet> HouseStreet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StreetCity> StreetCity { get; set; }
    }
}
