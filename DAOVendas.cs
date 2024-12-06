using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao1 {
    internal class DAOVendas {
        List<Vendas> databaseVendas = new List<Vendas>();

        public void create(Vendas cliente) {
            databaseVendas.Add(cliente);
        }

        public Boolean update(Vendas venda) {
            Vendas vendaExiste = get(venda.id);
            if (vendaExiste != null) {
                vendaExiste.cliente = venda.cliente;
                vendaExiste.total = venda.total;
                return true;
            }
            return false;
        }

        public Vendas get(int id) {
            foreach (Vendas v in databaseVendas) {
                if (v.id == id) {
                    Console.WriteLine("Venda encontrada! :D");
                    printById(id);
                    return v;
                }
            }
            return null;
        }

        public Boolean getVendaDoCliente(int idCliente) {
            // este método verifica se o cliente possui vendas registradas

            foreach (Vendas venda in databaseVendas) {
                if (venda.cliente.id == idCliente)
                    return true;
            }
            return false;
        }

        public Boolean getProdutoVendido(int idProduto) {
            // este método verifica se o produto já foi vendido

            foreach (Vendas venda in databaseVendas){
                foreach (Produto produto in venda.produtosVenda) { 
                    if(produto.id == idProduto){
                        return true;
                    }
                }
            }
            return false;
        }
        
        public Boolean delete(int id) {
            Vendas vendaExiste = get(id);
            if (vendaExiste != null) {
                databaseVendas.Remove(vendaExiste);
                return true;
            }
            return false;
        }

        public void getAll() {
            Console.WriteLine("=== Listando Vendas ===");
            foreach (Vendas v in databaseVendas) {
                Console.WriteLine($"--*  Venda número {v.id}  *--");
                Console.WriteLine($"ID da Venda: {v.id}");

                foreach (Vendas venda in databaseVendas) {
                    venda.ExibirVenda();
                }
                Console.WriteLine($"TOTAL: {v.total}");
            }
            Console.WriteLine("=========================");
        }

        public void printById(int idVenda) {
            Vendas venda = get(idVenda);
            if (venda != null)
            {
                String produtos = "";
                foreach (Produto produto in venda.produtosVenda) {
                    produtos += "\t-" + produto.modelo + "   ..." + produto.quantidadeProduto + "x";
                }

                Console.WriteLine($"ID: {venda.id}");
                Console.WriteLine($"Cliente: {venda.cliente.nome}");
                Console.WriteLine($"Total da venda: {venda.total}");
                Console.WriteLine($"Produtos: \n{produtos}");
            }
        }
    }
}
