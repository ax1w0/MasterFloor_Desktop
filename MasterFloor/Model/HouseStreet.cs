

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class HouseStreet
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public int StreetId { get; set; }
    
        public virtual House House { get; set; }
        public virtual Street Street { get; set; }
    }
}
