using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using NightWatchBackend.Communication;
using NightWatchBackend.Database.Models;
using NightWatchBackend.Repositories;
using NightWatchBackend.Resources;
using System.Security.Cryptography;
using System.Text;

namespace NightWatchBackend.Services
{
    public class UserService
    {
        private readonly UserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(UserRepository userRepository,IMapper mapper) {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        internal async Task<List<UserResources>> GetAllUsers()
        {
           List<User> u = await userRepository.GetAllUser();
            return mapper.Map<List<UserResources>>(u);
            
        }

        internal async Task<User> UserReg(RegData data)
        {
            var inputBytes = Encoding.UTF8.GetBytes(data.password);
            var inputHash = SHA256.HashData(inputBytes);
            var hex = Convert.ToHexString(inputHash);

            //File.WriteAllBytes("./ProfilK/" + data.username);
            User One = new User() {  
                Email = data.email, 
                Username = data.username,
                Password = hex, 
                BirthDate = DateOnly.Parse(data.dateofbirth), 
                //ProfilePath = "./ProfilK/" + data.username, 
                CreatedOn = DateTime.UtcNow};
                await userRepository.InsertUserToDb(One);
            return One;

        }

        internal async Task<User> UsrLogin(LoginData data)
        {
            User active = await userRepository.GetActiveUser(data);

            return active;
        }
    }
}
