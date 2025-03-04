namespace Motivation.Model
{
    public class Quote
    {
        public int Id {get; set;}
        public string? motivation {get; set;} = "don't give up!";
        public DateTime quoteCreated {get; set;}
        public int EmotionId {get; set;}
        public Emotion? emotion{get; set;}
    }
}