using AutoMapper;
using Backend.Models;
using Backend.Models.DTO;
using System.Text.RegularExpressions;

namespace Backend.Mapping
{
    public class BackendMappingProfile: Profile
    {
        public BackendMappingProfile()
        {
            CreateMap<VrstaVozila, VrstaVozilaDTORead>();
            CreateMap<VrstaVozilaDTOInsertUpdate, VrstaVozila>();
            CreateMap<VrstaVozila, VrstaVozilaDTOInsertUpdate>();

            CreateMap<Kupac, KupacDTORead>();
            CreateMap<KupacDTOInsertUpdate, Kupac>();
            CreateMap<Kupac, KupacDTOInsertUpdate>();

            CreateMap<Dobavljac, DobavljacDTORead>();
            CreateMap<DobavljacDTOInsertUpdate, Dobavljac>();
            CreateMap<Dobavljac, DobavljacDTOInsertUpdate>();

            CreateMap<Vozilo, VoziloDTORead>()
              .ForCtorParam(
                  "VrstaVozilaNaziv",
                  opt => opt.MapFrom(src => src.VrstaVozila.Naziv)
              ).ForCtorParam(
                  "DobavljacNaziv",
                  opt => opt.MapFrom(src => src.Dobavljac.Naziv)
              ).ForCtorParam(
                  "KupacIme",
                  opt => opt.MapFrom(src => src.Kupac.Ime + " " + src.Kupac.Prezime)
              );
            CreateMap<Vozilo, VoziloDTOInsertUpdate>().ForMember(
                    dest => dest.VrstaVozilaSifra,
                    opt => opt.MapFrom(src => src.VrstaVozila.Sifra)
                ).ForMember(
                    dest => dest.DobavljacSifra,
                    opt => opt.MapFrom(src => src.Dobavljac.Sifra)
                ).ForMember(
                    dest => dest.KupacSifra,
                    opt => opt.MapFrom(src => src.Kupac.Sifra)
                );
            CreateMap<VoziloDTOInsertUpdate, Vozilo>();



        }
    }
}
