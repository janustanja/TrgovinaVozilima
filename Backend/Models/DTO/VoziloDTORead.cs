namespace Backend.Models.DTO
{
    public record VoziloDTORead(
        int Sifra,
        string VrstaVozilaNaziv,
        string DobavljacNaziv,
        string Marka,
        int GodProizvodnje,
        int PrijedeniKm,
        decimal Cijena,
        string KupacIme
        );
    
}
