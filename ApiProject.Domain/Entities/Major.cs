using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Entities
{
    public class Major
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string PaymentType{get;set;}
        public int PlacesLeft { get; set; }

        
        public virtual ICollection<User>? Students { get; set; }
    }
}
