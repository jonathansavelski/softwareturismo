using grupo3.prototipos.CAI.Entidades;
using grupo3.prototipos.CAI.Models;

namespace grupo3.prototipos.CAI
{
    public partial class AgregarPasajeroForm : Form
    {
        AgregarPasajeroModel modelo;

        public AgregarPasajeroForm()
        {
            InitializeComponent();
        }

        private void AgregarPasajeroForm_Load(object sender, EventArgs e)
        {
            modelo = new AgregarPasajeroModel();
        }

        private void DNIPersonaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Cancela la pulsación de la tecla, lo que impide que se ingrese el carácter no deseado.
                e.Handled = true;
            }

            // Verifica si el texto en el TextBox alcanza la longitud máxima (9 dígitos)
            if (DNIPersonaTextBox.Text.Length >= 8 && e.KeyChar != (char)Keys.Back)
            {
                // Cancela la pulsación de la tecla si se alcanzó la longitud máxima.
                e.Handled = true;
            }
        }

        private void AgregarPersonaButton_Click(object sender, EventArgs e)
        {
            string nombre = NombrePersonaTextBox.Text;
            string apellido = ApellidoPersonaTextBox.Text;
            string dni = DNIPersonaTextBox.Text;
            DateTime fecha = dtpFechaNacimiento.Value.Date;

            string errores = "";

            errores += modelo.ValidarVacio(nombre, "Nombre");
            errores += modelo.ValidarVacio(apellido, "Apellido");
            errores += modelo.ValidarVacio(dni, "DNI");
            errores += modelo.ValidarFecha(fecha);

            if (!string.IsNullOrEmpty(errores))
            {
                MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                VueloEnt vueloSeleccionado = modelo.ObtenerDatosParcialesVuelo();
                HotelEnt hotelSeleccionado = modelo.ObtenerDatosParcialesHotel();

                //if (tipoDeProducto == "Vuelo")
                if(vueloSeleccionado != null)
                {
                    string error = modelo.ValidarTipoPasajero(fecha, vueloSeleccionado.TarifaVuelo[0].TipoDePasajeroVuelo);

                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        // Si no hay errores, agrega a la persona
                        Pasajero p = new Pasajero();
                        p.Nombre = NombrePersonaTextBox.Text;
                        p.Apellido = ApellidoPersonaTextBox.Text;
                        p.Dni = Convert.ToInt32(DNIPersonaTextBox.Text);
                        p.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                        p.TipoDeProducto = "Vuelo";
                        p.CodigoProducto = vueloSeleccionado.TarifaVuelo[0].CodigoTarifa;

                        modelo.GuardarPasajero(p);                      
                        this.Close();
                    }
                }

                //Si tipoDeProducto == "Hotel"
                if (hotelSeleccionado != null)
                {
                    Pasajero p = new Pasajero();
                    p.Nombre = NombrePersonaTextBox.Text;
                    p.Apellido = ApellidoPersonaTextBox.Text;
                    p.Dni = Convert.ToInt32(DNIPersonaTextBox.Text);
                    p.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                    p.TipoDeProducto = "Hotel";
                    p.CodigoProducto = hotelSeleccionado.DisponibilidadHotel[0].HabitacionesDisp[0].CodigoHabitacion;

                    modelo.GuardarPasajero(p);
                    this.Close();                  
                }

                vueloSeleccionado = null; //Limpio el valor
                hotelSeleccionado = null; //Limpio el valor
            }
        }

        private void CancelarAgregarPersonaButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
