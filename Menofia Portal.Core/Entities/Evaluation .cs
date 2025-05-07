namespace Menofia_Portal.Core.Entities
{
    public class Evaluation : BaseEntity
    {
        public double Rate { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
