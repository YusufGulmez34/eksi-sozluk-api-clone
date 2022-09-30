using EksiSozlukAPI.Application.Features.Commands.Title.CreateTitle;

namespace EksiSozlukAPI.Application.Services
{
    public interface ITitleService
    {
        Task<CreateTitleCommandResponse> AddTitleAsync(CreateTitleCommandRequest createTitle);
    }
}
