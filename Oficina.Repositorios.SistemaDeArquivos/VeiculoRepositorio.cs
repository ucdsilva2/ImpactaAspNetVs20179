﻿using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Oficina.Repositorios.SistemaDeArquivos
{
    public class VeiculoRepositorio
    {
        private string _caminhoArquivo;
        private XDocument _arquivoXml;

        //Método construtor
        public VeiculoRepositorio()
        {
            _caminhoArquivo = Path.Combine(
                                AppDomain.CurrentDomain.BaseDirectory,
                                ConfigurationManager.AppSettings["caminhoArquivoVeiculo"]);

        }
        
        //Insert
        public void Inserir<T>(T veiculo) where T: Veiculo //where T : Veiculo opcional para restringir
        {
            //<T>método genérico, em vez de receber um objeto único veiculo, recebe moto, veiculoPasseio...
            _arquivoXml = XDocument.Load(_caminhoArquivo);

            var registro = new StringWriter();
            new XmlSerializer(typeof(T)).Serialize(registro, veiculo);

            _arquivoXml.Root.Add(XElement.Parse(registro.ToString()));
            _arquivoXml.Save(_caminhoArquivo);
        }
    }
}
