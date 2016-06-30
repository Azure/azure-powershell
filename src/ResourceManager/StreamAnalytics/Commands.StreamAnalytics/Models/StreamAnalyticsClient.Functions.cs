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
        public virtual PSFunction GetFunction(string resourceGroupName, string jobName, string name)
        {
            var response = StreamAnalyticsManagementClient.Functions.Get(
                resourceGroupName, jobName, name);

            return new PSFunction(response.Function)
            {
                ResourceGroupName = resourceGroupName,
                JobName = jobName
            };
        }

        public virtual List<PSFunction> ListFunctions(string resourceGroupName, string jobName)
        {
            List<PSFunction> functions = new List<PSFunction>();

            var response = StreamAnalyticsManagementClient.Functions.ListFunctionsInJob(resourceGroupName, jobName);

            if (response != null && response.Value != null)
            {
                foreach (var function in response.Value)
                {
                    functions.Add(new PSFunction(function)
                    {
                        ResourceGroupName = resourceGroupName,
                        JobName = jobName
                    });
                }
            }

            return functions;
        }

        public virtual List<PSFunction> FilterPSFunctions(FunctionFilterOptions filterOptions)
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

            List<PSFunction> functions = new List<PSFunction>();

            if (!string.IsNullOrWhiteSpace(filterOptions.Name))
            {
                functions.Add(GetFunction(filterOptions.ResourceGroupName, filterOptions.JobName, filterOptions.Name));
            }
            else
            {
                functions.AddRange(ListFunctions(filterOptions.ResourceGroupName, filterOptions.JobName));
            }

            return functions;
        }

        protected virtual Function CreateOrUpdatePSFunction(string resourceGroupName, string jobName, string functionName, string rawJsonContent)
        {
            if (string.IsNullOrWhiteSpace(rawJsonContent))
            {
                throw new ArgumentNullException("rawJsonContent");
            }

            // If create failed, the current behavior is to throw
            var response = StreamAnalyticsManagementClient.Functions.CreateOrUpdateWithRawJsonContent(
                    resourceGroupName,
                    jobName,
                    functionName,
                    new FunctionCreateOrUpdateWithRawJsonContentParameters() { Content = rawJsonContent });

            return response.Function;
        }

        public virtual PSFunction CreatePSFunction(CreatePSFunctionParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter");
            }

            PSFunction function = null;
            parameter.ConfirmAction(
                    parameter.Force,
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.FunctionExists,
                        parameter.FunctionName,
                        parameter.JobName,
                        parameter.ResourceGroupName),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.FunctionCreating,
                        parameter.FunctionName,
                        parameter.JobName,
                        parameter.ResourceGroupName),
                    parameter.FunctionName,
                    () =>
                    {
                        function = new PSFunction(
                            CreateOrUpdatePSFunction(parameter.ResourceGroupName,
                                parameter.JobName,
                                parameter.FunctionName,
                                parameter.RawJsonContent))
                        {
                            ResourceGroupName = parameter.ResourceGroupName,
                            JobName = parameter.JobName
                        };
                    },
                    () => CheckFunctionExists(parameter.ResourceGroupName, parameter.JobName, parameter.FunctionName));

            return function;
        }

        public virtual HttpStatusCode RemovePSFunction(string resourceGroupName, string jobName, string functionName)
        {
            AzureOperationResponse response = StreamAnalyticsManagementClient.Functions.Delete(resourceGroupName, jobName, functionName);

            return response.StatusCode;
        }

        public virtual ResourceTestConnectionResponse TestPSFunction(string resourceGroupName, string jobName, string functionName)
        {
            return StreamAnalyticsManagementClient.Functions.TestConnection(resourceGroupName, jobName, functionName);
        }

        public virtual PSFunction RetrieveDefaultPSFunctionDefinition(RetrieveDefaultPSFunctionDefinitionParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter");
            }

            var response = StreamAnalyticsManagementClient.Functions.RetrieveDefaultDefinitionWithRawJsonContent(
                parameter.ResourceGroupName, parameter.JobName, parameter.FunctionName,
                new FunctionRetrieveDefaultDefinitionWithRawJsonContentParameters() { Content = parameter.RawJsonContent });

            return new PSFunction(response.Function)
            {
                ResourceGroupName = parameter.ResourceGroupName,
                JobName = parameter.JobName
            };
        }

        private bool CheckFunctionExists(string resourceGroupName, string jobName, string functionName)
        {
            try
            {
                PSFunction function = GetFunction(resourceGroupName, jobName, functionName);
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
