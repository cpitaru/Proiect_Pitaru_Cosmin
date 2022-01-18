using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Pitaru_Cosmin.Models
{
    public class Furnizor
    {
        public int ID { get; set; }

        [Display(Name = "Nume furnizor")] 
        public string NumeFurnizor { get; set; }
        public ICollection<Ceai> Ceai { get; set; }
    }
}
