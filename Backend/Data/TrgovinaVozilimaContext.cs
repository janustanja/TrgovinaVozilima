
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


    }
}