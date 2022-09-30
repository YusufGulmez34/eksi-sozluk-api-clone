namespace EksiSozlukAPI.Application.Features
{
    public class ResponseData<T> : Response where T : class
    {
        public T Data { get; set; }
        public ResponseData(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
    }

    public class SuccessResponseData<T> : ResponseData<T> where T : class
    {
        public SuccessResponseData(T data, string message) : base(data, true, message)
        {
        }
    }

}
