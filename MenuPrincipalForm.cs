using grupo3.prototipos.CAI.Models;

namespace grupo3.prototipos.CAI
{
    public partial class MenuPrincipalForm : Form
    {
        MenuPrincipalModel modelo;
        
        public MenuPrincipalForm()
        {
            InitializeComponent();
            modelo = new MenuPrincipalModel();
        }

        private void NuevoItinerarioBtn_Click(object sender, EventArgs e)
        {
            CrearItinerarioForm crearItinerario = new CrearItinerarioForm();
            crearItinerario.ShowDialog();
            modelo.GuardarItinerario();
            modelo.RestablecerItinerario();
        }

        private void BuscarItinerarioBtn_Click(object sender, EventArgs e)
        {
            BusquedaItinerarioForm buscarListaItinerarios = new BusquedaItinerarioForm();
            buscarListaItinerarios.ShowDialog();
            modelo.GuardarItinerario();
            modelo.RestablecerItinerario();
        }
    }
}
