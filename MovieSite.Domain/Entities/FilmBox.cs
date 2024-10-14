using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSite.Domain.Entities
{
    public class FilmBox
    {
        public int FilmID { get; set; }
        public int BoxID { get; set; }
        public int SortOrder { get; set; }

        public Film Film { get; set; }
        public Box Box { get; set; }
    }
}
