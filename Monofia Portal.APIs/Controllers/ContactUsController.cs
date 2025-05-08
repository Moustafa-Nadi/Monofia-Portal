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
        #region comment 
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ContactUs>>> GetAll() =>
        //    Ok(await _repository.GetAllAsync());

        //[HttpPost("send-message")] // POST: /api/ContactUs/send-message
        //public async Task<IActionResult> SendMessage([FromBody] ContactUsRequest request)
        //{
        //    if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Description))
        //    {
        //        return BadRequest("Email and Description are required.");
        //    }

        //    var adminEmail = "mohamedhosnymohamedbaza2021@gmail.com"; // Replace with actual admin email
        //    var subject = "New Contact Us Message";
        //    var body = $"From: {request.Email}\n\nMessage:\n{request.Description}";

        //    await _emailService.SendEmailAsync(adminEmail, subject, body);

        //    return Ok("Message sent successfully.");
        //}
        #endregion

        [HttpPost("contact-us")] // يحدد إن هذا الميثود هو endpoint من نوع POST على الرابط: /api/ContactUs/contact-us
        public async Task<IActionResult> ContactUs([FromBody] ContactUsRequest request) // بياخد البيانات المبعوتة من الفرونت (Email + Description)
        {
            // لو الإيميل أو الرسالة فاضية، يرجّع BadRequest
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Description))
                return BadRequest("Email and Description are required.");

            // إيميل الأدمن اللي هنبعت له الرسالة
            var adminEmail = "mohamedhosnymohamedbaza2021@gmail.com"; // استبدلها بإيميل الأدمن الفعلي

            // عنوان الرسالة (Subject)
            var subject = "New Contact Us Message";

            // جسم الرسالة (Body) وبيحتوي على إيميل المستخدم ورسالة التواصل
            var body = $"From: {request.Email}\n\nMessage:\n{request.Description}";

            // استدعاء خدمة الإيميل علشان تبعت الرسالة
            await _emailService.SendEmailAsync(adminEmail, subject, body);

            // يرجع رد ناجح للفرونت إنه تم إرسال الرسالة
            return Ok("Message sent successfully.");
        }

    }
}
