using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DobavljacController : ControllerBase
    {
        private readonly TrgovinaVozilimaContext _context;

        public DobavljacController(TrgovinaVozilimaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Dobavljaci);

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
                var s = _context.Dobavljaci.Find(sifra);
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
        public IActionResult Post(Dobavljac dobavljac)
        {
            try
            {
                _context.Dobavljaci.Add(dobavljac);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, dobavljac);
            }
            catch (Exception e)
            {
                return BadRequest(new { poruka = e.Message });
            }

        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]

        public IActionResult Put(int sifra, Dobavljac dobavljac)
        {
            try
            {

                var s = _context.Dobavljaci.Find(sifra);

                if (s == null)
                {
                    return NotFound();
                }

                s.Naziv = dobavljac.Naziv;
                s.Adresa = dobavljac.Adresa;
                s.Iban = dobavljac.Iban;

                _context.Dobavljaci.Update(s);
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
                var s = _context.Dobavljaci.Find(sifra);
                if (s == null)
                {
                    return NotFound();
                }
                _context.Dobavljaci.Remove(s);
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
