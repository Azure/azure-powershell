// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Azure;
using Azure.Analytics.Synapse.ManagedPrivateEndpoints;
using Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.Rest.Azure;
using System;
using System.IO;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseManagedPrivateEndpointsClient
    {
        private readonly ManagedPrivateEndpointsClient _managedPrivateEndpointClient;

        public SynapseManagedPrivateEndpointsClient(String workspaceName, IAzureContext context)
        {
            if (context == null)
            {
                throw new AzPSInvalidOperationException(Resources.InvalidDefaultSubscription);
            }

            string suffix = context.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix);
            Uri uri = new Uri("https://" + workspaceName + "." + suffix);
            _managedPrivateEndpointClient = new ManagedPrivateEndpointsClient(uri, new AzureSessionCredential(context));
        }

        public ManagedPrivateEndpoint CreateManagedPrivateEndpoint(string managedPrivateEndpointName, string rawJsonContent, string managedVirtualNetworkName = "default")
        {
            ManagedPrivateEndpoint managedPrivateEndpoint = JsonConvert.DeserializeObject<ManagedPrivateEndpoint>(rawJsonContent);
            var operation = _managedPrivateEndpointClient.Create(managedPrivateEndpointName, managedPrivateEndpoint, managedVirtualNetworkName);
            return operation.Value;
        }

        public void DeleteManagedPrivateEndpoint(string managedPrivateEndpointName, string managedVirtualNetworkName = "default")
        {
            _managedPrivateEndpointClient.Delete(managedPrivateEndpointName, managedVirtualNetworkName);
        }

        public ManagedPrivateEndpoint GetManagedPrivateEndpoint(string managedPrivateEndpointName, string managedVirtualNetworkName = "default")
        {
            var opration = _managedPrivateEndpointClient.Get(managedPrivateEndpointName, managedVirtualNetworkName);
            return opration.Value;            
        }

        public Pageable<ManagedPrivateEndpoint> ListManagedPrivateEndpoints(string managedVirtualNetworkName = "default")
        {
            var endpoints = _managedPrivateEndpointClient.List(managedVirtualNetworkName);
            return endpoints;
        }

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
    }
}
