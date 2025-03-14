using Microsoft.EntityFrameworkCore;
using Motivation.Data;
using Motivation.Interface;
using Motivation.Model;



namespace Motivation.Repository
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly MotivateDbContext _motivateDbContext;

        private readonly OpenAiService _aiService;
        public QuoteRepository(MotivateDbContext motivateDbContext, OpenAiService aiService)
        {   
            _aiService = aiService;
            _motivateDbContext = motivateDbContext;
        }
        public async Task<Quote> createQuoteAsync(Quote quote)
        {
            await _motivateDbContext.AddAsync(quote);
            await _motivateDbContext.SaveChangesAsync();
            return quote;
        }

        public async Task<ICollection<Quote>> listQuotesAsync()
        {
            var quote = await _motivateDbContext.quotes.ToListAsync();
            return quote;

        }

        // public async Task<Quote> saveQuoteAsync(Quote quote)
        // {
        //     var save = await _motivateDbContext.SaveChangesAsync();
        //     return quote;
        // }

        public async Task<ICollection<Quote>> getQuotesByEmotionAsync(string emotion)
        {
            var result = await _motivateDbContext.quotes
            .Where(q => q.emotion.name == emotion)
            .ToListAsync();
            
            return result;
        }
        public async Task<bool> deleteQuoteAsync(Quote quote)
        {
            _motivateDbContext.quotes.Remove(quote);
            var result =  await _motivateDbContext.SaveChangesAsync();
            return result < 1? true : false;
            
        }

        public async Task<Quote> retrieveByQuoteId (int quoteId)
        {
            var quote = await _motivateDbContext.quotes.Where(q => q.Id == quoteId)
            .FirstOrDefaultAsync();
            return quote;
        }

        public async Task<string> GenerateMotivationalQuoteAsync(string emotion)
        {
            return await _aiService.GenerateMotivationalQupteAsync(emotion);
        }
    }
}