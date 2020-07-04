using System.Security.AccessControl;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Gym.API.Domain.Models;
using Gym.API.Domain.Services;
using Gym.API.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using Gym.API.Domain.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Gym.API.Extensions;

namespace Gym.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppSettings appSettings;
        private readonly IUserRepository userRepository;
        public AuthService(IOptions<AppSettings> appSettings, IUserRepository userRepository) {
            this.appSettings = appSettings.Value;
            this.userRepository = userRepository;
        }

        public async Task<User> Authenticate(string login,
                                 string password)
        {
            var user = (await userRepository.ListAsync())
                            .SingleOrDefault(usr => usr.Login == login &&
                                                    usr.Password == password);

            if (user != null)
            {
                user.GenerateToken(appSettings.Secret, appSettings.ExpiresMinutes);
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}