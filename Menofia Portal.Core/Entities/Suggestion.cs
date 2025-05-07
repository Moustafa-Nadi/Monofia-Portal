namespace Menofia_Portal.Core.Entities
{
    public class Suggestion : BaseEntity
    {
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
