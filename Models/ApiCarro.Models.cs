using System;

namespace ApiCarro.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Cor { get; set; }
        public int Ano { get; set; }
    }
}