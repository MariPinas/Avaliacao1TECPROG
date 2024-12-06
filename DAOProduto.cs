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
                if (p.id == id)
                    return p;
            }
            return null;
        }

        public Boolean delete(int id) {
            Produto produtoExiste = get(id);
            if (produtoExiste != null) {
                databaseProduto.Remove(produtoExiste);
                return true;
            }
            return false;
        }

        public void getAll() {
            Console.WriteLine("=== Listando Produtos ===");
            foreach (Produto p in databaseProduto) {
                Console.WriteLine($"--*  Produto número {p.id}  *--");
                Console.WriteLine($"ID: {p.id}");
                Console.WriteLine($"Marca: {p.marca}");
                Console.WriteLine($"Modelo: {p.modelo}");
                Console.WriteLine($"Descrição: {p.descricao}");
                Console.WriteLine($"Preço: {p.preco}");
            }
            Console.WriteLine("=========================");
        }
    }
}
