using Motivation.Model;

namespace Motivation.Interface
{
    public interface IQuoteRepository
    {
        Task<Quote> createQuoteAsync(Quote quote);
        Task<ICollection<Quote>> listQuotesAsync();
        Task<ICollection<Quote>> getQuotesByEmotionAsync (string emotion);
        // Task<Quote> saveQuoteAsync(Quote quote);
        //Task<bool> deleteQuoteAsync(Quote quoteId);
        //Task<Quote> retrieveByQuoteId (int quoteId);
        //get quote by emotion
        Task<string> GenerateMotivationalQuoteAsync(string emotion);
    }
}