using System.Collections;

namespace EksiSozlukAPI.Application.DTOs
{
    public class PagedData<T>where T : ICollection
    {
        public int PageNumber { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public Uri? NextPage { get; set; }
        public Uri? PreviousPage { get; set; }
        public Uri? FirstPage { get; set; }
        public Uri? LastPage { get; set; }
        public T? Data { get; set; }
    }
}
