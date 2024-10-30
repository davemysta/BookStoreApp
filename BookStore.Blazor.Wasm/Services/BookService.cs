using Blazored.LocalStorage;
using BookStore.Blazor.Wasm.Services.Base;

namespace BookStore.Blazor.Wasm.Services
{
    public class BookService : BaseHttpService, IBookService
    {
        IClient _client;

        public BookService(
            IClient client,
            ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
        }

        public async Task<Response<int>> CreateBook(BookDTO book)
        {
            Response<int> response = new();

            try
            {
                await GetBearerToken();
                await _client.BooksPOSTAsync(book);
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<int>(ex);
            }

            return response;
        }

        public async Task<Response<List<BookListItemDTO>>> GetBooks()
        {
            Response<List<BookListItemDTO>> response;

            try
            {
                await GetBearerToken();
                var data = await _client.BooksAllAsync();
                response = new Response<List<BookListItemDTO>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<List<BookListItemDTO>>(ex);
            }

            return response;
        }

        public async Task<Response<int>> EditBook(int id, BookDTO book)
        {
            Response<int> response = new();

            try
            {
                await GetBearerToken();
                await _client.BooksPUTAsync(id, book);
                response.Success = true;
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<int>(ex);
            }

            return response;
        }

        public async Task<Response<BookDTO>> GetBook(int id)
        {
            Response<BookDTO> response;

            try
            {
                await GetBearerToken();
                var data = await _client.BooksGETAsync(id);
                response = new Response<BookDTO>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<BookDTO>(ex);
            }

            return response;
        }

        public async Task<Response<int>> DeleteBook(int id)
        {
            Response<int> response = new();

            try
            {
                await GetBearerToken();
                await _client.BooksDELETEAsync(id);
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
