using MovieSite.Domain.Entities;
using MovieSite.Domain.ViewModels.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSite.Domain.ViewModels.FilmViewModels
{
    public class FilterFilmViewModel : SearchItems<Film>
    {
        public string FilterTitle { get; set; }
        public string FilterDirector { get; set; }
        public DateTime? FilterRegDateFrom { get; set; }
        public DateTime? FilterRegDateTo { get; set; }


    }
}
