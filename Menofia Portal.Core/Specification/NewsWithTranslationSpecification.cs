using Menofia_Portal.Core.Entities;

namespace Menofia_Portal.Core.Specification
{
    public class NewsWithTranslationSpecification : BaseSpecification<PortalNews>
    {
        public NewsWithTranslationSpecification(DateTime? dateTime, int? id, string? search) : base(N => (!dateTime.HasValue || N.Date == dateTime) && N.Translations.Any(T => T.LangId == id) && (search == null || N.Translations.Any(T => T.Header.Contains(search))))
        {
            Includes.Add(N => N.Translations.Where(T => T.LangId == id));
            Includes.Add(N => N.Images);
        }
    }
}
