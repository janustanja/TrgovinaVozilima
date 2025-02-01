using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

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
                return Ok(_context.Vozila);

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

                s.VrstaVozilaSifra = vozilo.VrstaVozilaSifra;
                s.DobavljacSifra = vozilo.DobavljacSifra;
                s.Marka = vozilo.Marka;
                s.GodProizvodnje = vozilo.GodProizvodnje;
                s.PrijedeniKm = vozilo.PrijedeniKm;
                s.Cijena = vozilo.Cijena;
                s.KupacSifra = vozilo.KupacSifra;


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
