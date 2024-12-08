using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao1 {
    internal class Vendas {
        public List<Produto> produtosVenda = new List<Produto>();
        public int id { get; private set; }
        public Cliente cliente { get; set; }
        public double total { get; set; }
        private static int contadorId = 1;

        public Vendas(Cliente cliente) {
            this.id = contadorId++;
            this.cliente = cliente;
            this.total = 0;
        }

        public void ExibirVenda() {
            Console.WriteLine($"==== Exibicao da venda de ID: {this.id} ====");
            Console.WriteLine($"ID do Comprador: {this.cliente.id} ");

            foreach (Produto i in produtosVenda) {
                i.getProduto(i);
            }
            Console.WriteLine($"TOTAL DA COMPRA: {this.total} REAIS");
            Console.WriteLine("========================================================");
        }

        public void ExibirCarrinho() { 
            Console.WriteLine($"ID do Comprador: {this.cliente.id} ");

            foreach (Produto i in produtosVenda) {
                i.getProduto(i);
            }
            Console.WriteLine($"TOTAL DO CARRINHO: {this.total} REAIS");
            Console.WriteLine("========================================================");
        }

        public Boolean addProduto(Produto p) {
            
            if (p == null) {
                return false;
            } else {
                foreach (Produto produto in produtosVenda) {
                    if (p.id == produto.id) {
                        produto.quantidadeProduto += 1;
                        total += p.preco;
                        return true;
                    }
                }
                produtosVenda.Add(p);
                total += p.preco;
                return true;
            }
        }
    }
}
