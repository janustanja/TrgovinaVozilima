using System.ComponentModel.DataAnnotations.Schema;
namespace Backend.Models
{
    public class Kupac : Entitet
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Iban { get; set; }

        public ICollection<Vozilo> Vozila { get; }
    }
}
