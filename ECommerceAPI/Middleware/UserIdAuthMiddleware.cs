using Dapper;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;

namespace ECommerceAPI.Middleware
{
    public class UserIdAuth
    {
        private readonly RequestDelegate _next;

        public UserIdAuth(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (!httpContext.Request.Headers.ContainsKey("x-user-id"))
            {
                httpContext.Response.StatusCode = 401;
                return;
            }

            string userId = httpContext.Request.Headers["x-user-id"];
            if (!Guid.TryParse(userId, out Guid parsedUserId))
            {
                httpContext.Response.StatusCode = 401;
                return;
            }

            if (!IsValidUserId(parsedUserId))
            {
                httpContext.Response.StatusCode = 401;
                return;
            }

            await _next(httpContext);
        }


        private static bool IsValidUserId(Guid userId)
        {
            var query = "Select * From Users Where UserId = @userId";
            string conString = "server=(localdb)\\MSSQLLocalDB;database=ecommercedb;trusted_connection=true;encrypt=false";
            using var connection = new SqlConnection(conString);
            var user = connection.QueryAsync<UserEntity>(query, new { userId }).Result.FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class UserAuthExtensions
    {
        public static IApplicationBuilder UseUserAuth(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserIdAuth>();
        }
    }
}
