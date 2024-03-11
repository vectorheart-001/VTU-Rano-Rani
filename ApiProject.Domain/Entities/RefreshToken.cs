using ApiProject.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Entities
{
    public class RefreshToken:BaseEntity
    {
        public string Token { get; set; }
        public Guid UserId { get; set; }
        
    }
}
