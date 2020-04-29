using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public abstract class Entidade
    {
        private List<string> _mensagensValidacao { get; set; }
        private List<string> mensagensValidacao 
        {
            get { return _mensagensValidacao ?? (_mensagensValidacao = new List<string>()); }
        }
        protected void LimparMensagensValidacao()
        {
            mensagensValidacao.Clear();
        }

        protected void AdicionarCritica(string mensagem)
        {
            mensagensValidacao.Add(mensagem);
        }

        public string ObterMensagensValidacao()
        {
            return string.Join(". ", mensagensValidacao);
        }

        public abstract void Validate();
        public bool EhValido 
        {
            get { return !mensagensValidacao.Any(); }
        }
    }
}
