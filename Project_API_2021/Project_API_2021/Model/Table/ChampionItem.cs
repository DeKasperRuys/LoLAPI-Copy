using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_API_2021.Model
{
    public class ChampionItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //Joint class voor veel op veel relatie
        public int ChampionID { get; set; }

        public Champion Champion { get; set; }


        public int ItemID { get; set; }


        public Item Item { get; set; }
    }
}
