using Bliss.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Bliss.Data.Mapping
{
    public class QuestionMapping : IEntityTypeConfiguration<QuestionModel>
    {
        public void Configure(EntityTypeBuilder<QuestionModel> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Question)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Image_url)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(c => c.Thumb_url)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(c => c.Published_at)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasColumnType("datetime");

            builder.Property(c => c.Update_at)
                .HasColumnType("datetime");

            builder.HasMany(f => f.Choices)
                .WithOne(p => p.Question)
                .HasForeignKey(p => p.QuestionId);

            builder.ToTable("Questions");
        }
    }
}