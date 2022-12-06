using AutoMapper;
using Blog.Core.DTOs;
using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.AutoMapper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {            

            CreateMap<Post, PostDto>()
                .ForMember(dto => dto.PostTags, 
                opt => opt.MapFrom(x => x.PostTags.Select(y => y.Tag)));

            CreateMap<PostCreateDto, Post>()
                .ForMember(dest => dest.PostTags,
                opt => opt.MapFrom(x => 0
                )).ReverseMap();

            //CreateMap<PostCreateDto, Post>().ReverseMap();
            CreateMap<PostUpdateDto, Post>().ReverseMap();

            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<PostTag, PostTagDto>().ReverseMap();

            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<CommentCreateDto, Comment>().ReverseMap();
            
            
        }
    }
}
