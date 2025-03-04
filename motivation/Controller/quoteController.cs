using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Motivation.Data;
using Motivation.DTO;
using Motivation.Interface;
using Motivation.Model;
using Motivation.Repository;

namespace Motivation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class quoteController:ControllerBase
    {
        private readonly MotivateDbContext _motivateDbContext;
        private readonly IQuoteRepository _quoteRpository;
        private readonly IMapper _mapper;
        public quoteController(MotivateDbContext motivateDbContext, IQuoteRepository quoteRepository, IMapper mapper)
        {
            _motivateDbContext = motivateDbContext;
            _quoteRpository = quoteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuotes()
        {
            var quotes = await _quoteRpository.listQuotesAsync();
            return Ok(quotes);
        }

        [HttpGet ("retrieveQuote")]
        public async Task<IActionResult> RetrieveByQuote(int quoteId)
        {
           var(isValid, errorResult) = ValidateQuoteId(quoteId);
           if(!isValid)
           {
            return errorResult;
           }
           var quote = await _quoteRpository.retrieveByQuoteId(quoteId);
           return HandleQuoteResult(quote, "Quote does not seem to exist");
        }

        [HttpPost("createquote")]
        public async Task<IActionResult> CreateQuote(QuoteDto quote)
        {
            if(quote == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var createquote = _mapper.Map<Quote>(quote);
            var motivate = await _quoteRpository.createQuoteAsync(createquote);
            return Ok(motivate);
        }

        [HttpPost("deletequote")]
        public async Task<IActionResult> deleteQuote (int quoteId)
        {
            var (isValid, errorResult) = ValidateQuoteId(quoteId);
            if(!isValid)
            {
                return errorResult;
            }
            var quote = await _quoteRpository.retrieveByQuoteId(quoteId);
            if(quote == null){
                return NotFound("Check the Id Shared error");
            }
            await _quoteRpository.deleteQuoteAsync(quote);
            return NoContent();
        }

        //get quote by emotion
        [HttpGet("quoteByEmotion")]
        public async Task <IActionResult> GetQuoteByEmotion(string emotion)
        {
            if(emotion == null)
            {
                return BadRequest("does not exist");
            }
            var quote = await _quoteRpository.getQuotesByEmotionAsync(emotion);
            if(quote == null)
            {
                return NotFound(" there's not quote for this emotion ");
            }
            return Ok(quote);
        }
        private (bool isValid, IActionResult? errorResult) ValidateQuoteId(int quoteId)
        {
            if(quoteId <= 0){
                return(false, BadRequest("Invalid quoteId"));
            }
            return (true, null);
        }
        private IActionResult HandleQuoteResult(Quote quote, string notFoundMessage)
        {
            if(quote == null){
                return NotFound(notFoundMessage);
            }
            return Ok(quote);
        }

    }
   
}