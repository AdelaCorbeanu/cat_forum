using AutoMapper;
using cat_forum.Models;
using cat_forum.Models.DTOs;

namespace cat_forum.Helpers.Mapper
{
    public class MapperProfile : Profile 
    {
        public MapperProfile()
        {
            CreateMap<ForumPost, PostDTO>();
            CreateMap<PostDTO, ForumPost>();
        }
    }
}
