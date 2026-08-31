

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class City
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public City()
        {
            this.StreetCity = new HashSet<StreetCity>();
        }
    
        public int Id { get; set; }
        public string NameCity { get; set; }
        public int RegionId { get; set; }
    
        public virtual Region Region { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StreetCity> StreetCity { get; set; }
    }
}
