using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project_API_2021.Model
{
    public class Champion
    {
        public int ID { get; set; }

        //Validation 
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Maximum length of name is 20 characters")]
        public string ChampionName { get; set; }
        //public string ChampionStory { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public string ChampionRole { get; set; }

        [Range(typeof(DateTime), "1/1/2006", "24/05/2022")]
        public DateTime ReleaseDate { get; set; }

        //Toegevoegd voor range, maar weet leeftijd niet
        /*[Range(0, 5000)]
        public int Age { get; set; }*/

        public int FactionId { get; set; }
        [ForeignKey("FactionId")]
        //[JsonIgnore]
        public Faction Faction { get; set; }
        //[JsonIgnore]
        public ICollection<ChampionItem> ChampionItem { get; set; }
    }

}
