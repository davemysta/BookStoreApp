namespace BookStore.Blazor.Wasm.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}
