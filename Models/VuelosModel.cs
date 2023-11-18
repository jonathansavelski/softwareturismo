using grupo3.prototipos.CAI.Entidades;
using grupo3.prototipos.CAI.Módulos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace grupo3.prototipos.CAI.Models
{
    internal class VuelosModel
    {
        public VuelosModel()
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

        public void BuscarVuelos(string ciudadOrigen, string ciudadDestino, DateTime fechaDesde, DateTime fechaHasta, string tipoPasajero, ListView VuelosListView)
        {
            ModuloProductos.BuscarVuelos(ciudadOrigen, ciudadDestino, fechaDesde, fechaHasta, tipoPasajero, VuelosListView);
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

        public void GuardarVuelo(VueloEnt vuelo)
        {
            ModuloItinerario.GuardarVuelo(vuelo);
        }  
    }
}