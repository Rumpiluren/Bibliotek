﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotek.Models
{
    public class PublicationAuthor
    {
        public int PublicationId { get; set; }
        public int AuthorId { get; set; }
        public Publication Publication { get; set; }
        public Author Author { get; set; }
    }
}
