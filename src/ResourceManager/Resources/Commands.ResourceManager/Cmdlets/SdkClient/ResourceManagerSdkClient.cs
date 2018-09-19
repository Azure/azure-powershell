﻿// ----------------------------------------------------------------------------------
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
using System.Net;
using System.Runtime.Serialization.Formatters;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkExtensions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;
using Microsoft.Azure.Commands.ResourceManager.Common.Paging;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient
{
    public class ResourceManagerSdkClient
    {
        /// <summary>
        /// A string that indicates the value of the resource type name for the RP's operations api
        /// </summary>
        public const string Operations = "operations";

        /// <summary>
        /// A string that indicates the value of the registering state enum for a provider
        /// </summary>
        public const string RegisteredStateName = "Registered";

        public const string ResourceGroupTypeName = "ResourceGroup";

        public const string ErrorFormat = "Error: Code={0}; Message={1}\r\n";

        /// <summary>
        /// Used when provisioning the deployment status.
        /// </summary>
        private List<DeploymentOperation> operations;

        public IResourceManagementClient ResourceManagementClient { get; set; }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public static List<string> KnownLocations = new List<string>
        {
            "East Asia", "South East Asia", "East US", "West US", "North Central US",
            "South Central US", "Central US", "North Europe", "West Europe"
        };

        internal static List<string> KnownLocationsNormalized = KnownLocations
            .Select(loc => loc.ToLower().Replace(" ", "")).ToList();

        /// <summary>
        /// Creates new ResourceManagementClient
        /// </summary>
        /// <param name="context">Profile containing resources to manipulate</param>
        public ResourceManagerSdkClient(IAzureContext context)
            : this(
                AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {

        }

        /// <summary>
        /// Creates new ResourcesClient instance
        /// </summary>
        /// <param name="resourceManagementClient">The IResourceManagementClient instance</param>
        /// <param name="galleryTemplatesClient">The IGalleryClient instance</param>
        /// <param name="authorizationManagementClient">The management client instance</param>
        public ResourceManagerSdkClient(
            IResourceManagementClient resourceManagementClient)
        {
            this.ResourceManagementClient = resourceManagementClient;
        }

        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        public ResourceManagerSdkClient()
        {

        }

        private string GetDeploymentParameters(Hashtable templateParameterObject)
        {
            if (templateParameterObject != null)
            {
                return SerializeHashtable(templateParameterObject, addValueLayer: false);
            }
            else
            {
                return null;
            }
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
                TypeNameHandling = TypeNameHandling.None,
                Formatting = Formatting.Indented
            });
        }

        public virtual PSResourceProvider UnregisterProvider(string providerName)
        {
            var response = this.ResourceManagementClient.Providers.Unregister(providerName);

            if (response == null)
            {
                throw new KeyNotFoundException(string.Format(ProjectResources.ResourceProviderUnregistrationFailed, providerName));
            }

            return response.ToPSResourceProvider();
        }

        private string GetTemplate(string templateFile)
        {
            string template = string.Empty;

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

            return template;
        }

        private ResourceGroup CreateOrUpdateResourceGroup(string name, string location, Hashtable tags)
        {
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(tags, validate: true);

            var result = ResourceManagementClient.ResourceGroups.CreateOrUpdate(name,
                new ResourceGroup
                {
                    Location = location,
                    Tags = tagDictionary
                });

            return result;
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

        private void WriteDeploymentProgress(string resourceGroup, string deploymentName, Deployment deployment)
        {
            const string normalStatusFormat = "Resource {0} '{1}' provisioning status is {2}";
            const string failureStatusFormat = "Resource {0} '{1}' failed with message '{2}'";
            List<DeploymentOperation> newOperations;

            var result = this.ListDeploymentOperations(resourceGroup, deploymentName);

            newOperations = GetNewOperations(operations, result);
            operations.AddRange(newOperations);

            while (!string.IsNullOrEmpty(result.NextPageLink))
            {
                result = this.ListNextDeploymentOperations(resourceGroup, result.NextPageLink);
                newOperations = GetNewOperations(operations, result);
                operations.AddRange(newOperations);
            }

            foreach (DeploymentOperation operation in newOperations)
            {
                string statusMessage;

                if (operation.Properties.ProvisioningState != ProvisioningState.Failed.ToString())
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
                    string errorMessage = operation.Properties.StatusMessage.ToString();

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

                    if (detailedMessage != null && detailedMessage.Count > 0)
                    {
                        detailedMessage.ForEach(s => WriteError(s));
                    }
                }
            }
        }

        public static List<string> ParseDetailErrorMessage(string statusMessage)
        {
            if (!string.IsNullOrEmpty(statusMessage))
            {
                List<string> detailedMessage = new List<string>();
                try
                {
                    dynamic errorMessage = JsonConvert.DeserializeObject(statusMessage);
                    if (errorMessage.error != null && errorMessage.error.details != null)
                    {
                        foreach (var detail in errorMessage.error.details)
                        {
                            detailedMessage.Add(detail.message.ToString());
                        }
                    }
                }
                catch
                {
                    //statusMessage is not always a valid JSON. It can sometimes be a string, which can result is DeserializeObject exception above in try
                    detailedMessage.Add(statusMessage);
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
            params ProvisioningState[] status)
        {
            DeploymentExtended deployment;

            // Poll deployment state and deployment operations after RetryAfter.
            // If no RetryAfter provided: In phase one, poll every 5 seconds. Phase one
            // takes 400 seconds. In phase two, poll every 60 seconds.
            const int counterUnit = 1000;
            int step = 5;
            int phaseOne = 400;

            do
            {
                WriteVerbose(string.Format(ProjectResources.CheckingDeploymentStatus, step));
                TestMockSupport.Delay(step * counterUnit);

                if (phaseOne > 0)
                {
                    phaseOne -= step;
                }

                if (job != null)
                {
                    job(resourceGroup, deploymentName, basicDeployment);
                }

                var getDeploymentTask = resourceGroup != null
                    ? ResourceManagementClient.Deployments.GetWithHttpMessagesAsync(resourceGroup, deploymentName)
                    : ResourceManagementClient.Deployments.GetAtSubscriptionScopeWithHttpMessagesAsync(deploymentName);

                using (var getResult = getDeploymentTask.ConfigureAwait(false).GetAwaiter().GetResult())
                {
                    deployment = getResult.Body;
                    var response = getResult.Response;
                    if (response != null && response.Headers.RetryAfter != null && response.Headers.RetryAfter.Delta.HasValue)
                    {
                        step = response.Headers.RetryAfter.Delta.Value.Seconds;
                    }
                    else
                    {
                        step = phaseOne > 0 ? 5 : 60;
                    }
                }
            } while (!status.Any(s => s.ToString().Equals(deployment.Properties.ProvisioningState, StringComparison.OrdinalIgnoreCase)));

            return deployment;
        }

        private List<DeploymentOperation> GetNewOperations(List<DeploymentOperation> old, IPage<DeploymentOperation> current)
        {
            List<DeploymentOperation> newOperations = new List<DeploymentOperation>();
            foreach (DeploymentOperation operation in current)
            {
                DeploymentOperation operationWithSameIdAndProvisioningState = old.Find(o => o.OperationId.Equals(operation.OperationId) && o.Properties.ProvisioningState.Equals(operation.Properties.ProvisioningState));
                if (operationWithSameIdAndProvisioningState == null)
                {
                    newOperations.Add(operation);
                }

                //If nested deployment, get the operations under those deployments as well
                if (operation.Properties.TargetResource != null && operation.Properties.TargetResource.ResourceType.Equals(Constants.MicrosoftResourcesDeploymentType, StringComparison.OrdinalIgnoreCase))
                {
                    HttpStatusCode statusCode;
                    Enum.TryParse<HttpStatusCode>(operation.Properties.StatusCode, out statusCode);
                    if (!statusCode.IsClientFailureRequest())
                    {
                        var resourceGroupName = ResourceIdUtility.GetResourceGroupName(operation.Properties.TargetResource.Id);
                        var deploymentName = operation.Properties.TargetResource.ResourceName;

                        if (this.CheckDeploymentExistence(resourceGroupName, deploymentName) == true)
                        {
                            List<DeploymentOperation> newNestedOperations = new List<DeploymentOperation>();

                            var result = this.ListDeploymentOperations(resourceGroupName, deploymentName);

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
            }

            return newOperations;
        }

        private Deployment CreateBasicDeployment(PSDeploymentCmdletParameters parameters, DeploymentMode deploymentMode, string debugSetting)
        {
            Deployment deployment = new Deployment
            {
                Properties = new DeploymentProperties
                {
                    Mode = deploymentMode
                }
            };

            if (!string.IsNullOrEmpty(debugSetting))
            {
                deployment.Properties.DebugSetting = new DebugSetting
                {
                    DetailLevel = debugSetting
                };
            }

            if (Uri.IsWellFormedUriString(parameters.TemplateFile, UriKind.Absolute))
            {
                deployment.Properties.TemplateLink = new TemplateLink
                {
                    Uri = parameters.TemplateFile
                };
            }
            else
            {
                deployment.Properties.Template = JObject.Parse(FileUtilities.DataStore.ReadFileAsText(parameters.TemplateFile));
            }

            if (Uri.IsWellFormedUriString(parameters.ParameterUri, UriKind.Absolute))
            {
                deployment.Properties.ParametersLink = new ParametersLink
                {
                    Uri = parameters.ParameterUri
                };
            }
            else
            {
                string templateParams = GetDeploymentParameters(parameters.TemplateParameterObject);
                deployment.Properties.Parameters = string.IsNullOrEmpty(templateParams) ? null : JObject.Parse(templateParams);
            }

            deployment.Location = parameters.Location;
            deployment.Properties.OnErrorDeployment = parameters.OnErrorDeployment;

            return deployment;
        }

        private TemplateValidationInfo CheckBasicDeploymentErrors(string resourceGroup, string deploymentName, Deployment deployment)
        {
            DeploymentValidateResult validationResult = resourceGroup != null
                ? ResourceManagementClient.Deployments.Validate(resourceGroup, deploymentName, deployment)
                : ResourceManagementClient.Deployments.ValidateAtSubscriptionScope(deploymentName, deployment);

            return new TemplateValidationInfo(validationResult);
        }

        private IPage<DeploymentOperation> ListDeploymentOperations(string resourceGroupName, string deploymentName)
        {
            return resourceGroupName != null
                ? this.ResourceManagementClient.DeploymentOperations.List(resourceGroupName, deploymentName, null)
                : this.ResourceManagementClient.DeploymentOperations.ListAtSubscriptionScope(deploymentName, null);
        }

        private IPage<DeploymentOperation> ListNextDeploymentOperations(string resourceGroupName, string nextLink)
        {
            return resourceGroupName != null
                ? this.ResourceManagementClient.DeploymentOperations.ListNext(nextLink)
                : this.ResourceManagementClient.DeploymentOperations.ListAtSubscriptionScopeNext(nextLink);
        }

        private bool CheckDeploymentExistence(string resourceGroupName, string deploymentName)
        {
            return resourceGroupName != null
                ? this.ResourceManagementClient.Deployments.CheckExistence(resourceGroupName, deploymentName)
                : this.ResourceManagementClient.Deployments.CheckExistenceAtSubscriptionScope(deploymentName);
        }

        private void BeginDeployment(string resourceGroupName, string deploymentName, Deployment deployment)
        {
            if (resourceGroupName == null)
            {
                this.ResourceManagementClient.Deployments.BeginCreateOrUpdateAtSubscriptionScope(deploymentName, deployment);
            }
            else
            {
                this.ResourceManagementClient.Deployments.BeginCreateOrUpdate(resourceGroupName, deploymentName, deployment);
            }
        }

        public string GetDeploymentTemplate(string deploymentName)
        {
            var exportResult = ResourceManagementClient.Deployments.ExportTemplateAtSubscriptionScope(deploymentName);

            return JToken.FromObject(exportResult.Template).ToString();
        }

        public virtual List<Provider> ListResourceProviders(string providerName = null, bool listAvailable = true)
        {
            if (!string.IsNullOrEmpty(providerName))
            {
                var provider = this.ResourceManagementClient.Providers.Get(providerName);

                if (provider == null)
                {
                    throw new KeyNotFoundException(string.Format(ProjectResources.ResourceProviderNotFound, providerName));
                }

                return new List<Provider> { provider };
            }
            else
            {
                var returnList = new List<Provider>();
                var tempResult = this.ResourceManagementClient.Providers.List(null);
                returnList.AddRange(tempResult);

                while (!string.IsNullOrWhiteSpace(tempResult.NextPageLink))
                {
                    tempResult = this.ResourceManagementClient.Providers.ListNext(tempResult.NextPageLink);
                    returnList.AddRange(tempResult);
                }

                return listAvailable
                    ? returnList
                    : returnList.Where(this.IsProviderRegistered).ToList();
            }
        }

        public List<Provider> GetRegisteredProviders(List<Provider> providers)
        {
            return providers.CoalesceEnumerable().Where(this.IsProviderRegistered).ToList();
        }

        private bool IsProviderRegistered(Provider provider)
        {
            return string.Equals(
                ResourceManagerSdkClient.RegisteredStateName,
                provider.RegistrationState,
                StringComparison.InvariantCultureIgnoreCase);
        }

        public PSResourceProvider RegisterProvider(string providerName)
        {
            var response = this.ResourceManagementClient.Providers.Register(providerName);

            if (response == null)
            {
                throw new KeyNotFoundException(string.Format(ProjectResources.ResourceProviderRegistrationFailed, providerName));
            }

            return response.ToPSResourceProvider();
        }

        /// <summary>
        /// Parses an array of resource ids to extract the resource group name
        /// </summary>
        /// <param name="resourceIds">An array of resource ids</param>
        public ResourceIdentifier[] ParseResourceIds(string[] resourceIds)
        {
            var splitResourceIds = resourceIds
               .Select(resourceId => resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries))
               .ToArray();

            if (splitResourceIds.Any(splitResourceId => splitResourceId.Length % 2 != 0 ||
                splitResourceId.Length < 8 ||
                !string.Equals("subscriptions", splitResourceId[0], StringComparison.InvariantCultureIgnoreCase) ||
                !string.Equals("resourceGroups", splitResourceId[2], StringComparison.InvariantCultureIgnoreCase) ||
                !string.Equals("providers", splitResourceId[4], StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new System.Management.Automation.PSArgumentException(ProjectResources.InvalidFormatOfResourceId);
            }

            return resourceIds
                .Distinct(StringComparer.InvariantCultureIgnoreCase)
                .Select(resourceId => new ResourceIdentifier(resourceId))
                .ToArray();
        }

        /// <summary>
        /// Creates a new resource group
        /// </summary>
        /// <param name="parameters">The create parameters</param>
        public virtual PSResourceGroup CreatePSResourceGroup(PSCreateResourceGroupParameters parameters)
        {
            bool resourceExists = ResourceManagementClient.ResourceGroups.CheckExistence(parameters.ResourceGroupName);

            ResourceGroup resourceGroup = null;
            parameters.ConfirmAction(parameters.Force,
                ProjectResources.ResourceGroupAlreadyExists,
                ProjectResources.NewResourceGroupMessage,
                parameters.ResourceGroupName,
                () =>
                {
                    resourceGroup = CreateOrUpdateResourceGroup(parameters.ResourceGroupName, parameters.Location, parameters.Tag);
                    WriteVerbose(string.Format(ProjectResources.CreatedResourceGroup, resourceGroup.Name, resourceGroup.Location));
                },
                () => resourceExists);

            return resourceGroup != null ? resourceGroup.ToPSResourceGroup() : null;
        }

        /// <summary>
        /// Updates a resource group.
        /// </summary>
        /// <param name="parameters">The create parameters</param>
        public virtual PSResourceGroup UpdatePSResourceGroup(PSUpdateResourceGroupParameters parameters)
        {
            if (!ResourceManagementClient.ResourceGroups.CheckExistence(parameters.ResourceGroupName))
            {
                WriteError(ProjectResources.ResourceGroupDoesntExists);
                return null;
            }

            ResourceGroup resourceGroup = ResourceManagementClient.ResourceGroups.Get(parameters.ResourceGroupName);

            resourceGroup = CreateOrUpdateResourceGroup(parameters.ResourceGroupName, resourceGroup.Location, parameters.Tag);
            WriteVerbose(string.Format(ProjectResources.UpdatedResourceGroup, resourceGroup.Name, resourceGroup.Location));

            return resourceGroup.ToPSResourceGroup();
        }

        /// <summary>
        /// Filters the subscription's resource groups.
        /// </summary>
        /// <param name="name">The resource group name.</param>
        /// <param name="tag">The resource group tag.</param>
        /// <param name="detailed">Whether the  return is detailed or not.</param>
        /// <param name="location">The resource group location.</param>
        /// <returns>The filtered resource groups</returns>
        public virtual List<PSResourceGroup> FilterResourceGroups(string name, Hashtable tag, bool detailed, string location = null)
        {
            List<PSResourceGroup> result = new List<PSResourceGroup>();

            if (string.IsNullOrEmpty(name) || name.Contains("*"))
            {
                List<ResourceGroup> resourceGroups = new List<ResourceGroup>();

                var listResult = ResourceManagementClient.ResourceGroups.List(null);
                resourceGroups.AddRange(listResult);

                while (!string.IsNullOrEmpty(listResult.NextPageLink))
                {
                    listResult = ResourceManagementClient.ResourceGroups.ListNext(listResult.NextPageLink);
                    resourceGroups.AddRange(listResult);
                }

                if (!string.IsNullOrEmpty(name))
                {
                    if (name.StartsWith("*"))
                    {
                        name = name.TrimStart('*');
                        if (name.EndsWith("*"))
                        {
                            name = name.TrimEnd('*');
                            resourceGroups = resourceGroups.Where(g => g.Name.Contains(name)).ToList();
                        }
                        else
                        {
                            resourceGroups = resourceGroups.Where(g => g.Name.EndsWith(name)).ToList();
                        }
                    }
                    else if (name.EndsWith("*"))
                    {
                        name = name.TrimEnd('*');
                        resourceGroups = resourceGroups.Where(g => g.Name.StartsWith(name)).ToList();
                    }
                }

                resourceGroups = !string.IsNullOrEmpty(location)
                    ? resourceGroups.Where(resourceGroup => resourceGroup.Location.EqualsAsLocation(location)).ToList()
                    : resourceGroups;

                // TODO: Replace with server side filtering when available
                if (tag != null && tag.Count >= 1)
                {
                    PSTagValuePair tagValuePair = TagsConversionHelper.Create(tag);
                    if (tagValuePair == null)
                    {
                        throw new ArgumentException(ProjectResources.InvalidTagFormat);
                    }
                    if (string.IsNullOrEmpty(tagValuePair.Value))
                    {
                        resourceGroups =
                            resourceGroups.Where(rg => rg.Tags != null
                                                       && rg.Tags.Keys.Contains(tagValuePair.Name,
                                                           StringComparer.OrdinalIgnoreCase))
                                .Select(rg => rg).ToList();
                    }
                    else
                    {
                        resourceGroups =
                            resourceGroups.Where(rg => rg.Tags != null && rg.Tags.Keys.Contains(tagValuePair.Name,
                                                           StringComparer.OrdinalIgnoreCase))
                                          .Where(rg => rg.Tags.Values.Contains(tagValuePair.Value,
                                                           StringComparer.OrdinalIgnoreCase))
                                .Select(rg => rg).ToList();
                    }
                }
                result.AddRange(resourceGroups.Select(rg => rg.ToPSResourceGroup()));
            }
            else
            {
                try
                {
                    result.Add(ResourceManagementClient.ResourceGroups.Get(name).ToPSResourceGroup());
                }
                catch (CloudException)
                {
                    WriteError(ProjectResources.ResourceGroupDoesntExists);
                }
            }

            return result;
        }

        /// <summary>
        /// Deletes a given resource group
        /// </summary>
        /// <param name="name">The resource group name</param>
        public virtual void DeleteResourceGroup(string name)
        {
            if (!ResourceManagementClient.ResourceGroups.CheckExistence(name))
            {
                WriteError(ProjectResources.ResourceGroupDoesntExists);
            }
            else
            {
                ResourceManagementClient.ResourceGroups.Delete(name);
            }
        }

        /// <summary>
        /// Filters the deployments at subscription scope.
        /// </summary>
        /// <param name="options">The filtering options</param>
        /// <returns>The filtered list of deployments</returns>
        public virtual List<PSDeployment> FilterDeploymentsAtSubscriptionScope(FilterDeploymentOptions options)
        {
            List<PSDeployment> deployments = new List<PSDeployment>();
            string name = options.DeploymentName;
            List<string> excludedProvisioningStates = options.ExcludedProvisioningStates ?? new List<string>();

            if (!string.IsNullOrEmpty(name))
            {
                deployments.Add(ResourceManagementClient.Deployments.GetAtSubscriptionScope(name).ToPSDeployment());
            }
            else
            {
                var result = ResourceManagementClient.Deployments.ListAtSubscriptionScope();

                deployments.AddRange(result.Select(d => d.ToPSDeployment()));

                while (!string.IsNullOrEmpty(result.NextPageLink))
                {
                    result = ResourceManagementClient.Deployments.ListAtSubscriptionScopeNext(result.NextPageLink);
                    deployments.AddRange(result.Select(d => d.ToPSDeployment()));
                }
            }

            if (excludedProvisioningStates.Count > 0)
            {
                return deployments.Where(d => excludedProvisioningStates
                    .All(s => !s.Equals(d.ProvisioningState, StringComparison.OrdinalIgnoreCase))).ToList();
            }
            else
            {
                return deployments;
            }
        }

        /// <summary>
        /// Filters the resource group deployments
        /// </summary>
        /// <param name="options">The filtering options</param>
        /// <returns>The filtered list of deployments</returns>
        public virtual List<PSResourceGroupDeployment> FilterResourceGroupDeployments(FilterDeploymentOptions options)
        {
            List<PSResourceGroupDeployment> deployments = new List<PSResourceGroupDeployment>();
            string resourceGroup = options.ResourceGroupName;
            string name = options.DeploymentName;
            List<string> excludedProvisioningStates = options.ExcludedProvisioningStates ?? new List<string>();

            if (!string.IsNullOrEmpty(resourceGroup) && !string.IsNullOrEmpty(name))
            {
                deployments.Add(ResourceManagementClient.Deployments.Get(resourceGroup, name).ToPSResourceGroupDeployment(options.ResourceGroupName));
            }
            else if (!string.IsNullOrEmpty(resourceGroup))
            {
                var result = ResourceManagementClient.Deployments.ListByResourceGroup(resourceGroup, null);

                deployments.AddRange(result.Select(d => d.ToPSResourceGroupDeployment(options.ResourceGroupName)));

                while (!string.IsNullOrEmpty(result.NextPageLink))
                {
                    result = ResourceManagementClient.Deployments.ListByResourceGroupNext(result.NextPageLink);
                    deployments.AddRange(result.Select(d => d.ToPSResourceGroupDeployment(options.ResourceGroupName)));
                }
            }

            if (excludedProvisioningStates.Count > 0)
            {
                return deployments.Where(d => excludedProvisioningStates
                    .All(s => !s.Equals(d.ProvisioningState, StringComparison.OrdinalIgnoreCase))).ToList();
            }
            else
            {
                return deployments;
            }
        }

        /// <summary>
        /// Gets the deployment operations at subscription scope.
        /// </summary>
        /// <param name="deploymentName">The deployment name</param>
        /// <param name="operationId">The operation Id</param>
        /// <returns>The deployment operations</returns>
        public virtual List<PSDeploymentOperation> GetDeploymentOperations(string deploymentName, string operationId = null)
        {
            List<PSDeploymentOperation> deploymentOperations = new List<PSDeploymentOperation>();

            if (!string.IsNullOrEmpty(operationId))
            {
                deploymentOperations.Add(ResourceManagementClient.DeploymentOperations.GetAtSubscriptionScope(deploymentName, operationId).ToPSDeploymentOperation());
            }
            else
            {
                var result = ResourceManagementClient.DeploymentOperations.ListAtSubscriptionScope(deploymentName);

                deploymentOperations.AddRange(result.Select(d => d.ToPSDeploymentOperation()));

                while (!string.IsNullOrEmpty(result.NextPageLink))
                {
                    result = ResourceManagementClient.DeploymentOperations.ListAtSubscriptionScopeNext(result.NextPageLink);
                    deploymentOperations.AddRange(result.Select(d => d.ToPSDeploymentOperation()));
                }
            }

            return deploymentOperations;
        }

        /// <summary>
        /// Creates new deployment
        /// </summary>
        /// <param name="parameters">The create deployment parameters</param>
        public virtual PSDeployment ExecuteDeploymentAtSubscriptionScope(PSDeploymentCmdletParameters parameters)
        {
            parameters.DeploymentName = GenerateDeploymentName(parameters);
            Deployment deployment = CreateBasicDeployment(parameters, parameters.DeploymentMode, parameters.DeploymentDebugLogLevel);

            TemplateValidationInfo validationInfo = CheckBasicDeploymentErrors(parameters.ResourceGroupName, parameters.DeploymentName, deployment);

            if (validationInfo.Errors.Count != 0)
            {
                foreach (var error in validationInfo.Errors)
                {
                    WriteError(string.Format(ErrorFormat, error.Code, error.Message));
                    if (error.Details != null && error.Details.Count > 0)
                    {
                        foreach (var innerError in error.Details)
                        {
                            DisplayInnerDetailErrorMessage(innerError);
                        }
                    }
                }
                throw new InvalidOperationException(ProjectResources.FailedDeploymentValidation);
            }
            else
            {
                WriteVerbose(ProjectResources.TemplateValid);
            }

            this.BeginDeployment(parameters.ResourceGroupName, parameters.DeploymentName, deployment);

            WriteVerbose(string.Format(ProjectResources.CreatedDeployment, parameters.DeploymentName));
            DeploymentExtended result = ProvisionDeploymentStatus(parameters.ResourceGroupName, parameters.DeploymentName, deployment);

            return result.ToPSDeployment();
        }

        /// <summary>
        /// Creates new deployment
        /// </summary>
        /// <param name="parameters">The create deployment parameters</param>
        public virtual PSResourceGroupDeployment ExecuteDeployment(PSDeploymentCmdletParameters parameters)
        {
            parameters.DeploymentName = GenerateDeploymentName(parameters);
            Deployment deployment = CreateBasicDeployment(parameters, parameters.DeploymentMode, parameters.DeploymentDebugLogLevel);

            TemplateValidationInfo validationInfo = CheckBasicDeploymentErrors(parameters.ResourceGroupName, parameters.DeploymentName, deployment);

            if (validationInfo.Errors.Count != 0)
            {
                foreach (var error in validationInfo.Errors)
                {
                    WriteError(string.Format(ErrorFormat, error.Code, error.Message));
                    if (error.Details != null && error.Details.Count > 0)
                    {
                        foreach (var innerError in error.Details)
                        {
                            DisplayInnerDetailErrorMessage(innerError);
                        }
                    }
                }
                throw new InvalidOperationException(ProjectResources.FailedDeploymentValidation);
            }
            else
            {
                WriteVerbose(ProjectResources.TemplateValid);
            }

            this.BeginDeployment(parameters.ResourceGroupName, parameters.DeploymentName, deployment);
            
            WriteVerbose(string.Format(ProjectResources.CreatedDeployment, parameters.DeploymentName));
            DeploymentExtended result = ProvisionDeploymentStatus(parameters.ResourceGroupName, parameters.DeploymentName, deployment);

            return result.ToPSResourceGroupDeployment(parameters.ResourceGroupName);
        }

        private void DisplayInnerDetailErrorMessage(ResourceManagementErrorWithDetails error)
        {
            WriteError(string.Format(ErrorFormat, error.Code, error.Message));
            if (error.Details != null)
            {
                foreach (var innerError in error.Details)
                {
                    DisplayInnerDetailErrorMessage(innerError);
                }
            }
        }

        private string GenerateDeploymentName(PSDeploymentCmdletParameters parameters)
        {
            if (!string.IsNullOrEmpty(parameters.DeploymentName))
            {
                return parameters.DeploymentName;
            }
            else if (!string.IsNullOrEmpty(parameters.TemplateFile))
            {
                return Path.GetFileNameWithoutExtension(parameters.TemplateFile);
            }
            else
            {
                return Guid.NewGuid().ToString();
            }
        }

        /// <summary>
        /// Deletes a deployment
        /// </summary>
        /// <param name="deploymentName">Deployment name</param>
        public virtual void DeleteDeploymentAtSubscriptionScope(string deploymentName)
        {
            if (!ResourceManagementClient.Deployments.CheckExistenceAtSubscriptionScope(deploymentName))
            {
                throw new ArgumentException(string.Format(ProjectResources.DeploymentDoesntExistAtSubscriptionScope, deploymentName));
            }

            ResourceManagementClient.Deployments.DeleteAtSubscriptionScope(deploymentName);
        }

        /// <summary>
        /// Deletes a deployment
        /// </summary>
        /// <param name="resourceGroup">The resource group name</param>
        /// <param name="deploymentName">Deployment name</param>
        public virtual void DeleteDeployment(string resourceGroup, string deploymentName)
        {

            if (!ResourceManagementClient.Deployments.CheckExistence(resourceGroup, deploymentName))
            {
                throw new ArgumentException(string.Format(ProjectResources.DeploymentDoesntExistInResourceGroup, deploymentName, resourceGroup));
            }

            ResourceManagementClient.Deployments.Delete(resourceGroup, deploymentName);
        }

        /// <summary>
        /// Cancels the active deployment.
        /// </summary>
        /// <param name="deploymentName">Deployment name</param>
        public virtual void CancelDeploymentAtSubscriptionScope(string deploymentName)
        {
            if (string.IsNullOrEmpty(deploymentName))
            {
                throw new ArgumentException(string.Format(ProjectResources.NoDeploymentToCancel, deploymentName));
            }

            FilterDeploymentOptions options = new FilterDeploymentOptions
            {
                DeploymentName = deploymentName,
                ExcludedProvisioningStates = new List<string>
                {
                    ProvisioningState.Failed.ToString(),
                    ProvisioningState.Succeeded.ToString()
                }
            };

            List<PSDeployment> deployments = this.FilterDeploymentsAtSubscriptionScope(options);

            if (deployments.Count == 0)
            {
                throw new ArgumentException(string.Format(ProjectResources.NoRunningDeploymentsAtSubscriptionScope, deploymentName));
            }
            else
            {
                ResourceManagementClient.Deployments.CancelAtSubscriptionScope(deployments.First().DeploymentName);
            }
        }

        /// <summary>
        /// Cancels the active deployment.
        /// </summary>
        /// <param name="resourceGroup">The resource group name</param>
        /// <param name="deploymentName">Deployment name</param>
        public virtual void CancelDeployment(string resourceGroup, string deploymentName)
        {
            FilterDeploymentOptions options = new FilterDeploymentOptions
            {
                DeploymentName = deploymentName,
                ResourceGroupName = resourceGroup
            };

            if (string.IsNullOrEmpty(deploymentName))
            {
                options.ExcludedProvisioningStates = new List<string>
                {
                    ProvisioningState.Failed.ToString(),
                    ProvisioningState.Succeeded.ToString()
                };
            }

            List<PSResourceGroupDeployment> deployments = FilterResourceGroupDeployments(options);

            if (deployments.Count == 0)
            {
                if (string.IsNullOrEmpty(deploymentName))
                {
                    throw new ArgumentException(string.Format(ProjectResources.NoDeploymentToCancel, deploymentName));
                }
                else
                {
                    throw new ArgumentException(string.Format(ProjectResources.NoRunningDeployments, resourceGroup));
                }
            }
            else if (deployments.Count == 1)
            {
                ResourceManagementClient.Deployments.Cancel(resourceGroup, deployments.First().DeploymentName);
            }
            else
            {
                throw new ArgumentException(ProjectResources.MultipleRunningDeployment);
            }
        }

        /// <summary>
        /// Validates a given deployment.
        /// </summary>
        /// <param name="parameters">The deployment create options</param>
        /// <param name="deploymentMode">The deployment mode</param>
        /// <returns>The validation errors if there's any, or empty list otherwise.</returns>
        public virtual List<PSResourceManagerError> ValidateDeployment(PSDeploymentCmdletParameters parameters, DeploymentMode deploymentMode)
        {
            Deployment deployment = CreateBasicDeployment(parameters, deploymentMode, null);
            TemplateValidationInfo validationInfo = CheckBasicDeploymentErrors(parameters.ResourceGroupName, Guid.NewGuid().ToString(), deployment);

            if (validationInfo.Errors.Count == 0)
            {
                WriteVerbose(ProjectResources.TemplateValid);
            }
            return validationInfo.Errors.Select(e => e.ToPSResourceManagerError()).ToList();
        }

        public virtual IEnumerable<PSResource> ListResources(Rest.Azure.OData.ODataQuery<GenericResourceFilter> filter = null, ulong first = ulong.MaxValue, ulong skip = ulong.MinValue)
        {
            return new GenericPageEnumerable<GenericResource>(
                delegate()
                {
                    return ResourceManagementClient.Resources.List(filter);
                }, ResourceManagementClient.Resources.ListNext, first, skip).Select(r => new PSResource(r));
        }

        public virtual IEnumerable<PSResource> ListByResourceGroup(
            string resourceGroupName,
            Rest.Azure.OData.ODataQuery<GenericResourceFilter> filter,
            ulong first = ulong.MaxValue,
            ulong skip = ulong.MinValue)
        {
            return new GenericPageEnumerable<GenericResource>(
                delegate ()
                {
                    return ResourceManagementClient.Resources.ListByResourceGroup(resourceGroupName, filter);
                }, ResourceManagementClient.Resources.ListByResourceGroupNext, first, skip).Select(r => new PSResource(r));
        }

        public virtual PSResource GetById(string resourceId, string apiVersion)
        {
            PSResource result = null;
            var resourceIdentifier = new ResourceIdentifier(resourceId);
            var providers = ResourceManagementClient.Providers.List();
            foreach (var provider in providers)
            {
                var resourceType = provider.ResourceTypes
                                            .Where(t => string.Equals(string.Format("{0}/{1}", provider.NamespaceProperty, t.ResourceType), resourceIdentifier.ResourceType, StringComparison.OrdinalIgnoreCase))
                                            .FirstOrDefault();
                if (resourceType != null)
                {
                    apiVersion = resourceType.ApiVersions.Contains(apiVersion) ? apiVersion : resourceType.ApiVersions.FirstOrDefault();
                    if (!string.IsNullOrEmpty(apiVersion))
                    {
                        return new PSResource(ResourceManagementClient.Resources.GetById(resourceId, apiVersion));
                    }
                }
            }

            return result;
        }
    }
}
