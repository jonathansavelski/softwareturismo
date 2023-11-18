
namespace grupo3.prototipos.CAI.Entidades
{
    public class ItinerarioEnt
    {
        public string NumeroItinerario { get; set; }
        public DateTime FechaCreacionItinerario { get; set; }
        public List<string> CodigosVuelosAgregados { get; set; }
        public List<string> CodigosHotelesAgregados { get; set; }
        public List <Pasajero> Pasajeros { get; set; }
        public double Cotizacion { get; set; }
        public string Estado { get; set; }
        public bool Pago { get; set; }

        public ItinerarioEnt(string Numero)
        {
            this.NumeroItinerario = Numero;
            this.FechaCreacionItinerario = DateTime.Now;
            this.Pago = false;
        }
        public ItinerarioEnt()
        {
            this.FechaCreacionItinerario = DateTime.Now;
        }
    }   
}
 