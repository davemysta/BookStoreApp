using BookStore.Blazor.Server.Services.Base;

namespace BookStore.Blazor.Server.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(LoginUserDTO loginModel);
        public Task Logout();
    }
}
