using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Features.Queries.Title.GetTitlesByChannelId
{
    public class GetTitlesByChannelIdQueryRequest : PageFilter, IRequest<GetTitlesByChannelIdQueryResponse>
    {
        public GetTitlesByChannelIdQueryRequest():base()
        {
        }

        public GetTitlesByChannelIdQueryRequest(int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
        }

        public int ChannelId { get; set; }
    }
}
