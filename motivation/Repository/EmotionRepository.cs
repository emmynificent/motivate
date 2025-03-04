using Microsoft.EntityFrameworkCore;
using Motivation.Data;
using Motivation.Interface;
using Motivation.Model;

namespace Motivation.Repository
{
    public class EmotionRepository : IEmotionRepository
    {
        private readonly MotivateDbContext _motivateDbContext;
        public EmotionRepository(MotivateDbContext motivateDbContext)
        {
            _motivateDbContext = motivateDbContext;
        }

        public async Task<Emotion> createEmotionAsync(Emotion emotion)
        {
            await _motivateDbContext.AddAsync(emotion);
            await _motivateDbContext.SaveChangesAsync();
            return emotion;
        }

        public async Task<ICollection<Emotion>> GetEmotionsAsync()
        {
            var motion = await _motivateDbContext.emotions.ToListAsync();
            return motion;
        }

        // public async Task<Emotion> saveEmotionAsync(Emotion emotion)
        // {
        //     var save = await _motivateDbContext.SaveChangesAsync();
        //     return emotion;
        // }

        public async Task<Emotion> GetEmotionAsync(string emotion)
        {
            var motion = await _motivateDbContext.emotions.FirstOrDefaultAsync(e => e.name == emotion);
            return motion;
        }
    }
}