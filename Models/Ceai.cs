using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Pitaru_Cosmin.Models
{
    public class Ceai
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Nume ceai")]
        public string Nume_ceai { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele producatorului trebuie sa fie de forma 'Prenume Nume'"), 
        Required, StringLength(50, MinimumLength = 3)]
        public string Producator { get; set; }

        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")] 
        public decimal Pret { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data ambalarii")]
        public DateTime DataAmbalarii { get; set; }

        public int FurnizorID { get; set; }
        public Furnizor Furnizor { get; set; }


        [Display(Name = "Categorii ceai")]
        public ICollection<CategorieCeai> CategoriiCeai { get; set; }
    }
}
