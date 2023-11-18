using grupo3.prototipos.CAI.Entidades;
using grupo3.prototipos.CAI.Módulos;
using System.Globalization;

namespace grupo3.prototipos.CAI.Models
{
    class HotelesModel
    {
        public HotelesModel()
        {
        }

        public string ValidarVacio(string valor, string campo)
        {
            string error = "";

            if (string.IsNullOrEmpty(valor))
            {
                error = "El campo " + campo + " no puede estar vacío." + "\n";
            }
            return error;
        }

        public string ValidarFechaDesde(DateTime fecha)
        {
            string error = "";

            if (fecha < DateTime.Now.Date)
            {
                error = "La fecha no debe ser anterior a hoy." + "\n";
            }
            return error;
        }

        public string ValidarFechaHasta(DateTime fechaDesde, DateTime fechaHasta)
        {
            string error = "";

            if (fechaHasta < fechaDesde)
            {
                error = "El rango de fechas es incorrecto." + "\n";
            }
            return error;
        }

        public HotelEnt CrearHotel(ListViewItem selectedItem)
        {
            // Recuperar los datos del hotel del ListView
            string codigoHotel = selectedItem.SubItems[0].Text;
            string nombreHotel = selectedItem.SubItems[1].Text;
            string codigoCiudadHotel = selectedItem.SubItems[2].Text;
            string direccionHotel = selectedItem.SubItems[3].Text;
            int calificacionHotel = Convert.ToInt32(selectedItem.SubItems[4].Text);

            string nombreHabitacion = selectedItem.SubItems[5].Text;
            float tarifaPorDiaHabitacion = Convert.ToSingle(selectedItem.SubItems[6].Text);
            int capacidadTotalHabitacion = Convert.ToInt32(selectedItem.SubItems[7].Text);
            int maximoAdultosHabitacion = Convert.ToInt32(selectedItem.SubItems[8].Text);
            int maximoMenoresHabitacion = Convert.ToInt32(selectedItem.SubItems[9].Text);
            int maximoInfantesHabitacion = Convert.ToInt32(selectedItem.SubItems[10].Text);
            string codigoHabitacion = selectedItem.SubItems[11].Text;
            DateTime fecha = DateTime.ParseExact(selectedItem.SubItems[12].Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            int cantidadHabitacionesDisponibles = Convert.ToInt32(selectedItem.SubItems[13].Text);

            // Crear el objeto Hotel
            HotelEnt hotelSeleccionado = new HotelEnt
            {
                CodigoHotel = codigoHotel,
                NombreHotel = nombreHotel,
                CiudadHotel = codigoCiudadHotel,
                DireccionHotel = direccionHotel,
                CalificacionHotel = calificacionHotel,
                DisponibilidadHotel = new List<DisponibilidadHotel>
                {
                    new DisponibilidadHotel
                    {
                        NombreHabitacion = nombreHabitacion,
                        TarifaPorDiaHabitacion = tarifaPorDiaHabitacion,
                        CapacidadTotalHabitacion = capacidadTotalHabitacion,
                        MaximoAdultosHabitacion = maximoAdultosHabitacion,
                        MaximoMenoresHabitacion = maximoMenoresHabitacion,
                        MaximoInfantesHabitacion = maximoInfantesHabitacion,
                        HabitacionesDisp = new List<HabitacionesHotel>
                        {
                            new HabitacionesHotel
                            {
                                CodigoHabitacion = codigoHabitacion,
                                Fecha = fecha,
                                CantidadHabitacionesDisponibles = cantidadHabitacionesDisponibles
                            }
                        }
                    }
                }
            };
            return hotelSeleccionado;
        }

        public void BuscarHoteles(string ciudad, DateTime fechaDesde, DateTime fechaHasta, int cantidadAdultos, int cantidadMenores, int cantidadInfantes, ListView HotelesListView)
        {
            ModuloProductos.BuscarHoteles(ciudad, fechaDesde, fechaHasta, cantidadAdultos, cantidadMenores, cantidadInfantes, HotelesListView);
        }

        public void GuardarHotel(HotelEnt hotel)
        {
            ModuloItinerario.GuardarHotel(hotel);
        }
    }
}
