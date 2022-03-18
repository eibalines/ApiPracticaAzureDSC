using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPracticaAzureDSC.Models;

namespace ApiPracticaAzureDSC.Data
{
    public class SeriesContext: DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options) : base(options) { }
        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Serie> Series { get; set; }
    }
}
