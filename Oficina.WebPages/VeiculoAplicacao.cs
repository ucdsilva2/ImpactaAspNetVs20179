using Oficina.Dominio;
using Oficina.Repositorios.SistemaDeArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oficina.WebPages
{
    public class VeiculoAplicacao
    {
        //Fields já instanciados, serão usados no código
        private VeiculoRepositorio _veiculoRepositorio  = new VeiculoRepositorio();
        private MarcaRepositorio   _marcaRepositorio    = new MarcaRepositorio();
        private ModeloRepositorio  _modeloRepositorio   = new ModeloRepositorio();
        private CorRepositorio     _corRepositorio      = new CorRepositorio();

        //Propriedades que serão utilizadas
        public List<Marca>          Marcas              { get; set; }
        public string               MarcaSelecionada    { get; set; }
        public List<Modelo>         Modelos             { get; set; }
        public List<Cor>            Cores               { get; set; }
        public List<Combustivel>    Combustiveis        { get; set; }
        public List<Cambio>         Cambios             { get; set; }

        //Método Contrutor
        public VeiculoAplicacao()
        {
            PopularControles();
        }
        

        //Método que popula os list para que serão usados nos combos
        public void PopularControles()
        {
            Marcas       =  _marcaRepositorio.Selecionar();
            Cores        =  _corRepositorio.Selecionar();
            Combustiveis = Enum.GetValues(typeof(Combustivel)).Cast<Combustivel>().ToList();
            Cambios      = Enum.GetValues(typeof(Cambio)).Cast<Cambio>().ToList();
        }

    }
}