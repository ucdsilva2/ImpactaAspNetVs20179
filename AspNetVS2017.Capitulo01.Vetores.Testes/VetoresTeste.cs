using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AspNetVS2017.Capitulo01.Vetores.Testes
{
    [TestClass]
    public class VetoresTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            var strings = new string[10];
            strings[0] = "Vítor";

            var decimais = new decimal[] {0.5m, 1, 1.59m};

            int[] inteiros = { 1, 58, 10, 0 };

            foreach (var inteiro in inteiros)
            {
                Console.WriteLine(inteiro);
            }

            Console.WriteLine($"Tamanho do vetor: {inteiros.Length}");

            
        }

        [TestMethod]
        public void RedimensionamentoTeste()
        {
            var decimais = new decimal[] { 0.5m, 1, 1.59m };
            
            Array.Resize(ref decimais, 5);

            decimais[4] = 2.1m;
        }

        [TestMethod]
        public void OrdenacaoTeste()
        {
            var decimais = new decimal[] { 0.5m,  1.59m, 0.4m };

            Array.Sort(decimais); //CRIA UM VERTOR NOVO USANDO MEMÓRIA

            //Só funciona no contexto de teste unitário
            Assert.AreEqual(decimais[0], 0.4m); //só valida o teste se...
        }

        [TestMethod]
        public void ParamsTeste()
        {
            //var decimais = new decimal[] { 0.5m, 1, 1.59m, 0.4m };
            //Console.WriteLine(Media(decimais));

            //Params só funciona com vetor
            Console.WriteLine(Media(0.5m, 1, 1.59m, 0.4m));
        }

        //private decimal Media(decimal valor1, decimal valor2)
        //{
        //    return (valor1 + valor2) / 2;
        //}

        private decimal Media(params decimal[] valores)
        {
            //params só pode ser usado com vetores, é para digitar direto na chamada do método os números
            var soma = 0m;

            foreach (var valor in valores)
            {
                //soma = soma + valor;
                soma += valor;
            }

            return soma / valores.Length;

            //return valores.Average();
        }

        [TestMethod]
        public void TodaStringEhUmVetorTeste()
        {
            //toda string é um vetor de chars
            var nome = "Vitor";

            foreach (var caractere in nome)
            {
                Console.WriteLine(caractere);
            }

            Assert.AreEqual(nome[0], 'V');
            //Assert.AreEqual(nome.First(), 'V');

        }
    }
}
