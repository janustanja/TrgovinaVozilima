using System.Text.RegularExpressions;
using AutoMapper;
using Backend.Data;
using Backend.Models;
using Backend.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VoziloController(TrgovinaVozilimaContext context, IMapper mapper) : BackendController(context, mapper)
    {
        

   

        [HttpGet]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        return Ok(_context.Vozila.Include(v=>v.Kupac).Include(v => v.VrstaVozila).Include(v => v.Dobavljac));

        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new { poruka = e.Message });

        //    }
        //}

        public ActionResult<List<VoziloDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<VoziloDTORead>>(_context.Vozila.Include(g => g.VrstaVozila).Include(g => g.Dobavljac).Include(g => g.Kupac)));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }

        }

        [HttpGet]
        [Route("{sifra:int}")]

        //public IActionResult GetBySifra(int sifra)
        //{
        //    try
        //    {
        //        var s = _context.Vozila.Find(sifra);
        //        if (s == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(s);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new { poruka = e.Message });
        //    }
        //}

        public ActionResult<VoziloDTOInsertUpdate> GetBySifra(int sifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            Vozilo? e;
            try
            {
                e = _context.Vozila.Include(g => g.VrstaVozila).Include(g => g.Dobavljac).Include(g => g.Kupac).FirstOrDefault(g => g.Sifra == sifra);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (e == null)
            {
                return NotFound(new { poruka = "Vozilo ne postoji u bazi" });
            }

            return Ok(_mapper.Map<VoziloDTOInsertUpdate>(e));
        }

        [HttpPost]
        //public IActionResult Post(Vozilo vozilo)
        //{
        //    try
        //    {
        //        _context.Vozila.Add(vozilo);
        //        _context.SaveChanges();
        //        return StatusCode(StatusCodes.Status201Created, vozilo);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new { poruka = e.Message });
        //    }

        //}

        public IActionResult Post(VoziloDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }

            Dobavljac? es;
            try
            {
                es = _context.Dobavljaci.Find(dto.DobavljacSifra);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (es == null)
            {
                return NotFound(new { poruka = "Smjer na grupi ne postoji u bazi" });
            }

            try
            {
                var e = _mapper.Map<Grupa>(dto);
                e.Smjer = es;
                _context.Grupe.Add(e);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<GrupaDTORead>(e));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
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
