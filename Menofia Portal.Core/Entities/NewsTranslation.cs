using System.Text.Json.Serialization;

namespace Menofia_Portal.Core.Entities
{
    public class NewsTranslation
    {
        public int Id { get; set; }

        public string Header { get; set; }

        public string Abbreviation { get; set; }

        public string Body { get; set; }

        public string Source { get; set; }

        public int LangId { get; set; }

        public string ImageAlt { get; set; }

        public int? NewsId { get; set; }

        [JsonIgnore]
        public PortalNews News { get; set; }
    }
}
