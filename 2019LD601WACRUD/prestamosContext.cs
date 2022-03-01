using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2019LD601WACRUD.Model;
using Microsoft.EntityFrameworkCore;

namespace _2019LD601WACRUD
{
    public class prestamosContext : DbContext
    {
        public prestamosContext(DbContextOptions<prestamosContext> options) : base(options)
        {

        }

        public DbSet<equipos> equipos { get; set; }

        public DbSet<estados_equipo> estados_equipo { get; set; }
        public DbSet<marcas> marcas { get; set; }
        public DbSet<tipo_equipo> tipo_equipo { get; set; }
}
}
