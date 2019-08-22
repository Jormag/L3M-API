namespace WebApi.Models
{
    ///<summary>
    /// Entidad que representa el inventario de productos de una sucursal
    /// </summary>
    public class BranchInventory
    {
        ///<summary>
        /// Nombre de la sucursal
        /// </summary>
        public string Barcode { get; set; }
        ///<summary>
        /// Codigo de barras del producto
        /// </summary>
        public string Name { get; set; }
        ///<summary>
        /// Nombre del producto
        /// </summary>
        public string Description { get; set; }
        ///<summary>
        /// Descripcion del producto
        /// </summary>
        public int BranchPrice { get; set; }
        ///<summary>
        /// Precio por sucursal
        /// </summary>
        public int Stock { get; set; }
        ///<summary>
        /// Nombre de la sucursal
        /// </summary>
        public string BranchOffice { get; set; }
    }
}