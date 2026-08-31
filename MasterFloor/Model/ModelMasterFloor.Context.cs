namespace MasterFloor.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MasterFloorEntities : DbContext
    {
        public MasterFloorEntities()
            : base("name=MasterFloorEntities")
        {
        }
        public static MasterFloorEntities _context;
        public static MasterFloorEntities GetContext()
        {
            if (_context == null)
                _context = new MasterFloorEntities();

            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<HouseStreet> HouseStreet { get; set; }
        public virtual DbSet<IndexAddress> IndexAddress { get; set; }
        public virtual DbSet<MaterialProduct> MaterialProduct { get; set; }
        public virtual DbSet<Materials> Materials { get; set; }
        public virtual DbSet<MaterialType> MaterialType { get; set; }
        public virtual DbSet<MeasureUnitProduction> MeasureUnitProduction { get; set; }
        public virtual DbSet<MeasureUnits> MeasureUnits { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<PartnerType> PartnerType { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<RealizationHistory> RealizationHistory { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<StatusFamily> StatusFamily { get; set; }
        public virtual DbSet<StatusHealth> StatusHealth { get; set; }
        public virtual DbSet<StatusPay> StatusPay { get; set; }
        public virtual DbSet<Street> Street { get; set; }
        public virtual DbSet<StreetCity> StreetCity { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SupplierType> SupplierType { get; set; }
        public virtual DbSet<Supply> Supply { get; set; }
    }
}
