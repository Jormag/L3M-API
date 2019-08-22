namespace WebApi.Models
{
    ///<summary>
    ///Entidad encargada de los Registros de Horas
    ///</summary>
    public class HourRecord
    {
        ///<summary>
        ///Nombre del trabajador
        ///</summary>
        public string Name { get; set; }
        ///<summary>
        ///Fecha de Inicio de la semana de trabajo
        ///</summary>
        public string WeekBeginning { get; set; }
        ///<summary>
        ///Fecha de finalizacion de la semana de trabajo
        ///</summary>
        public string WeekEnd { get; set; }
        ///<summary>
        ///Cantidad de horas trabajadas
        ///</summary>
        public int WorkedHours { get; set; }
    }

}
