using Auth.DTOs;

namespace Auth.Services.AuthService
{
    public interface IAuthService
    {
        public Task<AuthDTO> GenerateToken();
    }
}
