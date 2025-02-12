using System.IO.Abstractions.TestingHelpers;
using AzDev.Models.Inventory;

namespace AzDev.Tests;

public class SwaggerTests
{
    [Fact]
    public void CanParseSwaggerJson()
    {
        var uri = "$(repo)/specification/dnsresolver/resource-manager/Microsoft.Network/stable/2022-07-01/dnsresolver.json";
        var commit = "commit_hash";
        var swagger = new SwaggerReference(uri, commit);
        Assert.Equal(uri, swagger.RawUri);
        Assert.Equal($"https://github.com/Azure/azure-rest-api-specs/blob/{commit}/specification/dnsresolver/resource-manager/Microsoft.Network/stable/2022-07-01/dnsresolver.json", swagger.Uri);
    }

    [Fact]
    public void CanParseSwaggerReadme()
    {
        var uri = "$(repo)/specification/servicenetworking/resource-manager/readme.md";
        var commit = "commit_hash";
        var swagger = new SwaggerReference(uri, commit);
        Assert.Equal(uri, swagger.RawUri);
        Assert.Equal($"https://github.com/Azure/azure-rest-api-specs/blob/{commit}/specification/servicenetworking/resource-manager/readme.md", swagger.Uri);
    }
}
