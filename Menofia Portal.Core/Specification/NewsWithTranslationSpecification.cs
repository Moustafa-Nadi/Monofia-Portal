using Menofia_Portal.Core.Entities;

namespace Menofia_Portal.Core.Specification
{
    public class NewsWithTranslationSpecification : BaseSpecification<PortalNews>
    {
        public NewsWithTranslationSpecification(DateTime? dateTime1, DateTime? dateTime2, int? id, string? search) :
            base(N => (!dateTime1.HasValue || N.Date.Date <= dateTime1.Value.Date)
            && (!dateTime2.HasValue || N.Date.Date >= dateTime2.Value.Date)
            && N.Translations.Any(T => T.LangId == id)
            && (search == null || N.Translations.Any(T => T.Header.Contains(search))))
        {
            Includes.Add(N => N.Translations.Where(T => T.LangId == id));
            Includes.Add(N => N.Images);
        }
    }
}
