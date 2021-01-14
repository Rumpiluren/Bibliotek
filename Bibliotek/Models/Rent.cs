using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bibliotek.Models
{
    public class Rent
    {
        [Key]
        public int RentId { get; set; }
        [Required]
        public DateTime RentDate { get; set; }
        [Required]
        public DateTime ReturnDate
        {
            get
            {
                return RentDate.AddDays(30);
            }
        }
        [Required]
        public int LibraryKard { get; set; }    //???
        public Borrower Borrower { get; set; }
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
        public bool Returned { get; set; }
        public int DaysOverdue
        {
            get
            {
                TimeSpan duration = DateTime.Now - ReturnDate;
                return Math.Clamp(duration.Days, 0, int.MaxValue);
            }
        }
    }
}
