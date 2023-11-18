
namespace grupo3.prototipos.CAI.Entidades
{
    public class HotelEnt
    {
        public string CodigoHotel { get; set; }
        public string CiudadHotel { get; set; }
        public string NombreHotel { get; set; }
        public string DireccionHotel { get; set; }
        public int CalificacionHotel { get; set; }
        public List<DisponibilidadHotel> DisponibilidadHotel { get; set; }

        public HotelEnt() { }
    }
}
