using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITripPlanner.Models
{
    public class Activite
    {
        public string Nom { get; set; }
        public int IdActivite { get; set; }
        public string IdApiActivite { get; set; }
        public float Duree { get; set; }
        public int Creneau { get; set; }

        //public int CurrentIdVoyage { get; set; }
        //public Voyage Voyage { get; set; }
    }
}
