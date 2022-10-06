namespace EksiSozlukAPI.Application.Features
{
    public class PageFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PageFilter()
        {
            PageNumber = 1;
            PageSize = 3;
        }

        public PageFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber == 0 ? 1 : pageNumber;
            PageSize = pageSize;
        }
    }
}
