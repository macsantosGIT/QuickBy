using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public string NumeroEndereco { get; set; }
        public int FormaPagamentoId { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }

        /// <summary>
        /// Um pedido deve ter pelo menos um Item ou varios Itens
        /// </summary>
        public virtual ICollection<ItemPedido> Itens { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (!Itens.Any())
                AdicionarCritica("Crítica - Pedido não pode ficar sem item!");

            if (string.IsNullOrEmpty(CEP))
                AdicionarCritica("Crítica - CEP não pode ser vazo!");

            if(FormaPagamentoId == 0)
                AdicionarCritica("Crítica - Não foi informada a Forma de Pagamento!");
        }
    }
}
