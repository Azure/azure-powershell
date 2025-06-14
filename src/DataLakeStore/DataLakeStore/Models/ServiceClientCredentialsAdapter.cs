using Azure.Core;
using Microsoft.Rest;
using System;
using System.Threading;
using System.Threading.Tasks;

public class ServiceClientCredentialsAdapter : TokenCredential
{
    private readonly ServiceClientCredentials _serviceClientCredentials;
    private readonly string _scope;

    public ServiceClientCredentialsAdapter(ServiceClientCredentials serviceClientCredentials, string scope)
    {
        _serviceClientCredentials = serviceClientCredentials ?? throw new ArgumentNullException(nameof(serviceClientCredentials));
        _scope = scope ?? throw new ArgumentNullException(nameof(scope));
    }

    public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        throw new NotSupportedException("Synchronous token retrieval is not supported. Use GetTokenAsync instead.");
    }

    public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {

        // Always use the provided scope and ignore the incoming requestContext.Scopes
        var tokenRequestContext = new TokenRequestContext(new[] { _scope });
        return new ValueTask<AccessToken>(GetAccessTokenAsync(tokenRequestContext, cancellationToken));
    }

    private async Task<AccessToken> GetAccessTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        var httpRequest = new System.Net.Http.HttpRequestMessage();
        try
        {
            await _serviceClientCredentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during ProcessHttpRequestAsync: {ex.Message}");
            throw;
        }
        var token = httpRequest.Headers.Authorization.Parameter;
        // Use a long-lived expiration for mock purposes
        return new AccessToken(token, DateTimeOffset.MaxValue);
    }
}