

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class MaterialProduct
    {
        public int MatProdId { get; set; }
        public int MaterialId { get; set; }
        public int ProductId { get; set; }
    
        public virtual Materials Materials { get; set; }
        public virtual Product Product { get; set; }
    }
}
