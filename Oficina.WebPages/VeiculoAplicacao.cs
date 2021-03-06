﻿using Oficina.Dominio;
using Oficina.Repositorios.SistemaDeArquivos;
using System;
using System.Collections.Generic;
using System.IO;
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
        public List<Modelo>         Modelos             { get; set; } = new List<Modelo>();
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
            Marcas              =  _marcaRepositorio.Selecionar();
            MarcaSelecionada    = HttpContext.Current.Request.QueryString["marcaId"];

            if (!string.IsNullOrEmpty(MarcaSelecionada))
            {
                Modelos = _modeloRepositorio.SelecionarPorMarca(Convert.ToInt32(MarcaSelecionada));
            }

            Cores               =  _corRepositorio.Selecionar();
            Combustiveis        = Enum.GetValues(typeof(Combustivel)).Cast<Combustivel>().ToList();
            Cambios             = Enum.GetValues(typeof(Cambio)).Cast<Cambio>().ToList();
        }

        //Método para gravar
        public void Inserir()
        {
            try
            {
                var veiculo = new VeiculoPasseio();
                var formulario = HttpContext.Current.Request.Form;

                veiculo.Ano = Convert.ToInt32(formulario["ano"]);
                veiculo.Cambio = (Cambio)Convert.ToInt32(formulario["cambio"]);
                veiculo.Combustivel = (Combustivel)Convert.ToInt32(formulario["combustivel"]);
                veiculo.Cor = _corRepositorio.Selecionar(Convert.ToInt32(formulario["cor"]));
                veiculo.Modelo = _modeloRepositorio.Selecionar(Convert.ToInt32(formulario["modelo"]));
                veiculo.Observacao = formulario["observacao"];
                veiculo.Placa = formulario["placa"];
                veiculo.Carroceria = TipoCarroceria.Hatch;

                _veiculoRepositorio.Inserir(veiculo);
            }
            catch (FileNotFoundException ex)
            {
                HttpContext.Current.Items.Add("MensagemErro", $"Arquivo {ex.FileName} não econtrado.");
                throw; //propaga o erro pra instancias superiores
            }
            catch (UnauthorizedAccessException)
            {
                HttpContext.Current.Items.Add("MensagemErro", "Arquivo sem permissão de gravação.");
                throw; //propaga o erro pra instancias superiores
            }
            catch (DirectoryNotFoundException)
            {
                HttpContext.Current.Items.Add("MensagemErro", "Caminho não encontrado.");
                throw; //propaga o erro pra instancias superiores
            }
            catch (Exception excecao)
            {
                HttpContext.Current.Items.Add("MensagemErro", "Oooops! Ocorreu um erro.");
                throw; //propaga o erro pra instancias superiores
                
                
                //throw excecao; forma de omitir os thows anteriores
                //(fazer ainda) logar o objeto excecao no banco de dados
                //log4net
            }
            finally
            {
                //é executado sempre independente de sucesso ou erro
                //é executo mesmo se tenha um return.
            }
        }
    }
}