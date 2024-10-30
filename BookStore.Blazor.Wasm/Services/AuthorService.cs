using Blazored.LocalStorage;
using BookStore.Blazor.Wasm.Services.Base;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.Blazor.Wasm.Services
{
    public class AuthorService : BaseHttpService, IAuthorService
    {
        IClient _client;

        public AuthorService(
            IClient client, 
            ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
        }

        public async Task<Response<int>> CreateAuthor(AuthorDTO author)
        {
            Response<int> response = new();

            try
            {
                await GetBearerToken();
                await _client.AuthorsPOSTAsync(author);
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<int>(ex);
            }

            return response;            
        }

        public async Task<Response<List<AuthorDTO>>> GetAuthors()
        {
            Response<List<AuthorDTO>> response;

            try
            {
                await GetBearerToken();
                var data = await _client.AuthorsAllAsync();
                response = new Response<List<AuthorDTO>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException ex) 
            {
                response = ConvertApiExceptions<List<AuthorDTO>>(ex);
            }

            return response;
        }

        public async Task<Response<int>> EditAuthor(int id,AuthorDTO author)
        {
            Response<int> response = new();

            try
            {
                await GetBearerToken();
                await _client.AuthorsPUTAsync(id, author);
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<int>(ex);
            }

            return response;
        }

        public async Task<Response<AuthorDTO>> GetAuthor(int id)
        {
            Response<AuthorDTO> response;

            try
            {
                await GetBearerToken();
                var data = await _client.AuthorsGETAsync(id);
                response = new Response<AuthorDTO>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<AuthorDTO>(ex);
            }

            return response;
        }

        public async Task<Response<int>> DeleteAuthor(int id)
        {
            Response<int> response = new();

            try
            {
                await GetBearerToken();
                await _client.AuthorsDELETEAsync(id);
                response.Success = true;
            }
            catch (ApiException ex)
            {
                response.Message = ConvertApiExceptions<int>(ex).ToString() ?? string.Empty;
            }

            return response;
        }
    }
}
