namespace WebApi.Models
{
    ///<summary>
    /// Entidad que representa una Sucursal
    /// </summary>
    public class BranchOffice
    {
        ///<summary>
        /// Nombre de la sucursal
        /// </summary>
        public string Name { get; set; }
        ///<summary>
        /// Direccion de la Sucursal
        /// </summary>
        public string Address { get; set; }
        ///<summary>
        /// Numero telefonico de la Sucursal
        /// </summary>
        public string Phone { get; set; }
        ///<summary>
        /// Nombre del administrador a cargo de la Sucursal
        /// </summary>
        public string Administrator { get; set; }
    }
}