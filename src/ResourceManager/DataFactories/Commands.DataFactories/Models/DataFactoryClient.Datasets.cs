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
        public virtual Dataset CreateOrUpdateDataset(string resourceGroupName, string dataFactoryName, string datasetName, string rawJsonContent)
        {
            if (string.IsNullOrWhiteSpace(rawJsonContent))
            {
                throw new ArgumentNullException("rawJsonContent");
            }

            // If create or update failed, the current behavior is to throw
            var response = DataPipelineManagementClient.Datasets.CreateOrUpdateWithRawJsonContent(
                resourceGroupName,
                dataFactoryName,
                datasetName,
                new DatasetCreateOrUpdateWithRawJsonContentParameters() { Content = rawJsonContent });

            return response.Dataset;
        }

        public virtual PSDataset GetDataset(string resourceGroupName, string dataFactoryName, string datasetName)
        {
            var response = DataPipelineManagementClient.Datasets.Get(
                resourceGroupName, dataFactoryName, datasetName);

            return new PSDataset(response.Dataset)
            {
                ResourceGroupName = resourceGroupName,
                DataFactoryName = dataFactoryName
            };
        }

        public virtual List<PSDataset> ListDatasets(DatasetFilterOptions filterOptions)
        {
            List<PSDataset> datasets = new List<PSDataset>();

            DatasetListResponse response;
            if (filterOptions.NextLink.IsNextPageLink())
            {
                response = DataPipelineManagementClient.Datasets.ListNext(filterOptions.NextLink);
            }
            else
            {
                response = DataPipelineManagementClient.Datasets.List(filterOptions.ResourceGroupName, filterOptions.DataFactoryName);
            }
            filterOptions.NextLink = response != null ? response.NextLink : null;

            if (response != null && response.Datasets != null)
            {
                foreach (var dataset in response.Datasets)
                {
                    datasets.Add(
                        new PSDataset(dataset)
                        {
                            ResourceGroupName = filterOptions.ResourceGroupName,
                            DataFactoryName = filterOptions.DataFactoryName
                        });
                }
            }

            return datasets;
        }

        public virtual HttpStatusCode DeleteDataset(string resourceGroupName, string dataFactoryName, string datasetName)
        {
            AzureOperationResponse response = DataPipelineManagementClient.Datasets.Delete(resourceGroupName, dataFactoryName, datasetName);
            return response.StatusCode;
        }

        public virtual List<PSDataset> FilterPSDatasets(DatasetFilterOptions filterOptions)
        {
            if (filterOptions == null)
            {
                throw new ArgumentNullException("filterOptions");
            }

            if (string.IsNullOrWhiteSpace(filterOptions.ResourceGroupName))
            {
                throw new ArgumentException(Resources.ResourceGroupNameCannotBeEmpty);
            }

            List<PSDataset> datasets = new List<PSDataset>();

            if (!string.IsNullOrWhiteSpace(filterOptions.Name))
            {
                datasets.Add(this.GetDataset(filterOptions.ResourceGroupName, filterOptions.DataFactoryName, filterOptions.Name));
            }
            else
            {
                datasets.AddRange(this.ListDatasets(filterOptions));
            }

            return datasets;
        }

        public virtual PSDataset CreatePSDataset(CreatePSDatasetParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            PSDataset dataset = null;
            Action createDataset = () =>
            {
                dataset =
                    new PSDataset(this.CreateOrUpdateDataset(
                        parameters.ResourceGroupName,
                        parameters.DataFactoryName,
                        parameters.Name,
                        parameters.RawJsonContent))
                    {
                        ResourceGroupName = parameters.ResourceGroupName,
                        DataFactoryName = parameters.DataFactoryName
                    };

                if (!DataFactoryCommonUtilities.IsSucceededProvisioningState(dataset.ProvisioningState))
                {
                    string errorMessage = dataset.Properties == null
                        ? string.Empty
                        : dataset.Properties.ErrorMessage;
                    throw new ProvisioningFailedException(errorMessage);
                }
            };

            parameters.ConfirmAction(
                parameters.Force,  // prompt only if the dataset exists
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.DatasetExists,
                    parameters.Name,
                    parameters.DataFactoryName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.DatasetCreating,
                    parameters.Name,
                    parameters.DataFactoryName),
                parameters.Name,
                createDataset,
                () => this.CheckDatasetExists(parameters.ResourceGroupName, parameters.DataFactoryName,
                parameters.Name));

            return dataset;
        }

        private bool CheckDatasetExists(string resourceGroupName, string dataFactoryName, string datasetName)
        {
            // ToDo: implement HEAD to check if the dataset exists
            try
            {
                PSDataset dataset = this.GetDataset(resourceGroupName, dataFactoryName, datasetName);

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
