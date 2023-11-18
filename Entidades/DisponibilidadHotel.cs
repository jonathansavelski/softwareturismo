
namespace grupo3.prototipos.CAI.Entidades
{
    public class DisponibilidadHotel
    {
        public string NombreHabitacion { get; set; } //Habitacion doble
        public float TarifaPorDiaHabitacion { get; set; }
        public int CapacidadTotalHabitacion { get; set; }
        public int MaximoAdultosHabitacion { get; set; }
        public int MaximoMenoresHabitacion { get; set; }
        public int MaximoInfantesHabitacion { get; set; }



        public List<HabitacionesHotel> HabitacionesDisp { get; set; }
    }
}
