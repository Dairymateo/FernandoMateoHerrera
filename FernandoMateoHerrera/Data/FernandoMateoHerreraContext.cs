using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FernandoMateoHerrera.Models;

namespace FernandoMateoHerrera.Data
{
    public class FernandoMateoHerreraContext : DbContext
    {
        public FernandoMateoHerreraContext (DbContextOptions<FernandoMateoHerreraContext> options)
            : base(options)
        {
        }

        public DbSet<FernandoMateoHerrera.Models.Carrera> Carrera { get; set; } = default!;
        public DbSet<FernandoMateoHerrera.Models.MHerrera> MHerrera { get; set; } = default!;
    }
}
