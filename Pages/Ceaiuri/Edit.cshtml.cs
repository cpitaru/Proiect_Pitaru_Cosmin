using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Pitaru_Cosmin.Data;
using Proiect_Pitaru_Cosmin.Models;

namespace Proiect_Pitaru_Cosmin.Pages.Ceaiuri
{
    public class EditModel : CategoriiCeaiPageModel
    {
        private readonly Proiect_Pitaru_Cosmin.Data.Proiect_Pitaru_CosminContext _context;

        public EditModel(Proiect_Pitaru_Cosmin.Data.Proiect_Pitaru_CosminContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ceai Ceai { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            Ceai = await _context.Ceai
                .Include(b => b.Furnizor)
                .Include(b => b.CategoriiCeai).ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Ceai == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Ceai);

            ViewData["FurnizorID"] = new SelectList(_context.Set<Furnizor>(), "ID", "NumeFurnizor");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ceaiToUpdate = await _context.Ceai
            .Include(i => i.Furnizor)
            .Include(i => i.CategoriiCeai)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (ceaiToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Ceai>(
            ceaiToUpdate,
            "Ceai",
            i => i.Nume_ceai, i => i.Producator,
            i => i.Pret, i => i.DataAmbalarii, i => i.Furnizor))
            {
                UpdateCeaiCategories(_context, selectedCategories, ceaiToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateCeaiCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateCeaiCategories(_context, selectedCategories, ceaiToUpdate);
            PopulateAssignedCategoryData(_context, ceaiToUpdate);
            return Page();
        }


        private bool CeaiExists(int id)
        {
            return _context.Ceai.Any(e => e.ID == id);
        }
    }
}
