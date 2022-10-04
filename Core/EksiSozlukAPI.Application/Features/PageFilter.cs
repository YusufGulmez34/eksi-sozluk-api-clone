using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Features
{
    public class PageFilter
    {

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PageFilter()
        {

        }
        public PageFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber == 0 ? 1 : pageNumber;
            PageSize = pageSize;
        }
    }
}
