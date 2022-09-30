using AutoMapper;
using EksiSozlukAPI.Application.Features.Commands.User.CreateUser;
using EksiSozlukAPI.Application.Repositories.User;
using EksiSozlukAPI.Application.Services.User;
using E = EksiSozlukAPI.Domain.Entities;

namespace EksiSozlukAPI.Persistence.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IMapper _mapper;


        public UserService(IUserWriteRepository userWriteRepository, IMapper mapper)
        {
            _userWriteRepository = userWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserCommandResponse> AddUserAsync(CreateUserCommandRequest createUser)
        {
            E.User user = _mapper.Map<E.User>(createUser);
            bool result = await _userWriteRepository.AddAsync(user);
            if (!result)
            {
                return new ErrorCreateUserCommandResponse("Error");
            }
            await _userWriteRepository.SaveAsync();
            return new SuccessCreateUserCommandResponse("Success");

        }
    }
}
