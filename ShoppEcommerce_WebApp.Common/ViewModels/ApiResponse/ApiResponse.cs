﻿
namespace ShoppEcommerce_WebApp.Common.ViewModels.ApiResponse
{
    public class ApiResponse
    {
        public int Code { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
