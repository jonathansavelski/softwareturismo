using grupo3.prototipos.CAI.Entidades;
using grupo3.prototipos.CAI.Models;

namespace grupo3.prototipos.CAI
{
    public partial class HotelesForm : Form
    {
        HotelesModel modelo;

        public HotelesForm()
        {
            InitializeComponent();
        }

        private void HotelesForm_Load(object sender, EventArgs e)
        {
            modelo = new HotelesModel();
            HotelesDisponiblesGroupBox.Enabled = false;
        }

        private void BuscarHotelButton_Click(object sender, EventArgs e)
        {
            string ciudadHotel = txtOrigenHotel.Text;
            DateTime fechaDesde = dtpInicioHotel.Value.Date;
            DateTime fechaHasta = dtpFinHotel.Value.Date;
            int cantidadAdultos = (int)nudAdultoHotel.Value;
            int cantidadInfantes = (int)nudInfanteHotel.Value;
            int cantidadMenores = (int)nudMenorHotel.Value;

            string errores = "";

            errores += modelo.ValidarVacio(ciudadHotel, "Ciudad");
            errores += modelo.ValidarFechaDesde(fechaDesde);
            errores += modelo.ValidarFechaHasta(fechaDesde, fechaHasta);

            if (!string.IsNullOrEmpty(errores))
            {
                MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                AñadirAlItinerarioHotelesButton.Enabled = false;

                HotelesListView.Items.Clear();
                modelo.BuscarHoteles(ciudadHotel, fechaDesde, fechaHasta, cantidadAdultos, cantidadMenores, cantidadInfantes, HotelesListView);

                if (HotelesListView.Items.Count > 0)
                {
                    HotelesDisponiblesGroupBox.Enabled = true;
                }
            }
        }

        private void HotelesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cuando se selecciona un item del List View
            AñadirAlItinerarioHotelesButton.Enabled = true;
        }

        private void AñadirAlItinerarioHotelButton_Click(object sender, EventArgs e)
        {
            if (HotelesListView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in HotelesListView.SelectedItems)
                {
                    HotelEnt hotelSeleccionado = modelo.CrearHotel(selectedItem);
                    modelo.GuardarHotel(hotelSeleccionado);
                }

                MessageBox.Show($"Se ha añadido correctamente al itinerario.", "Itinerario añadido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
