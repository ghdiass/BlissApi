// <auto-generated />
using System;
using Bliss.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bliss.Data.Migrations
{
    [DbContext(typeof(BlissContext))]
    [Migration("20220329151959_Add_tables_questios_choices")]
    partial class Add_tables_questios_choices
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bliss.Business.Models.ChoiceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Choice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("Votes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Choices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Choice = "Swift",
                            QuestionId = 1,
                            Votes = 0
                        },
                        new
                        {
                            Id = 2,
                            Choice = "Python",
                            QuestionId = 1,
                            Votes = 0
                        },
                        new
                        {
                            Id = 3,
                            Choice = "Objective-C",
                            QuestionId = 1,
                            Votes = 0
                        },
                        new
                        {
                            Id = 4,
                            Choice = "Ruby",
                            QuestionId = 1,
                            Votes = 0
                        });
                });

            modelBuilder.Entity("Bliss.Business.Models.QuestionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Published_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thumb_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image_url = "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                            Published_at = new DateTime(2022, 3, 29, 12, 19, 59, 54, DateTimeKind.Local).AddTicks(5711),
                            Question = "Favourite programming language?",
                            Thumb_url = "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)"
                        });
                });

            modelBuilder.Entity("Bliss.Business.Models.ChoiceModel", b =>
                {
                    b.HasOne("Bliss.Business.Models.QuestionModel", "Question")
                        .WithMany("Choices")
                        .HasForeignKey("QuestionId")
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Bliss.Business.Models.QuestionModel", b =>
                {
                    b.Navigation("Choices");
                });
#pragma warning restore 612, 618
        }
    }
}
