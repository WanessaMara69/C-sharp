using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCarro.Models;

namespace MinhaApi.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }

        public List<Carro> Carros { get; set; } = new();


    }
}