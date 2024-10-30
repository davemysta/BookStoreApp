using BookStore.Blazor.Server.Services.Base;

namespace BookStore.Blazor.Server.Services
{
    public interface IAuthorService
    {
        Task<Response<List<AuthorDTO>>> GetAuthors();
        Task<Response<AuthorDTO>> GetAuthor(int id);
        Task<Response<int>> CreateAuthor(AuthorDTO author);
        Task<Response<int>> EditAuthor(int id, AuthorDTO author);
        Task<Response<int>> DeleteAuthor(int id);
    }
}