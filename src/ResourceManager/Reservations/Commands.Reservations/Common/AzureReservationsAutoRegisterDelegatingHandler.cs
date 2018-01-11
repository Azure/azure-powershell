using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ResourceManager.Common.Properties;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Reservations.Common
{
    class AzureReservationsAutoRegisterDelegatingHandler : DelegatingHandler, ICloneable
    {
        private const short RetryCount = 10;

        private Func<ResourceManagementClient> createClient;

        private Action<string> writeDebug;

        private string providerName;

        private bool shouldRegister;

        public ResourceManagementClient ResourceManagementClient { get; set; }

        public AzureReservationsAutoRegisterDelegatingHandler(string providerName, bool shouldRegister, 
            Func<ResourceManagementClient> createClient, Action<string> writeDebug)
        {
            this.providerName = providerName;
            this.createClient = createClient;
            this.writeDebug = writeDebug;
            this.shouldRegister = shouldRegister;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                if (shouldRegister)
                {
                    ResourceManagementClient = createClient();
                    writeDebug($"Attempting to check if Subscription is registered with {providerName}");
                    var provider = ResourceManagementClient.Providers.Get(providerName);
                    if (provider.RegistrationState != RegistrationState.Registered)
                    {
                        writeDebug(string.Format(Resources.ResourceProviderRegisterAttempt, providerName));
                        short retryCount = 0;
                        do
                        {
                            if (retryCount++ > RetryCount)
                            {
                                throw new TimeoutException();
                            }
                            provider = ResourceManagementClient.Providers.Register(providerName);
                            TestMockSupport.Delay(2000);
                        } while (provider.RegistrationState != RegistrationState.Registered);
                        writeDebug(string.Format(Resources.ResourceProviderRegisterSuccessful, providerName));
                    }
                    else
                    {
                        writeDebug($"Subscription is already registered with {providerName}");
                    }
                }
            }
            catch (Exception e)
            {
                writeDebug(string.Format(Resources.ResourceProviderRegisterFailure, providerName, e.Message));

                if (e.Message?.IndexOf("does not have authorization") >= 0 && e.Message?.IndexOf("register/action",
                        StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    throw new CloudException(e.Message);
                }
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        public object Clone()
        {
            return new AzureReservationsAutoRegisterDelegatingHandler(providerName, shouldRegister, createClient, writeDebug);
        }
    }
}
