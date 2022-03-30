using Bliss.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bliss.Data.Mapping
{
    public class EmailMapping : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Subject)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.To)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(c => c.Body)
                .IsRequired()
                .HasColumnType("varchar(MAX)");

            builder.Property(c => c.Send)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(c => c.Error)
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Send_At)
                .HasColumnType("datetime");

            builder.ToTable("Emails");
        }
    }
}