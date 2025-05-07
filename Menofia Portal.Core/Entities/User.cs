using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menofia_Portal.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public ICollection<Rating> Ratings { get; set; }= new List<Rating>();
        public ICollection<Complaint> Complaints { get; set; }= new List<Complaint>();
        public ICollection<Suggestion> Suggestions { get; set; }= new List<Suggestion>();

    }
}
