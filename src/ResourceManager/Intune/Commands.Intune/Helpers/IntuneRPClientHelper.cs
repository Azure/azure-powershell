namespace Commands.Intune.Helpers
{
    using Commands.Intune.RestClient;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Handlers;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.RestClients;
    using Microsoft.Azure.Common.Authentication;
    using Microsoft.Azure.Common.Authentication.Models;
    using System;
    using System.Net.Http;

    /// <summary>
    /// Helper class for constructing <see cref="IntuneResourceManagementClient"/>.
    /// </summary>
    internal static class IntuneRPClientHelper
    {
        /// <summary>
        /// Gets a new instance of the <see cref="IntuneResourceManagementClient"/>.
        /// </summary>
        /// <param name="context">The azure profile.</param>
        /// <param name="apiVersion">Api version of the service.</param>
        internal static IntuneResourceManagementClient GetIntuneManagementClient(AzureContext context, string apiVersion)
        {
            var endpoint = context.Environment.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager);

            if (string.IsNullOrWhiteSpace(endpoint))
            {
                throw new ApplicationException(
                    "The endpoint for the Azure Resource Manager service is not set. Please report this issue via GitHub or contact Microsoft customer support.");
            }

            var endpointUri = new Uri(endpoint, UriKind.Absolute);

            var intuneClient = new IntuneResourceManagementClient(
                 new DelegatingHandler[]
            {
                new TracingHandler(),
                new UserAgentHandler(headerValues: AzureSession.ClientFactory.UserAgents),

                // NOTE: When Tenant-Only support is given update the following AuthenticationHandler to take Tenant-creds.
                new AuthenticationHandler(cloudCredentials: AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(context)),
                // new RetryHandler(),
            }
                );

            intuneClient.BaseUri = endpointUri;
            intuneClient.ApiVersion = apiVersion;

            return intuneClient;
        }
    }
}
