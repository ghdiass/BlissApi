using Bliss.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bliss.Data.Context
{
    public class BlissContext : DbContext
    {
        public BlissContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<ChoiceModel> Choices { get; set; }
        public DbSet<Email> Emails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContextOptions).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) 
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            SeedQuestion(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedQuestion(ModelBuilder builder)
        {
            var question = new QuestionModel(1,
                "Favourite programming language?",
                "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)");
            
            builder.Entity<QuestionModel>().HasData(question);

            var choices = new List<ChoiceModel>()
            {
                new ChoiceModel(1, question.Id, "Swift"),
                new ChoiceModel(2, question.Id, "Python"),
                new ChoiceModel(3, question.Id, "Objective-C"),
                new ChoiceModel(4, question.Id, "Ruby")
            };

            foreach (var choice in choices)
                builder.Entity<ChoiceModel>().HasData(choice);
        }
    }
}