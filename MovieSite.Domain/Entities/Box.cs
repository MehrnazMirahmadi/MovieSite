using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSite.Domain.Entities
{
    public class Box
    {
        public int BoxID { get; set; }
        public string BoxName { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }

        public ICollection<FilmBox> FilmBoxes { get; set; }
    }
}
