using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;

namespace QuickBuy.Repositorio.Config
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            
            //Builder utiliza o padrao Fluent, ou seja, ter acesso a mais de um metodo na mesma instrucao
            //Encadeando as chamadas de outros metodos
            builder
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(50);
            
            builder
                .Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(400);
            
            builder
                .Property(p => p.Preco)
                .HasColumnType("decimal(19,4)")
                .IsRequired();
        }
    }
}
