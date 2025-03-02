using AutoMapper;
using Backend.Data;
using Backend.Models;
using Backend.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DobavljacController(TrgovinaVozilimaContext context, IMapper mapper) : BackendController(context, mapper)
    {

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        return Ok(_context.Dobavljaci);

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
        //        var s = _context.Dobavljaci.Find(sifra);
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
        //public IActionResult Post(Dobavljac dobavljac)
        //{
        //    try
        //    {
        //        _context.Dobavljaci.Add(dobavljac);
        //        _context.SaveChanges();
        //        return StatusCode(StatusCodes.Status201Created, dobavljac);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new { poruka = e.Message });
        //    }

        //}

        //[HttpPut]
        //[Route("{sifra:int}")]
        //[Produces("application/json")]

        //public IActionResult Put(int sifra, Dobavljac dobavljac)
        //{
        //    try
        //    {

        //        var s = _context.Dobavljaci.Find(sifra);

        //        if (s == null)
        //        {
        //            return NotFound();
        //        }

        //        s.Naziv = dobavljac.Naziv;
        //        s.Adresa = dobavljac.Adresa;
        //        s.Iban = dobavljac.Iban;

        //        _context.Dobavljaci.Update(s);
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
        //        var s = _context.Dobavljaci.Find(sifra);
        //        if (s == null)
        //        {
        //            return NotFound();
        //        }
        //        _context.Dobavljaci.Remove(s);
        //        _context.SaveChanges();
        //        return Ok(new { poruka = "Uspješno obrisano!" });
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new { poruka = e.Message });
        //    }
        //}

        [HttpGet]
        public ActionResult<List<DobavljacDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<DobavljacDTORead>>(_context.Dobavljaci));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }

        }


        [HttpGet]
        [Route("{sifra:int}")]
        public ActionResult<DobavljacDTOInsertUpdate> GetBySifra(int sifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            Dobavljac? e;
            try
            {
                e = _context.Dobavljaci.Find(sifra);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (e == null)
            {
                return NotFound(new { poruka = "Dobavljac ne postoji u bazi" });
            }

            return Ok(_mapper.Map<DobavljacDTOInsertUpdate>(e));
        }

        [HttpPost]
        public IActionResult Post(DobavljacDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var e = _mapper.Map<Dobavljac>(dto);
                _context.Dobavljaci.Add(e);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<DobavljacDTORead>(e));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }



        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, DobavljacDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Dobavljac? e;
                try
                {
                    e = _context.Dobavljaci.Find(sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound(new { poruka = "Dobavljac ne postoji u bazi" });
                }

                e = _mapper.Map(dto, e);

                _context.Dobavljaci.Update(e);
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
                Dobavljac? e;
                try
                {
                    e = _context.Dobavljaci.Find(sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound("Dobavljac ne postoji u bazi");
                }
                _context.Dobavljaci.Remove(e);
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
        public ActionResult<List<DobavljacDTORead>> TraziDobavljac(string uvjet)
        {
            if (uvjet == null || uvjet.Length < 3)
            {
                return BadRequest(ModelState);
            }
            uvjet = uvjet.ToLower();
            try
            {
                IEnumerable<Dobavljac> query = _context.Dobavljaci;
                var niz = uvjet.Split(" ");
                foreach (var s in uvjet.Split(" "))
                {
                    query = query.Where(p => p.Naziv.ToLower().Contains(s));
                }
                var dobavljaci = query.ToList();
                return Ok(_mapper.Map<List<DobavljacDTORead>>(dobavljaci));
            }
            catch (Exception e)
            {
                return BadRequest(new { poruka = e.Message });
            }
        }

    }
}
