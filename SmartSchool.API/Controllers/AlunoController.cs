using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>
        {
            new Aluno
            {
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Almeida",
                Telefone = "12345675234"
            },

            new Aluno
            {
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Kent",
                Telefone = "85421987545"
            },

            new Aluno
            {
                Id = 3,
                Nome = "Laura",
                Sobrenome = "Maria",
                Telefone = "1819616874"
            },

        };


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            return Ok(aluno);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));

            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("Item Deletado");
        }

        public AlunoController()
        {

        }
    }

}
