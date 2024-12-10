using System;
using ApiCarro.Models;
using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Models.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class CarrosController : ControllerBase
    {
        private static List<Carro> carros = new List<Carro>
        {
            new Carro {Id = 1, Marca = "Toyota", Modelo = "Corola", Cor = "Preto", Ano = 2022},
            new Carro {Id = 2, Marca = "Chevrolet", Modelo = "Onix", Cor = "Vermelho", Ano = 2020}

        };

        [HttpGet]
        public ActionResult<List<Carro>> Get()
        {
            return Ok(carros);
        }

        [HttpGet("{id}")]
        public ActionResult<Carro> GetById(int id)
        {
            var carro = carros.FirstOrDefault(p => p.Id == id);
            if (carro == null) return NotFound("Carro não encontrado");
            return Ok(carro);
        }

        [HttpPost]
        public ActionResult<Carro> Post([FromBody] Carro novoCarro)
        {
            novoCarro.Id = carros.Count + 1;
            carros.Add(novoCarro);
            return Created(nameof(GetById), novoCarro);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Carro carroAtualizado)
        {
            var carro = carros.FirstOrDefault(p => p.Id == id);
            if (carro == null) return NotFound("Carro não encontrado");

            if (carroAtualizado.Marca != null)
                carro.Marca = carroAtualizado.Marca;

            if (carroAtualizado.Modelo != null)
                carro.Modelo = carroAtualizado.Modelo;

            if (carroAtualizado.Cor != null)
                carro.Cor = carroAtualizado.Cor;

            if (carroAtualizado.Ano != 0)
                carro.Ano = carroAtualizado.Ano;

            return Ok(new
            {
                Menssagem = "Carro alterado com sucesso",
                carroAtualizado = carro
            });
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var carro = carros.FirstOrDefault(p => p.Id == id);
            if (carro == null) return NotFound("Carro não encontrado");

            carros.Remove(carro);

            return Ok("Carro deletado com sucesso");
        }


    }

}