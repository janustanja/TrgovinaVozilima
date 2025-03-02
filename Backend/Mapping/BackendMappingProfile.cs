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

            CreateMap<Vozilo, Vozilo>()
              .ForCtorParam(
                  "VrstaVozilaSifra",
                  opt => opt.MapFrom(src => src.VrstaVozila.Sifra)
              );
            CreateMap<Vozilo, VoziloDTOInsertUpdate>().ForMember(
                    dest => dest.VrstaVozilaSifra,
                    opt => opt.MapFrom(src => src.VrstaVozila.Sifra)
                );
            CreateMap<VoziloDTOInsertUpdate, Vozilo>();



        }
    }
}
