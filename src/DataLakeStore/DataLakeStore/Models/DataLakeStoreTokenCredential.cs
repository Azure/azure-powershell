using Azure.Core;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    public class DataLakeStoreTokenCredential : TokenCredential
    {
        private readonly IAccessToken _accessToken;

        public DataLakeStoreTokenCredential(IAzureContext context)
        {
            if (context == null || context.Account == null)
            {
                throw new InvalidOperationException("Context or Account cannot be null.");
            }

            _accessToken = AzureSession.Instance.AuthenticationFactory.Authenticate(
                context.Account,
                context.Environment,
                context.Tenant.Id,
                null,
                ShowDialog.Never,
                null,
                AzureEnvironment.Endpoint.DataLakeEndpointResourceId);
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(_accessToken.AccessToken))
            {
                throw new InvalidOperationException("Access token is null or empty.");
            }
            var expiration = DateTimeOffset.UtcNow.AddHours(1);
            return new AccessToken(_accessToken.AccessToken, expiration);
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
        }
    }
}