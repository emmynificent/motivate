using Motivation.Model;

namespace Motivation.Interface
{
    public interface IQuoteRepository
    {
        Task<Quote> createQuoteAsync(Quote quote);
        Task<ICollection<Quote>> listQuotesAsync();
        // Task<Quote> saveQuoteAsync(Quote quote);
        Task<bool> deleteQuoteAsync(Quote quoteId);
        Task<ICollection<Quote>> getQuotesByEmotionAsync (string emotion);
        Task<Quote> retrieveByQuoteId (int quoteId);
        //get quote by emotion

    }
}