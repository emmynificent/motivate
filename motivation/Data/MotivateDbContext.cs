using Microsoft.EntityFrameworkCore;
using Motivation.Model;

namespace Motivation.Data
{
    public class MotivateDbContext: DbContext
    {
        public MotivateDbContext(DbContextOptions<MotivateDbContext> options) : base (options)
        {
            
        }

        public DbSet <Emotion> emotions {get; set;}
        public DbSet<Quote> quotes {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Emotions
            modelBuilder.Entity<Emotion>().HasData(
                new Emotion { Id = 1, name = "happy" },
                new Emotion { Id = 2, name = "sad" },
                new Emotion { Id = 3, name = "anxious" },
                new Emotion { Id = 4, name = "confident" },
                new Emotion { Id = 5, name = "stressed" }
            );

            // Seed Quotes
            modelBuilder.Entity<Quote>().HasData(
                new Quote { Id = 1, motivation = "Happiness is a journey, not a destination.", EmotionId = 1 },
                new Quote { Id = 2, motivation = "It's okay to feel sad; tomorrow is a new day.", EmotionId = 2 },
                new Quote { Id = 3, motivation = "Take a deep breath; you've got this.", EmotionId = 3 },
                new Quote { Id = 4, motivation = "Believe in yourself, and the rest will follow.", EmotionId = 4 },
                new Quote { Id = 5, motivation = "Stress is just another test to show your strength.", EmotionId = 5 }
            );
        }
    }
}