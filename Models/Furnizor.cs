using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Pitaru_Cosmin.Models
{
    public class Furnizor
    {
        public int ID { get; set; }
        public string NumeFurnizor { get; set; }
        public ICollection<Ceai> Ceai { get; set; }
    }
}
