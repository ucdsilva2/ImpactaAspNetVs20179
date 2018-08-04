using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{
    public class Motocicleta: Veiculo
    {
        public TipoMotocicleta Tipo { get; set; }

        //override é o abstract da classe derivada
        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
