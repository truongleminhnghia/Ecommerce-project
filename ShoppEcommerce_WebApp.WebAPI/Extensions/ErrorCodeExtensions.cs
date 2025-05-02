﻿using ShoppEcommerce_WebApp.Common.Exceptions;
using System.Net;

namespace ShoppEcommerce_WebApp.WebAPI.Extensions
{
    public static class ErrorCodeExtensions
    {
        private static readonly Dictionary<ErrorCode, ErrorCodeMetadata> _metadata = new()
        {
            { ErrorCode.UNAUTHORIZED, new(HttpStatusCode.Unauthorized, "Unauthorized access. Please provide valid authentication credentials.") },
            { ErrorCode.FORBIDDEN, new(HttpStatusCode.Forbidden, "Forbidden. You do not have permission to access this resource.") },
            { ErrorCode.TOKEN_EXPIRED, new(HttpStatusCode.Unauthorized, "Token has expired. Please login again.") },
            { ErrorCode.INVALID_TOKEN, new(HttpStatusCode.Unauthorized, "Invalid authentication token.") },
            { ErrorCode.INVALID_CREDENTIALS, new(HttpStatusCode.Unauthorized, "Invalid credentials provided.") },
            { ErrorCode.USER_NOT_FOUND, new(HttpStatusCode.NotFound, "User not found.") },
            { ErrorCode.INTERNAL_SERVER_ERROR, new(HttpStatusCode.InternalServerError, "An unexpected error occurred. Please try again later.") },
            { ErrorCode.EMAIL_ALREADY_EXISTS, new(HttpStatusCode.BadRequest, "Email already exists.") },
            { ErrorCode.LIST_EMPTY, new(HttpStatusCode.BadRequest, "List empty.") },
            { ErrorCode.EMAIL_DOT_NOT_EXISTS, new(HttpStatusCode.BadRequest, "Email do not exist.") },
            { ErrorCode.INVALID_PASSWORD, new(HttpStatusCode.BadRequest, "invalid password.") },
            { ErrorCode.TOKEN_NOT_NULL, new(HttpStatusCode.BadRequest, "Token must be not null.") },
            { ErrorCode.ACCOUNT_STATUS_NOT_NULL, new(HttpStatusCode.BadRequest, "Account status must be not null.") },
            { ErrorCode.ROLE_NOT_NULL, new(HttpStatusCode.BadRequest, "Role must be not null.") },
            { ErrorCode.ROLE_HAS_EXISTED, new (HttpStatusCode.NotFound, "Role has exited") },
            { ErrorCode.NOT_FOUND, new ErrorCodeMetadata(HttpStatusCode.NotFound, "Not found") },

        };

        public static string GetMessage(this ErrorCode code) => _metadata[code].Message;
        public static HttpStatusCode GetStatusCode(this ErrorCode code) => _metadata[code].StatusCode;
    }
}
