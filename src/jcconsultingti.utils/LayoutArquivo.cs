using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.utils
{
    [AttributeUsage(AttributeTargets.All)]
    public class Layout : System.Attribute
    {
        private int Inicio;
        private int Tamanho;
                
        public Layout(int Inicio, int Tamanho)
        {
            this.Inicio = Inicio;
            this.Tamanho = Tamanho;

        }
    }
}