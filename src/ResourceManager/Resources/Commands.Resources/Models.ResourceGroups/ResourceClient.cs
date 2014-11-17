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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Monitoring.Events;
using Newtonsoft.Json;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Azure.Commands.Resources.Models.Authorization;
using System.Diagnostics;

namespace Microsoft.Azure.Commands.Resources.Models
{
    public partial class ResourcesClient
    {
        /// <summary>
        /// Used when provisioning the deployment status.
        /// </summary>
        private List<DeploymentOperation> operations;

        public IResourceManagementClient ResourceManagementClient { get; set; }

        public IAuthorizationManagementClient AuthorizationManagementClient { get; set; }

        public GalleryTemplatesClient GalleryTemplatesClient { get; set; }

        public IEventsClient EventsClient { get; set; }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        /// <summary>
        /// Creates new ResourceManagementClient
        /// </summary>
        /// <param name="subscription">Subscription containing resources to manipulate</param>
        public ResourcesClient(AzureContext context)
            : this(
                AzureSession.ClientFactory.CreateClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager),
                new GalleryTemplatesClient(context),
                AzureSession.ClientFactory.CreateClient<EventsClient>(context, AzureEnvironment.Endpoint.ResourceManager),
                AzureSession.ClientFactory.CreateClient<AuthorizationManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {

        }

        /// <summary>
        /// Creates new ResourcesClient instance
        /// </summary>
        /// <param name="resourceManagementClient">The IResourceManagementClient instance</param>
        /// <param name="galleryTemplatesClient">The IGalleryClient instance</param>
        /// <param name="eventsClient">The IEventsClient instance</param>
        public ResourcesClient(
            IResourceManagementClient resourceManagementClient,
            GalleryTemplatesClient galleryTemplatesClient,
            IEventsClient eventsClient,
            IAuthorizationManagementClient authorizationManagementClient)
        {
            ResourceManagementClient = resourceManagementClient;
            GalleryTemplatesClient = galleryTemplatesClient;
            EventsClient = eventsClient;
            AuthorizationManagementClient = authorizationManagementClient;
        }

        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        public ResourcesClient()
        {

        }

        private string GetDeploymentParameters(Hashtable templateParameterObject)
        {
            if (templateParameterObject != null)
            {
                return SerializeHashtable(templateParameterObject, addValueLayer: true);
            }
            else
            {
                return null;
            }
        }

        private List<Provider> ListResourceProviders()
        {
            ProviderListResult result = ResourceManagementClient.Providers.List(null);
            List<Provider> providers = new List<Provider>(result.Providers);

            while (!string.IsNullOrEmpty(result.NextLink))
            {
                result = ResourceManagementClient.Providers.ListNext(result.NextLink);
                providers.AddRange(result.Providers);
            }
            return providers;
        }

        public string SerializeHashtable(Hashtable templateParameterObject, bool addValueLayer)
        {
            if (templateParameterObject == null)
            {
                return null;
            }
            Dictionary<string, object> parametersDictionary = templateParameterObject.ToDictionary(addValueLayer);
            return JsonConvert.SerializeObject(parametersDictionary, new JsonSerializerSettings
                {
                    TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                    TypeNameHandling = TypeNameHandling.None,
                    Formatting = Formatting.Indented
                });
        }

        public virtual void UnregisterProvider(string RPName)
        {
            ResourceManagementClient.Providers.Unregister(RPName);
        }

        private string GetTemplate(string templateFile, string galleryTemplateName)
        {
            string template;

            if (!string.IsNullOrEmpty(templateFile))
            {
                if (Uri.IsWellFormedUriString(templateFile, UriKind.Absolute))
                {
                    template = GeneralUtilities.DownloadFile(templateFile);
                }
                else
                {
                    template = FileUtilities.DataStore.ReadFileAsText(templateFile);
                }
            }
            else
            {
                Debug.Assert(!string.IsNullOrEmpty(galleryTemplateName));
                string templateUri = GalleryTemplatesClient.GetGalleryTemplateFile(galleryTemplateName);
                template = GeneralUtilities.DownloadFile(templateUri);
            }

            return template;
        }

        private ResourceGroup CreateOrUpdateResourceGroup(string name, string location, Hashtable[] tags)
        {
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(tags, validate: true);

            var result = ResourceManagementClient.ResourceGroups.CreateOrUpdate(name,
                new BasicResourceGroup
                {
                    Location = location,
                    Tags = tagDictionary
                });

            return result.ResourceGroup;
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

        private Deployment ProvisionDeploymentStatus(string resourceGroup, string deploymentName, BasicDeployment deployment)
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

        private void WriteDeploymentProgress(string resourceGroup, string deploymentName, BasicDeployment deployment)
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
                    statusMessage = string.Format(normalStatusFormat,
                        operation.Properties.TargetResource.ResourceType,
                        operation.Properties.TargetResource.ResourceName,
                        operation.Properties.ProvisioningState.ToLower());

                    WriteVerbose(statusMessage);
                }
                else
                {
                    string errorMessage = ParseErrorMessage(operation.Properties.StatusMessage);

                    statusMessage = string.Format(failureStatusFormat,
                        operation.Properties.TargetResource.ResourceType,
                        operation.Properties.TargetResource.ResourceName,
                        errorMessage);

                    WriteError(statusMessage);
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

        private Deployment WaitDeploymentStatus(
            string resourceGroup,
            string deploymentName,
            BasicDeployment basicDeployment,
            Action<string, string, BasicDeployment> job,
            params string[] status)
        {
            Deployment deployment;

            do
            {
                if (job != null)
                {
                    job(resourceGroup, deploymentName, basicDeployment);
                }

                deployment = ResourceManagementClient.Deployments.Get(resourceGroup, deploymentName).Deployment;
                Thread.Sleep(2000);

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
            }

            return newOperations;
        }

        private BasicDeployment CreateBasicDeployment(ValidatePSResourceGroupDeploymentParameters parameters)
        {
            BasicDeployment deployment = new BasicDeployment
            {
                Mode = DeploymentMode.Incremental,
                Template = GetTemplate(parameters.TemplateFile, parameters.GalleryTemplateIdentity),
                Parameters = GetDeploymentParameters(parameters.TemplateParameterObject)
            };

            return deployment;
        }

        private TemplateValidationInfo CheckBasicDeploymentErrors(string resourceGroup, string deploymentName, BasicDeployment deployment)
        {
            DeploymentValidateResponse validationResult = ResourceManagementClient.Deployments.Validate(
                resourceGroup,
                deploymentName,
                deployment);

            return new TemplateValidationInfo(validationResult);
        }

        internal List<PSPermission> GetResourceGroupPermissions(string resourceGroup)
        {
            PermissionGetResult permissionsResult = AuthorizationManagementClient.Permissions.ListForResourceGroup(resourceGroup);

            if (permissionsResult != null)
            {
                return permissionsResult.Permissions.Select(p => p.ToPSPermission()).ToList();
            }

            return null;
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
    }
}