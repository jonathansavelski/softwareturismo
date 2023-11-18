using grupo3.prototipos.CAI.Entidades;
using grupo3.prototipos.CAI.Módulos;
using System.Globalization;

namespace grupo3.prototipos.CAI.Models
{
    public class CrearItinerariosModel
    {
        public CrearItinerariosModel()
        {
        }

        public void CrearOCargarItinerario(Label label, GroupBox grp)
        {
            if (ModuloItinerario.itinerarioSeleccionado == null)
            {
                ItinerarioEnt nuevoItinerario = ModuloItinerario.GenerarItinerarioUnico();
                label.Text = Convert.ToString(nuevoItinerario.NumeroItinerario);
            }
            else
            {
                label.Text = Convert.ToString(ModuloItinerario.itinerarioSeleccionado.NumeroItinerario);

                if (ModuloItinerario.itinerarioSeleccionado.Estado != "Guardado")
                {
                    grp.Enabled = false;
                }
            }
        }

        public void CargarVuelo(ListView VuelosListView)
        {
            List<string> codigosTarifas = ModuloItinerario.itinerarioSeleccionado.CodigosVuelosAgregados;
            HashSet<VueloEnt> vuelos = new HashSet<VueloEnt>();

            if (codigosTarifas != null)
            {
                //Limpio la listview
                VuelosListView.Items.Clear();

                foreach (string codigoTarifa in codigosTarifas)
                {
                    vuelos.Add(ModuloProductos.CargarVuelo(codigoTarifa));
                }

                //Agrego items a la listView
                foreach (VueloEnt vuelo in vuelos)
                {
                    for (int i = 0; i < vuelo.TarifaVuelo.Count; i++)
                    {
                        string codigoTarifaActual = vuelo.TarifaVuelo[i].CodigoTarifa;

                        // Obtener la cantidad de veces que aparece el código de tarifa en la lista
                        int cantidad = codigosTarifas.Count(c => c == codigoTarifaActual);

                        if (codigosTarifas.Contains(vuelo.TarifaVuelo[i].CodigoTarifa))
                        {
                            for (int j = 0; j < cantidad; j++)
                            {
                                var item = new ListViewItem();

                                item.Text = vuelo.CodigoVuelo;
                                item.SubItems.Add(vuelo.CiudadOrigenVuelo);
                                item.SubItems.Add(vuelo.CodigoOrigenVuelo);
                                item.SubItems.Add(vuelo.CiudadDestinoVuelo);
                                item.SubItems.Add(vuelo.CodigoDestinoVuelo);
                                item.SubItems.Add(vuelo.FechaSalidaVuelo.ToString());
                                item.SubItems.Add(vuelo.FechaArriboVuelo.ToString());
                                item.SubItems.Add(vuelo.TiempoDeVueloVuelo);
                                item.SubItems.Add(vuelo.AerolineaVuelo);
                                item.SubItems.Add(vuelo.TarifaVuelo[i].CodigoTarifa);
                                item.SubItems.Add(vuelo.TarifaVuelo[i].ClaseVuelo.ToString());
                                item.SubItems.Add(vuelo.TarifaVuelo[i].TipoDePasajeroVuelo.ToString());
                                item.SubItems.Add(vuelo.TarifaVuelo[i].PrecioVuelo.ToString("N2")); //separa miles y dos decimales
                                item.SubItems.Add(vuelo.TarifaVuelo[i].DisponibilidadVuelo.ToString());

                                VuelosListView.Items.Add(item);
                            }
                        }
                       
                    }
                }
                
                VuelosListView.Enabled = true;
            }
        }

        public void CargarHotel(ListView HotelesListView)
        {
            List<string> codigosHabitaciones = ModuloItinerario.itinerarioSeleccionado.CodigosHotelesAgregados;
            HashSet<HotelEnt> hoteles = new HashSet<HotelEnt>(); //garantiza que no se agregan hoteles duplicados

            if (codigosHabitaciones != null)
            {
                //Limpio la listview
                HotelesListView.Items.Clear();

                foreach (string codigoHabitacion in codigosHabitaciones)
                {
                    hoteles.Add(ModuloProductos.CargarHotel(codigoHabitacion));
                }

                //Agrego items a la listView
                foreach (HotelEnt hotel in hoteles)
                {
                    for (int i = 0; i < hotel.DisponibilidadHotel.Count; i++)
                    {
                        for (int j = 0; j < hotel.DisponibilidadHotel[i].HabitacionesDisp.Count; j++)
                        {
                            string codigoTarifaActual = hotel.DisponibilidadHotel[i].HabitacionesDisp[j].CodigoHabitacion;

                            // Obtener la cantidad de veces que aparece el código de tarifa en la lista
                            int cantidad = codigosHabitaciones.Count(c => c == codigoTarifaActual);

                            if (codigosHabitaciones.Contains(hotel.DisponibilidadHotel[i].HabitacionesDisp[j].CodigoHabitacion))
                            {
                                for (int k = 0; k < cantidad; k++)
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
                                    item.SubItems.Add(hotel.DisponibilidadHotel[i].HabitacionesDisp[j].Fecha.ToString());
                                    item.SubItems.Add(hotel.DisponibilidadHotel[i].HabitacionesDisp[j].CantidadHabitacionesDisponibles.ToString());

                                    HotelesListView.Items.Add(item);
                                }
                            }
                        }
                    }
                }
                HotelesListView.Enabled = true;
            }
        }

