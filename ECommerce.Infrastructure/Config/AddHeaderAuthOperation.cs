using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ECommerce.Infrastructure.Config
{
    public class AddHeaderAuthOperation : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext operationFilter)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            var parameter = new OpenApiParameter
            {
                Name = "x-user-id",
                In = ParameterLocation.Header,
                Description = "User ID header for the request",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            };

            operation.Parameters.Add(parameter);
        }
    }
}
