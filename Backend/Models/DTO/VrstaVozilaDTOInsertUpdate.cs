using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTO
{
    public record VrstaVozilaDTOInsertUpdate(
        [Required(ErrorMessage = "Naziv obavezno")]
        string Naziv
        );
    
}
