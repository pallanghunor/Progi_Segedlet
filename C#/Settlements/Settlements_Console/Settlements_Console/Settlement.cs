using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Settlements_Console
{

    public class Settlement
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? countyname { get; set; }
        public string? region { get; set; }
        public int population { get; set; }
        public double areasize { get; set; }

        public static List<Settlement>? LoadFromJSON(string fileName)
        {
            string jsonStr = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Settlement>>(jsonStr);
        }

    }

}