        public void EliminarVuelo(ListView vuelosListView)
        {
            //Eliminación de lista
            ModuloItinerario.codigosTarifasVuelosAgregados.Remove(vuelosListView.SelectedItems[0].SubItems[9].Text);

            vuelosListView.Items.Remove(vuelosListView.SelectedItems[0]);

            MessageBox.Show("Se ha eliminado el vuelo seleccionado.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void EliminarHotel(ListView hotelesListView)
        {
            //Eliminación de lista
            ModuloItinerario.codigosHabitacionesHotelesAgregados.Remove(hotelesListView.SelectedItems[0].SubItems[11].Text);

            hotelesListView.Items.Remove(hotelesListView.SelectedItems[0]);

            MessageBox.Show("Se ha eliminado el vuelo seleccionado.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public VueloEnt CrearVuelo(ListViewItem selectedItem)
        {
            // Se recuperan los datos del vuelo del ListView
            string codigoVuelo = selectedItem.SubItems[0].Text;
            string ciudadOrigen = selectedItem.SubItems[1].Text;
            string aeropuertoOrigen = selectedItem.SubItems[2].Text;
            string ciudadDestino = selectedItem.SubItems[3].Text;
            string aeropuertoDestino = selectedItem.SubItems[4].Text;

            DateTime fechaSalida = DateTime.ParseExact(selectedItem.SubItems[5].Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime fechaArribo = DateTime.ParseExact(selectedItem.SubItems[6].Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            string tiempo = selectedItem.SubItems[7].Text;
            string aerolinea = selectedItem.SubItems[8].Text;
            string codigoTarifa = selectedItem.SubItems[9].Text;
            char clase = char.Parse(selectedItem.SubItems[10].Text);
            char tipoDePasajero = char.Parse(selectedItem.SubItems[11].Text);
            float precio = Convert.ToSingle(selectedItem.SubItems[12].Text);
            int disponibilidad = Convert.ToInt32(selectedItem.SubItems[13].Text);

            // Se crea el objeto Vuelo
            VueloEnt vueloSeleccionado = new VueloEnt
            {
                CodigoVuelo = codigoVuelo,
                CiudadOrigenVuelo = ciudadOrigen,
                CodigoOrigenVuelo = aeropuertoOrigen,
                CiudadDestinoVuelo = ciudadDestino,
                CodigoDestinoVuelo = aeropuertoDestino,
                FechaSalidaVuelo = fechaSalida,
                FechaArriboVuelo = fechaArribo,
                TiempoDeVueloVuelo = tiempo,
                AerolineaVuelo = aerolinea,
                TarifaVuelo = new List<TarifaVuelo>
                {
                    new TarifaVuelo
                    {
                        CodigoTarifa = codigoTarifa,
                        ClaseVuelo = clase,
                        TipoDePasajeroVuelo = tipoDePasajero,
                        PrecioVuelo = precio,
                        DisponibilidadVuelo = disponibilidad
                    }
                }
            };
            return vueloSeleccionado;
        }

        public void GuardarDatosParcialesVuelo(VueloEnt vuelo)
        {
            ModuloItinerario.vueloSeleccionado = vuelo;
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
            DateTime fecha = DateTime.ParseExact(selectedItem.SubItems[12].Text, "d/M/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
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

        public void GuardarDatosParcialesHotel(HotelEnt hotel)
        {
            ModuloItinerario.hotelSeleccionado = hotel;
        }

        public void CargarPasajero(ListView PasajerosListView, string TipoDeProducto)
        {
            List<Pasajero> pasajeros = ModuloItinerario.itinerarioSeleccionado.Pasajeros;

            if (pasajeros != null)
            {
                PasajerosListView.Items.Clear();
                PasajerosListView.Enabled = true;

                foreach (Pasajero pasajero in pasajeros)
                {
                    if (pasajero.TipoDeProducto == TipoDeProducto) { 

                        var item = new ListViewItem();

                        item.Text = pasajero.CodigoProducto;
                        item.SubItems.Add(pasajero.Nombre);
                        item.SubItems.Add(pasajero.Apellido);
                        item.SubItems.Add(pasajero.Dni.ToString());

                        DateTime fechaActual = DateTime.Now.Date;
                        int edad = fechaActual.Year - pasajero.FechaNacimiento.Year;
                        string tipoDePasajero = "";

                        if (edad >= 18)
                        {
                            tipoDePasajero = "Adulto";
                        }
                        else if (edad >= 2 && edad <= 17)
                        {
                            tipoDePasajero = "Menor";
                        }
                        else if (edad >= 0 && edad < 2)
                        {
                            tipoDePasajero = "Infante";
                        }

                        item.SubItems.Add(tipoDePasajero);

                        PasajerosListView.Items.Add(item);
                    }
                }         
            }
        }
 
        public void CopiarItinerario(Label NumeroItinerarioLabel)
        {
            Clipboard.SetText(NumeroItinerarioLabel.Text);
            MessageBox.Show("Número de itinerario copiado", "Copiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void EliminarPasajero(ListView pasajerosListView)
        {
            string codigo = pasajerosListView.SelectedItems[0].SubItems[0].Text;
            int DNI = Convert.ToInt32(pasajerosListView.SelectedItems[0].SubItems[3].Text);

            Pasajero pasajero = ModuloItinerario.pasajeros.Find(p => p.Dni == DNI && p.CodigoProducto == codigo);

            ModuloItinerario.pasajeros.Remove(pasajero);
            pasajerosListView.Items.Remove(pasajerosListView.SelectedItems[0]);
            MessageBox.Show("Se ha eliminado el pasajero seleccionado.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ResetearHotelesYVuelosSeleccionados()
        {
            ModuloItinerario.vueloSeleccionado = null; //Reseteo
            ModuloItinerario.hotelSeleccionado = null; //Reseteo
        }

        public void Cotizar(Label label)
        {
            double suma = ModuloItinerario.Cotizar();

            if (suma > 0)
            {
                label.Text = "El valor de la cotización es de $" + suma.ToString("N2");
            }
            else
            {
                label.Text = "";
            }
        }
    }
}