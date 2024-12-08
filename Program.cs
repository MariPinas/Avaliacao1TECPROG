using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Avaliacao1 {
    internal class Program {
        static void Main(string[] args) {
            DAOCliente daoCliente = new DAOCliente();
            DAOProduto daoProduto = new DAOProduto();
            DAOVendas daoVenda = new DAOVendas();
            int id, idade, op, op1;
            string nome, cpf, marca, modelo, descricao;
            double preco;


            do {
                Console.WriteLine("\n==== Sistema de Vendas ====");
                Console.WriteLine("\n [1] Cliente \t [2] Produto \t [3] Venda \t [4] Sair ");
                Console.WriteLine("\n Escolha uma opcao do menu:");
                string entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out op)) {
                    Console.WriteLine("\n--- Opção inválida - digite um número válido ---");
                    continue;
                }


                Console.WriteLine("=========================================");

                switch (op) {
                    case 1:
                        do {
                            Console.WriteLine("\n ==== CLIENTE ====");
                            Console.WriteLine("\n [1] Cadastrar Cliente \t [2] Procurar Cliente \t [3] Deletar Cliente \t [4] Listar Clientes \t [5] Sair");
                            Console.WriteLine("\n Escolha uma opcao do menu:");
                            string entrada1 = Console.ReadLine();
                            if (!int.TryParse(entrada1, out op1))
                            {
                                Console.WriteLine("\n--- Opção inválida - digite um número válido ---");
                                continue;
                            }
                            Console.WriteLine("\n ========================================= \n");

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
                                    if (daoCliente.get(id) != null)
                                    {
                                        Console.WriteLine("Cliente encontrado! :D");
                                        daoCliente.printById(daoCliente.get(id).id);
                                    }
                                    else
                                        Console.WriteLine("Cliente não cadastrado! ");
                                    break;
                                case 3:
                                    Console.WriteLine("Informe o codigo do cliente: ");
                                    id = Convert.ToInt16(Console.ReadLine());
                                    daoCliente.delete(id, daoVenda);
                                    break;
                                case 4:
                                    daoCliente.getAll();
                                    break;
                                case 5:
                                    Console.WriteLine("Retornando ao menu principal...");
                                    break;
                                default:
                                    Console.WriteLine("Opção Inválida...");
                                    break;

                            }

                        } while (op1 != 5);
                        break;
                    case 2:
                        do {
                            Console.WriteLine("\n==== PRODUTO ====");
                            Console.WriteLine("[1] Cadastrar Produto \t [2] Procurar Produto \t [3] Deletar Produto \t [4] Listar Produto \t [5] Sair");
                            Console.WriteLine("\n Escolha uma opcao do menu:");
                            string entrada1 = Console.ReadLine();
                            if (!int.TryParse(entrada1, out op1))
                            {
                                Console.WriteLine("\n--- Opção inválida - digite um número válido ---");
                                continue;
                            }
                            Console.WriteLine("=========================================");

                            switch (op1) {
                                case 1:
                                    Console.WriteLine("Informe o código do produto: ");
                                    id = Convert.ToInt16(Console.ReadLine());
                                    Console.WriteLine("Informe o nome do produto: ");
                                    nome = Console.ReadLine();
                                    Console.WriteLine("Informe a marca do produto: ");
                                    marca = Console.ReadLine();
                                    Console.WriteLine("Informe o modelo do produto: ");
                                    modelo = Console.ReadLine();
                                    Console.WriteLine("Informe a descrição do produto: ");
                                    descricao = Console.ReadLine();
                                    Console.WriteLine("Informe o preço do produto: ");
                                    preco = Convert.ToDouble(Console.ReadLine());
                                    Produto produto = new Produto(id, nome, marca, modelo, descricao, preco);
                                    daoProduto.create(produto);
                                    Console.WriteLine("Produto cadastrado!");
                                    break;
                                case 2:
                                    Console.WriteLine("Informe o código do produto: ");
                                    id = Convert.ToInt16(Console.ReadLine());
                                    if(daoProduto.get(id) != null){
                                        Console.WriteLine("Produto encontrado com sucesso! :D");
                                        daoProduto.printById(daoProduto.get(id).id);
                                    } else
                                        Console.WriteLine("Produto não encontrado!");
                                    break;
                                case 3:
                                    Console.WriteLine("Informe o código do produto: ");
                                    id = Convert.ToInt16(Console.ReadLine());
                                    daoProduto.delete(id, daoVenda);
                                    break;
                                case 4:
                                    daoProduto.getAll();
                                    break;
                                case 5:
                                    Console.WriteLine("Retornando ao menu principal...");
                                    break;
                                default:
                                    Console.WriteLine("Opção Inválida...");
                                    break;
                            }

                        } while (op1 != 5);
                        break;
                    case 3:
                        do {
                            Console.WriteLine("\n==== VENDA ====");
                            Console.WriteLine("[1] Registrar Venda \t [2] Procurar Venda \t [3] Atualizar Venda");
                            Console.WriteLine("\n[4] Listar Vendas \t [5] Totalizar Vendas \t [6] Sair");
                            Console.WriteLine("\n Escolha uma opcao do menu:");
                            string entrada1 = Console.ReadLine();
                            if (!int.TryParse(entrada1, out op1))
                            {
                                Console.WriteLine("\n--- Opção inválida - digite um número válido ---");
                                continue;
                            }
                            Console.WriteLine("=========================================");

                            switch (op1) {
                                case 1:
                                    Console.WriteLine("Informe o id do cliente: ");
                                    id = Convert.ToInt16(Console.ReadLine());
                                    if(daoCliente.get(id) != null) {
                                        Vendas venda = new Vendas(daoCliente.get(id));
                                        do
                                        {
                                            Console.WriteLine("Insira o código do produto: ");
                                            id = Convert.ToInt16(Console.ReadLine());
                                            if (daoProduto.get(id) != null)
                                            {
                                                venda.addProduto(daoProduto.get(id));
                                                Console.WriteLine("Produto registrado!");
                                            }
                                        } while (id != 0 && id > 0);
                                        if(venda.produtosVenda.Count == 0)
                                            Console.WriteLine("Não é possível registrar venda sem produtos...");
                                        else {
                                            daoVenda.create(venda);
                                            Console.WriteLine("Venda registrada com sucesso! ");
                                        }
                                    } else {
                                        Console.WriteLine("Cliente não encontrado! ");
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("Insira o código do produto: ");
                                    id = Convert.ToInt16(Console.ReadLine());
                                    if (daoVenda.get(id) != null)
                                    {
                                        Console.WriteLine("Venda encontrada! :D");
                                        daoVenda.printById(daoVenda.get(id).id);
                                    }
                                    else
                                        Console.WriteLine("Venda não encontrada! ");
                                    break;
                                case 3:
                                    // testar a atualização da venda
                                    // modifique essa parte se necessário
                                    Console.WriteLine("Informe o código da venda: ");
                                    id = Convert.ToInt16(Console.ReadLine());
                                    if (daoVenda.get(id) != null)
                                    {
                                        Cliente cliente = daoVenda.get(id).cliente;
                                        Vendas venda = new Vendas(cliente);
                                        do
                                        {
                                            Console.WriteLine("Insira o código do produto: ");
                                            id = Convert.ToInt16(Console.ReadLine());
                                            if (daoProduto.get(id) != null)
                                            {
                                                venda.addProduto(daoProduto.get(id));
                                                Console.WriteLine("Produto registrado!");
                                            }
                                                
                                        } while (id != 0 && id > 0);
                                        if (venda.produtosVenda.Count == 0)
                                            Console.WriteLine("Não é possível atualizar venda sem produtos...");
                                        else
                                        {
                                            if (daoVenda.update(venda) == true)
                                                Console.WriteLine("Venda atualizada com sucesso!");
                                            else
                                                Console.WriteLine("Não foi possível atualizar a venda...");
                                        }
                                    }
                                    else
                                        Console.WriteLine("Código inválido ou inexistente! ");
                                    break;
                                case 4:
                                    daoVenda.getAll();
                                    break;
                                case 5:
                                    daoVenda.getTotalizacao();
                                    break;
                                case 6:
                                    Console.WriteLine("Retornando ao menu principal...");
                                    break;
                                default:
                                    Console.WriteLine("Opção Inválida...");
                                    break;

                            }

                        } while (op1 != 6);
                        break;
                    case 4:
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    default:
                        Console.WriteLine("Opção Inválida...");
                        break;
                }
            } while (op != 4);

        }
    }
}
