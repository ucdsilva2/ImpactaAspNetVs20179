using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Repositorios.SistemaDeArquivos;
using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaDeArquivos.Tests
{
    [TestClass()]
    public class CorRepositorioTests
    {
        [TestMethod()]
        public void SelecionarTodosTest()
        {
            var corRepositorio = new CorRepositorio();

            var cores = corRepositorio.Selecionar();

            foreach (var cor in cores)
            {
                Console.WriteLine($"{cor.Id} - {cor.Nome}");
            }

        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(-1)]
        public void SelecionarCorIDTest(int CorID)
        {
            var corRepositorio = new CorRepositorio();
   
            var cor = corRepositorio.Selecionar(CorID);

            if (CorID > 0)
            {
                Assert.IsTrue(cor.Id == 1);
            }
            else
            {
                Assert.IsNull(cor);
            }
        }
    }
}