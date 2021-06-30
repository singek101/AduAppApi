using Aduaba.DTO;
using Aduaba.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aduaba.Services
{
    public interface IUserServices
    {
        Task<string> RegisterAsync(RegisterRequest model);
        Task<string> UpdateAsync(UpdateRequest model);
        Task<string> DeleteAsync();
        Task<AuthenticationResponse> LoginAsync(LoginRequest model);
        Task<AuthenticationResponse> RefreshTokenAsync(string token);
        public bool RevokeRefreshToken(string token);
        //Task<string> LogoutAsync();
    }
}
