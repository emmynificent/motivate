using AutoMapper;
using Motivation.Model;

namespace Motivation.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Emotion, EmotionDto>();
            CreateMap<EmotionDto, Emotion>();
            CreateMap<QuoteDto, Quote>();
            CreateMap<Quote, QuoteDto>();
        }
    }
}