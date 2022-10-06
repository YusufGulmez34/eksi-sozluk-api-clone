using EksiSozlukAPI.Application.DTOs;
using EksiSozlukAPI.Application.Features;
using System.Collections;

namespace EksiSozlukAPI.Persistence.Services
{
    public static class UrlGenerationService
    {
        public static PagedData<T> UrlGenerator<T>(string baseUrl, PageFilter request, int totalCount) where T : ICollection
        {
            PagedData<T> pagedData = new PagedData<T>();

            pagedData.PageNumber = request.PageNumber;

            pagedData.TotalPages = (totalCount % request.PageSize) > 0
                                    ? totalCount / request.PageSize + 1
                                    : totalCount / request.PageSize;

            pagedData.FirstPage = pagedData.PageNumber == 1
                                    ? null
                                    : GenerateUri(baseUrl,  request.PageSize, 1);

            pagedData.NextPage = pagedData.PageNumber == pagedData.TotalPages
                                    ? null
                                    : GenerateUri(baseUrl, request.PageSize, pagedData.PageNumber + 1);

            pagedData.PreviousPage = pagedData.PageNumber == 1
                                    ? null
                                    : GenerateUri(baseUrl, request.PageSize, pagedData.PageNumber - 1);

            pagedData.LastPage = pagedData.PageNumber == pagedData.TotalPages
                                    ? null
                                    : GenerateUri(baseUrl, request.PageSize, pagedData.TotalPages);
            return pagedData;
        }
        public static Uri GenerateUri(string baseUrl,  int pageSize, int pageNumber)
        {
            return new Uri(baseUrl += $"PageSize={pageSize}&PageNumber={pageNumber}");
        }
    }
}
