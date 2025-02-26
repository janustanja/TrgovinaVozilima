using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTO
{
    public record DobavljacDTOInsertUpdate(
        [Required(ErrorMessage = "Naziv obavezno")]
        string Naziv,
        [Required(ErrorMessage = "Adresa obavezno")]
        string Adresa,
        [Required(ErrorMessage = "Iban obavezno")]
        string Iban
        );
    
}
