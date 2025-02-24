using System.ComponentModel.DataAnnotations.Schema;
namespace Backend.Models
{
    public class Vozilo : Entitet
    {
        //[Column("VrstaVozilaSifra")]

        [ForeignKey("vrstaVozila")]
        public required VrstaVozila VrstaVozila { get; set; }

        //public int VrstaVozilaSifra { get; set; }

        //[Column("DobavljacSifra")]

        [ForeignKey("dobavljac")]
        public required Dobavljac Dobavljac { get; set; }

        //public int DobavljacSifra { get; set; }

        public string Marka { get; set; } = "";
        public string GodProizvodnje { get; set; } = "";
        public int PrijedeniKm { get; set; } 
        public decimal Cijena { get; set; }

        //[Column("KupacSifra")]

        [ForeignKey("kupac")]
        public required Kupac Kupac { get; set; } 
        
        //public int KupacSifra { get; set; }


    }
}
