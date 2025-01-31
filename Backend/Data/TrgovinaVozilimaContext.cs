
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace TrgovinaVozilima.Data
{
    public class TrgovinaVozilimaContext : DbContext
    {
        public TrgovinaVozilimaContext(DbContextOptions<TrgovinaVozilimaContext> options) : base(options)
        {

        }
        public DbSet<VrstaVozila> VrsteVozila { get; set; }


    }
}