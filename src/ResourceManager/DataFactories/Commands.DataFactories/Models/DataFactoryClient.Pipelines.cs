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
using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Commands.DataFactories.Properties;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.WindowsAzure;

namespace Microsoft.Azure.Commands.DataFactories
{
    public partial class DataFactoryClient
    {
        public virtual Pipeline CreateOrUpdatePipeline(string resourceGroupName, string dataFactoryName,
            string pipelineName, string rawJsonContent)
        {
            if (string.IsNullOrWhiteSpace(rawJsonContent))
            {
                throw new ArgumentNullException("rawJsonContent");
            }

            // If create failed, the current behavior is to throw
            var response =
                DataPipelineManagementClient.Pipelines.CreateOrUpdateWithRawJsonContent(
                    resourceGroupName,
                    dataFactoryName,
                    pipelineName,
                    new PipelineCreateOrUpdateWithRawJsonContentParameters() { Content = rawJsonContent });

            return response.Pipeline;
        }

        public virtual HttpStatusCode DeletePipeline(string resourceGroupName, string dataFactoryName, string pipelineName)
        {
            OperationResponse response = DataPipelineManagementClient.Pipelines.Delete(
                resourceGroupName, dataFactoryName, pipelineName);

            return response.StatusCode;
        }

        public virtual PSPipeline GetPipeline(string resourceGroupName, string dataFactoryName, string pipelineName)
        {
            var response = DataPipelineManagementClient.Pipelines.Get(
                resourceGroupName, dataFactoryName, pipelineName);

            return new PSPipeline(response.Pipeline)
            {
                ResourceGroupName = resourceGroupName,
                DataFactoryName = dataFactoryName
            };
        }

        public virtual List<PSDataSliceRun> GetPipelineRuns(string resourceGroupName, string dataFactoryName, string pipelineName,
            string activityName, DateTime runRangeStartTime, DateTime? runRangeEndTime, string runRecordStatus = null)
        {
            var pipelineRuns = new List<PSDataSliceRun>();

            var response = DataPipelineManagementClient.PipelineRuns.List(resourceGroupName, dataFactoryName, pipelineName,
                new PipelineRunListParameters()
                {
                    ActivityName = activityName,
                    RunRangeStartTime = runRangeStartTime.ConvertToISO8601DateTimeString(),
                    RunRangeEndTime = runRangeEndTime != null ? runRangeEndTime.Value.ConvertToISO8601DateTimeString() : null,
                    RunRecordStatus = runRecordStatus
                });

            if (response != null && response.PipelineRuns != null)
            {
                foreach (var run in response.PipelineRuns)
                {
                    pipelineRuns.Add(
                        new PSDataSliceRun(run)
                        {
                            ResourceGroupName = resourceGroupName,
                            DataFactoryName = dataFactoryName
                        });
                }
            }

            return pipelineRuns;
        }

        public virtual List<PSPipeline> ListPipelines(string resourceGroupName, string dataFactoryName)
        {
            List<PSPipeline> pipelines = new List<PSPipeline>();

            var response = DataPipelineManagementClient.Pipelines.List(resourceGroupName, dataFactoryName);

            if (response != null && response.Pipelines != null)
            {
                foreach (var pipeline in response.Pipelines)
                {
                    pipelines.Add(
                        new PSPipeline(pipeline)
                        {
                            ResourceGroupName = resourceGroupName,
                            DataFactoryName = dataFactoryName
                        });
                }
            }

            return pipelines;
        }

        public virtual void SetPipelineActivePeriod(
            string resourceGroupName,
            string dataFactoryName,
            string pipelineName,
            DateTime startTime,
            DateTime endTime,
            bool autoResolve,
            bool forceRecalc)
        {
            DataPipelineManagementClient.Pipelines.SetActivePeriod(
                resourceGroupName,
                dataFactoryName,
                pipelineName,
                new PipelineSetActivePeriodParameters()
                {
                    ActivePeriodStartTime = startTime.ConvertToISO8601DateTimeString(),
                    ActivePeriodEndTime = endTime.ConvertToISO8601DateTimeString(),
                    AutoResolve = autoResolve,
                    ForceRecalc = forceRecalc
                });
        }

        public virtual void SuspendPipeline(string resourceGroupName, string dataFactoryName, string pipelineName)
        {
            DataPipelineManagementClient.Pipelines.Suspend(resourceGroupName, dataFactoryName, pipelineName);
        }

        public virtual void ResumePipeline(string resourceGroupName, string dataFactoryName, string pipelineName)
        {
            DataPipelineManagementClient.Pipelines.Resume(resourceGroupName, dataFactoryName, pipelineName);
        }

        public virtual List<PSPipeline> FilterPSPipelines(PipelineFilterOptions filterOptions)
        {
            if (filterOptions == null)
            {
                throw new ArgumentNullException("filterOptions");
            }

            if (string.IsNullOrWhiteSpace(filterOptions.ResourceGroupName))
            {
                throw new ArgumentException(Resources.ResourceGroupNameCannotBeEmpty);
            }

            List<PSPipeline> Pipelines = new List<PSPipeline>();

            if (!string.IsNullOrWhiteSpace(filterOptions.Name))
            {
                Pipelines.Add(GetPipeline(filterOptions.ResourceGroupName, filterOptions.DataFactoryName,
                    filterOptions.Name));
            }
            else
            {
                Pipelines.AddRange(ListPipelines(filterOptions.ResourceGroupName,
                    filterOptions.DataFactoryName));
            }

            return Pipelines;
        }

        public virtual PSPipeline CreatePSPipeline(CreatePSPipelineParameters parameters)
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
                        parameters.RawJsonContent))
                    {
                        ResourceGroupName = parameters.ResourceGroupName,
                        DataFactoryName = parameters.DataFactoryName
                    };
            };

            if (parameters.Force)
            {
                // If user decides to overwrite anyway, then there is no need to check if the linked service exists or not.
                createPipeline();
            }
            else
            {
                bool pipelineExists = CheckPipelineExists(parameters.ResourceGroupName,
                    parameters.DataFactoryName, parameters.Name);

                parameters.ConfirmAction(
                        !pipelineExists,  // prompt only if the linked service exists
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
                        createPipeline);
            }

            return pipeline;
        }

        private bool CheckPipelineExists(string resourceGroupName, string dataFactoryName, string pipelineName)
        {
            // ToDo: implement HEAD to check if the pipeline exists
            try
            {
                PSPipeline pipeline = GetPipeline(resourceGroupName, dataFactoryName, pipelineName);

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