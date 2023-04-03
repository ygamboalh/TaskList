using AutoMapper;
using TaskListWebApi.Dtos;
using TaskListWebApi.Models;

namespace TaskListWebApi.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TaskCreateDto, TaskList>().ForMember(dest => dest.Id,opt => opt.Ignore());
            CreateMap<TaskUpdateDto, TaskList>();
            CreateMap<TaskList, TaskToListDto>();
        }
    }
}
