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

        public Boolean update(Cliente cliente) {
            Cliente clienteExiste = read(cliente.id);
            if (clienteExiste != null) {
                clienteExiste.idade = cliente.idade;
                clienteExiste.nome = cliente.nome;
                clienteExiste.cpf = cliente.cpf;
                return true;
            }
            return false;
        }
        public Cliente read(int id) {
            foreach(Cliente c in databaseClientes) {
                if(c.id == id)
                    return c;
            }
            return null;
        }

        public Boolean delete(int id) {
            Cliente clienteExiste = read(id);
            if (clienteExiste != null) {
                //implementar checar se estar na venda
                databaseClientes.Remove(clienteExiste);
                return true;
            }
            return false;
        }

        public void getAll() {
            Console.WriteLine("=== Listando Clientes ===");
            foreach (Cliente c in databaseClientes) {
                Console.WriteLine($"--*  Cliente número {c.id}  *--");
                Console.WriteLine($"ID: {c.id}");
                Console.WriteLine($"Nome: {c.nome}");
                Console.WriteLine($"CPF: {c.cpf}");          
            }
            Console.WriteLine("=========================");
        }
    }
}
