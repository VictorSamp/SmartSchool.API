using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System.Linq;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var Professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (Professor == null) return BadRequest("O professor não foi encontrado");

            return Ok(Professor);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var Professor = _context.Professores.FirstOrDefault(a => a.Nome.Contains(nome));
            if (Professor == null) return BadRequest("O professor não foi encontrado");

            return Ok(Professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var Professor = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (Professor == null) return BadRequest("O professor não foi encontrado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var Professor = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (Professor == null) return BadRequest("O professor não foi encontrado");

            _context.Update(Professor);
            _context.SaveChanges();
            return Ok(Professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("O professor não foi encontrado");

            _context.Remove(professor);
            _context.SaveChanges();
            return Ok();
        }

        public ProfessorController()
        {

        }
    }
}
