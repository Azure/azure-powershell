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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.Authorization.Version2015_07_01;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure.OData;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Microsoft.Azure.Commands.WebApps.Models
{
    public partial class ResourceClient
    {
        /// <summary>
        /// A string that indicates the value of the resource type name for the RP's operations api
        /// </summary>
        public const string Operations = "operations";

        /// <summary>
        /// A string that indicates the value of the registering state enum for a provider
        /// </summary>
        public const string RegisteredStateName = "Registered";

        /// <summary>
        /// Used when provisioning the deployment status.
        /// </summary>
        private List<DeploymentOperation> operations;

        public ResourceManagementClient ResourceManagementClient { get; set; }

        public AuthorizationManagementClient AuthorizationManagementClient { get; set; }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        /// <summary>
        /// Creates new ResourceManagementClient
        /// </summary>
        /// <param name="context">Profile containing resources to manipulate</param>
        public ResourceClient(IAzureContext context)
            : this(
                AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager),
                AzureSession.Instance.ClientFactory.CreateArmClient<AuthorizationManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {

        }

        /// <summary>
        /// Creates new ResourcesClient instance
        /// </summary>
        /// <param name="resourceManagementClient">The IResourceManagementClient instance</param>
        /// <param name="authorizationManagementClient">The management client instance</param>
        public ResourceClient(
            ResourceManagementClient resourceManagementClient,
            AuthorizationManagementClient authorizationManagementClient)
        {
            AuthorizationManagementClient = authorizationManagementClient;
            this.ResourceManagementClient = resourceManagementClient;
        }

        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        public ResourceClient()
        {

        }

        private void WriteVerbose(string progress)
        {
            if (VerboseLogger != null)
            {
                VerboseLogger(progress);
            }
        }

        private void WriteWarning(string warning)
        {
            if (WarningLogger != null)
            {
                WarningLogger(warning);
            }
        }

        private void WriteError(string error)
        {
            if (ErrorLogger != null)
            {
                ErrorLogger(error);
            }
        }

        /// <summary>
        /// Gets a web app resource from the ARM cache.
        /// </summary>
        public GenericResource GetAppResource(string name, string slot = null)
        {
            ODataQuery<GenericResourceFilter> query;
            if (string.IsNullOrEmpty(slot) || string.Equals(slot, "production", StringComparison.InvariantCultureIgnoreCase))
            {
                query = new ODataQuery<GenericResourceFilter>($"resourceType eq 'Microsoft.Web/sites' and name eq '{name}'");
            }
            else
            {
                query = new ODataQuery<GenericResourceFilter>($"resourceType eq 'Microsoft.Web/sites/slots' and name eq '{name}/{slot}'");
            }
            return ResourceManagementClient.Resources.List(query).FirstOrDefault();
        }

        /// <summary>
        /// Gets all locations of deleted sites resource
        /// </summary>
        public IEnumerable<string> GetDeletedSitesLocations()
        {
            Provider webProvider = ResourceManagementClient.Providers.Get("Microsoft.Web");
            ProviderResourceType resType = webProvider.ResourceTypes.First((rt) =>
            {
                return string.Equals(rt.ResourceType, "deletedSites", StringComparison.InvariantCultureIgnoreCase);
            });
            return resType.Locations;
        }

        public DeploymentExtended ProvisionDeploymentStatus(string resourceGroup, string deploymentName, Deployment deployment)
        {
            operations = new List<DeploymentOperation>();

            return WaitDeploymentStatus(
                resourceGroup,
                deploymentName,
                deployment,
                WriteDeploymentProgress,
                "Canceled",
                "Succeeded",
                "Failed");
        }

        private void WriteDeploymentProgress(string resourceGroup, string deploymentName, Deployment deployment)
        {
            const string normalStatusFormat = "Resource {0} '{1}' provisioning status is {2}";
            const string failureStatusFormat = "Resource {0} '{1}' failed with message '{2}'";
            List<DeploymentOperation> newOperations;
            Rest.Azure.IPage<DeploymentOperation> result;

            result = ResourceManagementClient.DeploymentOperations.List(resourceGroup, deploymentName, null);
            newOperations = GetNewOperations(operations, result);
            operations.AddRange(newOperations);

            while (!string.IsNullOrEmpty(result.NextPageLink))
            {
                result = ResourceManagementClient.DeploymentOperations.ListNext(result.NextPageLink);
                newOperations = GetNewOperations(operations, result);
                operations.AddRange(newOperations);
            }

            foreach (DeploymentOperation operation in newOperations)
            {
                string statusMessage;

                if (operation.Properties.ProvisioningState != "Failed")
                {
                    if (operation.Properties.TargetResource != null)
                    {
                        statusMessage = string.Format(normalStatusFormat,
                        operation.Properties.TargetResource.ResourceType,
                        operation.Properties.TargetResource.ResourceName,
                        operation.Properties.ProvisioningState.ToLower());

                        WriteVerbose(statusMessage);
                    }
                }
                else
                {
                    string errorMessage = ParseErrorMessage(operation.Properties.StatusMessage.ToString());

                    if (operation.Properties.TargetResource != null)
                    {
                        statusMessage = string.Format(failureStatusFormat,
                        operation.Properties.TargetResource.ResourceType,
                        operation.Properties.TargetResource.ResourceName,
                        errorMessage);

                        WriteError(statusMessage);
                    }
                    else
                    {
                        WriteError(errorMessage);
                    }

                    List<string> detailedMessage = ParseDetailErrorMessage(operation.Properties.StatusMessage.ToString());

                    if (detailedMessage != null)
                    {
                        detailedMessage.ForEach(s => WriteError(s));
                    }
                }
            }
        }

        public static string ParseErrorMessage(string statusMessage)
        {
            CloudError error = CloudException.ParseXmlOrJsonError(statusMessage);
            if (error.Message == null)
            {
                return error.OriginalMessage;
            }
            else
            {
                return error.Message;
            }
        }

        public static List<string> ParseDetailErrorMessage(string statusMessage)
        {
            if (!string.IsNullOrEmpty(statusMessage))
            {
                List<string> detailedMessage = new List<string>();
                dynamic errorMessage = JsonConvert.DeserializeObject(statusMessage);
                if (errorMessage.error != null && errorMessage.error.details != null)
                {
                    foreach (var detail in errorMessage.error.details)
                    {
                        detailedMessage.Add(detail.message.ToString());
                    }
                }
                return detailedMessage;
            }
            return null;
        }

        private DeploymentExtended WaitDeploymentStatus(
            string resourceGroup,
            string deploymentName,
            Deployment basicDeployment,
            Action<string, string, Deployment> job,
            params string[] status)
        {
            DeploymentExtended deployment;
            int counter = 5000;

            do
            {
                WriteVerbose(string.Format("Checking deployment status in {0} seconds.", counter / 1000));
                TestMockSupport.Delay(counter);

                if (job != null)
                {
                    job(resourceGroup, deploymentName, basicDeployment);
                }

                deployment = ResourceManagementClient.Deployments.Get(resourceGroup, deploymentName);
                counter = counter + 5000 > 60000 ? 60000 : counter + 5000;

            } while (!status.Any(s => s.Equals(deployment.Properties.ProvisioningState, StringComparison.OrdinalIgnoreCase)));

            return deployment;
        }

        private List<DeploymentOperation> GetNewOperations(List<DeploymentOperation> old, Rest.Azure.IPage<DeploymentOperation> current)
        {
            List<DeploymentOperation> newOperations = new List<DeploymentOperation>();
            foreach (DeploymentOperation operation in current)
            {
                DeploymentOperation operationWithSameIdAndProvisioningState = old.Find(o => o.OperationId.Equals(operation.OperationId) && o.Properties.ProvisioningState.Equals(operation.Properties.ProvisioningState));
                if (operationWithSameIdAndProvisioningState == null)
                {
                    newOperations.Add(operation);
                }

                //If nested deployment, get the operations under those deployments as well. Check if the deployment exists before calling list operations on it
                if (operation.Properties.TargetResource != null &&
                    operation.Properties.TargetResource.ResourceType.Equals("Microsoft.Resources/deployments", StringComparison.OrdinalIgnoreCase) &&
                    ResourceManagementClient.Deployments.CheckExistence(
                        resourceGroupName: GetResourceGroupName(operation.Properties.TargetResource.Id),
                        deploymentName: operation.Properties.TargetResource.ResourceName))
                {
                    HttpStatusCode statusCode;
                    Enum.TryParse<HttpStatusCode>(operation.Properties.StatusCode, out statusCode);
                    if (!IsClientFailureRequest((int)statusCode))
                    {
                        List<DeploymentOperation> newNestedOperations = new List<DeploymentOperation>();
                        Rest.Azure.IPage<DeploymentOperation> result;

                        result = ResourceManagementClient.DeploymentOperations.List(
                            resourceGroupName: GetResourceGroupName(operation.Properties.TargetResource.Id),
                            deploymentName: operation.Properties.TargetResource.ResourceName);

                        newNestedOperations = GetNewOperations(operations, result);

                        foreach (DeploymentOperation op in newNestedOperations)
                        {
                            DeploymentOperation nestedOperationWithSameIdAndProvisioningState = newOperations.Find(o => o.OperationId.Equals(op.OperationId) && o.Properties.ProvisioningState.Equals(op.Properties.ProvisioningState));

                            if (nestedOperationWithSameIdAndProvisioningState == null)
                            {
                                newOperations.Add(op);
                            }
                        }
                    }
                }
            }

            return newOperations;
        }

        /// <summary>
        /// Returns true if the status code corresponds to client failure.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        private static bool IsClientFailureRequest(int statusCode)
        {
            return statusCode == 505 || statusCode == 501 || (statusCode >= 400 && statusCode < 500 && statusCode != 408);
        }

        /// <summary>
        /// Gets the name of the resource group from the resource id.
        /// </summary>
        /// <param name="resourceId">The resource id.</param>
        private static string GetResourceGroupName(string resourceId)
        {
            return GetNextSegmentAfter(resourceId: resourceId, segmentName: "ResourceGroups");
        }

        /// <summary>
        /// Gets the next segment after the one specified in <paramref name="segmentName"/>.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="segmentName">The segment name.</param>
        /// <param name="selectLastSegment">When set to true, gets the last segment (default) otherwise gets the first one.</param>
        private static string GetNextSegmentAfter(string resourceId, string segmentName, bool selectLastSegment = false)
        {
            var segment = GetSubstringAfterSegment(
                    resourceId: resourceId,
                    segmentName: segmentName,
                    selectLastSegment: selectLastSegment);
            var segments = SplitRemoveEmpty(segment, '/').FirstOrDefault();
            return string.IsNullOrWhiteSpace(segment)
                ? null
                : segment;
        }

        /// <summary>
        /// Gets a the substring after a segment.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="segmentName">The segment name.</param>
        /// <param name="selectLastSegment">When set to true, gets the last segment (default) otherwise gets the first one.</param>
        private static string GetSubstringAfterSegment(string resourceId, string segmentName, bool selectLastSegment = true)
        {
            var segment = string.Format("/{0}/", segmentName.Trim('/').ToUpperInvariant());

            var index = selectLastSegment
                ? resourceId.LastIndexOf(segment, StringComparison.InvariantCultureIgnoreCase)
                : resourceId.IndexOf(segment, StringComparison.InvariantCultureIgnoreCase);

            return index < 0
                ? null
                : resourceId.Substring(index + segment.Length);
        }

        /// <summary>
        /// Splits the string with given separators and removes empty entries.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="separator">Separator characters.</param>
        private static string[] SplitRemoveEmpty(string source, params char[] separator)
        {
            source = source ?? string.Empty;
            return source.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
