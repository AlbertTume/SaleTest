using SaliTest.Domain.Entities;

namespace SaliTest.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> ValidateUserAsync(string username, string password);
    }
}