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

        [Display(Name = "Nume ceai")]
        public string Nume_ceai { get; set; }
        public string Producator { get; set; }
        
        [Column(TypeName = "decimal(6, 2)")] 
        public decimal Pret { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data ambalarii")]
        public DateTime DataAmbalarii { get; set; }
    }
}
