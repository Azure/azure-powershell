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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    public partial class DataFactoryClient
    {
        public virtual PSPrivateEndpointConnection GetPrivateEndpointConnection(string resourceGroupName, string dataFactoryName,
          string privateEndpointConnectionName)
        {
            PrivateEndpointConnectionResource response = this.DataFactoryManagementClient.PrivateEndpointConnection.Get(resourceGroupName, dataFactoryName, privateEndpointConnectionName);

            if (response == null)
            {
                return null;
            }
            return new PSPrivateEndpointConnection(response, resourceGroupName, dataFactoryName);
        }
        public virtual IList<PSPrivateEndpointConnection> ListPrivateEndpointConnections(AdfEntityFilterOptions filterOptions)
        {
            var privateEndpointConnections = new List<PSPrivateEndpointConnection>();

            IPage<PrivateEndpointConnectionResource> response;
            if (filterOptions.NextLink.IsNextPageLink())
            {
                response = this.DataFactoryManagementClient.PrivateEndPointConnections.ListByFactoryNext(filterOptions.NextLink);
            }
            else
            {
                response = this.DataFactoryManagementClient.PrivateEndPointConnections.ListByFactory(filterOptions.ResourceGroupName,
                    filterOptions.DataFactoryName);
            }
            filterOptions.NextLink = response != null ? response.NextPageLink : null;

            if (response != null)
            {
                privateEndpointConnections.AddRange(response.ToList().Select(privateEndpointConnection =>
                    new PSPrivateEndpointConnection(privateEndpointConnection, filterOptions.ResourceGroupName, filterOptions.DataFactoryName)));
            }

            return privateEndpointConnections;
        }

        public virtual IList<PSPrivateEndpointConnection> FilterPSPrivateEndpointConnections(AdfEntityFilterOptions filterOptions)
        {
            if (filterOptions == null)
            {
                throw new ArgumentNullException("filterOptions");
            }

            var privateEndpointConnections = new List<PSPrivateEndpointConnection>();

            if (filterOptions.Name != null)
            {
                privateEndpointConnections.Add(GetPrivateEndpointConnection(filterOptions.ResourceGroupName, filterOptions.DataFactoryName,
                    filterOptions.Name));
            }
            else
            {
                privateEndpointConnections.AddRange(ListPrivateEndpointConnections(filterOptions));
            }

            return privateEndpointConnections;
        }

        public virtual HttpStatusCode DeletePrivateEndpointConnection(string resourceGroupName, string dataFactoryName, string privateEndpointConnectionName)
        {
            Rest.Azure.AzureOperationResponse response = this.DataFactoryManagementClient.PrivateEndpointConnection.DeleteWithHttpMessagesAsync(resourceGroupName,
                dataFactoryName, privateEndpointConnectionName).Result;

            return response.Response.StatusCode;
        }

        public virtual PrivateEndpointConnectionResource CreateOrUpdatePrivateEndpointConnection(string resourceGroupName, string dataFactoryName, string privateEndpointConnectionName, string rawJsonContent)
        {
            if (string.IsNullOrWhiteSpace(rawJsonContent))
            {
                throw new ArgumentNullException("rawJsonContent");
            }

            PrivateLinkConnectionApprovalRequestResource privateLinkConnectionApprovalRequestResource;
            try
            {
                privateLinkConnectionApprovalRequestResource = SafeJsonConvert.DeserializeObject<PrivateLinkConnectionApprovalRequestResource>(rawJsonContent, this.DataFactoryManagementClient.DeserializationSettings);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.JsonIsInvalidTemplate, ex));
            }

            // If create or update failed, the current behavior is to throw
            return this.DataFactoryManagementClient.PrivateEndpointConnection.CreateOrUpdate(
                resourceGroupName,
                dataFactoryName,
                privateEndpointConnectionName,
                privateLinkConnectionApprovalRequestResource);
        }

        public virtual PSPrivateEndpointConnection CreatePrivateEndpointConnection(CreatePSAdfEntityParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            PSPrivateEndpointConnection privateEndpointConnection = null;
            Action createPrivateEndpointConnection = () =>
            {
                privateEndpointConnection =
                    new PSPrivateEndpointConnection(this.CreateOrUpdatePrivateEndpointConnection(
                        parameters.ResourceGroupName,
                        parameters.DataFactoryName,
                        parameters.Name,
                        parameters.RawJsonContent), parameters.ResourceGroupName,
                        parameters.DataFactoryName
                    );
            };

            parameters.ConfirmAction(
                parameters.Force,  // prompt only if the privateEndpointConnection exists
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.PrivateEndpointConnectionExists,
                    parameters.Name,
                    parameters.DataFactoryName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.PrivateEndpointConnectionCreating,
                    parameters.Name,
                    parameters.DataFactoryName),
                parameters.Name,
                createPrivateEndpointConnection,
                () => this.CheckDatasetExists(parameters.ResourceGroupName, parameters.DataFactoryName,
                parameters.Name));

            return privateEndpointConnection;
        }

    }
}
