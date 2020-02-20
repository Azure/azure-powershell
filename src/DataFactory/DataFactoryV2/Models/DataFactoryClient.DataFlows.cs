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
        public virtual DataFlowResource CreateOrUpdateDataFlow(string resourceGroupName, string dataFactoryName, string dataFlowName, string rawJsonContent)
        {
            if (string.IsNullOrWhiteSpace(rawJsonContent))
            {
                throw new ArgumentNullException("rawJsonContent");
            }

            DataFlowResource dataFlow;
            try
            {
                dataFlow = SafeJsonConvert.DeserializeObject<DataFlowResource>(rawJsonContent, this.DataFactoryManagementClient.DeserializationSettings);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.JsonIsInvalidTemplate, ex));
            }

            // If create or update failed, the current behavior is to throw
            return this.DataFactoryManagementClient.DataFlows.CreateOrUpdate(
                resourceGroupName,
                dataFactoryName,
                dataFlowName,
                dataFlow);
        }

        public virtual PSDataFlow GetDataFlow(string resourceGroupName, string dataFactoryName, string dataFlowName)
        {
            var response = this.DataFactoryManagementClient.DataFlows.Get(resourceGroupName, dataFactoryName, dataFlowName);

            if (response == null)
            {
                return null;
            }

            return new PSDataFlow(response, resourceGroupName, dataFactoryName);
        }

        public virtual List<PSDataFlow> ListDataFlows(AdfEntityFilterOptions filterOptions)
        {
            List<PSDataFlow> dataFlows = new List<PSDataFlow>();

            IPage<DataFlowResource> response;
            if (filterOptions.NextLink.IsNextPageLink())
            {
                response = this.DataFactoryManagementClient.DataFlows.ListByFactoryNext(filterOptions.NextLink);
            }
            else
            {
                response = this.DataFactoryManagementClient.DataFlows.ListByFactory(filterOptions.ResourceGroupName, filterOptions.DataFactoryName);
            }
            filterOptions.NextLink = response?.NextPageLink;

            if (response != null && response.ToList().Count > 0)
            {
                dataFlows.AddRange(response.ToList().Select(dataFlow =>
                    new PSDataFlow(dataFlow, filterOptions.ResourceGroupName, filterOptions.DataFactoryName)));
            }

            return dataFlows;
        }

        public virtual HttpStatusCode DeleteDataFlow(string resourceGroupName, string dataFactoryName, string dataFlowName)
        {
            var response = this.DataFactoryManagementClient.DataFlows.DeleteWithHttpMessagesAsync
                (resourceGroupName, dataFactoryName, dataFlowName).Result;
            return response.Response.StatusCode;
        }

        public virtual List<PSDataFlow> FilterPSDataFlows(AdfEntityFilterOptions filterOptions)
        {
            if (filterOptions == null)
            {
                throw new ArgumentNullException("filterOptions");
            }

            List<PSDataFlow> dataFlows = new List<PSDataFlow>();

            if (filterOptions.Name != null)
            {
                dataFlows.Add(this.GetDataFlow(filterOptions.ResourceGroupName, filterOptions.DataFactoryName, filterOptions.Name));
            }
            else
            {
                dataFlows.AddRange(this.ListDataFlows(filterOptions));
            }

            return dataFlows;
        }

        public virtual PSDataFlow CreatePSDataFlow(CreatePSAdfEntityParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            PSDataFlow dataFlow = null;
            Action createDataFlow = () =>
            {
                dataFlow =
                    new PSDataFlow(this.CreateOrUpdateDataFlow(
                        parameters.ResourceGroupName,
                        parameters.DataFactoryName,
                        parameters.Name,
                        parameters.RawJsonContent), parameters.ResourceGroupName,
                        parameters.DataFactoryName
                    );
            };

            parameters.ConfirmAction(
                parameters.Force,  // prompt only if the data flow exists
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.DataFlowExists,
                    parameters.Name,
                    parameters.DataFactoryName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.DataFlowCreating,
                    parameters.Name,
                    parameters.DataFactoryName),
                parameters.Name,
                createDataFlow,
                () => this.CheckDataFlowExists(parameters.ResourceGroupName, parameters.DataFactoryName,
                parameters.Name));

            return dataFlow;
        }

        private bool CheckDataFlowExists(string resourceGroupName, string dataFactoryName, string dataFlowName)
        {
            try
            {
                PSDataFlow dataFlow = this.GetDataFlow(resourceGroupName, dataFactoryName, dataFlowName);
                return dataFlow != null;
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
