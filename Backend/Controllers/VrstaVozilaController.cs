using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VrstaVozilaController : ControllerBase
    {
        private readonly TrgovinaVozilimaContext _context;

        public VrstaVozilaController(TrgovinaVozilimaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.VrsteVozila);

            }
            catch (Exception e)
            {
                return BadRequest(new { poruka = e.Message });

            }
        }

        [HttpGet]
        [Route("{sifra:int}")]

        public IActionResult GetBySifra(int sifra)
        {
            try
            {
                var s = _context.VrsteVozila.Find(sifra);
                if (s == null)
                {
                    return NotFound();
                }
                return Ok(s);
            }
            catch (Exception e)
            {
                return BadRequest(new { poruka = e.Message });
            }
        }

        [HttpPost]
        public IActionResult Post(VrstaVozila vrstaVozila)
        {
            try
            {
                _context.VrsteVozila.Add(vrstaVozila);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, vrstaVozila);
            }
            catch (Exception e)
            {
                return BadRequest(new { poruka = e.Message });
            }

        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]

        public IActionResult Put(int sifra, VrstaVozila vrstaVozila)
        {
            try
            {

                var s = _context.VrsteVozila.Find(sifra);

                if (s == null)
                {
                    return NotFound();
                }

                s.Naziv = vrstaVozila.Naziv;

                _context.VrsteVozila.Update(s);
                _context.SaveChanges();
                return Ok(new { poruka = "Uspješno promijenjen podatak!" });
            }
            catch (Exception e)
            {
                return BadRequest(new { poruka = e.Message });
            }

        }
        [HttpDelete]
        [Route("{sifra:int}")]
        public IActionResult Delete(int sifra)
        {
            try
            {
                var s = _context.VrsteVozila.Find(sifra);
                if (s == null)
                {
                    return NotFound();
                }
                _context.VrsteVozila.Remove(s);
                _context.SaveChanges();
                return Ok(new { poruka = "Uspješno obrisano!" });
            }
            catch (Exception e)
            {
                return BadRequest(new { poruka = e.Message });
            }
        }
    }
}

