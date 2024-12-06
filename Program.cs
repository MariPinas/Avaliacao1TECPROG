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
            int id, idade, op, op1, op2, op3;
            string nome, cpf;


            do {
                Console.WriteLine("==== Sistema de Vendas ====");
                Console.WriteLine("[1] Cliente \t [2] Produto \t [3] Venda \t [4] Sair ");
                Console.WriteLine("Escolha uma opcao do menu:");
                op = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("=========================================");

                switch (op) {
                    case 1:
                        do {
                            Console.WriteLine("==== CLIENTE ====");
                            Console.WriteLine("[1] Cadastrar Cliente \t [2] Procurar Cliente \t [3] Deletar Cliente \t [4] Listar Clientes");
                            Console.WriteLine("Escolha uma opcao do menu:");
                            op1 = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("=========================================");

                            switch (op1) {
                                case 1:
                                    Console.WriteLine("Informe o nome do cliente: ");
                                    nome = Console.ReadLine();
                                    Console.WriteLine("Informe a idade do cliente: ");
                                    idade = Convert.ToInt16(Console.ReadLine());
                                    Console.WriteLine("Informe o cpf do cliente: ");
                                    cpf = Console.ReadLine();
                                    Cliente cliente = new Cliente(nome, idade, cpf);
                                    daoCliente.create(cliente);
                                    Console.WriteLine("Cliente cadastrado!");
                                    break;
                                case 2:
                                    Console.WriteLine("Informe o codigo do cliente: ");
                                    id = Convert.ToInt16(Console.ReadLine());
                                    daoCliente.get(id);
                                    break;
                                case 3:
                                    Console.WriteLine("Informe o codigo do cliente: ");
                                    id = Convert.ToInt16(Console.ReadLine());
                                    daoCliente.delete(id, daoVenda);
                                    break;
                                case 4:
                                    daoCliente.getAll();
                                    break;
                            }

                        } while (op1 > 0 && op1 < 5);
                        break;
                    case 2:
                        do {
                            Console.WriteLine("==== PRODUTO ====");
                            Console.WriteLine("[1] Cadastrar Produto \t [2] Procurar Produto \t [3] Deletar Produto \t [4] Listar Produto \t [5] Sair");
                            Console.WriteLine("Escolha uma opcao do menu:");
                            op2 = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("=========================================");

                            switch (op2) {
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;
                            }

                        } while (op2 > 0 && op2 < 5);
                        break;
                    case 3:
                        do {
                            Console.WriteLine("==== VENDA ====");
                            Console.WriteLine("[1] Registrar Venda \t [2] Procurar Venda \t [3] Atualizar Venda \t\t [4] Listar Vendas \t [5] Totalizar Vendas");
                            Console.WriteLine("Escolha uma opcao do menu:");
                            op3 = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("=========================================");

                            switch (op3) {
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;
                                case 5:
                                    break;
                                case 6:
                                    break;
                            }

                        } while (op3 > 0 && op3 < 6);
                        break;
                    default:
                        Console.WriteLine("Encerrando...");
                        break;
                }


            } while (op > 0 && op < 3);

        }
    }
}
