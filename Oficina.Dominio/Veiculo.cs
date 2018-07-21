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
    public class Veiculo
    {

        public int         Id           { get; set; }
        public string      Placa        { get; set; }
        public int         Ano          { get; set; }
        public string      Observacao   { get; set; }

        public Modelo      Modelo       { get; set; }
        public Cor         Cor          { get; set; }

        public Combustivel Combustivel  { get; set; }
        public Cambio      Cambio       { get; set; }

    }
}
