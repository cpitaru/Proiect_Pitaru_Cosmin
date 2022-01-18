using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Pitaru_Cosmin.Data;
using Proiect_Pitaru_Cosmin.Models;

namespace Proiect_Pitaru_Cosmin.Pages.Ceaiuri
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Pitaru_Cosmin.Data.Proiect_Pitaru_CosminContext _context;

        public IndexModel(Proiect_Pitaru_Cosmin.Data.Proiect_Pitaru_CosminContext context)
        {
            _context = context;
        }

        public IList<Ceai> Ceai { get;set; }

        public CeaiData CeaiD { get; set; }
        public int CeaiID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            CeaiD = new CeaiData();

            CeaiD.Ceaiuri = await _context.Ceai
            .Include(b => b.Furnizor)
            .Include(b => b.CategoriiCeai)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Nume_ceai)
            .ToListAsync();
            if (id != null)
            {
                CeaiID = id.Value;
                Ceai ceai = CeaiD.Ceaiuri
                .Where(i => i.ID == id.Value).Single();
                CeaiD.Categorii = ceai.CategoriiCeai.Select(s => s.Categorie);
            }
        }
    }
}
