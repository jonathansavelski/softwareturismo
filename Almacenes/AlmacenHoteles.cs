using grupo3.prototipos.CAI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace grupo3.prototipos.CAI.Almacenes
{
    static class AlmacenHoteles
    {
        public static List<HotelEnt> HotelesDisponibles;
        static string path = "hoteles.json";

        static AlmacenHoteles()
        {
            string contenidoDelArchivo = File.ReadAllText(path);
            HotelesDisponibles = JsonSerializer.Deserialize<List<HotelEnt>>(contenidoDelArchivo);
        }

        public static void Guardar(List<HotelEnt> hoteles)
        {
            string json = JsonSerializer.Serialize(hoteles);
            File.WriteAllText(path, json);
        }
    }
}
