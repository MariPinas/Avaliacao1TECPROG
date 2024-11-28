using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao1{
    internal class Program{
        static void Main(string[] args){
            DAOCliente daoCliente = new DAOCliente();

            Cliente cliente1 = new Cliente("Mariana", 18, "1234532");

            daoCliente.create(cliente1);

            daoCliente.getAll();

        }
    }
}
