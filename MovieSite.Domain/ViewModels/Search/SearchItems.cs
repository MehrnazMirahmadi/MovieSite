using MovieSite.Domain.ViewModels.Paging;

namespace MovieSite.Domain.ViewModels.Search
{
    public class SearchItems<T> : BasePaging
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public List<T> Results { get; set; }

        public SearchItems<T> SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            this.SkipEntity = paging.SkipEntity;
            this.HowManyShowPageAfterAndBefore = paging.HowManyShowPageAfterAndBefore;
            this.PageCount = paging.PageCount;
            this.TakeEntity = paging.TakeEntity;

            return this;
        }
        public SearchItems<T> SetEntity(List<T> results)
        {
            this.Results = results;
            return this;
        }
    }

}
