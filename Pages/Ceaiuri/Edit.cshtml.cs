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
    public class EditModel : PageModel
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

            Ceai = await _context.Ceai.FirstOrDefaultAsync(m => m.ID == id);

            if (Ceai == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ceai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CeaiExists(Ceai.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CeaiExists(int id)
        {
            return _context.Ceai.Any(e => e.ID == id);
        }
    }
}
