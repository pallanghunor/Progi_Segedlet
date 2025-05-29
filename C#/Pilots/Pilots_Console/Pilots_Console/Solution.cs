using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pilots_Console
{
    public static class Solution
    {
        public static List<Pilot> pilots { get; set; } = Pilot.LoadFromJSON("pilots.json") ?? new();

        public static void SearchByName()
        {
            Console.Write("5.feladat: Adja meg egy név részletét: ");
            var inputName = Console.ReadLine();
            List<Pilot> sought = pilots.Where(
                p => p.first_name.ToLower().StartsWith(inputName.ToString().ToLower())
                || p.last_name.ToLower().StartsWith(inputName.ToString().ToLower())
            ).ToList();
            if(sought.Count == 0)
            {
                Console.WriteLine($"Nem található pilóta a „{inputName}” névrészlettel!");
                return;
            }
            else
            {
                sought.ForEach(p =>
                {
                    Console.WriteLine($"\t{p.id}\t{p.name}\t{p.birthdate.Replace('-', '.')} {p.gender}\t{p.nation}");
                });
            }
        }

        // Linq-val GroupBy nation és rendezés
        //public static Dictionary<string, Pilot[]>? groupPilotsByNationLinq() => pilots?
        //        .GroupBy(p => p.nation)
        //        .OrderBy(p => p.Key)
        //        .ToDictionary(g => g.Key, g => g.ToArray());

        public static void WritePilotsByNation()
        {
            try
            {
                Dictionary<string, List<Pilot>> pilotsByNation = new();
                pilots.OrderBy(p => p.nation).ToList().ForEach(p =>
                {
                    if (!pilotsByNation.ContainsKey(p.nation))
                        pilotsByNation[p.nation] = new List<Pilot>(){ p };
                    else
                    {
                        pilotsByNation[p.nation].Add(p);
                    }
                });
                using(StreamWriter sw = new("pilot_groups.txt"))
                {
                    foreach (var item in pilotsByNation)
                    {
                        sw.WriteLine($"{item.Key} ({item.Value.Count}) fő:");
                        item.Value.ForEach(p => {
                            sw.WriteLine($"\t{p.name} - {p.birthdate}");
                        });
                    }
                }
                Console.WriteLine("6.feladat: pilot_groups.txt sikeresen megírva!");
            }
            catch (Exception)
            {
                Console.WriteLine($"Hiba! Fájl írása sikertelen!");
                return;                
            }
        }
    }
}
