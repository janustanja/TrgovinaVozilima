
using Microsoft.EntityFrameworkCore;
using Backend.Models;

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



    }
}