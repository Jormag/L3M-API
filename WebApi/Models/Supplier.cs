namespace WebApi.Models
{
    ///<summary>
    ///Entidad encargada de representar los Proveedores
    ///</summary>
    public class Supplier
    {
        ///<summary>
        ///Numero de cedula del proveedor
        ///</summary>
        public string IdentificationCard { get; set; }
        ///<summary>
        ///Nombre del proveedor
        ///</summary>
        public string Name { get; set; }
    }
}