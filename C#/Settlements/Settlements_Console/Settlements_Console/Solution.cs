using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Settlements_Console
{
    public static class Solution
    {
        public static List<Settlement>? Settlements { get; set; } = Settlement.LoadFromJSON("settlements.json");

        public static void FileWrite()
        {
            try
            {
                StreamWriter sw = new StreamWriter("settlements_groups.txt");
                List<string?> countynames = Settlements.Select(x => x.countyname).Distinct().Order().ToList();
                foreach (string cName in countynames)
                {
                    int regionNum = Settlements.Where(x => x.countyname == cName).Select(x => x.region).Distinct().Count();
                    sw.WriteLine($"{cName} megye - régiók száma: {regionNum}");
                    foreach (var s in Settlements)
                    {
                        if (s.countyname == cName)
                            sw.WriteLine($"\t{s.name}");
                    }
                }
                sw.Close();
                Console.WriteLine("6.feladat:\n\tFájl írása sikeres!");
            }
            catch (Exception)
            {
                Console.WriteLine("Hiba a fájl írása során!");
            }

        }

        public static string GetCountyMin()
        {
            int minPop = Int32.MaxValue;
            double minArea = Int32.MaxValue;
            string minStr = "";
            List<string?> countyNames = Settlements.Select(x => x.countyname).Distinct().ToList();
            foreach (var cName in countyNames)
            {
                int actPop = Settlements.Where(x => x.countyname == cName).Sum(x => x.population);
                double actAreaSize = Settlements.Where(x => x.countyname == cName).Sum(x => x.areasize);
                if(minPop > actPop)
                {
                    minPop = actPop;
                    minArea = actAreaSize;
                    minStr = cName;
                }
            }
            return $"Legkevesebben {minStr} megyében laknak ({minPop} fő), melynek területe {minArea:f2} km2";
        }

        public static string GetCountyMinDict()
        {
            Dictionary<string, MinSearchHelper> stat = new Dictionary<string, MinSearchHelper>();
            foreach (var s in Settlements)
            {
                if (stat.ContainsKey(s.countyname))
                {
                    stat[s.countyname].SumPopulation += s.population;
                    stat[s.countyname].SumAreaSize += s.areasize;
                }
                else
                {
                    stat.Add(s.countyname, new MinSearchHelper() { SumAreaSize = s.areasize, SumPopulation = s.population, CountyName = s.countyname});
                }
            }
            MinSearchHelper min = new MinSearchHelper() {SumPopulation = Int32.MaxValue};
            foreach (var item in stat)
            {
                if(item.Value.SumPopulation < min.SumPopulation)
                {
                    min.SumPopulation = item.Value.SumPopulation;
                    min.CountyName = item.Key;
                    min.SumAreaSize = item.Value.SumAreaSize;
                }
            }
            return $"Legkevesebben {min.CountyName} megyében laknak ({min.SumPopulation} fő), melynek területe {min.SumAreaSize:f2} km2";
        }

    }
}
