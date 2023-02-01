using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AntonellaCortes_PROGRESOFINAL.ACAPI
{
    public class Rootobject
    {
        public int id { get; set; }
        public string title { get; set; }
        public string thumbnail { get; set; }
        public string short_description { get; set; }
        public string game_url { get; set; }
        public string genre { get; set; }
        public string platform { get; set; }
        public string publisher { get; set; }
        public string developer { get; set; }
        public string release_date { get; set; }
        public string freetogame_profile_url { get; set; }
    }
}