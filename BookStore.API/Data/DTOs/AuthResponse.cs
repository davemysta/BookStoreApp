﻿namespace BookStore.API.Data.DTOs
{
    public class AuthResponse
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
