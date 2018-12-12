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

using Hyak.Common;
using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Commands.DataFactories.Properties;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace Microsoft.Azure.Commands.DataFactories
{
    public partial class DataFactoryClient
    {
        public virtual Hub CreateOrUpdateHub(
            string resourceGroupName,
            string dataFactoryName,
            string hubName,
            string rawJsonContent)
        {
            if (string.IsNullOrWhiteSpace(rawJsonContent))
            {
                throw new ArgumentNullException("rawJsonContent");
            }

            // If create or update failed, the current behavior is to throw
            var response = DataPipelineManagementClient.Hubs.CreateOrUpdateWithRawJsonContent(
                resourceGroupName,
                dataFactoryName,
                hubName,
                new HubCreateOrUpdateWithRawJsonContentParameters() { Content = rawJsonContent });

            return response.Hub;
        }

        public virtual PSHub CreatePSHub(CreatePSHubParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            PSHub hub = null;
            Action createHub = () =>
            {
                hub =
                    new PSHub(
                        this.CreateOrUpdateHub(
                            parameters.ResourceGroupName,
                            parameters.DataFactoryName,
                            parameters.Name,
                            parameters.RawJsonContent))
                    { DataFactoryName = parameters.DataFactoryName, ResourceGroupName = parameters.ResourceGroupName };

                if (!DataFactoryCommonUtilities.IsSucceededProvisioningState(hub.ProvisioningState))
                {
                    // ToDo: service side should set the error message for provisioning failures.
                    throw new ProvisioningFailedException(Resources.HubProvisioningFailed);
                }
            };

            if (parameters.Force)
            {
                createHub();
            }
            else
            {
                bool hubExists = this.CheckHubExists(
                    parameters.ResourceGroupName,
                    parameters.DataFactoryName,
                    parameters.Name);

                parameters.ConfirmAction(
                    !hubExists,
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.HubExists,
                        parameters.Name,
                        parameters.DataFactoryName),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.HubCreating,
                        parameters.Name,
                        parameters.DataFactoryName),
                    parameters.Name,
                    createHub);
            }

            return hub;
        }

        public virtual PSHub GetHub(string resourceGroupName, string dataFactoryName, string hubName)
        {
            var response = DataPipelineManagementClient.Hubs.Get(resourceGroupName, dataFactoryName, hubName);

            return new PSHub(response.Hub)
            {
                ResourceGroupName = resourceGroupName,
                DataFactoryName = dataFactoryName
            };
        }

        public virtual List<PSHub> ListHubs(HubFilterOptions filterOptions)
        {
            List<PSHub> hubs = new List<PSHub>();

            HubListResponse response;
            if (filterOptions.NextLink.IsNextPageLink())
            {
                response = DataPipelineManagementClient.Hubs.ListNext(filterOptions.NextLink);
            }
            else
            {
                response = DataPipelineManagementClient.Hubs.List(filterOptions.ResourceGroupName,
                    filterOptions.DataFactoryName);
            }
            filterOptions.NextLink = response != null ? response.NextLink : null;

            if (response != null && response.Hubs != null)
            {
                foreach (var hub in response.Hubs)
                {
                    hubs.Add(new PSHub(hub)
                    {
                        ResourceGroupName = filterOptions.ResourceGroupName,
                        DataFactoryName = filterOptions.DataFactoryName
                    });
                }
            }

            return hubs;
        }

        public virtual HttpStatusCode DeleteHub(string resourceGroupName, string dataFactoryName, string hubName)
        {
            AzureOperationResponse response = DataPipelineManagementClient.Hubs.Delete(
                resourceGroupName,
                dataFactoryName,
                hubName);

            return response.StatusCode;
        }

        public virtual List<PSHub> FilterPSHubs(HubFilterOptions filterOptions)
        {
            if (filterOptions == null)
            {
                throw new ArgumentNullException("filterOptions");
            }

            if (string.IsNullOrWhiteSpace(filterOptions.ResourceGroupName))
            {
                throw new ArgumentException(Resources.ResourceGroupNameCannotBeEmpty);
            }

            List<PSHub> hubs = new List<PSHub>();

            if (!string.IsNullOrWhiteSpace(filterOptions.Name))
            {
                hubs.Add(GetHub(filterOptions.ResourceGroupName, filterOptions.DataFactoryName, filterOptions.Name));
            }
            else
            {
                hubs.AddRange(ListHubs(filterOptions));
            }

            return hubs;
        }

        private bool CheckHubExists(string resourceGroupName, string dataFactoryName, string hubName)
        {
            try
            {
                PSHub hub = this.GetHub(resourceGroupName, dataFactoryName, hubName);

                return true;
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }
    }
}
