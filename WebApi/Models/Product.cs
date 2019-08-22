namespace WebApi.Models
{
    ///<summary>
    ///Entidad encargada de representar los productos
    ///</summary>
    public class Product
    {
        ///<summary>
        ///Codigo de Barras del producto
        ///</summary>
        public string Barcode { get; set; }
        ///<summary>
        ///Nombre del producto
        ///</summary>
        public string Name { get; set; }
        ///<summary>
        ///Descripcion del producto
        ///</summary>
        public string Description { get; set; }
        ///<summary>
        ///Precio del producto
        ///</summary>
        public int Price { get; set; }
        ///<summary>
        ///Proveedor del producto
        ///</summary>
        public string Supplier { get; set; }
        ///<summary>
        ///Indica si el producto posee impuesto o no
        ///</summary>
        public int Tax { get; set; }
        ///<summary>
        ///Indica si el producto posee descuento o no
        ///</summary>
        public int Discount { get; set; }
    }

}
