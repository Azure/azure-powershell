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
        public virtual LinkedServiceResource CreateOrUpdateLinkedService(string resourceGroupName, string dataFactoryName,
            string linkedServiceName, string rawJsonContent)
        {
            if (string.IsNullOrWhiteSpace(rawJsonContent))
            {
                throw new ArgumentNullException("rawJsonContent");
            }

            LinkedServiceResource linkedService;
            try
            {
                linkedService = SafeJsonConvert.DeserializeObject<LinkedServiceResource>(rawJsonContent, this.DataFactoryManagementClient.DeserializationSettings);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(string.Format("Json is not valid. Details: '{0}'", ex));
            }

            // If create or update failed, the current behavior is to throw
            return this.DataFactoryManagementClient.LinkedServices.CreateOrUpdate(
                    resourceGroupName,
                    dataFactoryName,
                    linkedServiceName,
                    linkedService);
        }

        public virtual PSLinkedService GetLinkedService(string resourceGroupName, string dataFactoryName,
            string linkedServiceName)
        {
            LinkedServiceResource response = this.DataFactoryManagementClient.LinkedServices.Get(resourceGroupName, dataFactoryName,
                linkedServiceName);

            if (response == null)
            {
                return null;
            }
            return new PSLinkedService(response, resourceGroupName, dataFactoryName);
        }

        public virtual List<PSLinkedService> ListLinkedServices(AdfEntityFilterOptions filterOptions)
        {
            var linkedServices = new List<PSLinkedService>();

            IPage<LinkedServiceResource> response;
            if (filterOptions.NextLink.IsNextPageLink())
            {
                response = this.DataFactoryManagementClient.LinkedServices.ListByFactoryNext(filterOptions.NextLink);
            }
            else
            {
                response = this.DataFactoryManagementClient.LinkedServices.ListByFactory(filterOptions.ResourceGroupName,
                    filterOptions.DataFactoryName);
            }
            filterOptions.NextLink = response != null ? response.NextPageLink : null;

            if (response != null)
            {
                linkedServices.AddRange(response.ToList().Select(linkedService =>
                    new PSLinkedService(linkedService, filterOptions.ResourceGroupName, filterOptions.DataFactoryName)));
            }

            return linkedServices;
        }

        public virtual HttpStatusCode DeleteLinkedService(string resourceGroupName, string dataFactoryName, string linkedServiceName)
        {
            Rest.Azure.AzureOperationResponse response = this.DataFactoryManagementClient.LinkedServices.DeleteWithHttpMessagesAsync(resourceGroupName,
                dataFactoryName, linkedServiceName).Result;

            return response.Response.StatusCode;
        }

        public virtual List<PSLinkedService> FilterPSLinkedServices(AdfEntityFilterOptions filterOptions)
        {
            if (filterOptions == null)
            {
                throw new ArgumentNullException("filterOptions");
            }

            var linkedServices = new List<PSLinkedService>();

            if (filterOptions.Name != null)
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

        public virtual PSLinkedService CreatePSLinkedService(CreatePSAdfEntityParameters parameters)
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
                        parameters.RawJsonContent), parameters.ResourceGroupName,
                        parameters.DataFactoryName
                    );
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
            try
            {
                PSLinkedService linkedService = GetLinkedService(resourceGroupName, dataFactoryName, linkedServiceName);
                return linkedService != null;
            }
            catch (ErrorResponseException e)
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
