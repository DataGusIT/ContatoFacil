using ControleSistema.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleSistema.Data.Map
{
    public class ContatoMap : IEntityTypeConfiguration<ContatoModel>
    {
        public void Configure(EntityTypeBuilder<ContatoModel> builder)
        {
            builder.HasOne(x => x.Usuario)
             .WithMany(u => u.Contatos)
             .HasForeignKey(x => x.UsuarioId)
             .IsRequired();  // Torne o campo obrigatório se não puder ser nulo

        }
    }
}
