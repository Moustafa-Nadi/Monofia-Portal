using Menofia_Portal.Core.Entities;
using Menofia_Portal.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Monofia_Portal.APIs.Controllers
{
    // ENUM to categorize the message type
    public enum MessageType
    {
        Complaint,
        Suggestion,
        Evaluation
    }

    // Updated request model to include the message type
    public class ContactUsRequest
    {
        public string Email { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public MessageType Type { get; set; } // New property for message type
    }

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

        [HttpPost("contact-us")] // POST: /api/ContactUs/contact-us
        public async Task<IActionResult> ContactUs([FromBody] ContactUsRequest request)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Description))
                return BadRequest("Email and Description are required.");

<<<<<<< HEAD
            var adminEmail = "mazenkhtab11@gmail.com"; // info@menofia.edu.eg  ==> the origin link
            var subject = "New Contact Us Message";
            var body = $"From: {request.Email}\n\nMessage: {request.Description}\nRate: {request.Rate}";
=======
            // Determine the email subject based on the message type
            string subject;
            switch (request.Type)
            {
                case MessageType.Complaint:
                    subject = "New Complaint Received";
                    break;
                case MessageType.Suggestion:
                    subject = "New Suggestion Received";
                    break;
                case MessageType.Evaluation:
                    subject = "New Evaluation Received";
                    break;
                default:
                    return BadRequest("Invalid message type.");
            }
>>>>>>> 0a6bbcc1e398c260df124194bc0ca331595ae730

            // Define admin email (this could be routed to different departments based on message type)
            var adminEmail = "mazenkhtab11@gmail.com"; // In a real scenario, route to different emails based on type

            // Construct the email body, including Rate only if the type is Evaluation
            var body = $"Type: {request.Type}\nFrom: {request.Email}\n\nMessage: {request.Description}";
            if (request.Type == MessageType.Evaluation)
            {
                body += $"\nRate: {request.Rate}";
            }

            // Send the email
            await _emailService.SendEmailAsync(adminEmail, subject, body);

            return Ok("Message sent successfully.");
        }
    }
}