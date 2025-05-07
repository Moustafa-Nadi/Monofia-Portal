namespace Menofia_Portal.Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public Evaluation Evaluation { get; set; }

        public ICollection<Complaint> Complaints { get; set; } = [];

        public ICollection<Suggestion> Suggestions { get; set; } = [];
    }
}
