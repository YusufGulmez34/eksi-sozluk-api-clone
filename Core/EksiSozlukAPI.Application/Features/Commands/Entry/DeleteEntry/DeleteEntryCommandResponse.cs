namespace EksiSozlukAPI.Application.Features.Commands.Entry.DeleteEntry
{
    public class DeleteEntryCommandResponse : Response
    {
        public DeleteEntryCommandResponse(bool success, string message) : base(success, message)
        {
        }
    }

    public class SuccessDeleteEntryCommandResponse : DeleteEntryCommandResponse
    {
        public SuccessDeleteEntryCommandResponse(string message) : base(true, message)
        {
        }
    }

    public class ErrorDeleteEntryCommandResponse : DeleteEntryCommandResponse
    {
        public ErrorDeleteEntryCommandResponse(string message) : base(false, message)
        {
        }
    }
}