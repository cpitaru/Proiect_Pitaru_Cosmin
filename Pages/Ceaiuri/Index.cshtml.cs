﻿using System;
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

        public async Task OnGetAsync()
        {
            Ceai = await _context.Ceai
                .Include(b => b.Furnizor)
                .ToListAsync();
        }
    }
}
