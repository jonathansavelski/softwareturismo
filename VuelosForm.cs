using grupo3.prototipos.CAI.Entidades;
using grupo3.prototipos.CAI.Models;

namespace grupo3.prototipos.CAI
{
    public partial class VuelosForm : Form
    {
        VuelosModel modelo;

        public VuelosForm()
        {
            InitializeComponent();
        }

        private void VuelosForm_Load(object sender, EventArgs e)
        {

            modelo = new VuelosModel();
            VuelosDisponiblesGroupBox.Enabled = false;
        }

        private void BuscarVuelosButton_Click(object sender, EventArgs e)
        {
            string ciudadOrigenVuelo = CiudadOrigenVueloTextBox.Text;
            string ciudadDestinoVuelo = CiudadDestinoVueloTextBox.Text;
            DateTime fechaDesde = RangoDesdeVueloDateTimePicker.Value.Date;
            DateTime fechaHasta = RangoHastaVueloDateTimePicker.Value.Date;
            string tipoPasajero = TipoPasajeroVueloComboBox.Text;

            string errores = "";

            errores += modelo.ValidarVacio(ciudadOrigenVuelo, "Lugar de origen");
            errores += modelo.ValidarVacio(ciudadDestinoVuelo, "Lugar de destino");
            errores += modelo.ValidarFechaDesde(fechaDesde);
            errores += modelo.ValidarFechaHasta(fechaDesde, fechaHasta);
            errores += modelo.ValidarVacio(tipoPasajero, "Tipo de pasajero");

            if (!string.IsNullOrEmpty(errores))
            {
                MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                AñadirAlItinerarioVueloButton.Enabled = false;

                VuelosListView.Items.Clear();
                modelo.BuscarVuelos(ciudadOrigenVuelo, ciudadDestinoVuelo, fechaDesde, fechaHasta, tipoPasajero, VuelosListView);

                if (VuelosListView.Items.Count > 0)
                {
                    VuelosDisponiblesGroupBox.Enabled = true;
                }
            }
        }

        private void VuelosListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cuando se selecciona un item del List View
            AñadirAlItinerarioVueloButton.Enabled = true;
        }

        private void AñadirAlItinerarioVueloButton_Click(object sender, EventArgs e)
        {
            if (VuelosListView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in VuelosListView.SelectedItems)
                {
                    VueloEnt vueloSeleccionado = modelo.CrearVuelo(selectedItem);
                    modelo.GuardarVuelo(vueloSeleccionado);
                }
            }
            MessageBox.Show($"Se ha añadido correctamente al itinerario.", "Itinerario añadido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}