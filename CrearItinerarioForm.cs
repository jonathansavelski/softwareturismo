using grupo3.prototipos.CAI.Entidades;
using grupo3.prototipos.CAI.Models;

namespace grupo3.prototipos.CAI
{
    public partial class CrearItinerarioForm : Form
    {
        private CrearItinerariosModel modelo;

        public CrearItinerarioForm()
        {
            InitializeComponent();
        }

        private void CrearItinerario_Load(object sender, EventArgs e)
        {
            modelo = new CrearItinerariosModel();

            modelo.CrearOCargarItinerario(NumeroItinerarioLabel, grpItinerario);

            ValorDeLaCotizacionLabel.Text = "";
            VuelosListView.Enabled = false;
            HotelesListView.Enabled = false;
            EliminarVueloButton.Enabled = false;
            EliminarHotelButton.Enabled = false;
            AgregarPasajeroVueloButton.Enabled = false;
            AgregarPasajeroHotelButton.Enabled = false;
            PasajerosHotelesListView.Enabled = false;
            PasajerosVuelosListView.Enabled = false;
            EliminarPasajeroVueloButton.Enabled = false;
            EliminarPasajeroHotelButton.Enabled = false;

            CargarFormulario();
        }

        private void CargarFormulario()
        {
            modelo.CargarVuelo(VuelosListView);
            modelo.CargarHotel(HotelesListView);
            modelo.Cotizar(ValorDeLaCotizacionLabel);
            modelo.CargarPasajero(PasajerosVuelosListView, "Vuelo");
            modelo.CargarPasajero(PasajerosHotelesListView, "Hotel");
        }

        private void ConsultaDisponibilidadVuelosBtn_Click(object sender, EventArgs e)
        {
            VuelosForm vuelosForm = new VuelosForm();
            vuelosForm.ShowDialog();

            CargarFormulario();
        }

        private void ConsultaDisponibilidadHotelesBtn_Click(object sender, EventArgs e)
        {
            HotelesForm hotelesForm = new HotelesForm();
            hotelesForm.ShowDialog();

            CargarFormulario();
        }

