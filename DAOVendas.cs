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
                Console.WriteLine($"ID da Venda: {v.id}");

                foreach (Vendas venda in databaseVendas) {
                    venda.ExibirVenda();
                }
                Console.WriteLine($"TOTAL: {v.total}");
            }
            Console.WriteLine("=========================");
        }
    }
}
