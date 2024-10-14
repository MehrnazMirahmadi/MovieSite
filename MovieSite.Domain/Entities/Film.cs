using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSite.Domain.Entities
{
    public class Film
    {
        public int FilmID { get; set; }
        public string FilmTitle { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public string CoverImage { get; set; }
        public long Capacity { get; set; }
        public DateTime RegDate { get; set; }
        public string FileUrl { get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }
        public string JsonLD { get; set; }
        public Guid RegisteringUserID { get; set; }
        public Guid ApprovalUserID { get; set; }
        public DateTime ApprovalDate { get; set; }

        public ICollection<FilmBox> FilmBoxes { get; set; }
        public ICollection<FilmTag> FilmTags { get; set; }
    }
}
