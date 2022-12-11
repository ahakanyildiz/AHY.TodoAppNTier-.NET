using AHY.ToDoAppNTier.Dtos.WorkDtos;
using AHY.ToDoAppNTier.Entities.Domains;
using AutoMapper;


namespace AHY.ToDoAppNTier.Business.Mappings.AutoMapper
{
    public class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<Work, WorkListDto>().ReverseMap();
            CreateMap<Work, WorkCreateDto>().ReverseMap();
            CreateMap<Work, WorkUpdateDto>().ReverseMap();
            CreateMap<WorkListDto,WorkUpdateDto>().ReverseMap();
        }
    }
}
