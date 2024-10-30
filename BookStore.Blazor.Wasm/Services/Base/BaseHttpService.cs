﻿using Blazored.LocalStorage;

namespace BookStore.Blazor.Wasm.Services.Base
{
    public class BaseHttpService
    {
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorage;
        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException apiException)
        {
            if (apiException.StatusCode == 400)
            {
                return new Response<Guid>()
                {
                    Message = "Validation errors have occured.",
                    ValidationErrors = apiException.Response,
                    Success = false
                };
            }

            if (apiException.StatusCode == 404)
            {
                return new Response<Guid>()
                {
                    Message = "The requested item could not be found",
                    Success = false
                };
            }

            if (apiException.StatusCode >= 200 && apiException.StatusCode <= 299)
            {
                return new Response<Guid>()
                {
                    Message = "Operation was successful",
                    Success = true
                };
            }

            return new Response<Guid>()
            {
                Message = "Something went wrong, please try again.",
                Success = false
            };
        }

        protected async Task GetBearerToken()
        {
            var token = await _localStorage.GetItemAsync<string>("accessToken");
            if(token != null)
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
