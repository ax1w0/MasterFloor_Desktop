

namespace MasterFloor.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Partner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Partner()
        {
            this.RealizationHistory = new HashSet<RealizationHistory>();
        }
    
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string INN { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Raiting { get; set; }
        public int DirectorId { get; set; }
        public int TypeId { get; set; }
        public int AddressId { get; set; }
        public Nullable<int> DiscountId { get; set; }
    
        public virtual Discount Discount { get; set; }
        public virtual IndexAddress IndexAddress { get; set; }
        public virtual PartnerType PartnerType { get; set; }
        public virtual Person Person { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RealizationHistory> RealizationHistory { get; set; }
    }
}
