using EksiSozlukAPI.Application.Features.Commands.Entry.CreateEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Services
{
    public interface IEntryService
    {
        Task<CreateEntryCommandResponse> AddEntryAsync(CreateEntryCommandRequest request); 
    }
}
