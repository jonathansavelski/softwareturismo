using grupo3.prototipos.CAI.Almacenes;
using grupo3.prototipos.CAI.Entidades;

namespace grupo3.prototipos.CAI.Módulos
{
    internal class ModuloProductos
    {
        public static List<VueloEnt> VuelosDisponibles = AlmacenVuelos.VuelosDisponibles;
        public static List<HotelEnt> HotelesDisponibles = AlmacenHoteles.HotelesDisponibles;

        public static void BuscarVuelos(string ciudadOrigen, string ciudadDestino, DateTime fechaDesde, DateTime fechaHasta, string tipoPasajero, ListView vuelosListView)
        {
            char TipoPasajeroChar;

            if (tipoPasajero.Equals("Adulto"))
            {
                TipoPasajeroChar = 'A';
            }
            else if (tipoPasajero.Equals("Menor"))
            {
                TipoPasajeroChar = 'M';
            }
            else
            {
                TipoPasajeroChar = 'I';
            }

            //Filtro
            List<VueloEnt> VuelosEncontrados = VuelosDisponibles.FindAll(vuelo =>
            string.Equals(vuelo.CiudadOrigenVuelo, ciudadOrigen, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(vuelo.CiudadDestinoVuelo, ciudadDestino, StringComparison.OrdinalIgnoreCase) &&
            vuelo.FechaSalidaVuelo > fechaDesde && vuelo.FechaSalidaVuelo < fechaHasta);

            if (VuelosEncontrados.Count == 0)
            {
                MessageBox.Show("No se encontraron vuelos con los filtros aplicados", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                foreach (var vuelo in VuelosEncontrados)
                {
                    for (int i = 0; i < vuelo.TarifaVuelo.Count; i++)
                    {
                        if (vuelo.TarifaVuelo[i].TipoDePasajeroVuelo.ToString() == TipoPasajeroChar.ToString() && vuelo.TarifaVuelo[i].DisponibilidadVuelo > 0)
                        {
                            //Agrego cada vuelo a una lista
                            var item = new ListViewItem();
                            item.Text = vuelo.CodigoVuelo;
                            item.SubItems.Add(vuelo.CiudadOrigenVuelo);
                            item.SubItems.Add(vuelo.CodigoOrigenVuelo); //implicitamente estoy agregando el subitem 1, no el 0.
                            item.SubItems.Add(vuelo.CiudadDestinoVuelo);
                            item.SubItems.Add(vuelo.CodigoDestinoVuelo);
                            item.SubItems.Add(vuelo.FechaSalidaVuelo.ToString("dd/MM/yyyy HH:mm:ss"));
                            item.SubItems.Add(vuelo.FechaArriboVuelo.ToString("dd/MM/yyyy HH:mm:ss"));
                            item.SubItems.Add(vuelo.TiempoDeVueloVuelo);
                            item.SubItems.Add(vuelo.AerolineaVuelo);

                            item.SubItems.Add(vuelo.TarifaVuelo[i].CodigoTarifa);
                            item.SubItems.Add(vuelo.TarifaVuelo[i].ClaseVuelo.ToString());
                            item.SubItems.Add(vuelo.TarifaVuelo[i].TipoDePasajeroVuelo.ToString());
                            item.SubItems.Add(vuelo.TarifaVuelo[i].PrecioVuelo.ToString());
                            item.SubItems.Add(vuelo.TarifaVuelo[i].DisponibilidadVuelo.ToString());
                            item.Tag = vuelo; // Tag = etiqueta. La propiedad Tag es de tipo object. En esta propiedad puedo guardar lo que quiera. Esto sirve para que podamos meter un dato en cada fila (que no se ve) y me sirve para identificarla en el resto del sistema. 

                            vuelosListView.Items.Add(item);
                        }
                    }
                }
            }
        }

        public static VueloEnt CargarVuelo(string codigoTarifa)
        {
            VueloEnt vuelo = VuelosDisponibles.Find(v => v.TarifaVuelo.Any(tarifa => tarifa.CodigoTarifa == codigoTarifa));

            return vuelo;
        }

        public static void BuscarHoteles(string ciudadHotel, DateTime fechaDesde, DateTime fechaHasta, int cantidadAdultos, int cantidadInfantes, int cantidadMenores, ListView listViewHoteles)
        {
            List<HotelEnt> HotelesEncontrados = HotelesDisponibles.FindAll(hotel =>
            hotel.DisponibilidadHotel.Any(disponibilidad => disponibilidad.MaximoAdultosHabitacion >= cantidadAdultos) &&
            hotel.DisponibilidadHotel.Any(disponibilidad => disponibilidad.MaximoInfantesHabitacion >= cantidadInfantes) &&
            hotel.DisponibilidadHotel.Any(disponibilidad => disponibilidad.MaximoMenoresHabitacion >= cantidadMenores) &&
            hotel.DisponibilidadHotel.Any(disponibilidad => disponibilidad.HabitacionesDisp.Any(habitaciones => habitaciones.Fecha >= fechaDesde) &&
            hotel.DisponibilidadHotel.Any(disponibilidad => disponibilidad.HabitacionesDisp.Any(habitaciones => habitaciones.Fecha <= fechaHasta) &&
            string.Equals(hotel.CiudadHotel, ciudadHotel, StringComparison.OrdinalIgnoreCase))));

            if (HotelesEncontrados.Count == 0)
            {
                MessageBox.Show("No se encontraron hoteles con los filtros aplicados.");
            }
            else
            {
                foreach (var hotel in HotelesEncontrados)
                {
                    for (int i = 0; i < hotel.DisponibilidadHotel.Count; i++)
                    {
                        if (hotel.DisponibilidadHotel[i].MaximoAdultosHabitacion >= cantidadAdultos &&
                            hotel.DisponibilidadHotel[i].MaximoMenoresHabitacion >= cantidadMenores &&
                            hotel.DisponibilidadHotel[i].MaximoInfantesHabitacion >= cantidadInfantes)
                        {
                            for (int j = 0; j < hotel.DisponibilidadHotel[i].HabitacionesDisp.Count; j++)
                            {
                                if (hotel.DisponibilidadHotel[i].HabitacionesDisp[j].CantidadHabitacionesDisponibles > 0)
                                {
                                    var item = new ListViewItem();
                                    item.Text = hotel.CodigoHotel;
                                    item.SubItems.Add(hotel.NombreHotel);
                                    item.SubItems.Add(hotel.CiudadHotel);
                                    item.SubItems.Add(hotel.DireccionHotel);
                                    item.SubItems.Add(hotel.CalificacionHotel.ToString());
                                    item.SubItems.Add(hotel.DisponibilidadHotel[i].NombreHabitacion);
                                    item.SubItems.Add(hotel.DisponibilidadHotel[i].TarifaPorDiaHabitacion.ToString("0.00"));
                                    item.SubItems.Add(hotel.DisponibilidadHotel[i].CapacidadTotalHabitacion.ToString());
                                    item.SubItems.Add(hotel.DisponibilidadHotel[i].MaximoAdultosHabitacion.ToString());
                                    item.SubItems.Add(hotel.DisponibilidadHotel[i].MaximoMenoresHabitacion.ToString());
                                    item.SubItems.Add(hotel.DisponibilidadHotel[i].MaximoInfantesHabitacion.ToString());
                                    item.SubItems.Add(hotel.DisponibilidadHotel[i].HabitacionesDisp[j].CodigoHabitacion);
                                    item.SubItems.Add(hotel.DisponibilidadHotel[i].HabitacionesDisp[j].Fecha.ToString("dd/MM/yyyy HH:mm:ss"));
                                    item.SubItems.Add(hotel.DisponibilidadHotel[i].HabitacionesDisp[j].CantidadHabitacionesDisponibles.ToString());
                                    item.Tag = hotel;

                                    listViewHoteles.Items.Add(item);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static HotelEnt CargarHotel(string codigoHabitacion)
        {
            HotelEnt hotel = HotelesDisponibles.FirstOrDefault(h => h.DisponibilidadHotel.Any(d => d.HabitacionesDisp.Any(hab => codigoHabitacion.Contains(hab.CodigoHabitacion))));

            return hotel;
        }

        public static void ReducirStockVuelos()
        {
            foreach (string codigo in ModuloItinerario.itinerarioSeleccionado.CodigosVuelosAgregados)
            {
                VueloEnt vuelo = CargarVuelo(codigo);

                for (int i = 0; i < vuelo.TarifaVuelo.Count; i++)
                {
                    if (vuelo.TarifaVuelo[i].CodigoTarifa == codigo)
                    {
                        vuelo.TarifaVuelo[i].DisponibilidadVuelo -= 1;
                    }
                }

                // Encuentra el índice del vuelo en la lista VuelosDisponibles
                int index = VuelosDisponibles.FindIndex(v => v.CodigoVuelo == vuelo.CodigoVuelo);

                // Actualiza la información en la lista
                if (index != -1)
                {
                    VuelosDisponibles[index] = vuelo;
                }
            }
            //Agrego la lista al json 
            AlmacenVuelos.Guardar(VuelosDisponibles);
        }

        public static void ReducirStockHoteles()
        {
            foreach (string codigo in ModuloItinerario.itinerarioSeleccionado.CodigosHotelesAgregados)
            {
                HotelEnt hotel = CargarHotel(codigo);

                for (int i = 0; i < hotel.DisponibilidadHotel.Count; i++)
                {
                    for (int j = 0; j < hotel.DisponibilidadHotel[i].HabitacionesDisp.Count; j++)
                    {
                        if (hotel.DisponibilidadHotel[i].HabitacionesDisp[j].CodigoHabitacion == codigo)
                        {
                            hotel.DisponibilidadHotel[i].HabitacionesDisp[j].CantidadHabitacionesDisponibles -= 1;
                        }
                    }
                }

                // Encuentra el índice del hotel en la lista HotelesDisponibles
                int index = HotelesDisponibles.FindIndex(h => h.CodigoHotel == hotel.CodigoHotel);

                // Actualiza la información en la lista
                if (index != -1)
                {
                    HotelesDisponibles[index] = hotel;
                }
            }
            //Agrego la lista al json 
            AlmacenHoteles.Guardar(HotelesDisponibles);
        }
    }
}
