using Menofia_Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menofia_Portal.Core.Specification
{
    public class SingleNewsWithSpecification : BaseSpecification<PortalNews>
    {
        public SingleNewsWithSpecification(int newsId, int langId) : base(N => N.News_Id == newsId)
        {
            Includes.Add(N => N.Translations.Where(T => T.LangId == langId));
            Includes.Add(N => N.Images);
        }
    }
}
