namespace Menofia_Portal.Core.Entities
{
    public class ContactUs : BaseEntity
    {
        public string PhoneNumber { get; set; }

        //public string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
