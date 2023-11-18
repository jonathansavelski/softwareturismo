using grupo3.prototipos.CAI.Entidades;
using grupo3.prototipos.CAI.Models;

namespace grupo3.prototipos.CAI
{
    public partial class BusquedaItinerarioForm : Form
    {
        BuscarItinerarioModel modelo;

        public BusquedaItinerarioForm()
        {
            InitializeComponent();
        }

        private void BusquedaItinerarioForm_Load(object sender, EventArgs e)
        {
            modelo = new BuscarItinerarioModel();

            ItinerarioListView.Enabled = false;
            VerDetallesBtn.Enabled = false;
            RealizarPrereservaButton.Enabled = false;
            RealizarReservaButton.Enabled = false;
            ConfirmarReservaButton.Enabled = false;
        }

        private void txtBuscarItinerario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BuscarItinerarioBtn_Click(object sender, EventArgs e)
        {
            string numeroItinerario = txtBuscarItinerario.Text;
            string errores = "";

            errores += modelo.ValidarVacio(numeroItinerario, "Número Itinerario");

            if (!string.IsNullOrEmpty(errores))
            {
                MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                ItinerarioListView.Items.Clear();

                ItinerarioEnt itinerario = modelo.BuscarItinerario(numeroItinerario, ItinerarioListView, RealizarPrereservaButton, RealizarReservaButton, ConfirmarReservaButton);

                if (itinerario != null)
                {
                    VerDetallesBtn.Enabled = true;
                }
                else
                {
                    VerDetallesBtn.Enabled = false;
                }
            }
        }

        private void VerDetallesBtn_Click(object sender, EventArgs e)
        {
            CrearItinerarioForm crearItinerarioForm = new CrearItinerarioForm();
            crearItinerarioForm.ShowDialog();

            //Recargar form
            ItinerarioListView.Items.Clear();
            ItinerarioEnt itinerario = modelo.BuscarItinerario(txtBuscarItinerario.Text, ItinerarioListView, RealizarPrereservaButton, RealizarReservaButton, ConfirmarReservaButton);
        }

        private void RealizarPrereservaButton_Click(object sender, EventArgs e)
        {
            string errores = "";

            errores += modelo.ValidarPasajeros();

            if (!string.IsNullOrEmpty(errores))
            {
                MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                //Reducción de stock
                modelo.ReducirStock();

                //Cambio de status
                modelo.CambiarEstadoPrereservaItinerario();

                DateTime fecha = DateTime.Now.AddHours(48);
                MessageBox.Show($"Realizaste correctamente la pre-reserva. Será válida hasta el {fecha.ToString("dd/MM/yyyy HH:mm")}hs.", "Pre-reserva confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Recargar form
                ItinerarioListView.Items.Clear();
                ItinerarioEnt itinerario = modelo.BuscarItinerario(txtBuscarItinerario.Text, ItinerarioListView, RealizarPrereservaButton, RealizarReservaButton, ConfirmarReservaButton);
            }
        }

        private void RealizarReservaButton_Click(object sender, EventArgs e)
        {
            //Cambio de status
            modelo.CambiarEstadoReservaItinerario();

            //Recargar form
            ItinerarioListView.Items.Clear();
            ItinerarioEnt itinerario = modelo.BuscarItinerario(txtBuscarItinerario.Text, ItinerarioListView, RealizarPrereservaButton, RealizarReservaButton, ConfirmarReservaButton);
        }

        private void ConfirmarReservaButton_Click(object sender, EventArgs e)
        {
            //Cambio de status
            modelo.CambiarEstadoConfirmacionReservaItinerario();

            MessageBox.Show("Se confirmó la reserva.","Reserva confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Recargar form
            ItinerarioListView.Items.Clear();
            ItinerarioEnt itinerario = modelo.BuscarItinerario(txtBuscarItinerario.Text, ItinerarioListView, RealizarPrereservaButton, RealizarReservaButton, ConfirmarReservaButton);
        }
    }
}