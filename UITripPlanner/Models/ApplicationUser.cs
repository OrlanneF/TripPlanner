using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITripPlanner.Models
{
    public class ApplicationUser : IdentityUser
    {
       
        public string Nom { get; set; }
        
        //public List<Voyage> VoyagesEnPreparation {get;set;}
        

        
    }
}
