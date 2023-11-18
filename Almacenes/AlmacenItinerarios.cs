using grupo3.prototipos.CAI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace grupo3.prototipos.CAI.Almacenes
{
    static class AlmacenItinerarios
    {
        public static List<ItinerarioEnt> itinerarios;
        private static string path = "itinerarios.json";

        static AlmacenItinerarios()
        {
            string contenidoDelArchivo = File.ReadAllText(path);
            itinerarios = JsonSerializer.Deserialize<List<ItinerarioEnt>>(contenidoDelArchivo);
        }
 
        public static void Guardar(List<ItinerarioEnt> itinerarios)
        {
            string json = JsonSerializer.Serialize(itinerarios);
            File.WriteAllText(path, json);
        }
    }
}
