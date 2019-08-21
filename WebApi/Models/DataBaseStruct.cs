using System.Collections.Generic;

namespace WebApi.Models
{
    public class DataBaseStruct
    {
        public List<Rol> Roles { get; set; }
        public List<BranchOffice> BranchOffices { get; set; }
        public List<Worker> Workers { get; set; }
        public List<HourRecord> HourRecords{ get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Product> Products { get; set; }
        public List<Purchase> Purchases { get; set; }
        public List<BranchInventory> BranchInventories { get; set; }
    }
}