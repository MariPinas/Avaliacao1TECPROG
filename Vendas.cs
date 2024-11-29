using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao1 {
    internal class Vendas {
        List<Produto> produtosVenda = new List<Produto>();
        public int id { get; private set; }
        public Cliente cliente { get; set; }
        public float total { get; set; }
        private static int contadorId = 1;

        public Vendas(Cliente cliente, float total, string cpf) {
            this.id = contadorId++;
            this.cliente = cliente;
            this.total = 0;
        }

        public void ExibirVenda() {
            Console.WriteLine($"==== Exibicao da venda de ID: {this.id} ====");
            Console.WriteLine($"Dados do Comprador: {this.cliente} ");

            foreach (Produto i in produtosVenda) {
                i.getProduto(i);
            }
            Console.WriteLine($"TOTAL DA COMPRA: {this.total}");
            Console.WriteLine("========================================================");
        }

        public Boolean addProduto(Produto p) {
            if (p == null) {
                return false;
            } else {
                produtosVenda.Add(p);
                total += p.preco;
                return true;
            }
        }
    }
}
