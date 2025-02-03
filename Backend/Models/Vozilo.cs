using System.ComponentModel.DataAnnotations.Schema;
namespace Backend.Models
{
    public class Vozilo : Entitet
    {
        //[Column("VrstaVozilaSifra")]
        
        public VrstaVozila VrstaVozila { get; set; }
        [ForeignKey("VrstaVozilaSifra")]
        public int VrstaVozilaSifra { get; set; }

        //[Column("DobavljacSifra")]
        
        public Dobavljac Dobavljac { get; set; }
        [ForeignKey("DobavljacSifra")]
        public int DobavljacSifra { get; set; }

        public string Marka { get; set; }
        public string GodProizvodnje { get; set; }
        public int PrijedeniKm { get; set; }
        public decimal Cijena { get; set; }

        //[Column("KupacSifra")]
        
        public Kupac Kupac { get; set; }
        [ForeignKey("KupacSifra")]
        public int KupacSifra { get; set; }
    }
}
