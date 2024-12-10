using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao1 {
    internal class DAOProduto {
        List<Produto> databaseProduto = new List<Produto>();

        public void create(Produto produto) {
            databaseProduto.Add(produto);
        }
        public Produto get(int id) {
            foreach (Produto p in databaseProduto) {
                if (p.id == id) {
                    return p;
                }
            }
            return null;
        }

        public Boolean delete(int idProduto, DAOVendas vendasFeitas)
        {
            // Deleta o produto se ele existe E não foi vendido
            Produto produtoExiste = get(idProduto);
            if (produtoExiste != null && !vendasFeitas.getProdutoVendido(idProduto)) {
                databaseProduto.Remove(produtoExiste);
                Console.WriteLine("Produto deletado com sucesso! :D");
                return true;
            }
            Console.WriteLine("Produto não deletado - inexistente ou possui vendas registradas");
            return false;
        }

        public void getAll() {
            if (databaseProduto.Count == 0) {
                Console.WriteLine("Não existem produtos cadastrados");
                return;
            }
            Console.WriteLine("=== Listando Produtos ===");
            foreach (Produto p in databaseProduto) {
                Console.WriteLine($"--*  Produto número {p.id}  *--");
                Console.WriteLine($"ID: {p.id}");
                Console.WriteLine($"Nome: {p.nome}");
                Console.WriteLine($"Marca: {p.marca}");
                Console.WriteLine($"Modelo: {p.modelo}");
                Console.WriteLine($"Descrição: {p.descricao}");
                Console.WriteLine($"Preço: {p.preco} reais");
            }
            Console.WriteLine("=========================");
        }

        public void printById(int idProduto){
            Produto produto = get(idProduto);
            if (produto != null)
            {
                Console.WriteLine("===========*============");
                Console.WriteLine($"ID: {produto.id}");
                Console.WriteLine($"Marca: {produto.marca}");
                Console.WriteLine($"Modelo: {produto.modelo}");
                Console.WriteLine($"Descrição: {produto.descricao}");
                Console.WriteLine($"Preço: R${produto.preco}");
                Console.WriteLine("===========*============");
            }
        }

        public int getProdutoCount() {
            return databaseProduto.Count;
        }
    }
}
