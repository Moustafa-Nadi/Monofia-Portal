using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menofia_Portal.Core.Entities
{
    public class Sector
    {
        public int SectorId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public ICollection<College> Colleges { get; set; } = new List<College>();
    }
}
