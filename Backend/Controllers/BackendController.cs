using AutoMapper;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    public abstract class BackendController : ControllerBase
    {

       
        protected readonly TrgovinaVozilimaContext _context;

        protected readonly IMapper _mapper;


      
        public BackendController(TrgovinaVozilimaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

    }
}
