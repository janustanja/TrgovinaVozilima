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
    public class KupacController(TrgovinaVozilimaContext context, IMapper mapper) : BackendController(context, mapper)
    {


        //[HttpGet]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        return Ok(_context.Kupci);

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
        //        var s = _context.Kupci.Find(sifra);
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
        //public IActionResult Post(Kupac kupac)
        //{
        //    try
        //    {
        //        _context.Kupci.Add(kupac);
        //        _context.SaveChanges();
        //        return StatusCode(StatusCodes.Status201Created, kupac);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new { poruka = e.Message });
        //    }

        //}

        //[HttpPut]
        //[Route("{sifra:int}")]
        //[Produces("application/json")]

        //public IActionResult Put(int sifra, Kupac kupac)
        //{
        //    try
        //    {

        //        var s = _context.Kupci.Find(sifra);

        //        if (s == null)
        //        {
        //            return NotFound();
        //        }

        //        s.Ime = kupac.Ime;
        //        s.Prezime = kupac.Prezime;
        //        s.Adresa = kupac.Adresa;
        //        s.Iban = kupac.Iban;

        //        _context.Kupci.Update(s);
        //        _context.SaveChanges();
        //        return Ok(new { poruka = "Uspješno promijenjen podatak!" });
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new { poruka = e.Message });
        //    }

        //}
        //[HttpDelete]
        //[Route("{sifra:int}")]
        //public IActionResult Delete(int sifra)
        //{
        //    try
        //    {
        //        var s = _context.Kupci.Find(sifra);
        //        if (s == null)
        //        {
        //            return NotFound();
        //        }
        //        _context.Kupci.Remove(s);
        //        _context.SaveChanges();
        //        return Ok(new { poruka = "Uspješno obrisano!" });
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new { poruka = e.Message });
        //    }
        //}

        [HttpGet]
        public ActionResult<List<KupacDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<KupacDTORead>>(_context.Kupci));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }

        }


        [HttpGet]
        [Route("{sifra:int}")]
        public ActionResult<KupacDTOInsertUpdate> GetBySifra(int sifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            Kupac? e;
            try
            {
                e = _context.Kupci.Find(sifra);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (e == null)
            {
                return NotFound(new { poruka = "Kupac ne postoji u bazi" });
            }

            return Ok(_mapper.Map<KupacDTOInsertUpdate>(e));
        }

        [HttpPost]
        public IActionResult Post(KupacDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var e = _mapper.Map<Kupac>(dto);
                _context.Kupci.Add(e);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<KupacDTORead>(e));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }



        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, KupacDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Kupac? e;
                try
                {
                    e = _context.Kupci.Find(sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound(new { poruka = "Kupac ne postoji u bazi" });
                }

                e = _mapper.Map(dto, e);

                _context.Kupci.Update(e);
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
                Kupac? e;
                try
                {
                    e = _context.Kupci.Find(sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound("Kupac ne postoji u bazi");
                }
                _context.Kupci.Remove(e);
                _context.SaveChanges();
                return Ok(new { poruka = "Uspješno obrisano" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpGet]
        [Route("trazi/{uvjet}")]
        public ActionResult<List<KupacDTORead>> TraziKupac(string uvjet)
        {
            if (uvjet == null || uvjet.Length < 3)
            {
                return BadRequest(ModelState);
            }
            uvjet = uvjet.ToLower();
            try
            {
                IEnumerable<Kupac> query = _context.Kupci;
                var niz = uvjet.Split(" ");
                foreach (var s in uvjet.Split(" "))
                {
                    query = query.Where(p => p.Ime.ToLower().Contains(s) || p.Prezime.ToLower().Contains(s));
                }
                var kupci = query.ToList();
                return Ok(_mapper.Map<List<KupacDTORead>>(kupci));
            }
            catch (Exception e)
            {
                return BadRequest(new { poruka = e.Message });
            }
        }


        [HttpGet]
        [Route("{sifraKupca:int}/vozila")]
        public ActionResult<List<VoziloDTORead>> GetVozila(int sifraKupca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<VoziloDTORead>>(_context.Kupci.Include(k=>k.Vozila)
                  .ThenInclude(v=>v.VrstaVozila)
                  .Include(k => k.Vozila)
                  .ThenInclude(v => v.Dobavljac)
                    .FirstOrDefault(k=> k.Sifra == sifraKupca).Vozila.ToList()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }

        }


    }
}