        private void VuelosListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VuelosListView.SelectedItems.Count > 0)
            {
                EliminarVueloButton.Enabled = true;
                AgregarPasajeroVueloButton.Enabled = true;

                for (int i = 0; i < VuelosListView.SelectedItems.Count; i++)
                {
                    ListViewItem selectedItem = VuelosListView.SelectedItems[i];
                    AgregarPasajeroVueloButton.Text = $"Agregar pasajero al vuelo {selectedItem.SubItems[9].Text}";
                }

                EliminarPasajeroVueloButton.Enabled = false;

                if (PasajerosVuelosListView.SelectedItems.Count > 0)
                {
                    PasajerosVuelosListView.SelectedItems[0].Selected = false; // Restablece elemento seleccionado
                }
            }
            else
            {
                AgregarPasajeroVueloButton.Text = "Agregar pasajero";
                EliminarVueloButton.Enabled = false;
                AgregarPasajeroVueloButton.Enabled = false;
            }

        }

        private void HotelesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HotelesListView.SelectedItems.Count > 0)
            {

                EliminarHotelButton.Enabled = true;
                AgregarPasajeroHotelButton.Enabled = true;

                for (int i = 0; i < HotelesListView.SelectedItems.Count; i++)
                {
                    ListViewItem selectedItem = HotelesListView.SelectedItems[i];
                    AgregarPasajeroHotelButton.Text = $"Agregar pasajero a la habitación {selectedItem.SubItems[11].Text}";
                }

                EliminarPasajeroHotelButton.Enabled = false;

                if (PasajerosHotelesListView.SelectedItems.Count > 0)
                {
                    PasajerosHotelesListView.SelectedItems[0].Selected = false; // Restablece elemento seleccionado
                }
            }
            else
            {
                AgregarPasajeroHotelButton.Text = "Agregar pasajero";
                EliminarHotelButton.Enabled = false;
                AgregarPasajeroHotelButton.Enabled = false;
            }
        }

        private void CopiarNumeroItinerario_Click(object sender, EventArgs e)
        {
            modelo.CopiarItinerario(NumeroItinerarioLabel);
        }

        private void EliminarVueloButton_Click(object sender, EventArgs e)
        {
            modelo.EliminarVuelo(VuelosListView);

            EliminarVueloButton.Enabled = false;

            //inhabilitar agregar pasajero
            AgregarPasajeroVueloButton.Enabled = false;
            AgregarPasajeroVueloButton.Text = "Agregar pasajero";

            CargarFormulario();
        }

        private void EliminarHotelButton_Click(object sender, EventArgs e)
        {
            modelo.EliminarHotel(HotelesListView);

            EliminarHotelButton.Enabled = false;

            //inhabilitar agregar pasajero
            AgregarPasajeroHotelButton.Enabled = false;
            AgregarPasajeroHotelButton.Text = "Agregar pasajero";

            CargarFormulario();
        }

        private void AgregarPasajeroVueloButton_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = VuelosListView.SelectedItems[0];
            VueloEnt vueloSeleccionado = modelo.CrearVuelo(selectedItem);

            modelo.GuardarDatosParcialesVuelo(vueloSeleccionado);

            AgregarPasajeroForm agregarPasajero = new AgregarPasajeroForm();
            agregarPasajero.ShowDialog();

            modelo.ResetearHotelesYVuelosSeleccionados();
            modelo.CargarPasajero(PasajerosVuelosListView, "Vuelo");

            AgregarPasajeroVueloButton.Text = "Agregar pasajero";
            AgregarPasajeroVueloButton.Enabled = false;

            if (VuelosListView.SelectedItems.Count > 0)
            {
                VuelosListView.SelectedItems[0].Selected = false; // Restablece elemento seleccionado
            }
        }

        private void AgregarPasajeroHotelButton_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = HotelesListView.SelectedItems[0];
            HotelEnt hotelSeleccionado = modelo.CrearHotel(selectedItem);

            modelo.GuardarDatosParcialesHotel(hotelSeleccionado);

            AgregarPasajeroForm agregarPasajero = new AgregarPasajeroForm();
            agregarPasajero.ShowDialog();

            modelo.ResetearHotelesYVuelosSeleccionados();

            modelo.CargarPasajero(PasajerosHotelesListView, "Hotel");

            AgregarPasajeroHotelButton.Text = "Agregar pasajero";
            AgregarPasajeroHotelButton.Enabled = false;

            if (HotelesListView.SelectedItems.Count > 0)
            {
                HotelesListView.SelectedItems[0].Selected = false; // Restablece elemento seleccionado
            }
        }

        private void PasajerosVuelosListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PasajerosVuelosListView.SelectedItems.Count > 0)
            {

                EliminarPasajeroVueloButton.Enabled = true;
                AgregarPasajeroVueloButton.Text = "Agregar pasajero";
                AgregarPasajeroVueloButton.Enabled = false;

                if (VuelosListView.SelectedItems.Count > 0)
                {
                    VuelosListView.SelectedItems[0].Selected = false; // Restablece elemento seleccionado
                }
            }
        }

        private void EliminarPasajeroVueloButton_Click(object sender, EventArgs e)
        {
            modelo.EliminarPasajero(PasajerosVuelosListView);
        }

        private void PasajerosHotelesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PasajerosHotelesListView.SelectedItems.Count > 0)
            {
                EliminarPasajeroHotelButton.Enabled = true;
                AgregarPasajeroHotelButton.Text = "Agregar pasajero";
                AgregarPasajeroHotelButton.Enabled = false;

                if (HotelesListView.SelectedItems.Count > 0)
                {
                    HotelesListView.SelectedItems[0].Selected = false; // Restablece elemento seleccionado
                }
            }
        }

        private void EliminarPasajeroHotelButton_Click(object sender, EventArgs e)
        {
            modelo.EliminarPasajero(PasajerosHotelesListView);
        }
    }
}