namespace BookStore.Blazor.Wasm.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get { return _httpClient; }
        }
    }
}
