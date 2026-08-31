

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supply
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int SupplierId { get; set; }
        public System.DateTime DateSupply { get; set; }
        public int Count { get; set; }
        public decimal Cost { get; set; }
    
        public virtual Materials Materials { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
