namespace WebApi.Models
{
    public class Product
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Supplier { get; set; }
        public int Tax { get; set; }
        public int Discount { get; set; }
    }

}
