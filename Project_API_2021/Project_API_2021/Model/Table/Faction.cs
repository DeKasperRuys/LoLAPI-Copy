using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project_API_2021.Model
{
    public class Faction
    {
        public int ID { get; set; }
        public string FactionName { get; set; }
        public string FactionDesciption { get; set; }

        //[JsonIgnore]
       // public ICollection<Champion> Champions { get; set; }
    }

}
