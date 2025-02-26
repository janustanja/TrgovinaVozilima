namespace Backend.Models.DTO
{
    public record VoziloDTORead(
        int Sifra,
        int VrstaVozila,
        int Dobavljac,
        string Marka,
        int GodProizvodnje,
        int PrijedeniKm,
        decimal Cijena,
        int Kupac
        );
    
}
