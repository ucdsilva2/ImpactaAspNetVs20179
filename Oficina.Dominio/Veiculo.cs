using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{
    //Classe é abstração da realiadade para o dominio da empresa
    //Internal: acessível apenas dentro do assembly (assembly: dll, exe)
    //Internal é se vc esquecer de colocar o public
    //Classe por padrão é sempre public
    public abstract class Veiculo //abstract não pode ser instanciada
    {

        private string _placa;

        public Guid        Id           { get; set; } = Guid.NewGuid();

        //propfull tab tab
        //ToDo: OO - Encapsulamento.
        public string Placa             {
                                            get { return _placa.ToUpper(); }
                                            set { _placa = value.ToUpper(); }
                                        }


        public int         Ano          { get; set; }
        public string      Observacao   { get; set; }

        public Modelo      Modelo       { get; set; }
        public Cor         Cor          { get; set; }

        public Combustivel Combustivel  { get; set; }
        public Cambio      Cambio       { get; set; }

        //abstract exige validar nos filhos
        public abstract List<string> Validar(); 

        //Método que valida esta classe (--protected só é visto pelas classes derivada por herança
        protected List<string> ValidarBase()
        {
            var erros = new List<string>();

            if (Ano <= 1950 || (Ano - DateTime.Now.Year >= 2))
            {
                erros.Add($"O ano informado {Ano} é inválido.");
            }

            return erros;
        }
    }
}
