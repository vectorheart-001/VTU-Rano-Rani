using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.DTOs.UserDTO
{
    public class UserRegisterRequest
    {
        [Required]
        
        public string FirstName { get; set; }
        [Required]

        public string SecondName { get; set; }
        [Required]

        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string PersonalId { get; set; }
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Phone { get; set; }
    }
}
