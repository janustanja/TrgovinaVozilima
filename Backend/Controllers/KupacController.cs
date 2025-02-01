using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KupacController : ControllerBase
    {
        private readonly TrgovinaVozilimaContext _context;

        public KupacController(TrgovinaVozilimaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Kupci);

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
                var s = _context.Kupci.Find(sifra);
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
        public IActionResult Post(Kupac kupac)
        {
            try
            {
                _context.Kupci.Add(kupac);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, kupac);
            }
            catch (Exception e)
            {
                return BadRequest(new { poruka = e.Message });
            }

        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]

        public IActionResult Put(int sifra, Kupac kupac)
        {
            try
            {

                var s = _context.Kupci.Find(sifra);

                if (s == null)
                {
                    return NotFound();
                }

                s.Ime = kupac.Ime;
                s.Prezime = kupac.Prezime;
                s.Adresa = kupac.Adresa;
                s.Iban = kupac.Iban;

                _context.Kupci.Update(s);
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
                var s = _context.Kupci.Find(sifra);
                if (s == null)
                {
                    return NotFound();
                }
                _context.Kupci.Remove(s);
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
