using CondominioDev.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioDev.Core.Data.Mappings
{
    public class HabitanteMap : IEntityTypeConfiguration<Habitante>
    {
        public void Configure(EntityTypeBuilder<Habitante> builder)
        {
            builder.ToTable("Habitantes");

            // Opcional, pois por convenção nossa propriedade já seria a chave primária
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .IsRequired();

            builder.Property(p => p.Sobrenome)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .IsRequired();

            builder.Property(p => p.DataDeNascimento)
                   .HasColumnType("date")
                   .IsRequired(); ;

            builder.Property(p => p.Renda)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired(); ;

            builder.Property(p => p.CPF)
                   .HasColumnType("varchar(11)")
                   .IsRequired(); ;
        }
    }
}