using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VoziloController: ControllerBase
    {
        private readonly TrgovinaVozilimaContext _context;

        public VoziloController(TrgovinaVozilimaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Vozila.Include(v=>v.Kupac).Include(v => v.VrstaVozila).Include(v => v.Dobavljac));

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
                var s = _context.Vozila.Find(sifra);
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
        public IActionResult Post(Vozilo vozilo)
        {
            try
            {
                _context.Vozila.Add(vozilo);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, vozilo);
            }
            catch (Exception e)
            {
                return BadRequest(new { poruka = e.Message });
            }

        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]

        public IActionResult Put(int sifra, Vozilo vozilo)
        {
            try
            {

                var s = _context.Vozila.Find(sifra);

                if (s == null)
                {
                    return NotFound();
                }

                s.VrstaVozila = vozilo.VrstaVozila;
                s.Dobavljac= vozilo.Dobavljac;
                s.Marka = vozilo.Marka;
                s.GodProizvodnje = vozilo.GodProizvodnje;
                s.PrijedeniKm = vozilo.PrijedeniKm;
                s.Cijena = vozilo.Cijena;
                s.Kupac = vozilo.Kupac;


                _context.Vozila.Update(s);
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
                var s = _context.Vozila.Find(sifra);
                if (s == null)
                {
                    return NotFound();
                }
                _context.Vozila.Remove(s);
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
