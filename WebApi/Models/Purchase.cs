namespace WebApi.Models
{
    ///<summary>
    ///Entidad encargada de representar las compras
    ///</summary>
    public class Purchase
    {
        ///<summary>
        ///Identificador de la compra
        ///</summary>
        public string ID { get; set; }
        ///<summary>
        ///Descripcion de la compra
        ///</summary>
        public string Description { get; set; }
        ///<summary>
        ///Fecha real en que se realizo la compra
        ///</summary>
        public string RealDate { get; set; }
        ///<summary>
        ///Fecha de registro de la compra
        ///</summary>
        public string RegistrationDate { get; set; }
        ///<summary>
        ///Proveedor de la compra
        ///</summary>
        public string Supplier { get; set; }
        ///<summary>
        ///Enlace de la imagen de la compra
        ///</summary>
        public string Image { get; set; }
        ///<summary>
        ///Sucursal en la que se realizo la compra
        ///</summary>
        public string BranchOffice { get; set; }
    }
}

