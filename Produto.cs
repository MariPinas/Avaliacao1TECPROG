using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao1 {
    internal class Produto {
        public int id { get; private set; }
        public String marca { get; set; }
        public String modelo { get; set; }
        public float preco { get; set; }
        private static int contadorId = 1;

        public Produto(string marca, string modelo, float preco) {
            this.id = contadorId++;
            this.marca = marca;
            this.modelo = modelo;
            this.preco = preco;
        }

        public void getProduto(Produto p) {
            Console.WriteLine($"ID: {p.id}");
            Console.WriteLine($"Marca: {p.marca}");
            Console.WriteLine($"Modelo: {p.modelo}");
            Console.WriteLine($"Preco: {p.preco}");
        }
    }
}
