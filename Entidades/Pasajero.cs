
namespace grupo3.prototipos.CAI.Entidades
{
    public class Pasajero
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoDeProducto { get; set; }
        public string CodigoProducto { get; set; }

        public int Edad
        {
            get
            {
                int edad = DateTime.Today.Year - FechaNacimiento.Year;

                // Verificar si ya pasó el cumpleaños de este año
                if (FechaNacimiento > DateTime.Today.AddYears(-edad))
                {
                    edad--;
                }

                return edad;
            }
        }
    }
}