using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Settlements_GUI.Models
{
    public class Settlement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountyId { get; set; }
        public County? County { get; set; }
        public string Region { get; set; }
        public int? Population { get; set; }
        public double? Areasize { get; set; }
    }
}
