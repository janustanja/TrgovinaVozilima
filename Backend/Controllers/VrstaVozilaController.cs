using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Models;
using AutoMapper;
using Backend.Models.DTO;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VrstaVozilaController(TrgovinaVozilimaContext context,IMapper mapper) : BackendController(context, mapper)
    {

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        return Ok(_context.VrsteVozila);

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
        //        var s = _context.VrsteVozila.Find(sifra);
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
        //public IActionResult Post(VrstaVozila vrstaVozila)
        //{
        //    try
        //    {
        //        _context.VrsteVozila.Add(vrstaVozila);
        //        _context.SaveChanges();
        //        return StatusCode(StatusCodes.Status201Created, vrstaVozila);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new { poruka = e.Message });
        //    }

        //}

        //[HttpPut]
        //[Route("{sifra:int}")]
        //[Produces("application/json")]

        //public IActionResult Put(int sifra, VrstaVozila vrstaVozila)
        //{
        //    try
        //    {

        //        var s = _context.VrsteVozila.Find(sifra);

        //        if (s == null)
        //        {
        //            return NotFound();
        //        }

        //        s.Naziv = vrstaVozila.Naziv;

        //        _context.VrsteVozila.Update(s);
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
        //        var s = _context.VrsteVozila.Find(sifra);
        //        if (s == null)
        //        {
        //            return NotFound();
        //        }
        //        _context.VrsteVozila.Remove(s);
        //        _context.SaveChanges();
        //        return Ok(new { poruka = "Uspješno obrisano!" });
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new { poruka = e.Message });
        //    }
        //}

        [HttpGet]
        public ActionResult<List<VrstaVozilaDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<VrstaVozilaDTORead>>(_context.VrsteVozila));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }

        }


        [HttpGet]
        [Route("{sifra:int}")]
        public ActionResult<VrstaVozilaDTOInsertUpdate> GetBySifra(int sifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            VrstaVozila? e;
            try
            {
                e = _context.VrsteVozila.Find(sifra);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (e == null)
            {
                return NotFound(new { poruka = "Vrsta vozila ne postoji u bazi" });
            }

            return Ok(_mapper.Map<VrstaVozilaDTOInsertUpdate>(e));
        }

        [HttpPost]
        public IActionResult Post(VrstaVozilaDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var e = _mapper.Map<VrstaVozila>(dto);
                _context.VrsteVozila.Add(e);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<VrstaVozilaDTORead>(e));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }



        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, VrstaVozilaDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                VrstaVozila? e;
                try
                {
                    e = _context.VrsteVozila.Find(sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound(new { poruka = "Vrsta vozila ne postoji u bazi" });
                }

                e = _mapper.Map(dto, e);

                _context.VrsteVozila.Update(e);
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
                VrstaVozila? e;
                try
                {
                    e = _context.VrsteVozila.Find(sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound("Vrsta vozila ne postoji u bazi");
                }
                _context.VrsteVozila.Remove(e);
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
        public ActionResult<List<VrstaVozilaDTORead>> TraziVrstaVozila(string uvjet)
        {
            if (uvjet == null || uvjet.Length < 3)
            {
                return BadRequest(ModelState);
            }
            uvjet = uvjet.ToLower();
            try
            {
                IEnumerable<VrstaVozila> query = _context.VrsteVozila;
                var niz = uvjet.Split(" ");
                foreach (var s in uvjet.Split(" "))
                {
                    query = query.Where(p => p.Naziv.ToLower().Contains(s));
                }
                var vrstaVozila = query.ToList();
                return Ok(_mapper.Map<List<VrstaVozilaDTORead>>(vrstaVozila));
            }
            catch (Exception e)
            {
                return BadRequest(new { poruka = e.Message });
            }
        }

    }
}

