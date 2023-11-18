using grupo3.prototipos.CAI.Entidades;
using grupo3.prototipos.CAI.Módulos;

namespace grupo3.prototipos.CAI.Models
{
    internal class AgregarPasajeroModel
    {
        public string ValidarVacio(string valor, string campo)
        {
            string error = "";

            if (string.IsNullOrEmpty(valor))
            {
                error = "El campo " + campo + " no puede estar vacío." + "\n";
            }
            return error;
        }

        public string ValidarFecha(DateTime fecha)
        {
            string error = "";

            if (fecha > DateTime.Now.Date)
            {
                error = "La fecha de nacimiento no puede ser posterior a hoy." + "\n";
            }
            return error;
        }

        public string ValidarTipoPasajero(DateTime fecha, char tipoDePasajero)
        {
            string error = ModuloItinerario.ValidarTipoPasajeroVuelos(fecha, tipoDePasajero);
            return error;
        }

        public VueloEnt ObtenerDatosParcialesVuelo()
        {
            VueloEnt vuelo = ModuloItinerario.vueloSeleccionado;
            return vuelo;
        }

        public HotelEnt ObtenerDatosParcialesHotel()
        {
            HotelEnt hotel = ModuloItinerario.hotelSeleccionado;
            return hotel;
        }

        public void GuardarPasajero(Pasajero pasajero)
        {
            ModuloItinerario.GuardarPasajero(pasajero);
        }
    }
}
