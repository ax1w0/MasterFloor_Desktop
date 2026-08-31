

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class MeasureUnits
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MeasureUnits()
        {
            this.MeasureUnitProduction = new HashSet<MeasureUnitProduction>();
        }
    
        public int Id { get; set; }
        public string NameMeasure { get; set; }
        public string ShortNameMeasure { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeasureUnitProduction> MeasureUnitProduction { get; set; }
    }
}
