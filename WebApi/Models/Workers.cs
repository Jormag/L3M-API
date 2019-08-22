namespace WebApi.Models
{
    ///<summary>
    ///Entidad encargada de representar los trabajadores
    ///</summary>
    public class Worker
    {
        ///<summary>
        ///Numero de cedula del trabajador
        ///</summary>
        public string IdentificationCard { get; set; }
        ///<summary>
        ///Nombre del trabajador
        ///</summary>
        public string Name { get; set; }
        ///<summary>
        ///Fecha de nacimiento
        ///</summary>
        public string BirthDate { get; set; }
        ///<summary>
        ///Fecha de ingreso
        ///</summary>
        public string AdmissionDate { get; set; }
        ///<summary>
        ///Sucursar en la que trabaja
        ///</summary>
        public string BranchOffice { get; set; }
        ///<summary>
        ///Salario por hora
        ///</summary>
        public int HourlyWage { get; set; }
        ///<summary>
        ///Rol del trabajador
        ///</summary>
        public string Rol { get; set; }
    }
}