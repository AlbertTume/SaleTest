using AutoMapper;
using SaliTest.Application.DTOs;
using SaliTest.Application.Interfaces;

namespace SaliTest.Application.Services
{
    public class AuthService : IAuthServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequest)
        {
            if (string.IsNullOrWhiteSpace(loginRequest.Username) || string.IsNullOrWhiteSpace(loginRequest.Password))
            {
                return new LoginResponseDto
                {
                    IsSuccess = false,
                    Message = "Username and password must be provided."
                };
            }

            var user = await _userRepository.ValidateUserAsync(loginRequest.Username, loginRequest.Password);

            if (user == null)
            {
                return new LoginResponseDto
                {
                    IsSuccess = false,
                    Message = "Invalid username or password."
                };
            }

            var response = _mapper.Map<LoginResponseDto>(user);
            response.IsSuccess = true;
            response.Message = "Login successful.";

            return response;
        }
    }
}