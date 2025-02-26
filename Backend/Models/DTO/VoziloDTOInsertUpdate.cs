using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTO
{
    public record VoziloDTOInsertUpdate(
        [Required(ErrorMessage = "VrstaVozila obavezno")]
        int VrstaVozila,
        [Required(ErrorMessage = "Dobavljac obavezno")]
        int Dobavljac,
        [Required(ErrorMessage = "Marka obavezno")]
        string Marka,
        [Required(ErrorMessage = "GodProizvodnje obavezno")]
        int GodProizvodnje,
        [Required(ErrorMessage = "PrijedeniKm obavezno")]
        int PrijedniKm,
        [Required(ErrorMessage = "Cijena obavezno")]
        decimal Cijena,
        [Required(ErrorMessage = "Kupac obavezno")]
        int Kupac
        );
    
}
