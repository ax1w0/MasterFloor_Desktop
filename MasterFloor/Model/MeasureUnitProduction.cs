

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class MeasureUnitProduction
    {
        public int ProdMeasUnitId { get; set; }
        public int ProdTypeId { get; set; }
        public int MeasureUnitId { get; set; }
    
        public virtual MeasureUnits MeasureUnits { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
