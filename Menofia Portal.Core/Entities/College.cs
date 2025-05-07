using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menofia_Portal.Core.Entities
{
    public class College
    {
        public int CollegeId { get; set; }
        public string Name { get; set; }
        public int SectorId { get; set; }
        public Sector Sector { get; set; }
        public ICollection<ProgramSystem> ProgramSystems { get; set; } = new List<ProgramSystem>();
    }
}
