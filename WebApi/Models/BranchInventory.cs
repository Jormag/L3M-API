namespace WebApi.Models
{
    public class BranchInventory
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BranchPrice { get; set; }
        public int Stock { get; set; }
        public string BranchOffice { get; set; }
    }
}