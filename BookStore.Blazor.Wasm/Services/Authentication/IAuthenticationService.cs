using BookStore.Blazor.Wasm.Services.Base;

namespace BookStore.Blazor.Wasm.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(LoginUserDTO loginModel);
        public Task Logout();
    }
}
