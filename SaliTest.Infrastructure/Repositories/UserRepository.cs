using Microsoft.EntityFrameworkCore;
using SaliTest.Application.Interfaces;
using SaliTest.Domain.Entities;

namespace SaliTest.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> ValidateUserAsync(string username, string password)
        {
            try
            {
                var usernameParam = new Npgsql.NpgsqlParameter("@p_username", username);
                var passwordParam = new Npgsql.NpgsqlParameter("@p_password", password);

                var result = await _context.Users
                    .FromSqlRaw("SELECT * FROM fn_validate_user(@p_username, @p_password)", usernameParam, passwordParam)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}