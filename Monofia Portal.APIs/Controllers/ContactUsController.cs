using Menofia_Portal.Core.Entities;
using Menofia_Portal.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Monofia_Portal.APIs.Controllers
{
    public class ContactUsController : ApiBaseController
    {
        private readonly IGenericRepository<ContactUs> _repository;
        private readonly IEmailService _emailService;

        public ContactUsController(
            IGenericRepository<ContactUs> repository,
            IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactUs>>> GetAll() =>
            Ok(await _repository.GetAllAsync());

        [HttpPost("send-message")] // POST: /api/ContactUs/send-message
        public async Task<IActionResult> SendMessage([FromBody] ContactUsRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Description))
            {
                return BadRequest("Email and Description are required.");
            }

            var adminEmail = "mazenkhtab11@gmail.com"; // Replace with actual admin email
            var subject = "New Contact Us Message";
            var body = $"From: {request.Email}\n\nMessage: {request.Description}\nRate: {request.Rate}";

            await _emailService.SendEmailAsync(adminEmail, subject, body);

            return Ok("Message sent successfully.");
        }
    }
}
