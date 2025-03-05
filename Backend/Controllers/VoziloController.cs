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




        //[HttpGet]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        return Ok(_context.Vozila.Include(v => v.Kupac).Include(v => v.VrstaVozila).Include(v => v.Dobavljac));

        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new { poruka = e.Message });

        //    }
        //}



        //[HttpGet]
        //[Route("{sifra:int}")]

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



        //[HttpPost]
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



        //    [HttpPut]
        //    [Route("{sifra:int}")]
        //    [Produces("application/json")]

        //    public IActionResult Put(int sifra, Vozilo vozilo)
        //    {
        //        try
        //        {

        //            var s = _context.Vozila.Find(sifra);

        //            if (s == null)
        //            {
        //                return NotFound();
        //            }

        //            s.VrstaVozila = vozilo.VrstaVozila;
        //            s.Dobavljac = vozilo.Dobavljac;
        //            s.Marka = vozilo.Marka;
        //            s.GodProizvodnje = vozilo.GodProizvodnje;
        //            s.PrijedeniKm = vozilo.PrijedeniKm;
        //            s.Cijena = vozilo.Cijena;
        //            s.Kupac = vozilo.Kupac;


        //            _context.Vozila.Update(s);
        //            _context.SaveChanges();
        //            return Ok(new { poruka = "Uspješno promijenjen podatak!" });
        //        }
        //        catch (Exception e)
        //        {
        //            return BadRequest(new { poruka = e.Message });
        //        }

        //    }
        //    [HttpDelete]
        //    [Route("{sifra:int}")]
        //    public IActionResult Delete(int sifra)
        //    {
        //        try
        //        {
        //            var s = _context.Vozila.Find(sifra);
        //            if (s == null)
        //            {
        //                return NotFound();
        //            }
        //            _context.Vozila.Remove(s);
        //            _context.SaveChanges();
        //            return Ok(new { poruka = "Uspješno obrisano!" });
        //        }
        //        catch (Exception e)
        //        {
        //            return BadRequest(new { poruka = e.Message });
        //        }
        //    }




        // RUTE
        [HttpGet]
        public ActionResult<List<VoziloDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<VoziloDTORead>>(_context.Vozila
                    .Include(g => g.VrstaVozila)
                    .Include(g => g.Dobavljac)
                    .Include(g => g.Kupac)));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }

        }


        [HttpGet]
        [Route("{sifra:int}")]
        public ActionResult<VoziloDTOInsertUpdate> GetBySifra(int sifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            Vozilo? e;
            try
            {
                e = _context.Vozila.Include(g => g.VrstaVozila).FirstOrDefault(g => g.Sifra == sifra);
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
        public IActionResult Post(VoziloDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }

            VrstaVozila? es;
            try
            {
                es = _context.VrsteVozila.Find(dto.VrstaVozilaSifra);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (es == null)
            {
                return NotFound(new { poruka = "Vrsta vozila na vozilu ne postoji u bazi" });
            }

            try
            {
                var e = _mapper.Map<Vozilo>(dto);
                e.VrstaVozila = es;
                _context.Vozila.Add(e);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<VoziloDTORead>(e));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }



        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, VoziloDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Vozilo? e;
                try
                {
                    e = _context.Vozila.Include(g => g.VrstaVozila).FirstOrDefault(x => x.Sifra == sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound(new { poruka = "Vozilo ne postoji u bazi" });
                }

                VrstaVozila? es;
                try
                {
                    es = _context.VrsteVozila.Find(dto.VrstaVozilaSifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (es == null)
                {
                    return NotFound(new { poruka = "Vrsta vozila na vozilu ne postoji u bazi" });
                }

                e = _mapper.Map(dto, e);
                e.VrstaVozila = es;
                _context.Vozila.Update(e);
                _context.SaveChanges();

                return Ok(new { poruka = "Uspješno promjenjeno" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }

        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Vozilo? e;
                try
                {
                    e = _context.Vozila.Find(sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound("Vozilo ne postoji u bazi");
                }
                _context.Vozila.Remove(e);
                _context.SaveChanges();
                return Ok(new { poruka = "Uspješno obrisano" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /*
        [HttpGet]
        [Route("Kupci/{sifraVozila:int}")]
        public ActionResult<List<KupacDTORead>> GetKupci(int sifraVozila)
        {
            if (!ModelState.IsValid || sifraVozila <= 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var p = _context.Vozila
                    .Include(i => i.Kupci).FirstOrDefault(x => x.Sifra == sifraVozila);
                if (p == null)
                {
                    return BadRequest("Ne postoji vozilo sa šifrom " + sifraVozila + " u bazi");
                }

                return Ok(_mapper.Map<List<KupacDTORead>>(p.Kupci));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }
        */

        /*
        [HttpPost]
        [Route("{sifra:int}/dodaj/{kupacSifra:int}")]
        public IActionResult DodajKupca(int sifra, int kupacSifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (sifra <= 0 || kupacSifra <= 0)
            {
                return BadRequest("Šifra vozila ili kupca nije dobra");
            }
            try
            {
                var vozilo = _context.Vozila
                    .Include(g => g.Kupci)
                    .FirstOrDefault(g => g.Sifra == sifra);
                if (vozilo == null)
                {
                    return BadRequest("Ne postoji vozilo sa šifrom " + sifra + " u bazi");
                }
                var kupac = _context.Kupci.Find(kupacSifra);
                if (kupac == null)
                {
                    return BadRequest("Ne postoji kupac sa šifrom " + kupacSifra + " u bazi");
                }
                vozilo.Kupci.Add(kupac);
                _context.Vozila.Update(vozilo);
                _context.SaveChanges();
                return Ok(new
                {
                    poruka = "Kupac " + kupac.Prezime + " " + kupac.Ime + " dodan na vozilo "
                 //+ vozilo.Naziv
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                       StatusCodes.Status503ServiceUnavailable,
                       ex.Message);
            }
        }
        */
        /*
        [HttpDelete]
        [Route("{sifra:int}/obrisi/{KupacSifra:int}")]
        public IActionResult ObrisiKupca(int sifra, int kupacSifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (sifra <= 0 || kupacSifra <= 0)
            {
                return BadRequest("Šifra vozila ili kupca nije dobra");
            }
            try
            {
                var vozilo = _context.Vozila
                    .Include(g => g.Kupci)
                    .FirstOrDefault(g => g.Sifra == sifra);
                if (vozilo == null)
                {
                    return BadRequest("Ne postoji vozilo sa šifrom " + sifra + " u bazi");
                }
                var kupac = _context.Kupci.Find(kupacSifra);
                if (kupac == null)
                {
                    return BadRequest("Ne postoji kupac sa šifrom " + kupacSifra + " u bazi");
                }
                vozilo.Kupci.Remove(kupac);
                _context.Vozila.Update(vozilo);
                _context.SaveChanges();

                return Ok(new
                {
                    poruka = "Kupac " + kupac.Prezime + " " + kupac.Ime + " obrisan s vozila "
                 //+ vozilo.Naziv
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });

            }
        }
        */
    }
    } 
