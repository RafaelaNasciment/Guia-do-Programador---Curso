using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Projeto2
{
    public class Program
    {
        [System.Serializable]
        public struct Cliente
        {
            public string nome;
            public string email;
            public string cpf;
        }

        static List<Cliente> clientList = new List<Cliente>();
        

        enum Menu { Listagem = 1, Adicionar = 2, Remover = 3, Sair = 4}
        static void Main(string[] args)
        {
            Carregar();
            var escolheuSair = false;

            while (escolheuSair == false)
            {
                Console.WriteLine("Bem vindo! Escolha a opção desejada: ");
                Console.WriteLine("1 - Listagem\n2 - Adicionar\n3 - Remover\n4 - Sair");
                var escolha = int.Parse(Console.ReadLine());

                Menu menu = (Menu)escolha;

                switch (menu)
                {
                    case Menu.Listagem:
                        Listagem();                        
                        break;
                    case Menu.Adicionar:
                        Adicionar();
                        break;
                    case Menu.Remover:
                        Remocao();
                        break;
                    case Menu.Sair:
                        escolheuSair = true;
                        break;
                }
                Console.Clear();
            }


            void Adicionar()
            {
                Cliente cliente = new Cliente();

                Console.WriteLine("Informe o nome do cliente: ");
                cliente.nome = Console.ReadLine();

                Console.WriteLine("Informe o e-mail: ");
                cliente.email = Console.ReadLine();

                Console.WriteLine("Informe o CPF: ");
                cliente.cpf = Console.ReadLine();

                clientList.Add(cliente);
                Salvar();

                Console.WriteLine("Cliente Adicionado com sucesso!");

            }

            void Listagem()
            {
                int i = 0;
                if(clientList.Count == 0)
                {
                    Console.WriteLine("Nenhum cliente cadastrado!");
                }
                foreach(var cliente in clientList)
                {
                    Console.WriteLine("Nome: " + cliente.nome);
                    Console.WriteLine("E-mail: " + cliente.email);
                    Console.WriteLine("CPF: " + cliente.cpf);
                    Console.WriteLine("ID: " + i);
                    Console.WriteLine("-------------------------------");
                    i++;
                }

                Console.WriteLine("Todos clientes foram listados! Aperte enter para retornar ao Menu");
                Console.ReadLine(); 
            }

            void Remocao()
            {
                Listagem();

                Console.WriteLine("Informe o Id do cliente: ");
                int id = int.Parse(Console.ReadLine());

                if(id >= 0 && id <= clientList.Count)
                {
                    clientList.RemoveAt(id);
                    Salvar();
                    Console.WriteLine("Cliente Removido com sucesso!");                   
                }
                else
                {
                    Console.WriteLine("Id inválido, Pressione ENTER para tentar novamente!");
                    Console.ReadLine();
                    Console.Clear();
                    Remocao();
                }
            }

            void Salvar() 
            {
                FileStream stream = new FileStream("clients.client", FileMode.OpenOrCreate);
                BinaryFormatter enconder = new BinaryFormatter();

                enconder.Serialize(stream, clientList);

                stream.Close();
            }

            void Carregar()
            {
                FileStream stream = new FileStream("clients.client", FileMode.OpenOrCreate);
                try
                {                    
                    BinaryFormatter enconder = new BinaryFormatter();

                    clientList = (List<Cliente>)enconder.Deserialize(stream);

                    if(clientList == null)
                    {
                        clientList = new List<Cliente>();
                    }
                    
                }
                catch (Exception)
                {
                    clientList = new List<Cliente>();
                }

                stream.Close();

            }
        }
    }
}
