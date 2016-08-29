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
using Microsoft.Azure.Commands.StreamAnalytics.Properties;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace Microsoft.Azure.Commands.StreamAnalytics.Models
{
    public partial class StreamAnalyticsClient
    {
        public virtual PSOutput GetOutput(string resourceGroupName, string jobName, string name)
        {
            var response = StreamAnalyticsManagementClient.Outputs.Get(
                resourceGroupName, jobName, name);

            return new PSOutput(response.Output)
            {
                ResourceGroupName = resourceGroupName,
                JobName = jobName
            };
        }

        public virtual List<PSOutput> ListOutputs(string resourceGroupName, string jobName)
        {
            List<PSOutput> outputs = new List<PSOutput>();

            var response = StreamAnalyticsManagementClient.Outputs.ListOutputInJob(resourceGroupName, jobName, new OutputListParameters("*"));

            if (response != null && response.Value != null)
            {
                foreach (var output in response.Value)
                {
                    outputs.Add(new PSOutput(output)
                    {
                        ResourceGroupName = resourceGroupName,
                        JobName = jobName
                    });
                }
            }

            return outputs;
        }

        public virtual List<PSOutput> FilterPSOutputs(OutputFilterOptions filterOptions)
        {
            if (filterOptions == null)
            {
                throw new ArgumentNullException("filterOptions");
            }

            if (string.IsNullOrWhiteSpace(filterOptions.ResourceGroupName))
            {
                throw new ArgumentException(Resources.ResourceGroupNameCannotBeEmpty);
            }

            if (string.IsNullOrWhiteSpace(filterOptions.JobName))
            {
                throw new ArgumentException(Resources.JobNameCannotBeEmpty);
            }

            List<PSOutput> outputs = new List<PSOutput>();

            if (!string.IsNullOrWhiteSpace(filterOptions.Name))
            {
                outputs.Add(GetOutput(filterOptions.ResourceGroupName, filterOptions.JobName, filterOptions.Name));
            }
            else
            {
                outputs.AddRange(ListOutputs(filterOptions.ResourceGroupName, filterOptions.JobName));
            }

            return outputs;
        }

        protected virtual Output CreateOrUpdatePSOutput(string resourceGroupName, string jobName, string outputName, string rawJsonContent)
        {
            if (string.IsNullOrWhiteSpace(rawJsonContent))
            {
                throw new ArgumentNullException("rawJsonContent");
            }

            // If create failed, the current behavior is to throw
            var response = StreamAnalyticsManagementClient.Outputs.CreateOrUpdateWithRawJsonContent(
                    resourceGroupName,
                    jobName,
                    outputName,
                    new OutputCreateOrUpdateWithRawJsonContentParameters() { Content = rawJsonContent });

            return response.Output;
        }

        public virtual PSOutput CreatePSOutput(CreatePSOutputParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter");
            }

            PSOutput output = null;
            parameter.ConfirmAction(
                    parameter.Force,
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.OutputExists,
                        parameter.OutputName,
                        parameter.JobName,
                        parameter.ResourceGroupName),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.OutputCreating,
                        parameter.OutputName,
                        parameter.JobName,
                        parameter.ResourceGroupName),
                    parameter.OutputName,
                    () =>
                    {
                        output =
                            new PSOutput(CreateOrUpdatePSOutput(parameter.ResourceGroupName,
                                parameter.JobName,
                                parameter.OutputName,
                                parameter.RawJsonContent))
                            {
                                ResourceGroupName = parameter.ResourceGroupName,
                                JobName = parameter.JobName
                            };
                    },
                    () => CheckOutputExists(parameter.ResourceGroupName, parameter.JobName, parameter.OutputName));

            return output;
        }

        public virtual HttpStatusCode RemovePSOutput(string resourceGroupName, string jobName, string outputName)
        {
            AzureOperationResponse response = StreamAnalyticsManagementClient.Outputs.Delete(resourceGroupName, jobName, outputName);

            return response.StatusCode;
        }

        public virtual ResourceTestConnectionResponse TestPSOutput(string resourceGroupName, string jobName, string outputName)
        {
            return StreamAnalyticsManagementClient.Outputs.TestConnection(resourceGroupName, jobName, outputName);
        }

        private bool CheckOutputExists(string resourceGroupName, string jobName, string outputName)
        {
            try
            {
                PSOutput output = GetOutput(resourceGroupName, jobName, outputName);
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