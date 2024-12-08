using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao1 {
    internal class Produto {
        public string nome { get; set; }
        public int id { get; private set; }
        public String marca { get; set; }
        public String modelo { get; set; }
        public String descricao { get; set; }
        public double preco { get; set; }
        public int quantidadeProduto { get; set; }
        private static int contadorId = 1;


        public Produto(string nome, string marca, string modelo, string descricao, double preco) {
            this.id = contadorId++;
            this.nome = nome;
            this.marca = marca;
            this.modelo = modelo;
            this.descricao = descricao;
            this.preco = preco;
            this.quantidadeProduto = 1;
        }

        public void getProduto(Produto p) {
            Console.WriteLine($"\nID Produto: {p.id}");
            Console.WriteLine($"{p.quantidadeProduto}x {p.nome}");
            Console.WriteLine($"Marca: {p.marca}");
            Console.WriteLine($"Modelo: {p.modelo}");
            Console.WriteLine($"Descrição: {p.descricao}");
            Console.WriteLine($"Preço: {p.preco} reais");
        }
    }
}
