using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSite.Domain.Entities
{
    public class FilmTag
    {
        public int FilmTagID { get; set; }
        public int FilmID { get; set; }
        public int TagID { get; set; }

        public Film Film { get; set; }
        public Tag Tag { get; set; }
    }
}
