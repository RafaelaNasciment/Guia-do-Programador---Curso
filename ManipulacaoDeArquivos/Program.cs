using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ManipulacaoDeArquivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArquivoDeTexto arquivoDeTexto = new ArquivoDeTexto();

            arquivoDeTexto.PrimeiroArquivo();

            ArquivoBinario arquivoBinario = new ArquivoBinario();

            arquivoBinario.PrimeiroBinario();

            Console.ReadLine();
        }
    }
}
