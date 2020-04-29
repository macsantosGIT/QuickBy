using QuickBuy.Dominio.Enumerados;

namespace QuickBuy.Dominio.ObjetoDeValor
{
    public class FormaPagamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool EhBoleto 
        { 
            get { return Id == (int)TipoFormaPagamento.Boleto; } 
        }
        public bool EhCartaoCredito
        {
            get { return Id == (int)TipoFormaPagamento.CartaoCredito; }
        }
        public bool EhDeposito
        {
            get { return Id == (int)TipoFormaPagamento.Deposito; }
        }
        public bool NaoFoiDefinido
        {
            get { return Id == (int)TipoFormaPagamento.NaoDefinido; }
        }


    }
}
