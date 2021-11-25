using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models
{
    public class User
    {
        //user information defined
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; }

        [Required]
        public string Email { get; set; }

        [MinLength(4), MaxLength(12)]
        [Required]
        public string Password { get; set; }
    }
}
