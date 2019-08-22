using System.Collections.Generic;

namespace WebApi.Models
{
    ///<summary>
    ///Estructura del JSON
    ///</summary>
    public class DataBaseStruct
    {
        ///<summary>
        ///Lista de Roles en el json
        ///</summary>
        public List<Rol> Roles { get; set; }
        ///<summary>
        ///Lista de Sucursales en el json
        ///</summary>
        public List<BranchOffice> BranchOffices { get; set; }
        ///<summary>
        ///Lista de Trabajadores en el json
        ///</summary>
        public List<Worker> Workers { get; set; }
        ///<summary>
        ///Lista de Registros de horas en el json
        ///</summary>
        public List<HourRecord> HourRecords{ get; set; }
        ///<summary>
        ///Lista de Proveedores en el json
        ///</summary>
        public List<Supplier> Suppliers { get; set; }
        ///<summary>
        ///Lista de Productis en el json
        ///</summary>
        public List<Product> Products { get; set; }
        ///<summary>
        ///Lista de Compras en el json
        ///</summary>
        public List<Purchase> Purchases { get; set; }
        ///<summary>
        ///Lista de Inventarios por sucursal en el json
        ///</summary>
        public List<BranchInventory> BranchInventories { get; set; }
    }
}