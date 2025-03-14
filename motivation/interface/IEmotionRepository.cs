using Motivation.Model;

namespace Motivation.Interface
{
    public interface IEmotionRepository
    {
        Task<Emotion> createEmotionAsync(Emotion emotion);
        Task<ICollection<Emotion>> GetEmotionsAsync ();
        Task<Emotion> EmotionExistAsync(Emotion emotion);
        // Task<Emotion> saveEmotionAsync(Emotion emotion);
        Task<Emotion> GetEmotionAsync (string emotion);
    }
}