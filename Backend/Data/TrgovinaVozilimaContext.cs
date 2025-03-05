
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using System.Text.RegularExpressions;

namespace Backend.Data
{
    public class TrgovinaVozilimaContext : DbContext
    {
        public TrgovinaVozilimaContext(DbContextOptions<TrgovinaVozilimaContext> options) : base(options)
        {

        }
        public DbSet<VrstaVozila> VrsteVozila { get; set; }
        public DbSet <Dobavljac> Dobavljaci { get; set; }
        public DbSet<Kupac> Kupci { get; set; }
        public DbSet<Vozilo> Vozila { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vozilo>().HasOne(g => g.VrstaVozila);
            modelBuilder.Entity<Vozilo>().HasOne(g => g.Kupac);
            modelBuilder.Entity<Vozilo>().HasOne(g => g.Dobavljac);

            modelBuilder.Entity<Kupac>().HasMany(g => g.Vozila).WithOne(g => g.Kupac);
        }



    }
}