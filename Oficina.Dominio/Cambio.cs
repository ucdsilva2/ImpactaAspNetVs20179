using System.ComponentModel;

namespace Oficina.Dominio
{
    public enum Cambio
    {
        Manual       = 1,
            [Description("Automático")] //atributo
            Automatico   = 2,
        Automatizado = 3
    }
}