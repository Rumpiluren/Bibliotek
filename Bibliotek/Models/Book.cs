using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Bibliotek.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
        public List<Rent> Rents { get; set; }
        public bool Rented
        {
            get
            {
                if (Rents == null)
                    return false;
                else if (Rents.Count == 0)
                    return false;
                else if (Rents.All(r => r.Returned))
                    return false;
                else
                {
                    return true;
                }
            }
        }
    }
}
