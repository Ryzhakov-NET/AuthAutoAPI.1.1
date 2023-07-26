using AutoMapper;
using RegistrationAPI.Dtos.Character;
using RegistrationAPI.Models;

namespace RegistrationAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}
