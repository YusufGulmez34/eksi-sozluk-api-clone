using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Features
{
    public class Response
    {
        public Response(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class SuccessResponse : Response
    {
        public SuccessResponse(string message) : base(true, message)
        {
        }
    }

    public class ErrorResponse : Response
    {
        public ErrorResponse(string message) : base(false, message)
        {
        }
    }

}
