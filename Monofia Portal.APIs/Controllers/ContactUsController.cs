using Menofia_Portal.Core.Entities;
using Menofia_Portal.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Monofia_Portal.APIs.Controllers
{
    public class ContactUsController : ApiBaseController
    {
        private readonly IEmailService _emailService;

        public ContactUsController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send-message")] // POST: /api/ContactUs/send-message
        public async Task<IActionResult> SendMessage([FromBody] ContactUsRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Description))
            {
                return BadRequest("Email and Description are required.");
            }

            var adminEmail = "mohamedhosnymohamedbaza2021@gmail.com"; // Replace with the actual admin email
            var subject = "New Contact Us Message";
            var body = $"From: {request.Email}\n\nMessage:\n{request.Description}";

            await _emailService.SendEmailAsync(adminEmail, subject, body);

            return Ok("Message sent successfully.");
        }
    }
}
