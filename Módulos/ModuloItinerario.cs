using grupo3.prototipos.CAI.Almacenes;
using grupo3.prototipos.CAI.Entidades;
using System.Diagnostics.Eventing.Reader;
using System.Text;

namespace grupo3.prototipos.CAI.Módulos
{
    public class ModuloItinerario
    {
        public static ItinerarioEnt itinerarioSeleccionado;
        public static List<string> codigosTarifasVuelosAgregados = new List<string>();
        public static List<string> codigosHabitacionesHotelesAgregados = new List<string>();
        public static List<ItinerarioEnt> itinerarios = AlmacenItinerarios.itinerarios;
        public static List<Pasajero> pasajeros = new List<Pasajero>();
        public static double cotizacion;
        public static string estado;
        public static VueloEnt vueloSeleccionado;
        public static HotelEnt hotelSeleccionado;

        public ModuloItinerario()
        {
        }

        public static ItinerarioEnt GenerarItinerarioUnico()
        {
            Random random = new Random();
            string numeroItinerario;

            do
            {
                numeroItinerario = random.Next(00000000, 99999999).ToString(); // Generar un número aleatorio de 8 dígitos.
            } while (itinerarios.Any(i => i.NumeroItinerario == numeroItinerario));

            //Genero itinerario
            itinerarioSeleccionado = new ItinerarioEnt(numeroItinerario);
            estado = "Guardado";

            return itinerarioSeleccionado;
        }

        public static void GuardarVuelo(VueloEnt vuelo)
        {
            if(codigosTarifasVuelosAgregados == null)
            {
                codigosTarifasVuelosAgregados = new List<string>();
            }
            codigosTarifasVuelosAgregados.Add(vuelo.TarifaVuelo[0].CodigoTarifa);
            itinerarioSeleccionado.CodigosVuelosAgregados = codigosTarifasVuelosAgregados;
        }

        public static void GuardarHotel(HotelEnt hotel)
        {
            if(codigosHabitacionesHotelesAgregados == null)
            {
                codigosHabitacionesHotelesAgregados = new List<string>();
            }
            codigosHabitacionesHotelesAgregados.Add(hotel.DisponibilidadHotel[0].HabitacionesDisp[0].CodigoHabitacion);
            itinerarioSeleccionado.CodigosHotelesAgregados = codigosHabitacionesHotelesAgregados;
        }

        public static string ValidarTipoPasajeroVuelos(DateTime fecha, char tipoDePasajero)
        {
            string error = "";

            DateTime fechaActual = DateTime.Now.Date;
            int edad = fechaActual.Year - fecha.Year;
            char tipoP;

            if (edad >= 18)
            {
                tipoP = 'A';
            }
            else if (edad >= 2 && edad <= 17)
            {
                tipoP = 'M';
            }
            else if (edad >= 0 && edad < 2)
            {
                tipoP = 'I';
            }
            else
            {
                return error;
            }

            if (tipoDePasajero != tipoP)
            {
                if (tipoDePasajero.Equals('A'))
                {
                    error = $"La fecha de nacimiento no corresponde con la tarifa seleccionada. Debe agregar un pasajero adulto.";
                }
                if (tipoDePasajero.Equals('M'))
                {
                    error = $"La fecha de nacimiento no corresponde con la tarifa seleccionada. Debe agregar un pasajero menor.";
                }
                if (tipoDePasajero.Equals('I'))
                {
                    error = $"La fecha de nacimiento no corresponde con la tarifa seleccionada. Debe agregar un pasajero infante.";
                }
            }

            return error;
        }

        public static void GuardarPasajero(Pasajero pasajero)
        {
            pasajeros.Add(pasajero);
            
            itinerarioSeleccionado.Pasajeros = pasajeros;
        }

        public static void GuardarItinerario()
        {
            if (itinerarioSeleccionado != null)
            {
                itinerarioSeleccionado.CodigosVuelosAgregados = codigosTarifasVuelosAgregados;
                itinerarioSeleccionado.CodigosHotelesAgregados = codigosHabitacionesHotelesAgregados;
                itinerarioSeleccionado.Pasajeros = pasajeros;
                itinerarioSeleccionado.Estado = estado;

                if (!itinerarios.Contains(itinerarioSeleccionado))
                {
                    //Agrego itinerario a la lista de itinerarios
                    itinerarios.Add(itinerarioSeleccionado);
                }

                //Agrego la lista al json 
                AlmacenItinerarios.Guardar(itinerarios);
            }
        }

        public static void RestablecerItinerario()
        {
            itinerarioSeleccionado = null;
            codigosTarifasVuelosAgregados = null;
            codigosHabitacionesHotelesAgregados = null; 
            pasajeros = new List<Pasajero>();
        }

