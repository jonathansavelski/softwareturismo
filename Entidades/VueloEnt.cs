
namespace grupo3.prototipos.CAI.Entidades
{
    public class VueloEnt
    {
        public string CodigoVuelo { get; set; }
        public string CodigoOrigenVuelo { get; set; }
        public string CiudadOrigenVuelo { get; set; }
        public string CodigoDestinoVuelo { get; set; }
        public string CiudadDestinoVuelo { get; set; }
        public DateTime FechaSalidaVuelo { get; set; }
        public DateTime FechaArriboVuelo { get; set; }
        public string TiempoDeVueloVuelo { get; set; }
        public string AerolineaVuelo { get; set; }
        public List<TarifaVuelo> TarifaVuelo { get; set; }
    }
}