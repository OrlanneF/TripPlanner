using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITripPlanner.Models
{
    public class Voyage
    {
        public string Id{ get; set; }
        public string Nom { get; set; }
        public ApplicationUser MyUser { get; set; }
        //    public string Destination   { get; set; }
        //    public DateTime Debut { get; set; }
        //    public DateTime Fin { get; set; }
        //    public ICollection<ApplicationUser> Voyageurs { get; set; }
        //    public ICollection<Activite> LesActivites { get; set; }
        //    public ICollection<Preference> LesPreferences { get; set; }
    }
}
