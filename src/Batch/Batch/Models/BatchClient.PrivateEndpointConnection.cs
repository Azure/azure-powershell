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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Properties;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Management.Batch;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        /// <summary>
        /// Lists private endpoint connections
        /// </summary>
        /// <param name="resourceGroup">The resource group</param>
        /// <param name="accountName">The account name</param>
        /// <param name="maxResults">The max results</param>
        /// <returns>The private endpoint connections</returns>
        public virtual IEnumerable<PSPrivateEndpointConnection> ListPrivateEndpointConnections(string resourceGroup, string accountName, int? maxResults = null)
        {
            if (resourceGroup == null)
            {
                throw new ArgumentNullException(nameof(resourceGroup));
            }
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            WriteVerbose(string.Format(Resources.GetPrivateEndpointConnectionNoFilter, resourceGroup, accountName));

            var result = ListAllPrivateEndpointConnections(
                resourceGroup,
                accountName,
                maxResults).Select(PSPrivateEndpointConnection.CreateFromPrivateEndpointConnection);

            return result;
        }

        public virtual PSPrivateEndpointConnection GetPrivateEndpointConnection(string resourceGroup, string accountName, string name)
        {
            if (resourceGroup == null)
            {
                throw new ArgumentNullException(nameof(resourceGroup));
            }
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            WriteVerbose(string.Format(Resources.GetPrivateEndpointConnectionByName, name));

            var result = 
                PSPrivateEndpointConnection.CreateFromPrivateEndpointConnection(
                    BatchManagementClient.PrivateEndpointConnection.Get(resourceGroup, accountName, name));

            return result;
        }

        public virtual void UpdatePrivateEndpointConnection(string resourceGroup, string accountName, string name, PrivateLinkServiceConnectionStatus status, string description)
        {
            if (resourceGroup == null)
            {
                throw new ArgumentNullException(nameof(resourceGroup));
            }
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var connection = new PrivateEndpointConnection(
                name: name,
                privateLinkServiceConnectionState: new PrivateLinkServiceConnectionState(
                    status: status,
                    description: description));

            BatchManagementClient.PrivateEndpointConnection.Update(resourceGroup, accountName, name, connection);
        }

        internal IEnumerable<PrivateEndpointConnection> ListAllPrivateEndpointConnections(string resourceGroup, string accountName, int? maxResults = null)
        {
            var privateEndpointConnections = new List<PrivateEndpointConnection>();
            var privateEndpointConnectionsPartial = BatchManagementClient.PrivateEndpointConnection.ListByBatchAccount(resourceGroup, accountName, maxResults);

            privateEndpointConnections.AddRange(privateEndpointConnectionsPartial);

            while(privateEndpointConnectionsPartial.NextPageLink != null)
            {
                privateEndpointConnectionsPartial = BatchManagementClient.PrivateEndpointConnection.ListByBatchAccountNext(privateEndpointConnectionsPartial.NextPageLink);
                privateEndpointConnections.AddRange(privateEndpointConnectionsPartial);
            }

            return privateEndpointConnections;
        }
    }
}
