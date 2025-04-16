namespace Monofia_Portal.Services.DTOs
{
    public class NewsDto
    {
        public int NewsId { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public bool isFeatured { get; set; }
        public IReadOnlyList<int> langId { get; set; }
        public IReadOnlyList<string> Header { get; set; }
        public IReadOnlyList<string> Abbreviation { get; set; }
        public IReadOnlyList<string> Body { get; set; }
        public IReadOnlyList<string> Images { get; set; }
    }
}
