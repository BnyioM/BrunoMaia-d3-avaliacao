using cadastro.Interfaces;
using cadastro.Models;
using cadastro.Repositories;
using System.Data.SqlClient;
using System.IO;

namespace cadastro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Base _base = new();

            AccountRepository _account = new();

            _base.CreateFolderFile("database/access.txt");

            string option = string.Empty;

            do
            {
                Console.WriteLine("\nMenu de Login\n");
                Console.WriteLine("Escolha uma das opções abaixo:\n");
                Console.WriteLine("1 - Acessar");
                Console.WriteLine("0 - Cancelar\n");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        List<Account> accounts = _account.ReadAll();

                        Account account1 = null;

                        Console.WriteLine("\nE-mail do usuário:");
                        var email = Console.ReadLine();

                        foreach (var account in accounts)
                        {
                            if (email == account.Email)
                            {
                                account1 = account;
                            }
                        }
                        
                        if (account1 == null)
                        {
                            Console.WriteLine("\nEsta conta não está cadastrada!");
                            Console.WriteLine("Redirecionando para o menu principal...");
                            break;
                        }

                        Console.WriteLine("\nSenha:");
                        var password = Console.ReadLine();

                        if (password != account1?.Password)
                        {
                            Console.WriteLine("\nSenha inválida! Acesso negado.");
                            Console.WriteLine("Redirecionando para o menu principal...");
                            break;
                        }

                        Console.WriteLine("\nAcesso concedido!");

                        string newLine = $"O usuário {account1.Name} ({account1.IdAccount}) acessou o sistema em {DateTimeOffset.Now}";

                        Console.WriteLine(newLine + "\n");

                        List<string> allLines = _base.ReadAllLinesTXT("database/access.txt");
                        allLines.Add(newLine);
                        _base.RewriteTXT("database/access.txt", allLines);

                        string select = string.Empty;

                        do
                        {
                            Console.WriteLine("\nMenu do Sistema\n");
                            Console.WriteLine("Escolha uma das opções abaixo:\n");
                            Console.WriteLine("1 - Deslogar");
                            Console.WriteLine("0 - Encerrar sistema\n");
                            select = Console.ReadLine();

                            switch (select)
                            {
                                case "1":
                                    string newLineLogOut = $"O usuário {account1.Name} ({account1.IdAccount}) deslogou do sistema em {DateTimeOffset.Now}";

                                    Console.WriteLine(newLineLogOut + "\n");

                                    allLines = _base.ReadAllLinesTXT("database/access.txt");
                                    allLines.Add(newLineLogOut);
                                    _base.RewriteTXT("database/access.txt", allLines);
                                    break;

                                case "0":
                                    option = "0";
                                    break;

                                default:
                                    Console.WriteLine("\nOpção inválida! Tente novamente...");
                                    break;
                            }

                        } while (select != "1" && select != "0");

                        break;

                    case "0":
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida! Tente novamente...");
                        break;
                }

            } while (option != "0");

            Console.WriteLine("Aplicação encerrada.");

        }
    }
}