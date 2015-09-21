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
using System.Globalization;
using System.Net;
using Microsoft.Azure.Commands.StreamAnalytics.Properties;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.WindowsAzure;
using Hyak.Common;

namespace Microsoft.Azure.Commands.StreamAnalytics.Models
{
    public partial class StreamAnalyticsClient
    {
        public virtual PSTransformation GetTransformation(string resourceGroupName, string jobName, string transformationName)
        {
            var response = StreamAnalyticsManagementClient.Transformations.Get(resourceGroupName, jobName, transformationName);

            return new PSTransformation(response.Transformation)
            {
                ResourceGroupName = resourceGroupName,
                JobName = jobName
            };
        }

        protected virtual Transformation CreateOrUpdatePSTransformation(string resourceGroupName, string jobName, string transformationName, string rawJsonContent)
        {
            if (string.IsNullOrWhiteSpace(rawJsonContent))
            {
                throw new ArgumentNullException("rawJsonContent");
            }

            // If create failed, the current behavior is to throw
            var response = StreamAnalyticsManagementClient.Transformations.CreateOrUpdateWithRawJsonContent(
                    resourceGroupName,
                    jobName,
                    transformationName,
                    new TransformationCreateOrUpdateWithRawJsonContentParameters() { Content = rawJsonContent });

            return response.Transformation;
        }

        public virtual PSTransformation CreatePSTransformation(CreatePSTransformationParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter");
            }

            PSTransformation transformation = null;
            Action createTransformation = () =>
            {
                transformation =
                    new PSTransformation(CreateOrUpdatePSTransformation(parameter.ResourceGroupName,
                        parameter.JobName,
                        parameter.TransformationName,
                        parameter.RawJsonContent))
                    {
                        ResourceGroupName = parameter.ResourceGroupName,
                        JobName = parameter.JobName
                    };
            };

            if (parameter.Force)
            {
                // If user decides to overwrite anyway, then there is no need to check if the linked service exists or not.
                createTransformation();
            }
            else
            {
                bool transformationExists = CheckTransformationExists(parameter.ResourceGroupName, parameter.JobName, parameter.TransformationName);

                parameter.ConfirmAction(
                        !transformationExists,
                        string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.TransformationExists,
                            parameter.TransformationName,
                            parameter.JobName,
                            parameter.ResourceGroupName),
                        string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.TransformationCreating,
                            parameter.TransformationName,
                            parameter.JobName,
                            parameter.ResourceGroupName),
                        parameter.TransformationName,
                        createTransformation);
            }

            return transformation;
        }

        private bool CheckTransformationExists(string resourceGroupName, string jobName, string transformationName)
        {
            try
            {
                PSTransformation transformation = GetTransformation(resourceGroupName, jobName, transformationName);
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