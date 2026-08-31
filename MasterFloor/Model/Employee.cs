

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string BankCard { get; set; }
        public int PositionId { get; set; }
        public Nullable<int> StatusFamilyId { get; set; }
        public Nullable<int> StatusHealthId { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual Position Position { get; set; }
        public virtual StatusFamily StatusFamily { get; set; }
        public virtual StatusHealth StatusHealth { get; set; }
    }
}
