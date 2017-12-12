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
        public virtual PipelineResource CreateOrUpdatePipeline(string resourceGroupName, string dataFactoryName,
            string pipelineName, string rawJsonContent)
        {
            if (string.IsNullOrWhiteSpace(rawJsonContent))
            {
                throw new ArgumentNullException("rawJsonContent");
            }

            PipelineResource pipeline;
            try
            {
                pipeline = SafeJsonConvert.DeserializeObject<PipelineResource>(rawJsonContent, this.DataFactoryManagementClient.DeserializationSettings);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(string.Format("Json is not valid. Details: '{0}'", ex));
            }

            PipelineResource response =
                this.DataFactoryManagementClient.Pipelines.CreateOrUpdate(
                    resourceGroupName,
                    dataFactoryName,
                    pipelineName,
                    pipeline);

            return response;
        }

        public virtual HttpStatusCode DeletePipeline(string resourceGroupName, string dataFactoryName, string pipelineName)
        {
            Rest.Azure.AzureOperationResponse response = this.DataFactoryManagementClient.Pipelines.DeleteWithHttpMessagesAsync(resourceGroupName, dataFactoryName, pipelineName).Result;

            return response.Response.StatusCode;
        }

        public virtual PSPipeline GetPipeline(string resourceGroupName, string dataFactoryName, string pipelineName)
        {
            PipelineResource response = this.DataFactoryManagementClient.Pipelines.Get(
                resourceGroupName, dataFactoryName, pipelineName);
            if (response == null)
            {
                return null;
            }

            return new PSPipeline(response, resourceGroupName, dataFactoryName);
        }

        public virtual List<PSPipeline> ListPipelines(AdfEntityFilterOptions filterOptions)
        {
            var pipelines = new List<PSPipeline>();

            IPage<PipelineResource> response;
            if (filterOptions.NextLink.IsNextPageLink())
            {
                response = this.DataFactoryManagementClient.Pipelines.ListByFactoryNext(filterOptions.NextLink);
            }
            else
            {
                response = this.DataFactoryManagementClient.Pipelines.ListByFactory(filterOptions.ResourceGroupName,
                    filterOptions.DataFactoryName);
            }
            filterOptions.NextLink = response != null ? response.NextPageLink : null;

            if (response != null)
            {
                pipelines.AddRange(response.ToList().Select(pipeline =>
                    new PSPipeline(pipeline, filterOptions.ResourceGroupName, filterOptions.DataFactoryName)));
            }

            return pipelines;
        }

        public virtual string CreatePipelineRun(string resourceGroupName, string dataFactoryName, string pipelineName, Dictionary<string, object> paramDictionary)
        {
            CreateRunResponse response = this.DataFactoryManagementClient.Pipelines.CreateRun(resourceGroupName, dataFactoryName, pipelineName, paramDictionary);

            return response.RunId;
        }

        public void StopPipelineRun(string resourceGroupName, string dataFactoryName, string pipelineRunId)
        {
            this.DataFactoryManagementClient.Factories.CancelPipelineRun(resourceGroupName, dataFactoryName, pipelineRunId);
        }

        public virtual List<PSPipeline> FilterPSPipelines(AdfEntityFilterOptions filterOptions)
        {
            if (filterOptions == null)
            {
                throw new ArgumentNullException("filterOptions");
            }

            var Pipelines = new List<PSPipeline>();

            if (filterOptions.Name != null)
            {
                Pipelines.Add(GetPipeline(filterOptions.ResourceGroupName, filterOptions.DataFactoryName,
                    filterOptions.Name));
            }
            else
            {
                Pipelines.AddRange(ListPipelines(filterOptions));
            }

            return Pipelines;
        }

        public virtual PSPipeline CreatePSPipeline(CreatePSAdfEntityParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            PSPipeline pipeline = null;
            Action createPipeline = () =>
            {
                pipeline =
                    new PSPipeline(CreateOrUpdatePipeline(parameters.ResourceGroupName,
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
                        Resources.PipelineExists,
                        parameters.Name,
                        parameters.DataFactoryName),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.PipelineCreating,
                        parameters.Name,
                        parameters.DataFactoryName),
                    parameters.Name,
                    createPipeline,
                    () => CheckPipelineExists(parameters.ResourceGroupName,
                            parameters.DataFactoryName, parameters.Name));

            return pipeline;
        }

        private bool CheckPipelineExists(string resourceGroupName, string dataFactoryName, string pipelineName)
        {
            try
            {
                PSPipeline pipeline = GetPipeline(resourceGroupName, dataFactoryName, pipelineName);
                return pipeline != null;
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