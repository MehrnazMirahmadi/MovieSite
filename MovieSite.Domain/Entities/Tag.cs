using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSite.Domain.Entities
{
    public class Tag
    {
        public int TagID { get; set; }
        public string TagText { get; set; }
        public DateTime RegDate { get; set; }
        public Guid RegisteringUserID { get; set; }
        public Guid ApprovalUserID { get; set; }

        public ICollection<FilmTag> FilmTags { get; set; }
    }
}
