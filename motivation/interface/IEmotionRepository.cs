using Motivation.Model;

namespace Motivation.Interface
{
    public interface IEmotionRepository
    {
        Task<Emotion> createEmotionAsync(Emotion emotion);
        Task<ICollection<Emotion>> GetEmotionsAsync ();
        // Task<Emotion> saveEmotionAsync(Emotion emotion);
        Task<Emotion> GetEmotionAsync (string emotion);
    }
}