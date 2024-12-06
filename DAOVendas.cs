using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao1 {
    internal class DAOVendas {
        List<Vendas> databaseVendas = new List<Vendas>();

        public void create(Vendas venda) {
            databaseVendas.Add(venda);
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
                if (v.id == id)
                    return v;
            }
            return null;
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
                v.ExibirVenda();
            }
        }

        public void getTotalizacao() {
            float total = 0;
            int qtd = 0;

            Console.WriteLine("=== Totalizacao Vendas ===");
            foreach (Vendas v in databaseVendas) {
                total += v.total;
                qtd++;
            }
            Console.WriteLine($"TOTAL: {total}");
            Console.WriteLine($"Quantidade de Vendas: {qtd}");
            Console.WriteLine("=========================");
        }

    }
}
