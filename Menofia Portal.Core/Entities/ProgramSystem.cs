using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menofia_Portal.Core.Entities
{
     public class ProgramSystem
    {
        public int ProgramSystemId { get; set; }
        public string Name { get; set; }
        public int CollegeId { get; set; }
        public College College { get; set; }
        public ICollection<SystemDetail> SystemDetails { get; set; } = new List<SystemDetail>();

    }
}
