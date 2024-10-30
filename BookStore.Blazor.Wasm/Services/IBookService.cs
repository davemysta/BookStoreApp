using BookStore.Blazor.Wasm.Services.Base;

namespace BookStore.Blazor.Wasm.Services
{
    public interface IBookService
    {
        Task<Response<List<BookListItemDTO>>> GetBooks();
        Task<Response<BookDTO>> GetBook(int id);
        Task<Response<int>> CreateBook(BookDTO book);
        Task<Response<int>> EditBook(int id, BookDTO book);
        Task<Response<int>> DeleteBook(int id);
    }
}