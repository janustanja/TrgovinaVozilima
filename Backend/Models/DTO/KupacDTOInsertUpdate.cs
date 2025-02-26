using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTO
{
    public record KupacDTOInsertUpdate(
        [Required(ErrorMessage = "Ime obavezno")]
        string Ime,
        [Required(ErrorMessage = "Prezime obavezno")]
        string Prezime,
        [Required(ErrorMessage = "Adresa obavezno")]
        string Adresa,
        [Required(ErrorMessage = "Iban obavezno")]
        string Iban
        );
    
}
