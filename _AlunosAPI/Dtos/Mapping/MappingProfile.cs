using _AlunosAPI.Models;
using AutoMapper;

namespace _AlunosAPI.Dtos.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Aluno, AlunoDTO>().ReverseMap();
        }
    }
}
