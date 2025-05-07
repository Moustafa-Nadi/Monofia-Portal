using Menofia_Portal.Core.Entities;
using Menofia_Portal.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Monofia_Portal.APIs.Controllers
{
    public class ContactUsController : ApiBaseController
    {
        private readonly IGenericRepository<ContactUs> _repository;

        public ContactUsController(IGenericRepository<ContactUs> repository) { _repository = repository; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactUs>>> GetAll() => Ok(await _repository.GetAllAsync());
    }
}
