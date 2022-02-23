using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.Entities
{
    public class Book
    {
        public int id_book { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public int id_genre { get; set; }
        public int numberpages { get; set; }
        public int id_editorial { get; set; }
        public int id_author { get; set; }
    }
}
