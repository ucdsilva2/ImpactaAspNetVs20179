using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Repositorios.SistemaDeArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaDeArquivos.Tests
{
    [TestClass()]
    public class MarcaRepositorioTests
    {
        MarcaRepositorio _repositorio = new MarcaRepositorio();

        [TestMethod()]
        public void SelecionarTodosTest()
        {
            var marcas = _repositorio.Selecionar();

            Assert.IsTrue(marcas.Count > 0);
            Assert.IsTrue(marcas[0].Id == 1);

        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(-1)]
        public void SelecionarMarcaIDTest(int marcaID)
        {
            var marca = _repositorio.Selecionar(marcaID);

            if (marcaID > 0)
            {
                Assert.AreEqual(marca.Id, marcaID);
            }
            else
            {
                Assert.IsNull(marca);
            }

        }
    }
}