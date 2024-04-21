using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NightWatchBackend.Communication;
using NightWatchBackend.Database;
using NightWatchBackend.Database.Models;
using System.Security.Cryptography;
using System.Text;

namespace NightWatchBackend.Repositories
{
    public class UserRepository
    {
        private readonly NightWatchDbContext context;

        public UserRepository(NightWatchDbContext context) {
            this.context = context;
        }

        internal async Task<User> GetActiveUser(LoginData data)
        {
            var inputBytes = Encoding.UTF8.GetBytes(data.Password);
            var inputHash = SHA256.HashData(inputBytes);
            var hex = Convert.ToHexString(inputHash);
            return await context.Users.FirstOrDefaultAsync(x => x.Email == data.Email.ToLower().Trim() && x.Password == hex);

        }
        internal async Task InsertUserToDb(User u)
        {
            context.Users.Add(u);
            await context.SaveChangesAsync();
        }
        
        internal async Task<List<User>> GetAllUser()
        {

            return await context.Users.Include(x => x.DislikedMovieNavigation).ToListAsync();
        }
    }
}
