using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulacaoDeArquivos
{
    public class ArquivoDeTexto
    {
        //Arquivos de textos, são arquivos que o ser humano consegue ler
        //Dentro de um arquivo de texto, tudo é convertido para string
        //Para manipular um arquivo de texto, são utilizados (inicialmente) o StreamWriter e o StreamReader

        //StreamWriter > Escrever/editar/criar um arquivo

        //StreamReader > Ler/Manipular o arquivo

        //SEMPRE fechar ao finalizar de manipular o arquivo     

        public void PrimeiroArquivo()
        {
            #region Criando um arquivo
            StreamWriter novoArquivo = new StreamWriter("primeiroArquivo.txt");
            novoArquivo.WriteLine("Primeira linha");
            novoArquivo.WriteLine("Segunda linha");
            novoArquivo.WriteLine("Terceira linha");
            novoArquivo.WriteLine("I just want to be good");

            novoArquivo.Close();    

            #endregion

            #region Abrindo esse arquivo > Linha por linha
            StreamReader conteudo = new StreamReader("primeiroArquivo.txt");

            string linha = "";

            while(linha != null)
            {
                linha = conteudo.ReadLine();
                Console.WriteLine(linha);
            }

            Console.WriteLine("Arquivo aberto!");
            #endregion

            #region Abrindo esse arquivo > Criando uma lista com ele
            StreamReader conteudo2 = new StreamReader("primeiroArquivo.txt");

            string linha2 = "";
            List<string> lista = new List<string>();    
            while(linha2 != null)
            {
                linha2 = conteudo2.ReadLine();
                lista.Add(linha2);
            }

            foreach(string palavra in lista)
            {
                Console.WriteLine(palavra);
            }

            Console.Write(lista[2]);
            #endregion

            conteudo.Close();
            conteudo2.Close();
        }

    }
}
