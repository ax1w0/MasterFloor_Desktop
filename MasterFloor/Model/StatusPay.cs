

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class StatusPay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StatusPay()
        {
            this.RealizationHistory = new HashSet<RealizationHistory>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RealizationHistory> RealizationHistory { get; set; }
    }
}
