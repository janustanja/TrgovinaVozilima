using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTO
{
    public record VoziloDTOInsertUpdate(
        [Required(ErrorMessage = "VrstaVozila obavezno")]
        int VrstaVozilaSifra,
        [Required(ErrorMessage = "Dobavljac obavezno")]
        int DobavljacSifra,
        [Required(ErrorMessage = "Marka obavezno")]
        string Marka,
        [Required(ErrorMessage = "GodProizvodnje obavezno")]
        int GodProizvodnje,
        [Required(ErrorMessage = "PrijedeniKm obavezno")]
        int PrijedeniKm,
        [Required(ErrorMessage = "Cijena obavezno")]
        decimal Cijena,
        [Required(ErrorMessage = "Kupac obavezno")]
        int KupacSifra
        );
    
}
