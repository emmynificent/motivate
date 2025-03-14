using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Motivation.Data;
using Motivation.DTO;
using Motivation.Interface;
using Motivation.Model;

namespace Motivation.Controller
{
    [Route ("api/[controller]")]
    [ApiController]
    public class EmotionController : ControllerBase
    {
        private readonly MotivateDbContext _motivationDbContext;
        private readonly IEmotionRepository _emotionRepository;
        private readonly IMapper  _mapper;

        public EmotionController(MotivateDbContext motivateDbContext, IEmotionRepository emotionRepository, IMapper mapper)
        {
            _motivationDbContext = motivateDbContext;
            _emotionRepository = emotionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmotions()
        {
            var motions =  await _emotionRepository.GetEmotionsAsync();
            return Ok(motions);
        } 

        [HttpPost]
        [Route ("emotion")]
        public async Task<IActionResult> CreateEmotion (EmotionDto emotion)
        {
            
            if(emotion == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid emotion data");
            }
            // if(_emotionRepository.EmotionExistAsync(emotion))

            var createEmotion = _mapper.Map<Emotion>(emotion);
            var createdEmotion =  await _emotionRepository.createEmotionAsync(createEmotion);
            return Ok(createdEmotion);
        }

        [HttpGet ("GetEmotion")]
        public async Task<IActionResult> GetEmotion(string emotion)
        {
            if(string.IsNullOrEmpty(emotion)){
                return BadRequest("Emotion cannot be null or empty");
            }
            var motion = await _emotionRepository.GetEmotionAsync(emotion);
            return HandleEmotionResult(motion, "this emotion is yet to be identified");
       }
       private IActionResult HandleEmotionResult(Emotion emotion, string notFoundMessage){
        if(emotion ==  null)
        {
            return NotFound(notFoundMessage);
        }
        return Ok(emotion);
       }

    }
}