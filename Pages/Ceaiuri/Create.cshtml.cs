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
    public class CreateModel : PageModel
    {
        private readonly Proiect_Pitaru_Cosmin.Data.Proiect_Pitaru_CosminContext _context;

        public CreateModel(Proiect_Pitaru_Cosmin.Data.Proiect_Pitaru_CosminContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Ceai Ceai { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ceai.Add(Ceai);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
