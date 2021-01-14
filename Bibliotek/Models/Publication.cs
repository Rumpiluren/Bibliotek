using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bibliotek.Models
{
    public class Publication
    {
        [Key]
        public int PublicationId { get; set; }
        [Required]
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public int Rating { get; set; }
        public List<PublicationAuthor> PublicationAuthors { get; set; }
    }
}
