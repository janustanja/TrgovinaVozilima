using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Dobavljac :Entitet
    {
        public string Naziv { get; set; } = "";
        public string Adresa { get; set; }
        public string Iban { get; set; }
    }
}
