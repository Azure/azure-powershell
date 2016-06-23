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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Microsoft.Azure.Commands.Resources.Models
{
    public partial class ResourcesClient
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

        public IResourceManagementClient ResourceManagementClient { get; set; }

        public IAuthorizationManagementClient AuthorizationManagementClient { get; set; }

        public GalleryTemplatesClient GalleryTemplatesClient { get; set; }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        /// <summary>
        /// Creates new ResourceManagementClient
        /// </summary>
        /// <param name="context">Profile containing resources to manipulate</param>
        public ResourcesClient(AzureContext context)
            : this(
                AzureSession.ClientFactory.CreateClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager),
                new GalleryTemplatesClient(context),
                AzureSession.ClientFactory.CreateClient<AuthorizationManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {

        }

        /// <summary>
        /// Creates new ResourcesClient instance
        /// </summary>
        /// <param name="resourceManagementClient">The IResourceManagementClient instance</param>
        /// <param name="galleryTemplatesClient">The IGalleryClient instance</param>
        /// <param name="authorizationManagementClient">The management client instance</param>
        public ResourcesClient(
            IResourceManagementClient resourceManagementClient,
            GalleryTemplatesClient galleryTemplatesClient,
            IAuthorizationManagementClient authorizationManagementClient)
        {
            GalleryTemplatesClient = galleryTemplatesClient;
            AuthorizationManagementClient = authorizationManagementClient;
            this.ResourceManagementClient = resourceManagementClient;
        }

        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        public ResourcesClient()
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

        public DeploymentExtended ProvisionDeploymentStatus(string resourceGroup, string deploymentName, Deployment deployment)
        {
            operations = new List<DeploymentOperation>();

            return WaitDeploymentStatus(
                resourceGroup,
                deploymentName,
                deployment,
                WriteDeploymentProgress,
                ProvisioningState.Canceled,
                ProvisioningState.Succeeded,
                ProvisioningState.Failed);
        }

        internal List<PSPermission> GetResourcePermissions(ResourceIdentifier identity)
        {
            PermissionGetResult permissionsResult = AuthorizationManagementClient.Permissions.ListForResource(
                    identity.ResourceGroupName,
                    identity.ToResourceIdentity());

            if (permissionsResult != null)
            {
                return permissionsResult.Permissions.Select(p => p.ToPSPermission()).ToList();
            }

            return null;
        }

        private void WriteDeploymentProgress(string resourceGroup, string deploymentName, Deployment deployment)
        {
            const string normalStatusFormat = "Resource {0} '{1}' provisioning status is {2}";
            const string failureStatusFormat = "Resource {0} '{1}' failed with message '{2}'";
            List<DeploymentOperation> newOperations;
            DeploymentOperationsListResult result;

            result = ResourceManagementClient.DeploymentOperations.List(resourceGroup, deploymentName, null);
            newOperations = GetNewOperations(operations, result.Operations);
            operations.AddRange(newOperations);

            while (!string.IsNullOrEmpty(result.NextLink))
            {
                result = ResourceManagementClient.DeploymentOperations.ListNext(result.NextLink);
                newOperations = GetNewOperations(operations, result.Operations);
                operations.AddRange(newOperations);
            }

            foreach (DeploymentOperation operation in newOperations)
            {
                string statusMessage;

                if (operation.Properties.ProvisioningState != ProvisioningState.Failed)
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
                    string errorMessage = ParseErrorMessage(operation.Properties.StatusMessage);

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

                    List<string> detailedMessage = ParseDetailErrorMessage(operation.Properties.StatusMessage);

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

                deployment = ResourceManagementClient.Deployments.Get(resourceGroup, deploymentName).Deployment;
                counter = counter + 5000 > 60000 ? 60000 : counter + 5000;

            } while (!status.Any(s => s.Equals(deployment.Properties.ProvisioningState, StringComparison.OrdinalIgnoreCase)));

            return deployment;
        }

        private List<DeploymentOperation> GetNewOperations(List<DeploymentOperation> old, IList<DeploymentOperation> current)
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
                    operation.Properties.TargetResource.ResourceType.Equals(Constants.MicrosoftResourcesDeploymentType, StringComparison.OrdinalIgnoreCase) &&
                    ResourceManagementClient.Deployments.CheckExistence(
                        resourceGroupName: ResourceIdUtility.GetResourceGroupName(operation.Properties.TargetResource.Id),
                        deploymentName: operation.Properties.TargetResource.ResourceName).Exists)
                {
                    HttpStatusCode statusCode;
                    Enum.TryParse<HttpStatusCode>(operation.Properties.StatusCode, out statusCode);
                    if (!statusCode.IsClientFailureRequest())
                    {
                        List<DeploymentOperation> newNestedOperations = new List<DeploymentOperation>();
                        DeploymentOperationsListResult result;

                        result = ResourceManagementClient.DeploymentOperations.List(
                            resourceGroupName: ResourceIdUtility.GetResourceGroupName(operation.Properties.TargetResource.Id),
                            deploymentName: operation.Properties.TargetResource.ResourceName,
                            parameters: null);

                        newNestedOperations = GetNewOperations(operations, result.Operations);

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
        /// Filters a given resource group resources.
        /// </summary>
        /// <param name="options">The filtering options</param>
        /// <returns>The filtered set of resources matching the filter criteria</returns>
        public virtual List<GenericResourceExtended> FilterResources(FilterResourcesOptions options)
        {
            List<GenericResourceExtended> resources = new List<GenericResourceExtended>();

            if (!string.IsNullOrEmpty(options.ResourceGroup) && !string.IsNullOrEmpty(options.Name))
            {
                resources.Add(ResourceManagementClient.Resources.Get(options.ResourceGroup,
                    new ResourceIdentity { ResourceName = options.Name }).Resource);
            }
            else
            {
                ResourceListResult result = ResourceManagementClient.Resources.List(new ResourceListParameters
                {
                    ResourceGroupName = options.ResourceGroup,
                    ResourceType = options.ResourceType
                });

                resources.AddRange(result.Resources);

                while (!string.IsNullOrEmpty(result.NextLink))
                {
                    result = ResourceManagementClient.Resources.ListNext(result.NextLink);
                    resources.AddRange(result.Resources);
                }
            }

            return resources;
        }

        public ProviderOperationsMetadata GetProviderOperationsMetadata(string providerNamespace)
        {
            ProviderOperationsMetadataGetResult result = this.ResourceManagementClient.ProviderOperationsMetadata.Get(providerNamespace);
            return result.Provider;
        }

        public IList<ProviderOperationsMetadata> ListProviderOperationsMetadata()
        {
            ProviderOperationsMetadataListResult result = this.ResourceManagementClient.ProviderOperationsMetadata.List();
            return result.Providers;
        }
    }
}