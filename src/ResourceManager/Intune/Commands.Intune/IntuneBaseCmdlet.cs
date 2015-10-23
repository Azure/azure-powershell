namespace Commands.Intune
{
    using System;
    using System.Net.Http;
    using RestClient;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Common.Authentication.Models;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Handlers;
    using Microsoft.Azure.Common.Authentication;
    using System.Collections.Concurrent;
    using System.Management.Automation;

    public abstract class IntuneBaseCmdlet: AzureRMCmdlet
    {
                /// <summary>
        /// Contains the errors that encountered while satisfying the request.
        /// </summary>
        internal static readonly ConcurrentBag<ErrorRecord> errors = new ConcurrentBag<ErrorRecord>();

        private static IntuneResourceManagementClient _intuneClient;

        internal IntuneResourceManagementClient IntuneClient
        {
            get
            {
                if(_intuneClient == null)
                {
                    _intuneClient = GetIntuneManagementClient(this.DefaultContext);
                }
                return _intuneClient;
            }
            set
            {
                this.IntuneClient = value;
            }
        }

        private string _asuHostName;
        internal string AsuHostName
        {
            get
            {
                if (_asuHostName == null)
                {
                    var location = IntuneClient.GetLocationByHostName();
                    _asuHostName = location.Properties.HostName;                    
                }

                return _asuHostName;
            }
        }
        /// <summary>
        /// Gets a new instance of the <see cref="IntuneResourceManagementClient"/>.
        /// </summary>
        /// <param name="context">The azure profile.</param>
        internal static IntuneResourceManagementClient GetIntuneManagementClient(AzureContext context)
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
                    new RetryHandler()
                });

            intuneClient.BaseUri = endpointUri;
            intuneClient.ApiVersion = IntuneConstants.ApiVersion;

            return intuneClient;
        }

        /// <summary>
        /// Writes te error records to console
        /// </summary>
        internal void WriteErrors()
        {
            if (errors.Count != 0)
            {
                foreach (var error in errors)
                {
                    base.WriteError(error);
                }
            }
        }

        /// <summary>
        /// Reusable function for executing actions by all commandlets
        /// </summary>
        /// <param name="action"></param>
        internal void SafeExecutor(Action action)
        {
            try
            {
                action();
            }
            catch(Exception e)
            {                
                this.WriteErrors();
                throw e;
            }
        }
    }
}
