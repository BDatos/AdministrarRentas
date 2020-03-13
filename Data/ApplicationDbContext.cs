using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AdministarRenta.Models;

namespace AdministarRenta.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AdministarRenta.Models.Alquilado> Alquilado { get; set; }
        public DbSet<AdministarRenta.Models.Carro> Carro { get; set; }
        public DbSet<AdministarRenta.Models.Casa> Casa { get; set; }
        public DbSet<AdministarRenta.Models.Chofer> Chofer { get; set; }
        public DbSet<AdministarRenta.Models.Huesped> Huesped { get; set; }
        public DbSet<AdministarRenta.Models.Itinerario> Itinerario { get; set; }
        public DbSet<AdministarRenta.Models.Responsable> Responsable { get; set; }
        public DbSet<AdministarRenta.Models.ServicioPrestado> ServicioPrestado { get; set; }
        public DbSet<AdministarRenta.Models.Servicios> Servicios { get; set; }
        public DbSet<AdministarRenta.Models.Taxi> Taxi { get; set; }

    }
}
