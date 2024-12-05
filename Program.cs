using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao1 {
    internal class Program {
        static void Main(string[] args) {
            DAOCliente daoCliente = new DAOCliente();
            DAOProduto daoProduto = new DAOProduto();
            DAOVendas daoVenda = new DAOVendas();




            //create cliente
            Cliente cliente1 = new Cliente("Mariana", 18, "1234532");
            daoCliente.create(cliente1);
            daoCliente.getAll();
            //update cliente
            Cliente clienteUP = new Cliente("Mariana2", 19, "123456");
            daoCliente.update(clienteUP);
            //delete cliente
            Cliente clienteD = daoCliente.get(1);

            if (daoCliente.delete(clienteD.id, ))
                Console.WriteLine("Exclusao com sucesso");
            else
                Console.WriteLine("Exclusao nao realizada");
            // get all cliente
            daoCliente.getAll();

            // Básicamente é esse o formato de CRUD para todas as classes,
            // recomendo ir comentando e descomentando e ir rodando parte por parte e não tudo de uma vez

        }
    }
}
