using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao1 {
    internal class DAOCliente {
        List<Cliente> databaseClientes = new List<Cliente>();

        public void create(Cliente cliente) {
            databaseClientes.Add(cliente);
        }

        public Cliente get(int id) {
            foreach(Cliente c in databaseClientes) {
                if(c.id == id) {
                    return c;
                }
            }
            return null;
        }

        public Boolean delete(int idCliente, DAOVendas vendasFeitas) {
            // Deleta o cliente se o cliente existe E não possui vendas feitas com ele
            Cliente clienteExiste = get(idCliente);
            if (clienteExiste != null && !vendasFeitas.getVendaDoCliente(idCliente)) {
                databaseClientes.Remove(clienteExiste);
                Console.WriteLine("Cliente deletado com sucesso! :D");
                return true;
            }
            Console.WriteLine("Cliente não deletado - inexistente ou presente em vendas registradas");
            return false;
        }

        public void getAll() {
            if (databaseClientes.Count == 0) {
                Console.WriteLine("Não existem clientes cadastrados! ");
                return;
            }

            Console.WriteLine("=== Listando Clientes ===");
            foreach (Cliente c in databaseClientes) {
                Console.WriteLine($"--*  Cliente número {c.id}  *--");
                Console.WriteLine($"Nome : {c.nome}");
                Console.WriteLine($"Idade: {c.idade}");
                Console.WriteLine($"CPF  : {c.cpf}");          
            }
            Console.WriteLine("=========================");
        }

        public void printById(int idCliente) {
            Cliente cliente = get(idCliente);
            if (cliente != null) {
                Console.WriteLine("===========*============");
                Console.WriteLine($"Nome : {cliente.nome}");
                Console.WriteLine($"Idade: {cliente.idade}");
                Console.WriteLine($"CPF  : {cliente.cpf}");
                Console.WriteLine("===========*============");

            }
        }

        public int getClienteCount() {
            return databaseClientes.Count;
        }
    }
}
