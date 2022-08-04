using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ManipulacaoDeArquivos
{
    public class ArquivoBinario
    {
        [System.Serializable] //Aqui informarmos que a Struct pode ser serializada
        struct Produto
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public void PrimeiroBinario()
        {
            #region Anotações | Preparação
            //Arquivos binarios > Arquivos que foram feitos para o computador ler

            //Dentro de um arquivo binário, os tipos de dados prevalecem, ex: numero é numero, letra é string, etc..

            List <string> linguagens = new List<string>()
            {
                "PHP", "C#", "JAVA", "PYTHON", "TYPESCRIP"
            };

            Produto banana = new Produto()
            {
                Id = "12345",
                Name = "Rafa"
            };
            #endregion
            //Criando o arquivo
            FileStream stream = new FileStream("MeuPrimeiroArquivoBinário", FileMode.OpenOrCreate);
            
            BinaryFormatter encoder = new BinaryFormatter();


            //ENVIANDO DADOS PRO ARQUIVO -----------------------------------------------------------
            encoder.Serialize(stream, "Rafa");
            encoder.Serialize(stream, 1234);
            encoder.Serialize(stream, false);
            encoder.Serialize(stream, linguagens);
            encoder.Serialize(stream, banana);

            //LENDO DADOS DO ARQUIVO ----------------------------------------------------------
            //É preciso saber a ordem dos tipo de dados que estão dentro do arquivo. EX:
            //1ª int, 2ª bool,3ª lista
            string texto = (string)encoder.Deserialize(stream);
            int inteiro = (int)encoder.Deserialize(stream);
            bool boleanus = (bool)encoder.Deserialize(stream);
            List<string> lista2 = (List<string>)encoder.Deserialize(stream);
            Produto prod = (Produto)encoder.Deserialize(stream);

            Console.WriteLine(texto + inteiro + boleanus + lista2[0] + prod.Name);

            stream.Close();

            //Localização > bin > debug
        }
    }
}
