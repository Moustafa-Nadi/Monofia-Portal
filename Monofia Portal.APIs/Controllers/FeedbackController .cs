using Menofia_Portal.Core.Entities;
using Menofia_Portal.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Monofia_Portal.APIs.Controllers
{
    public class FeedbackController : ApiBaseController
    {
        private readonly IGenericRepository<Evaluation> _evalRepo;
        private readonly IGenericRepository<Complaint> _compRepo;
        private readonly IGenericRepository<Suggestion> _suggRepo;

        public FeedbackController(IGenericRepository<Evaluation> evalRepo,
            IGenericRepository<Complaint> compRepo,
            IGenericRepository<Suggestion> suggRepo)
        {
            _evalRepo = evalRepo;
            _compRepo = compRepo;
            _suggRepo = suggRepo;
        }

        [HttpPost("Rating")] // Post : /api/Feedback/Rating
        public async Task<ActionResult<Evaluation>> CreateRate(Evaluation model)
        {
            var createdOrUpdated = _evalRepo.CreateAsync(model);
            return Ok(createdOrUpdated);
        }
        [HttpPost("complaints")] // Post : /api/Feedback/Rating
        public async Task<ActionResult<Evaluation>> AddComplaints(Complaint model)
        {
            var createdOrUpdated = _compRepo.CreateAsync(model);
            return Ok(createdOrUpdated);
        }

        [HttpPost("suggestion")] // Post : /api/Feedback/Rating
        public async Task<ActionResult<Evaluation>> AddSuggestion(Suggestion model)
        {
            var createdOrUpdated = _suggRepo.CreateAsync(model);
            return Ok(createdOrUpdated);
        }

    }
}
