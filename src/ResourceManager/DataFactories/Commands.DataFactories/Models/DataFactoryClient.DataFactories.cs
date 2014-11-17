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
using System.Net;
using System.Linq;
using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Commands.DataFactories.Properties;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities;

namespace Microsoft.Azure.Commands.DataFactories
{
    public partial class DataFactoryClient
    {
        public virtual PSDataFactory GetDataFactory(string resourceGroupName, string dataFactoryName)
        {
            var response = DataPipelineManagementClient.DataFactories.Get(resourceGroupName, dataFactoryName);

            return new PSDataFactory(response.DataFactory) { ResourceGroupName = resourceGroupName };
        }

        public virtual List<PSDataFactory> ListDataFactories(string resourceGroupName)
        {
            List<PSDataFactory> dataFactories = new List<PSDataFactory>();

            var response = DataPipelineManagementClient.DataFactories.List(resourceGroupName);

            if (response != null && response.DataFactories != null)
            {
                response.DataFactories.ForEach(
                    df => dataFactories.Add(new PSDataFactory(df) { ResourceGroupName = resourceGroupName }));
            }

            return dataFactories;
        }

        public virtual List<PSDataFactory> FilterPSDataFactories(DataFactoryFilterOptions filterOptions)
        {
            if (filterOptions == null)
            {
                throw new ArgumentNullException("filterOptions");
            }
            
            // ToDo: make ResourceGroupName optional
            if (string.IsNullOrWhiteSpace(filterOptions.ResourceGroupName))
            {
                throw new ArgumentException(Resources.ResourceGroupNameCannotBeEmpty);
            }

            List<PSDataFactory> dataFactories = new List<PSDataFactory>();

            if (!string.IsNullOrWhiteSpace(filterOptions.Name))
            {
                dataFactories.Add(GetDataFactory(filterOptions.ResourceGroupName, filterOptions.Name));
            }
            else
            {
                // ToDo: Filter list results by Tag
                dataFactories.AddRange(ListDataFactories(filterOptions.ResourceGroupName));
            }

            return dataFactories;
        }

        public virtual DataFactory CreateOrUpdateDataFactory(string resourceGroupName, string dataFactoryName,
            string location, IDictionary<string, string> tags)
        {
            var response = DataPipelineManagementClient.DataFactories.CreateOrUpdate(
                resourceGroupName,
                new DataFactoryCreateOrUpdateParameters()
                {
                    DataFactory =
                        new DataFactory()
                        {
                            Name = dataFactoryName,
                            Location = location,
                            Tags = tags
                        }
                });

            return response.DataFactory;
        }

        public virtual PSDataFactory CreatePSDataFactory(CreatePSDataFactoryParameters parameters)
        {
            PSDataFactory dataFactory = null;
            Action createDataFactory = () =>
            {
                Dictionary<string, string> tags = new Dictionary<string, string>();
                if (parameters.Tags != null)
                {
                    tags = parameters.Tags.ToDictionary();
                }

                dataFactory =
                    new PSDataFactory(
                        CreateOrUpdateDataFactory(parameters.ResourceGroupName, parameters.DataFactoryName,
                            parameters.Location, tags)) {ResourceGroupName = parameters.ResourceGroupName};
            };

            if (parameters.Force)
            {
                // If user decides to overwrite anyway, then there is no need to check if the data factory exists or not.
                createDataFactory();
            }
            else
            {
                bool dataFactoryExists = CheckDataFactoryExists(parameters.ResourceGroupName, parameters.DataFactoryName);

                parameters.ConfirmAction(
                    !dataFactoryExists,    // prompt only if the data factory exists
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
                    createDataFactory);
            }

            return dataFactory;
        }

        private bool CheckDataFactoryExists(string resourceGroupName, string dataFactoryName)
        {
            // ToDo: use HEAD to check if a resource exists or not
            try
            {
                PSDataFactory dataFactory = GetDataFactory(resourceGroupName, dataFactoryName);

                return true;
            }
            catch (CloudException e)
            {
                //Get throws NotFound exception if data factory not exists
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }
        
        public virtual HttpStatusCode DeleteDataFactory(string resourceGroupName, string dataFactoryName)
        {
            OperationResponse response = DataPipelineManagementClient.DataFactories.Delete(resourceGroupName,
                dataFactoryName);
            return response.StatusCode;
        }
    }
}
