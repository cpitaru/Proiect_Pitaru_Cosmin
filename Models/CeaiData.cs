using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Pitaru_Cosmin.Models
{
    public class CeaiData
    {
        public IEnumerable<Ceai> Ceaiuri { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieCeai> CategoriiCeai { get; set; }
    }
}
