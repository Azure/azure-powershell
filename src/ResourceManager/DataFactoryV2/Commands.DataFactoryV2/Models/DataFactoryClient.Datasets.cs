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
        public virtual DatasetResource CreateOrUpdateDataset(string resourceGroupName, string dataFactoryName, string datasetName, string rawJsonContent)
        {
            if (string.IsNullOrWhiteSpace(rawJsonContent))
            {
                throw new ArgumentNullException("rawJsonContent");
            }

            DatasetResource dataset;
            try
            {
                dataset = SafeJsonConvert.DeserializeObject<DatasetResource>(rawJsonContent, this.DataFactoryManagementClient.DeserializationSettings);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.JsonIsInvalidTemplate, ex));
            }

            // If create or update failed, the current behavior is to throw
            return this.DataFactoryManagementClient.Datasets.CreateOrUpdate(
                resourceGroupName,
                dataFactoryName,
                datasetName,
                dataset);
        }

        public virtual PSDataset GetDataset(string resourceGroupName, string dataFactoryName, string datasetName)
        {
            var response = this.DataFactoryManagementClient.Datasets.Get(resourceGroupName, dataFactoryName, datasetName);

            if (response == null)
            {
                return null;
            }

            return new PSDataset(response, resourceGroupName, dataFactoryName);
        }

        public virtual List<PSDataset> ListDatasets(AdfEntityFilterOptions filterOptions)
        {
            List<PSDataset> datasets = new List<PSDataset>();

            IPage<DatasetResource> response;
            if (filterOptions.NextLink.IsNextPageLink())
            {
                response = this.DataFactoryManagementClient.Datasets.ListByFactoryNext(filterOptions.NextLink);
            }
            else
            {
                response = this.DataFactoryManagementClient.Datasets.ListByFactory(filterOptions.ResourceGroupName, filterOptions.DataFactoryName);
            }
            filterOptions.NextLink = response != null ? response.NextPageLink : null;

            if (response != null && response.ToList().Count > 0)
            {
                datasets.AddRange(response.ToList().Select(dataset =>
                    new PSDataset(dataset, filterOptions.ResourceGroupName, filterOptions.DataFactoryName)));
            }

            return datasets;
        }

        public virtual HttpStatusCode DeleteDataset(string resourceGroupName, string dataFactoryName, string datasetName)
        {
            var response = this.DataFactoryManagementClient.Datasets.DeleteWithHttpMessagesAsync
                (resourceGroupName, dataFactoryName, datasetName).Result;
            return response.Response.StatusCode;
        }

        public virtual List<PSDataset> FilterPSDatasets(AdfEntityFilterOptions filterOptions)
        {
            if (filterOptions == null)
            {
                throw new ArgumentNullException("filterOptions");
            }

            List<PSDataset> datasets = new List<PSDataset>();

            if (filterOptions.Name != null)
            {
                datasets.Add(this.GetDataset(filterOptions.ResourceGroupName, filterOptions.DataFactoryName, filterOptions.Name));
            }
            else
            {
                datasets.AddRange(this.ListDatasets(filterOptions));
            }

            return datasets;
        }

        public virtual PSDataset CreatePSDataset(CreatePSAdfEntityParameters parameters)
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
                        parameters.RawJsonContent), parameters.ResourceGroupName,
                        parameters.DataFactoryName
                    );
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
            try
            {
                PSDataset dataset = this.GetDataset(resourceGroupName, dataFactoryName, datasetName);
                return dataset != null;
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
