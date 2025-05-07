using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menofia_Portal.Core.Entities
{
    public class ContactUs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
