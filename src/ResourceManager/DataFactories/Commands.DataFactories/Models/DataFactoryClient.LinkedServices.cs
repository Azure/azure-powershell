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
        public virtual LinkedService CreateOrUpdateLinkedService(string resourceGroupName, string dataFactoryName,
            string linkedServiceName, string rawJsonContent)
        {
            if (string.IsNullOrWhiteSpace(rawJsonContent))
            {
                throw new ArgumentNullException("rawJsonContent");
            }

            // If create or update failed, the current behavior is to throw
            var response =
                DataPipelineManagementClient.LinkedServices.CreateOrUpdateWithRawJsonContent(
                    resourceGroupName,
                    dataFactoryName,
                    linkedServiceName,
                    new LinkedServiceCreateOrUpdateWithRawJsonContentParameters() { Content = rawJsonContent });

            return response.LinkedService;
        }

        public virtual PSLinkedService GetLinkedService(string resourceGroupName, string dataFactoryName,
            string linkedServiceName)
        {
            var response = DataPipelineManagementClient.LinkedServices.Get(resourceGroupName, dataFactoryName,
                linkedServiceName);
            return new PSLinkedService(response.LinkedService)
            {
                ResourceGroupName = resourceGroupName,
                DataFactoryName = dataFactoryName
            };
        }

        public virtual List<PSLinkedService> ListLinkedServices(LinkedServiceFilterOptions filterOptions)
        {
            List<PSLinkedService> linkedServices = new List<PSLinkedService>();

            LinkedServiceListResponse response;
            if (filterOptions.NextLink.IsNextPageLink())
            {
                response = DataPipelineManagementClient.LinkedServices.ListNext(filterOptions.NextLink);
            }
            else
            {
                response = DataPipelineManagementClient.LinkedServices.List(filterOptions.ResourceGroupName,
                    filterOptions.DataFactoryName);
            }
            filterOptions.NextLink = response != null ? response.NextLink : null;

            if (response != null && response.LinkedServices != null)
            {
                foreach (var linkedService in response.LinkedServices)
                {
                    linkedServices.Add(
                        new PSLinkedService(linkedService)
                        {
                            ResourceGroupName = filterOptions.ResourceGroupName,
                            DataFactoryName = filterOptions.DataFactoryName
                        });
                }
            }

            return linkedServices;
        }

        public virtual HttpStatusCode DeleteLinkedService(string resourceGroupName, string dataFactoryName, string linkedServiceName)
        {
            AzureOperationResponse response = DataPipelineManagementClient.LinkedServices.Delete(resourceGroupName,
                dataFactoryName, linkedServiceName);

            return response.StatusCode;
        }

        public virtual List<PSLinkedService> FilterPSLinkedServices(LinkedServiceFilterOptions filterOptions)
        {
            if (filterOptions == null)
            {
                throw new ArgumentNullException("filterOptions");
            }

            if (string.IsNullOrWhiteSpace(filterOptions.ResourceGroupName))
            {
                throw new ArgumentException(Resources.ResourceGroupNameCannotBeEmpty);
            }

            List<PSLinkedService> linkedServices = new List<PSLinkedService>();

            if (!string.IsNullOrWhiteSpace(filterOptions.Name))
            {
                linkedServices.Add(GetLinkedService(filterOptions.ResourceGroupName, filterOptions.DataFactoryName,
                    filterOptions.Name));
            }
            else
            {
                linkedServices.AddRange(ListLinkedServices(filterOptions));
            }

            return linkedServices;
        }

        public virtual PSLinkedService CreatePSLinkedService(CreatePSLinkedServiceParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            PSLinkedService linkedService = null;
            Action createLinkedService = () =>
            {
                linkedService =
                    new PSLinkedService(CreateOrUpdateLinkedService(parameters.ResourceGroupName,
                        parameters.DataFactoryName,
                        parameters.Name,
                        parameters.RawJsonContent))
                    {
                        ResourceGroupName = parameters.ResourceGroupName,
                        DataFactoryName = parameters.DataFactoryName
                    };

                if (!DataFactoryCommonUtilities.IsSucceededProvisioningState(linkedService.ProvisioningState))
                {
                    string errorMessage = linkedService.Properties == null
                        ? string.Empty
                        : linkedService.Properties.ErrorMessage;
                    throw new ProvisioningFailedException(errorMessage);
                }
            };

            parameters.ConfirmAction(
                    parameters.Force,  // prompt only if the linked service exists
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.LinkedServiceExists,
                        parameters.Name,
                        parameters.DataFactoryName),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.LinkedServiceCreating,
                        parameters.Name,
                        parameters.DataFactoryName),
                    parameters.Name,
                    createLinkedService,
                    () => CheckLinkedServiceExists(parameters.ResourceGroupName,
                            parameters.DataFactoryName, parameters.Name));

            return linkedService;
        }

        private bool CheckLinkedServiceExists(string resourceGroupName, string dataFactoryName, string linkedServiceName)
        {
            // ToDo: implement HEAD to check if the linked service exists
            try
            {
                PSLinkedService linkedService = GetLinkedService(resourceGroupName, dataFactoryName, linkedServiceName);

                return true;
            }
            catch (CloudException e)
            {
                //Get throws Exception message with NotFound Status
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
