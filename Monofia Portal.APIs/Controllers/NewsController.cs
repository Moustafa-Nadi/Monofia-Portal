using AutoMapper;
using Menofia_Portal.Core.Entities;
using Menofia_Portal.Core.Interfaces;
using Menofia_Portal.Core.Specification;
using Microsoft.AspNetCore.Mvc;
using Monofia_Portal.APIs.Errors;
using Monofia_Portal.Services.DTOs;

namespace Monofia_Portal.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IGenericRepository<PortalNews> _repository;
        private readonly IMapper _mapper;

        public NewsController(IGenericRepository<PortalNews> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsDto>>> GetAll(DateTime? dateTime, int id = 1)
        {
            var spec = new NewsWithTranslationSpecification(dateTime, id);
            var news = await _repository.GetAllAsync(spec);
            var newsDto = _mapper.Map<IEnumerable<NewsDto>>(news);
            return Ok(newsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NewsDto>> GetById(int newsId, int langId = 2)
        {
            var spec = new SingleNewsWithSpecification(newsId, langId);
            var news = await _repository.GetByIdAsync(spec);
            if (news is null)
            {
                return NotFound(new ApiResponse(404));
            }
            var newsDto = _mapper.Map<NewsDto>(news);
            return Ok(newsDto);
        }
    }
}
