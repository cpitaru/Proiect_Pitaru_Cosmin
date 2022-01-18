using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Pitaru_Cosmin.Models
{
    public class CategorieCeai
    {
        public int ID { get; set; }
        public int CeaiID { get; set; }
        public Ceai Ceai { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
