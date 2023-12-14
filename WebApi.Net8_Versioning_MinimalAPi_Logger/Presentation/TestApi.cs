using Carter;
using WebApi.Net8_Versioning_MinimalAPi.Abstractions;

namespace WebApi.Net8_Versioning_MinimalAPi.Presentation;

public class TestApi : ApiEndpoint, ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
    }
}