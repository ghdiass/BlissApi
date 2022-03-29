using Bliss.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bliss.Data.Mapping
{
    public class ChoiceMapping : IEntityTypeConfiguration<ChoiceModel>
    {
        public void Configure(EntityTypeBuilder<ChoiceModel> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Choice)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Votes)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("int");

            builder.ToTable("Choices");
        }
    }
}