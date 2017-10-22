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

using Microsoft.Azure.Commands.StreamAnalytics.Properties;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace Microsoft.Azure.Commands.StreamAnalytics.Models
{
    public partial class StreamAnalyticsClient
    {
        public virtual PSInput GetInput(string resourceGroupName, string jobName, string name)
        {
            var response = StreamAnalyticsManagementClient.Inputs.Get(
                resourceGroupName, jobName, name);

            return new PSInput(response)
            {
                ResourceGroupName = resourceGroupName,
                JobName = jobName
            };
        }

        public virtual List<PSInput> ListInputs(string resourceGroupName, string jobName)
        {
            List<PSInput> inputs = new List<PSInput>();

            var response = StreamAnalyticsManagementClient.Inputs.ListByStreamingJob(resourceGroupName, jobName, "*");

            if (response != null)
            {
                foreach (var input in response)
                {
                    inputs.Add(new PSInput(input)
                    {
                        ResourceGroupName = resourceGroupName,
                        JobName = jobName
                    });
                }
            }

            return inputs;
        }

        public virtual List<PSInput> FilterPSInputs(InputFilterOptions filterOptions)
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

            List<PSInput> inputs = new List<PSInput>();

            if (!string.IsNullOrWhiteSpace(filterOptions.Name))
            {
                inputs.Add(GetInput(filterOptions.ResourceGroupName, filterOptions.JobName, filterOptions.Name));
            }
            else
            {
                inputs.AddRange(ListInputs(filterOptions.ResourceGroupName, filterOptions.JobName));
            }

            return inputs;
        }

        protected virtual Input CreateOrUpdatePSInput(string resourceGroupName, string jobName, string inputName, string rawJsonContent)
        {
            if (string.IsNullOrWhiteSpace(rawJsonContent))
            {
                throw new ArgumentNullException("rawJsonContent");
            }

            Input input = SafeJsonConvert.DeserializeObject<Input>(
                rawJsonContent,
                StreamAnalyticsClientExtensions.DeserializationSettings);

            // If create failed, the current behavior is to throw
            var response = StreamAnalyticsManagementClient.Inputs.CreateOrReplace(
                    input,
                    resourceGroupName,
                    jobName,
                    inputName);

            return response;
        }

        public virtual PSInput CreatePSInput(CreatePSInputParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter");
            }

            PSInput input = null;
            parameter.ConfirmAction(
                    parameter.Force,
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.InputExists,
                        parameter.InputName,
                        parameter.JobName,
                        parameter.ResourceGroupName),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.InputCreating,
                        parameter.InputName,
                        parameter.JobName,
                        parameter.ResourceGroupName),
                    parameter.InputName,
                    () =>
                    {
                        input = new PSInput(
                            CreateOrUpdatePSInput(parameter.ResourceGroupName,
                                parameter.JobName,
                                parameter.InputName,
                                parameter.RawJsonContent))
                        {
                            ResourceGroupName = parameter.ResourceGroupName,
                            JobName = parameter.JobName
                        };
                    },
                    () => CheckInputExists(parameter.ResourceGroupName, parameter.JobName, parameter.InputName));

            return input;
        }

        public virtual void RemovePSInput(string resourceGroupName, string jobName, string inputName)
        {
            StreamAnalyticsManagementClient.Inputs.Delete(resourceGroupName, jobName, inputName);
        }

        public virtual ResourceTestStatus TestPSInput(string resourceGroupName, string jobName, string inputName)
        {
            return StreamAnalyticsManagementClient.Inputs.Test(resourceGroupName, jobName, inputName);
        }

        private bool CheckInputExists(string resourceGroupName, string jobName, string inputName)
        {
            try
            {
                PSInput input = GetInput(resourceGroupName, jobName, inputName);
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