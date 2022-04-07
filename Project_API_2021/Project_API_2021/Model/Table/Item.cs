using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project_API_2021.Model
{
    public class Item
    {
        public int ID { get; set; }
        [Required]
        public string ItemName { get; set; }
        //[JsonIgnore]
        public ICollection<ChampionItem> ChampionItem { get; set; }
    }
}
