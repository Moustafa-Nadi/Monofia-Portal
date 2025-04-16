using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menofia_Portal.Core.Entities
{
    public class NewsImage
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public string NewsUrl { get; set; }

        public PortalNews PortalNews { get; set; }
    }
}
