using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<String> teste = new List<String>();
            teste.Add("Victor");
            teste.Add("José");
            teste.Add("Jorge");
            teste.Add("Junior");
            teste.Add("Jarvan");
            var cliente = "Bruno";
            teste.Add(cliente);

            //Usa-se array quando sabe EXATAMENTE a quantidade de dados que deseja armanezar.

            //Usa-se lista quando não souber o numero de dados que precisa armanezar.

            //Acessando um elemento na lista, de acordo com o indice
            var quantidadeLista = teste.Count();

            Console.WriteLine("Elementos na lista: " + quantidadeLista);
            Console.WriteLine(teste[2]);

            //Editando um valor dentro da lista pelo indice
            teste[2] = "Bruno Henrique";

            Console.WriteLine(teste[2]);

            #region Visualizando todos elementos em uma lista
            Console.WriteLine("Apresentando nomes na lista");
            foreach (var elementos in teste)
            {
                Console.Write(elementos + ",");
            }
            Console.WriteLine();
            #endregion

            #region REMOVE
            Console.WriteLine("Removendo o Bruno Henrique");

            teste.RemoveAt(2); //Remove de acordo com o indice que eu informar;

            var quantidadeLista2 = teste.Count();
            Console.WriteLine("Elementos na lista: " + quantidadeLista2);

            Console.WriteLine("Apresentando nomes na lista após remoção");
            foreach (var elementos in teste)
            {
                Console.Write(elementos + ",");
            }
            Console.WriteLine();


            #endregion
            //OBS: REMOVEALL É MAIS PESADO QUE REMOVEAT, POIS PERCORRE A LISTA INTEIRA.
            #region REMOVENDO PELO CONTEUDO SEM SABER O INDICE
            //Predicado = Frase que iremos enviar para o C#, e o C# vai testar a frase para cada elemento dentro da lista. E se localizado, irá remover

            teste.RemoveAll(bunda => bunda == "José"); //Remove todos elementos que são iguais ao informado

            Console.WriteLine("Removendo todos tipos José");
            foreach (var elementos in teste)
            {
                Console.Write(elementos + ",");
            }
            Console.WriteLine();
            #endregion

            #region Localizando um elemento dentro de uma lista
            //FindAll > achar mais de 1 dado 
            // Find >> Achar 1 dado (Busca o PRIMEIRO elemento dentro da lista correspondente ao solicitado, o primeiroo only)
            //Recebe um predicado
            var busca = teste.Find(bunda => bunda == "Victor");
            var buscaTamanho = teste.Find(bunda => bunda.Length > 3);

            List<string> buscaAll = teste.FindAll(bunda => bunda.Length > 3); //O List<string> é porque ele retorna uma lista de resultados!
            Console.WriteLine();
            Console.WriteLine("Buscando....");
            Console.WriteLine("Find:" + busca);
            Console.WriteLine("FindLength:" + buscaTamanho);

            foreach (var nome in buscaAll)
            {
                Console.WriteLine("FindAll:" + nome);
            }

            #endregion


            Console.ReadLine();
        }
    }
}