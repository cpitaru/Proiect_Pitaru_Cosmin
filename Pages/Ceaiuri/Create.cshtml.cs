using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Pitaru_Cosmin.Data;
using Proiect_Pitaru_Cosmin.Models;

namespace Proiect_Pitaru_Cosmin.Pages.Ceaiuri
{
    public class CreateModel : CategoriiCeaiPageModel
    {
        private readonly Proiect_Pitaru_Cosmin.Data.Proiect_Pitaru_CosminContext _context;

        public CreateModel(Proiect_Pitaru_Cosmin.Data.Proiect_Pitaru_CosminContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["FurnizorID"] = new SelectList(_context.Set<Furnizor>(), "ID", "NumeFurnizor");
            var ceai = new Ceai();
            ceai.CategoriiCeai = new List<CategorieCeai>();
            PopulateAssignedCategoryData(_context, ceai);
            return Page();
        }

        [BindProperty]
        public Ceai Ceai { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newCeai = new Ceai();
            if (selectedCategories != null)
            {
                newCeai.CategoriiCeai = new List<CategorieCeai>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategorieCeai
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newCeai.CategoriiCeai.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Ceai>(
            newCeai,
            "Ceai",
            i => i.Nume_ceai, i => i.Producator,
            i => i.Pret, i => i.DataAmbalarii, i => i.FurnizorID))
            {
                _context.Ceai.Add(newCeai);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newCeai);
            return Page();
        }
    }
}
