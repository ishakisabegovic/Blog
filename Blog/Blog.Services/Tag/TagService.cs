using AutoMapper;
using Blog.Core.DTOs;
using Blog.Core.Entities.Exceptions;
using Blog.Repositories.RepositoryManager;
using Blog.Services.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Tag
{
    public class TagService : ITagService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public TagService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagDto>> GetAllTags()
        {
            var tags = await _repository.Tag.GetAllTags();
            var mappedTags = _mapper.Map<IEnumerable<TagDto>>(tags);
            return mappedTags;
        }
    }
}
