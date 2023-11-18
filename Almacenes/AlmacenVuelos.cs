using grupo3.prototipos.CAI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace grupo3.prototipos.CAI.Almacenes
{
    static class AlmacenVuelos
    {
        public static List<VueloEnt> VuelosDisponibles;
        static string path = "vuelos.json";

        static AlmacenVuelos()
        {
            string contenidoDelArchivo = File.ReadAllText(path);
            VuelosDisponibles = JsonSerializer.Deserialize<List<VueloEnt>>(contenidoDelArchivo);
        }

        public static void Guardar(List<VueloEnt> vuelos)
        {
            string json = JsonSerializer.Serialize(vuelos);
            File.WriteAllText(path, json);
        }
    }
       
}
