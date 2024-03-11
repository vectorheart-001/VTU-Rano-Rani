using System;
using System.Collections.Generic;
using ApiProject.Domain.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using ApiProject.Domain.Enums;

namespace ApiProject.Domain.Entities
{

    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string PeronalId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
       
        public string MajorId { get; set; }
        public virtual Major? Major { get; set; }
        public RequestStatus.Status Status { get; set; }
        
    }
}
