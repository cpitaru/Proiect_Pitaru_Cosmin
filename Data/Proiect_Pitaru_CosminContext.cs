using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Pitaru_Cosmin.Models;

namespace Proiect_Pitaru_Cosmin.Data
{
    public class Proiect_Pitaru_CosminContext : DbContext
    {
        public Proiect_Pitaru_CosminContext (DbContextOptions<Proiect_Pitaru_CosminContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Pitaru_Cosmin.Models.Ceai> Ceai { get; set; }

        public DbSet<Proiect_Pitaru_Cosmin.Models.Furnizor> Furnizor { get; set; }
    }
}
