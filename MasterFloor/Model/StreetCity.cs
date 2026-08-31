

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class StreetCity
    {
        public int Id { get; set; }
        public int StreetId { get; set; }
        public int CityId { get; set; }
    
        public virtual City City { get; set; }
        public virtual Street Street { get; set; }
    }
}
