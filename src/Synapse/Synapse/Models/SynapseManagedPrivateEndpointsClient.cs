using Azure;
using Azure.Analytics.Synapse.ManagedPrivateEndpoints;
using Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Properties;
using System;
using System.IO;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseManagedPrivateEndpointsClient
    {
        private readonly ManagedPrivateEndpointsClient _ManagedPrivateEndpointClient;

        public SynapseManagedPrivateEndpointsClient(String workspaceName, IAzureContext context)
        {
            if (context == null)
            {
                throw new AzPSInvalidOperationException(Resources.InvalidDefaultSubscription);
            }

            string suffix = context.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix);
            Uri uri = new Uri("https://" + workspaceName + "." + suffix);
            _ManagedPrivateEndpointClient = new ManagedPrivateEndpointsClient(uri, new AzureSessionCredential(context));
        }

        #region Managed Private Endpoint

        public ManagedPrivateEndpoint CreateManagedPrivateEndpoint(string managedPrivateEndpointName, string rawJsonContent, string managedVirtualNetworkName = "default")
        {
            ManagedPrivateEndpoint managedPrivateEndpoint = JsonConvert.DeserializeObject<ManagedPrivateEndpoint>(rawJsonContent);
            var operation = _ManagedPrivateEndpointClient.Create(managedPrivateEndpointName, managedPrivateEndpoint, managedVirtualNetworkName);
            return operation.Value;
        }

        public void DeleteManagedPrivateEndpoint(string managedPrivateEndpointName, string managedVirtualNetworkName = "default")
        {
            _ManagedPrivateEndpointClient.Delete(managedPrivateEndpointName, managedVirtualNetworkName);
        }

        public ManagedPrivateEndpoint GetManagedPrivateEndpoint(string managedPrivateEndpointName, string managedVirtualNetworkName = "default")
        {
            var opration =  _ManagedPrivateEndpointClient.Get(managedPrivateEndpointName, managedVirtualNetworkName);
            return opration.Value;
        }

        public Pageable<ManagedPrivateEndpoint> ListManagedPrivateEndpoints(string managedVirtualNetworkName = "default")
        {  
            var endpoints = _ManagedPrivateEndpointClient.List(managedVirtualNetworkName);
            return endpoints;
        }


        #endregion

        #region helper
        public virtual string ReadJsonFileContent(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            using (TextReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
        #endregion

    }
}
