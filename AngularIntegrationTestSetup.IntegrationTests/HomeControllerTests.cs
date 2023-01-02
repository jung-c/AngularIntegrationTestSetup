using AngularIntegrationTestSetup.Main;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AngularIntegrationTestSetup.IntegrationTests;

public class HomeControllerTests: IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly WebApplicationFactory<Startup> _factory;

    public HomeControllerTests(WebApplicationFactory<Startup> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("/")]
    [InlineData("/fetch-data")]
    [InlineData("/weatherforecast")]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
    {
        // Arrange
        using var client = _factory.CreateClient();
            
        // Act
        using var response = await client.GetAsync(url);

        // Assert
        response.EnsureSuccessStatusCode();
    }
}