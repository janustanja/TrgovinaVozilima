namespace Backend.Models.DTO
{
    public record VoziloDTORead(
        int Sifra,
        int VrstaVozilaNaziv,
        int DobavljacNaziv,
        string Marka,
        int GodProizvodnje,
        int PrijedeniKm,
        decimal Cijena,
        int KupacIme
        );
    
}
