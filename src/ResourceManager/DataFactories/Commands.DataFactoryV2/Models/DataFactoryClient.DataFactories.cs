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

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    public partial class DataFactoryClient
    {
        public virtual PSDataFactory GetDataFactory(string resourceGroupName, string dataFactoryName)
        {
            Factory response = this.DataFactoryManagementClient.Factories.Get(resourceGroupName, dataFactoryName);

            return response != null ? new PSDataFactory(response, resourceGroupName) : null;
        }

        public virtual List<PSDataFactory> ListDataFactories(DataFactoryFilterOptions filterOptions)
        {
            var dataFactories = new List<PSDataFactory>();

            IPage<Factory> response;

            if (filterOptions.NextLink.IsNextPageLink())
            {
                response = this.DataFactoryManagementClient.Factories.ListNext(filterOptions.NextLink);
            }
            else
            {
                response = this.DataFactoryManagementClient.Factories.ListByResourceGroup(filterOptions.ResourceGroupName);
            }
            filterOptions.NextLink = response != null ? response.NextPageLink : null;

            if (response != null)
            {
                dataFactories.AddRange(response.Select(df => new PSDataFactory(df, filterOptions.ResourceGroupName)));
            }

            return dataFactories;
        }

        public virtual List<PSDataFactory> FilterPSDataFactories(DataFactoryFilterOptions filterOptions)
        {
            if (filterOptions == null)
            {
                throw new ArgumentNullException("filterOptions");
            }

            var dataFactories = new List<PSDataFactory>();

            if (filterOptions.DataFactoryName != null)
            {
                PSDataFactory dataFactory = GetDataFactory(filterOptions.ResourceGroupName, filterOptions.DataFactoryName);
                if (dataFactory != null)
                {
                    dataFactories.Add(dataFactory);
                }
            }
            else
            {
                dataFactories.AddRange(ListDataFactories(filterOptions));
            }

            return dataFactories;
        }

        public virtual Factory CreateOrUpdateDataFactory(string resourceGroupName, string dataFactoryName,
            string loggingStorageAccountNme, string loggingStorageAccountKey, string location, IDictionary<string, string> tags)
        {
            Factory response = this.DataFactoryManagementClient.Factories.CreateOrUpdate(
                resourceGroupName,
                dataFactoryName,
                new Factory
                {
                    Location = location,
                    Tags = tags,
                    Identity = new FactoryIdentity()
                });

            return response;
        }

        public virtual PSDataFactory CreatePSDataFactory(CreatePSDataFactoryParameters parameters)
        {
            PSDataFactory dataFactory = null;
            Action createDataFactory = () =>
            {
                var tags = new Dictionary<string, string>();
                if (parameters.Tags != null)
                {
                    tags = parameters.Tags.ToDictionary();
                }

                dataFactory =
                    new PSDataFactory(
                        CreateOrUpdateDataFactory(parameters.ResourceGroupName, parameters.DataFactoryName,
                            parameters.LoggingStorageAccountName, parameters.LoggingStorageAccountKey,
                            parameters.Location, tags), parameters.ResourceGroupName);
            };

            parameters.ConfirmAction(
                parameters.Force,    // prompt only if the data factory exists
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.DataFactoryExists,
                    parameters.DataFactoryName,
                    parameters.ResourceGroupName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.DataFactoryCreating,
                    parameters.DataFactoryName,
                    parameters.ResourceGroupName),
                parameters.DataFactoryName,
                createDataFactory,
                () => CheckDataFactoryExists(parameters.ResourceGroupName, parameters.DataFactoryName, out dataFactory));

            if (!DataFactoryCommonUtilities.IsSucceededProvisioningState(dataFactory.ProvisioningState))
            {
                throw new ProvisioningFailedException(Resources.DataFactoryProvisioningError);
            }

            return dataFactory;
        }

        private bool CheckDataFactoryExists(string resourceGroupName, string dataFactoryName, out PSDataFactory dataFactory)
        {
            try
            {
                dataFactory = GetDataFactory(resourceGroupName, dataFactoryName);
                return dataFactory != null;
            }
            catch (ErrorResponseException e)
            {
                //Get throws Exception message with NotFound Status
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    dataFactory = null;
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public virtual HttpStatusCode DeleteDataFactory(string resourceGroupName, string dataFactoryName)
        {
            Rest.Azure.AzureOperationResponse response =
                this.DataFactoryManagementClient.Factories.DeleteWithHttpMessagesAsync(resourceGroupName, dataFactoryName).Result;
            return response.Response.StatusCode;
        }
    }
}
