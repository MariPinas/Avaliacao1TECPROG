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

            // AUTORES: Brunno Bocardo, Flavia Goes e Mariana Pereira

            do {
                Console.Clear();
                Console.WriteLine("\n\t\t==== Sistema de Vendas ====");
                Console.WriteLine("\n [1] Cliente \t [2] Produto \t [3] Venda \t [4] Sair ");
                Console.WriteLine("\n Escolha uma opcao do menu:");
                string entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out op)) {
                    Console.WriteLine("\n--- Opção inválida - digite um número válido ---\n");
                    continue;
                }


                Console.WriteLine("\n ====================*==================== \n");

                switch (op) {
                    case 1:
                        Console.Clear();
                        do {
                            Console.WriteLine("\n\t\t\t\t\t==== CLIENTE ====");
                            Console.WriteLine("\n [1] Cadastrar Cliente \t [2] Procurar Cliente \t [3] Deletar Cliente \t [4] Listar Clientes \t [5] Sair");
                            Console.WriteLine("\n Escolha uma opcao do menu:");
                            string entrada1 = Console.ReadLine();
                            if (!int.TryParse(entrada1, out op1)) {
                                Console.WriteLine("\n--- Opção inválida - digite um número válido ---\n");
                                continue;
                            }
                            Console.WriteLine("\n ====================*==================== \n");

                            switch (op1) {
                                case 1:
                                    do {
                                        Console.WriteLine("\nInforme o nome do cliente: ");
                                        nome = Console.ReadLine();
                                        if (string.IsNullOrWhiteSpace(nome)) {
                                            Console.WriteLine("\n--- O nome não pode estar vazio. Tente novamente. ---");
                                        }
                                    } while (string.IsNullOrWhiteSpace(nome));


                                    do {
                                        Console.WriteLine("\nInforme a idade do cliente: ");
                                        entrada = Console.ReadLine();
                                        if (!int.TryParse(entrada, out idade) || idade <= 0) {
                                            Console.WriteLine("\n--- Idade inválida - digite um número inteiro válido ---");
                                        }
                                    } while (idade <= 0);


                                    do {
                                        Console.WriteLine("\nInforme o CPF do cliente: ");
                                        cpf = Console.ReadLine();
                                        if (string.IsNullOrWhiteSpace(cpf)) {
                                            Console.WriteLine("\n--- O CPF não pode estar vazio. Tente novamente. ---");
                                        }
                                    } while (string.IsNullOrWhiteSpace(cpf));

                                    Cliente cliente = new Cliente(nome, idade, cpf);
                                    daoCliente.create(cliente);
                                    Console.WriteLine("\nCliente cadastrado!");
                                    break;
                                case 2:
                                    if (daoCliente.getClienteCount() == 0) {
                                        Console.WriteLine("\nNenhum cliente foi cadastrado.");
                                        continue;
                                    }
                                    do {
                                        Console.WriteLine("Informe o código do cliente: ");
                                        entrada = Console.ReadLine();
                                        if (!int.TryParse(entrada, out id) || id <= 0) {
                                            Console.WriteLine("\n--- ID inválido - insira um valor numérico válido. ---\n");
                                        }
                                    } while (id <= 0);
                                    if (daoCliente.get(id) != null) {
                                        Console.WriteLine("\nCliente encontrado! :D");
                                        daoCliente.printById(daoCliente.get(id).id);
                                    } else
                                        Console.WriteLine("\nCliente não cadastrado! ");
                                    break;
                                case 3:
                                
                                    do {
                                        Console.WriteLine("Informe o código do cliente: ");
                                        entrada = Console.ReadLine();
                                        if (!int.TryParse(entrada, out id) || id <= 0) {
                                            Console.WriteLine("\n--- ID inválido - insira um valor numérico válido. ---\n");
                                        }
                                    } while (id <= 0);
                                    
                                    daoCliente.delete(id, daoVenda);
                                    break;
                                case 4:
                                    daoCliente.getAll();
                                    break;
                                case 5:
                                    Console.WriteLine("\nRetornando ao menu principal...");
                                    break;
                                default:
                                    Console.WriteLine("\nOpção Inválida...");
                                    break;

                            }

                        } while (op1 != 5);
                        break;
                    case 2:
                        Console.Clear();
                        do {
                            Console.WriteLine("\n\t\t\t\t\t==== PRODUTO ====");
                            Console.WriteLine("\n[1] Cadastrar Produto \t [2] Procurar Produto \t [3] Deletar Produto \t [4] Listar Produto \t [5] Sair");
                            Console.WriteLine("\n Escolha uma opção do menu:");
                            string entrada1 = Console.ReadLine();
                            if (!int.TryParse(entrada1, out op1)) {
                                Console.WriteLine("\n--- Opção inválida - digite um número válido ---\n");
                                continue;
                            }
                            Console.WriteLine("\n ====================*==================== \n");

                            switch (op1) {
                                case 1:
                                    do {
                                        Console.WriteLine("\nInforme o nome do produto: \n");
                                        nome = Console.ReadLine();
                                        if (string.IsNullOrWhiteSpace(nome)) {
                                            Console.WriteLine("\n--- O nome do produto não pode estar vazio. Tente novamente. ---\n");
                                        }
                                    } while (string.IsNullOrWhiteSpace(nome));


                                    do {
                                        Console.WriteLine("\nInforme a marca do produto: ");
                                        marca = Console.ReadLine();
                                        if (string.IsNullOrWhiteSpace(marca)) {
                                            Console.WriteLine("\n--- A marca do produto não pode estar vazia. Tente novamente. ---\n");
                                        }
                                    } while (string.IsNullOrWhiteSpace(marca));


                                    do {
                                        Console.WriteLine("\nInforme o modelo do produto: ");
                                        modelo = Console.ReadLine();
                                        if (string.IsNullOrWhiteSpace(modelo)) {
                                            Console.WriteLine("\n--- O modelo do produto não pode estar vazio. Tente novamente. ---\n");
                                        }
                                    } while (string.IsNullOrWhiteSpace(modelo));


                                    do {
                                        Console.WriteLine("\nInforme a descrição do produto: ");
                                        descricao = Console.ReadLine();
                                        if (string.IsNullOrWhiteSpace(descricao)) {
                                            Console.WriteLine("\n--- A descrição do produto não pode estar vazia. Tente novamente. ---\n");
                                        }
                                    } while (string.IsNullOrWhiteSpace(descricao));


                                    do {
                                        Console.WriteLine("\nInforme o preço do produto: ");
                                        entrada = Console.ReadLine();
                                        if (!double.TryParse(entrada, out preco) || preco <= 0) {
                                            Console.WriteLine("\n--- ID inválido - insira um valor numérico válido. ---\n");
                                        }
                                    } while (preco <= 0);
                                    Produto produto = new Produto(nome, marca, modelo, descricao, preco);
                                    daoProduto.create(produto);
                                    Console.WriteLine("Produto cadastrado!");
                                    break;
                                case 2:
                                    if (daoProduto.getProdutoCount() == 0) {
                                        Console.WriteLine("Nenhum produto foi cadastrado.");
                                        continue;
                                    }
                                    do {
                                        Console.WriteLine("Informe o código do produto: ");
                                        entrada = Console.ReadLine();
                                        if (!int.TryParse(entrada, out id) || id <= 0) {
                                            Console.WriteLine("\n--- ID inválido - insira um valor numérico válido. ---\n");
                                        }
                                    } while (id <= 0);
                                    if (daoProduto.get(id) != null) {
                                        Console.WriteLine("\nProduto encontrado com sucesso! :D\n");
                                        daoProduto.printById(daoProduto.get(id).id);
                                    } else
                                        Console.WriteLine("\nProduto não encontrado!\n");
                                    break;
                                case 3:
                                    
                                    do {
                                        Console.WriteLine("Informe o código do produto: ");
                                        entrada = Console.ReadLine();
                                        if (!int.TryParse(entrada, out id) || id <= 0) {
                                            Console.WriteLine("\n--- ID inválido - insira um valor numérico válido. ---\n");
                                        }
                                    } while (id <= 0);
                                    daoProduto.delete(id, daoVenda);
                                    break;
                                case 4:
                                    daoProduto.getAll();
                                    break;
                                case 5:
                                    Console.WriteLine("\nRetornando ao menu principal...");
                                    break;
                                default:
                                    Console.WriteLine("\nOpção Inválida...");
                                    break;
                            }

                        } while (op1 != 5);
                        break;
                    case 3:
                        Console.Clear();
                        do {
                            Console.WriteLine("\n\t\t\t==== VENDA ====");
                            Console.WriteLine("\n\t[1] Registrar Venda\t[2] Procurar Venda");
                            Console.WriteLine("\n[3] Listar Vendas\t[4] Totalizar Vendas \t [5] Sair");
                            Console.WriteLine("\n Escolha uma opção do menu:");
                            string entrada1 = Console.ReadLine();
                            if (!int.TryParse(entrada1, out op1)) {
                                Console.WriteLine("\n--- Opção inválida - digite um número válido ---\n");
                                continue;
                            }
                            Console.WriteLine("\n ====================*==================== \n");
                            switch (op1) {
                                case 1:

                                    if (daoCliente.getClienteCount() == 0 || daoProduto.getProdutoCount() == 0) {
                                        Console.WriteLine("\n\nNenhum cliente ou produto cadastrado. Não é possível realizar vendas.");
                                        continue;
                                    }
                                    bool adicionouAlgo = false;
                                    int op2 = 0;
                                    int idProduto;
                                    do {
                                        Console.WriteLine("\nInforme o id do cliente: ");
                                        entrada = Console.ReadLine();
                                        if (!int.TryParse(entrada, out id) || id <= 0) {
                                            Console.WriteLine("\n--- ID inválido - insira um valor numérico válido. ---\n");
                                        }
                                    } while (id <= 0);
                                    Cliente clienteVenda = daoCliente.get(id);
                                    if (clienteVenda != null) {
                                        Vendas venda = new Vendas(clienteVenda);
                                        do {
                                            Console.WriteLine("\n" + clienteVenda.nome + ", escolha uma opção: ");
                                            Console.WriteLine("[1] Listar produtos \t [2] Adicionar produto no carrinho \t [3] Visualizar Carrinho \t [4]Cancelar compra");
                                            if (adicionouAlgo) {
                                                Console.WriteLine("[5] Finalizar compra");
                                            }
                                            op2 = Convert.ToInt16(Console.ReadLine());

                                            switch (op2) {
                                                case 1:
                                                    daoProduto.getAll();
                                                    break;
                                                case 2:
                                                    do {
                                                        Console.WriteLine("\nInsira o código do produto: ");
                                                        entrada = Console.ReadLine();
                                                        if (!int.TryParse(entrada, out idProduto) || idProduto <= 0) {
                                                            Console.WriteLine("\n--- ID inválido - insira um valor numérico válido. ---\n");
                                                        }
                                                    } while (idProduto <= 0);
                                                             
                                                    Produto produto = daoProduto.get(idProduto);
                                                    if (produto != null) {
                                                        venda.addProduto(produto);
                                                        Console.WriteLine("\n" + produto.nome + " foi adicionado ao carrinho!");
                                                        adicionouAlgo = true;
                                                    } else {
                                                        Console.WriteLine("Produto não encontrado");
                                                    }
                                                    break;
                                                case 3:
                                                    Console.WriteLine($"\n--* Carrinho de {clienteVenda.nome} *--\n");
                                                    if (venda.produtosVenda.Count == 0) {
                                                        Console.WriteLine("\nHm... O carrinho parece estar vazio, adicione algum produto! :D\n"); 
                                                    } else {
                                                        venda.ExibirCarrinho();
                                                    }
                                                    break;
                                                case 4:
                                                    Console.WriteLine("\n\nCompra cancelada");
                                                    break;
                                                case 5:
                                                    if (venda.produtosVenda.Count == 0) {
                                                        Console.WriteLine("\nEspertinho... adicione algo no carrinho para finalizar a compra\n");
                                                        op2 = 0;
                                                        break;
                                                    }
                                                    daoVenda.create(venda);
                                                    Console.WriteLine("Obrigado!! Volte sempre! :D");
                                                    break;
                                                default:
                                                    Console.WriteLine("Opção Inválida...");
                                                    break;
                                            }

                                        } while (op2 != 4 && op2 != 5);
                                    } else {
                                        Console.WriteLine("Cliente não encontrado! ");
                                    }
                                    break;
                                case 2:
                                    if (daoVenda.getVendaCount() == 0) {
                                        Console.WriteLine("Nenhuma venda foi realizada.");
                                        continue;
                                    }
                                    do {
                                        Console.WriteLine("Informe o código da venda: ");
                                        entrada = Console.ReadLine();
                                        if (!int.TryParse(entrada, out id) || id <= 0) {
                                            Console.WriteLine("\n--- ID inválido - insira um valor numérico válido. ---\n");
                                        }
                                    } while (id <= 0);
                                    if (daoVenda.get(id) != null) {
                                        Console.WriteLine("\nVenda encontrada! :D");
                                        daoVenda.printById(daoVenda.get(id).id);
                                    } else
                                        Console.WriteLine("\nVenda não encontrada! ");
                                    break;
                                case 3:
                                    daoVenda.getAll();
                                    break;
                                case 4:
                                    daoVenda.getTotalizacao();
                                    break;
                                case 5:
                                    Console.WriteLine("\nRetornando ao menu principal...");
                                    break;
                                default:
                                    Console.WriteLine("\nOpção Inválida...");
                                    break;

                            }

                        } while (op1 != 5);
                        break;
                    case 4:
                        Console.WriteLine("\nEncerrando o programa...");
                        break;
                    default:
                        Console.WriteLine("\nOpção Inválida...");
                        break;
                }
            } while (op != 4);

        }
    }
}
