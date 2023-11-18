using grupo3.prototipos.CAI.Entidades;
using grupo3.prototipos.CAI.Módulos;

namespace grupo3.prototipos.CAI.Models
{
    internal class BuscarItinerarioModel
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

        public ItinerarioEnt BuscarItinerario(string numeroItinerario, ListView itinerariosListView, Button RealizarPrereservaButton, Button RealizarReservaButton, Button ConfirmarReservaButton)
        {
            ItinerarioEnt itinerarioSeleccionado = ModuloItinerario.BuscarItinerario(numeroItinerario);

            if (itinerarioSeleccionado == null)
            {
                MessageBox.Show("No se encontraron itinerarios con el número ingresado.", "Itinerario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                itinerariosListView.Enabled = true;

                var item = new ListViewItem();
                item.Text = itinerarioSeleccionado.FechaCreacionItinerario.ToString("dd/MM/yyyy");
                item.SubItems.Add(itinerarioSeleccionado.Cotizacion.ToString("N2"));
                item.SubItems.Add(itinerarioSeleccionado.Estado);

                string pagoItinerario;

                if (itinerarioSeleccionado.Pago == true)
                {
                    pagoItinerario = "Sí";
                }
                else
                {
                    pagoItinerario = "No";
                }

                item.SubItems.Add(pagoItinerario.ToString());

                itinerariosListView.Items.Add(item);

                if (itinerarioSeleccionado.Estado == "Guardado")
                {
                    RealizarPrereservaButton.Enabled = true;
                    RealizarReservaButton.Enabled = false;
                    ConfirmarReservaButton.Enabled = false;
                }

                if (itinerarioSeleccionado.Estado == "Pre-reserva")
                {
                    RealizarPrereservaButton.Enabled = false;
                    RealizarReservaButton.Enabled = true;
                }

                if (itinerarioSeleccionado.Estado == "Reserva")
                {
                    RealizarPrereservaButton.Enabled = false;
                    RealizarReservaButton.Enabled = false;
                    ConfirmarReservaButton.Enabled = true;
                }

                if(itinerarioSeleccionado.Estado == "Confirmado")
                {
                    RealizarPrereservaButton.Enabled = false;
                    RealizarReservaButton.Enabled = false;
                    ConfirmarReservaButton.Enabled = false;
                }

                if (ChequearPago())
                {
                    if (itinerarioSeleccionado.Estado != "Reserva" && itinerarioSeleccionado.Estado != "Confirmado")
                    {
                        RealizarReservaButton.Enabled = true;
                    }                               
                }
            }
            return itinerarioSeleccionado;
        }

        public string ValidarPasajeros()
        {
            string errores = "";

            errores += ModuloItinerario.ValidarPasajerosVuelos();
            errores += ModuloItinerario.ValidarPasajerosHoteles();          

            return errores;
        }

        public void CambiarEstadoPrereservaItinerario()
        {
            ModuloItinerario.itinerarioSeleccionado.Estado = "Pre-reserva";
        }

        public void CambiarEstadoReservaItinerario()
        {
            if(ModuloItinerario.itinerarioSeleccionado.Pago == true)
            {
                ModuloItinerario.itinerarioSeleccionado.Estado = "Reserva";
                MessageBox.Show("Realizaste correctamente la reserva.", "Reserva completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Para realizar la reserva, debe estar confirmado el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CambiarEstadoConfirmacionReservaItinerario()
        {
            ModuloItinerario.itinerarioSeleccionado.Estado = "Confirmado";
        }

        public bool ChequearPago()
        {
            bool flag = false;

            if(ModuloItinerario.itinerarioSeleccionado.Pago)
            {
                flag = true;
            }
            return flag;
        }

        public void ReducirStock()
        {
            if (ModuloItinerario.itinerarioSeleccionado.CodigosVuelosAgregados != null)
            {
                ModuloProductos.ReducirStockVuelos();
            }
            if (ModuloItinerario.itinerarioSeleccionado.CodigosHotelesAgregados != null)
            {
                ModuloProductos.ReducirStockHoteles();
            }
        }
    }
}