        public static ItinerarioEnt BuscarItinerario(string numeroItinerario)
        {
            itinerarioSeleccionado = itinerarios.Find(itinerarios => itinerarios.NumeroItinerario == numeroItinerario);

            if (itinerarioSeleccionado != null)
            {
                codigosTarifasVuelosAgregados = itinerarioSeleccionado.CodigosVuelosAgregados;
                codigosHabitacionesHotelesAgregados = itinerarioSeleccionado.CodigosHotelesAgregados;
                pasajeros = itinerarioSeleccionado.Pasajeros;
                estado = itinerarioSeleccionado.Estado;
                cotizacion = itinerarioSeleccionado.Cotizacion;
            }
            return itinerarioSeleccionado;
        }

        public static string ValidarPasajerosVuelos()
        {
            //codigos tarifas del itinerario: codigosTarifasVuelosAgregados; 
            //vuelo de una tarifa ModuloProductos.CargarVuelo(pasajero.CodigoProducto);
            //pasajeros: pasajeros (tiene codigo de producto).

            string error = "";

            //mas adultos que inf en cada vuelo

            //lista de vuelos del itinerario
            Dictionary<VueloEnt, List<Pasajero>> vuelosItinerario = new();
            foreach (var codigoTarifa in codigosTarifasVuelosAgregados)
            {
                var vuelo = ModuloProductos.CargarVuelo(codigoTarifa);

                if (!vuelosItinerario.ContainsKey(vuelo))
                {
                    vuelosItinerario.Add(vuelo, new List<Pasajero>());

                    if (pasajeros != null)
                    {
                        foreach (var pasajero in pasajeros)
                        {
                            string primerasTresLetrasPasajero = pasajero.CodigoProducto.Substring(0, 3);
                            string primerasTresLetrasCodigoTarifa = codigoTarifa.Substring(0, 3);

                            if (primerasTresLetrasPasajero == primerasTresLetrasCodigoTarifa)
                            {
                                vuelosItinerario[vuelo].Add(pasajero);
                            }
                        }
                    }
                }
            }

            foreach (var vuelo in vuelosItinerario)
            {
                var adultos = 0;
                var menores = 0;
                var infantes = 0;

                foreach (var pasajero in vuelo.Value)
                {
                    if (pasajero.Edad >= 18)
                    {
                        adultos++;
                    }
                    else if (pasajero.Edad >= 2)
                    {
                        menores++;
                    }
                    else
                    {
                        infantes++;
                    }
                }

                if (adultos < (infantes + menores))
                {
                    error += $"Hay mas menores e infantes que adultos en el vuelo {vuelo.Key.CodigoVuelo}.\n";
                }
            }


            //que cada "tarifa" (asiento) tenga su pasajero.
            Dictionary<string, int> asientosPorTarifa = new();
            foreach (var codigoTarifa in codigosTarifasVuelosAgregados)
            {
                if (asientosPorTarifa.ContainsKey(codigoTarifa))
                {
                    asientosPorTarifa[codigoTarifa]++;
                }
                else
                {
                    asientosPorTarifa.Add(codigoTarifa, 1);
                }
            }

            Dictionary<string, int> pasajerosPorTarifa = new();
            if (pasajeros != null)
            {
                foreach (var pasajero in pasajeros)
                {
                    if (pasajero.TipoDeProducto == "Vuelo")
                    {
                        if (pasajerosPorTarifa.ContainsKey(pasajero.CodigoProducto))
                        {
                            pasajerosPorTarifa[pasajero.CodigoProducto]++;
                        }
                        else
                        {
                            pasajerosPorTarifa.Add(pasajero.CodigoProducto, 1);
                        }
                    }
                }
            }

            if (asientosPorTarifa.Count != pasajerosPorTarifa.Count)
            {
                error += "La cantidad de de asientos y pasajeros no coincide.\n";
            }

            foreach (var asientoTarifa in asientosPorTarifa)
            {
                if (!pasajerosPorTarifa.ContainsKey(asientoTarifa.Key))
                {
                    error += $"No hay pasajeros asignados para la tarifa {asientoTarifa.Key}.\n";
                    continue;
                }

                if (pasajerosPorTarifa[asientoTarifa.Key] != asientoTarifa.Value)
                {
                    error += $"Hay {asientoTarifa.Value} asientos reservados pero {pasajerosPorTarifa[asientoTarifa.Key]} pasajeros para la tarifa {asientoTarifa.Key}.\n";
                }
            }

            return error;
        }

