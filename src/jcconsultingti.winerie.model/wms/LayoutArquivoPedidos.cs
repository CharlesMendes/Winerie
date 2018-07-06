using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace jcconsultingti.winerie.model.NaturalChoice
{
    public class LayoutArquivoPedidos
    {
        public LayoutArquivoPedidos()
        {
            listaPedidos = new List<PedidoLayout>();
            listaProdutos = new List<ProdutoLayout>();
            listaEnderecos = new List<EnderecoLayout>();
            trailler = new TraillerLayout();
        }

        public List<PedidoLayout> listaPedidos { get; set; }
        public List<ProdutoLayout> listaProdutos { get; set; }
        public List<EnderecoLayout> listaEnderecos { get; set; }
        private TraillerLayout trailler { get; set; }
    }
}
