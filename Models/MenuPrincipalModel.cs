using grupo3.prototipos.CAI.Módulos;

namespace grupo3.prototipos.CAI.Models
{
    internal class MenuPrincipalModel
    {
        public void GuardarItinerario() 
        {
            ModuloItinerario.GuardarItinerario();
        }

        public void RestablecerItinerario()
        {
            ModuloItinerario.RestablecerItinerario();
        }
    }
}