        public static string ValidarPasajerosHoteles()
        {
            //pasajeros: cada uno tiene codigo de producto (habitacion).
            //1) Andres Panitsch "Doble" 25/11 
            //2) Andres Panitsch "Doble" 26/11
            //3) Andres Panitsch "Doble" 27/11
            //4) Andres Panitsch "Doble" 28/11

            //Codigos de habitaciones en el itinerario.
            //codigosHabitacionesHotelesAgregados

            //Me devuelve el hotel al que pertenece una habitacion
            //HotelEnt hotel = ModuloProductos.CargarHotel(codigoHabitacion);

            StringBuilder error = new StringBuilder();

            if (pasajeros != null)
            {
                foreach (var pasajero in pasajeros)
                {
                    if (pasajero.TipoDeProducto == "Hotel")
                    {
                        var ok = false;
                        foreach (var codigoHabitacion in codigosHabitacionesHotelesAgregados)
                        {
                            if (codigoHabitacion == pasajero.CodigoProducto)
                            {
                                ok = true;
                                break;
                            }
                        }

                        if (!ok)
                        {
                            error.AppendLine($"{pasajero.Apellido}, {pasajero.Nombre} está asignado al producto {pasajero.CodigoProducto}, que no se encuentra incluido en el itinerario");
                        }
                    }
                }
            }

            if (codigosHabitacionesHotelesAgregados != null)
            {
                foreach (var codigoHabitacion in codigosHabitacionesHotelesAgregados)
                {
                    int adultos = 0;
                    int men = 0;
                    int inf = 0;

                    if (pasajeros != null)
                    {
                        foreach (var pasajero in pasajeros)
                        {
                            if (pasajero.CodigoProducto == codigoHabitacion)
                            {
                                if (pasajero.Edad >= 18)
                                {
                                    adultos++;
                                }
                                else if (pasajero.Edad >= 2)
                                {
                                    men++;
                                }
                                else
                                {
                                    inf++;
                                }
                            }
                        }
                    }

                    if (adultos == 0)
                    {
                        error.AppendLine($"La habitación {codigoHabitacion} no tiene adultos asignados.");
                    }

                    HotelEnt hotel = ModuloProductos.CargarHotel(codigoHabitacion);
                    DisponibilidadHotel? habitacion = null;

                    foreach (var tipoHabitacion in hotel.DisponibilidadHotel)
                    {
                        foreach (var fechaHabitacion in tipoHabitacion.HabitacionesDisp)
                        {
                            if (fechaHabitacion.CodigoHabitacion == codigoHabitacion)
                            {
                                habitacion = tipoHabitacion;
                                break;
                            }
                        }

                        if (habitacion != null)
                        {
                            break;
                        }
                    }

                    if (habitacion == null)
                    {
                        error.AppendLine($"No se encuentra el codigo de producto (hotel) {codigoHabitacion}, ya asignado a un itinerario y a pasajeros.");
                    }
                    else
                    {
                        if (adultos > habitacion.MaximoAdultosHabitacion)
                        {
                            error.AppendLine($"Se ha superado la cantidad máxima de adultos ({habitacion.MaximoAdultosHabitacion}) para el producto {codigoHabitacion}");
                        }

                        if (men > habitacion.MaximoMenoresHabitacion)
                        {
                            error.AppendLine($"Se ha superado la cantidad máxima de menores ({habitacion.MaximoMenoresHabitacion}) para el producto {codigoHabitacion}");
                        }

                        if (inf > habitacion.MaximoInfantesHabitacion)
                        {
                            error.AppendLine($"Se ha superado la cantidad máxima de infantes ({habitacion.MaximoInfantesHabitacion}) para el producto {codigoHabitacion}");
                        }
                    }
                }
            }

            return error.ToString();
        }

        public static double Cotizar()
        {
            double suma = 0;

            if (codigosTarifasVuelosAgregados != null)
            {
                foreach (string codigo in codigosTarifasVuelosAgregados)
                {
                    VueloEnt vuelo = ModuloProductos.CargarVuelo(codigo);

                    for (int i = 0; i < vuelo.TarifaVuelo.Count; i++)
                    {
                        if (vuelo.TarifaVuelo[i].CodigoTarifa == codigo)
                        {
                            suma += vuelo.TarifaVuelo[i].PrecioVuelo;
                        }
                    }
                }
            }

            if (codigosHabitacionesHotelesAgregados != null)
            {
                foreach (string codigo in codigosHabitacionesHotelesAgregados)
                {
                    HotelEnt hotel = ModuloProductos.CargarHotel(codigo);

                    for (int i = 0; i < hotel.DisponibilidadHotel.Count; i++)
                    {
                        for (int j = 0; j < hotel.DisponibilidadHotel[i].HabitacionesDisp.Count; j++)
                        {
                            if (hotel.DisponibilidadHotel[i].HabitacionesDisp[j].CodigoHabitacion == codigo)
                            {
                                suma += hotel.DisponibilidadHotel[i].TarifaPorDiaHabitacion;
                            }
                        }
                    }
                }
            }

            itinerarioSeleccionado.Cotizacion = suma;

            return suma;
        }
    }
}
