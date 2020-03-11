using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITripPlanner.Models
{
    public class Preference
    {
        public int IdPreference { get; set; }
        public string IdApiPreference { get; set; }
        public float Poids { get; set; }
        public string Nom { get; set; }


        //public int CurrentIdVoyage { get; set; }
        //public Voyage Voyage {get;set ;}
    }
}
