

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class RealizationHistory
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public System.DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int PartnerId { get; set; }
        public int StatusPayId { get; set; }
    
        public virtual Partner Partner { get; set; }
        public virtual Product Product { get; set; }
        public virtual StatusPay StatusPay { get; set; }
    }
}
