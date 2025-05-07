using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menofia_Portal.Core.Entities
{
    public class SystemDetail
    { 
        public int SystemDetailId { get; set; }
        public string Text { get; set; }
        public int ProgramSystemId { get; set; }
        public ProgramSystem ProgramSystem { get; set; }
    }
}
