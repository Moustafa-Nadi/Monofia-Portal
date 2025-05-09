using AutoMapper;
using Menofia_Portal.Core.Entities;
using Menofia_Portal.Core.Interfaces;
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
        public async Task<ActionResult<IEnumerable<NewsDto>>> GetAll(
            DateTime? dateTime1,
            DateTime? dateTime2,
            int id = 1,
            int pageSize = 5,
            int pageNumber = 1,
            string search = null)
        {
            var news = await _repository.GetAllAsync(
                N => (!dateTime2.HasValue || N.Date.Date >= dateTime2.Value.Date) &&
                    N.Translations.Any(T => T.LangId == id) &&
                    (search == null || N.Translations.Any(T => T.Header.Contains(search))),
                pageSize,
                pageNumber,
                n => n.Translations.Where(T => T.LangId == id),
                n => n.Images);

            var newsDto = _mapper.Map<IEnumerable<NewsDto>>(news);
            return Ok(newsDto);
        }

        [HttpGet("id")]
        public async Task<ActionResult<NewsDto>> GetById(int newsId, int langId = 2)
        {
            var news = await _repository.GetByIdAsync(
                n => n.News_Id == newsId,
                N => N.Translations.Where(T => T.LangId == langId),
                N => N.Images.Where(i => i.Id == newsId));
            if (news is null)
            {
                return NotFound(new ApiResponse(404));
            }
            var newsDto = _mapper.Map<NewsDto>(news);
            return Ok(newsDto);
        }
    }
}
