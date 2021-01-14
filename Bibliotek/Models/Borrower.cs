using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bibliotek.Models
{
    public class Borrower
    {
        [Key]
        public int Card { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public List<Rent> Rents { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
