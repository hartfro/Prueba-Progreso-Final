using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableAttribute = SQLite.TableAttribute;
using MaxLengthAttribute = SQLite.MaxLengthAttribute;

namespace AntonellaCortes_PROGRESOFINAL.ACModels
{
    [Table("game")]
    public class ACGame // registro de recomendaciones de juego
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime Date { get; set; } // automático sistema
        public string UserName { get; set; } // ingresa el usuario
        //public string Review { get; set; } // ingresa el usuario
        public string title { get; set; }
        //public string thumbnail { get; set; }
        public string short_description { get; set; }
        //public string game_url { get; set; }
        public string genre { get; set; }
        public string platform { get; set; }
        public string publisher { get; set; }
        public string developer { get; set; }
        public string release_date { get; set; }
        //public string freetogame_profile_url { get; set; }
    }
}
