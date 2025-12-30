using SaliTest.Application.DTOs;

namespace SaliTest.Application.Interfaces
{
    public interface IAuthServices
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
    }
}