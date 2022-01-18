using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Pitaru_Cosmin.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        [Display(Name = "Nume categorie")] 
        public string NumeCategorie { get; set; }
        public ICollection<CategorieCeai> CategorieCeaiuri { get; set; }
    }
}
