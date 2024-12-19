using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCarro.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Models;


namespace MinhaApi.Models.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private static List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa { Id = 1, Nome = "Wanessa", Idade = 21},
            new Pessoa { Id = 2, Nome = "Carlos", Idade = 32}
        };

        private static List<Carro> carros = new List<Carro>
        {
            new Carro {Id = 1, Marca = "Toyota", Modelo = "Corola", Cor = "Preto", Ano = 2022},
            new Carro {Id = 2, Marca = "Chevrolet", Modelo = "Onix", Cor = "Vermelho", Ano = 2020}

        };

        // Api/pessoas
        [HttpGet]
        public ActionResult<List<Pessoa>> Get()
        {
            return Ok(pessoas);
        }

        [HttpGet("{id}/carro/{idCarro}")]
        public ActionResult<Pessoa> GetById(int id, int idCarro)
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Id == id);

            pessoa.Carros.Add(carros.FirstOrDefault(c => c.Id == idCarro));
            if (pessoa == null) return NotFound("Pessoa não encontrada."); //CRUD 
            return Ok(pessoa);
        }

        [HttpPost]
        public ActionResult<Pessoa> Post([FromBody] Pessoa novaPessoa) //utilizar FromBody qnd for pesquisar no corpo
        {
            novaPessoa.Id = pessoas.Count + 1;
            pessoas.Add(novaPessoa);
            return Created(nameof(GetById), novaPessoa);
        }

        //api/pessoas/3
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pessoa pessoaAtualizada)
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Id == id);

            if (pessoa == null) return NotFound("Pessoa não encontrada.");

            pessoa.Nome = pessoaAtualizada.Nome;
            pessoa.Idade = pessoaAtualizada.Idade;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Id == id);
            if (pessoa == null) return NotFound("Pessoa não encontrada.");

            pessoas.Remove(pessoa);
            return NoContent();
        }

    }
}