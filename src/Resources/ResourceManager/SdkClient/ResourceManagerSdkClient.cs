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
using System.Management.Automation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Collections;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Json;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkExtensions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common.Paging;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Azure.OData;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;
using ProvisioningState = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.ProvisioningState;

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
        /// The azure context.
        /// </summary>
        private IAzureContext azureContext;

        /// <summary>
        /// The resource management client dictionary for cross subscriptions.
        /// </summary>
        private InsensitiveDictionary<IResourceManagementClient> resourceManagementClientCache = new InsensitiveDictionary<IResourceManagementClient>();

        /// <summary>
        /// The default resource management client.
        /// </summary>
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
            this.azureContext = context;
        }

        /// <summary>
        /// Creates new ResourcesClient instance
        /// </summary>
        /// <param name="resourceManagementClient">The IResourceManagementClient instance</param>
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

        private IResourceManagementClient GetResourceManagementClient(string subscriptionId)
        {
            if (!subscriptionId.EqualsInsensitively(this.ResourceManagementClient.SubscriptionId))
            {
                if (this.resourceManagementClientCache.ContainsKey(subscriptionId))
                {
                    return resourceManagementClientCache[subscriptionId];
                }

                if (this.azureContext != null)
                {
                    var sdkClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(
                        context: this.azureContext,
                        endpoint: AzureEnvironment.Endpoint.ResourceManager);

                    sdkClient.SubscriptionId = subscriptionId;

                    resourceManagementClientCache[subscriptionId] = sdkClient;

                    return resourceManagementClientCache[subscriptionId];
                }
            }

            return this.ResourceManagementClient;
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

        public ResourceGroupExportResult ExportResourceGroup(string resourceGroupName, ExportTemplateRequest properties)
        {
            return ResourceManagementClient.ResourceGroups.ExportTemplate(resourceGroupName, properties);
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
        
        private DeploymentExtended WaitDeploymentStatus(
            Func<Task<AzureOperationResponse<DeploymentExtended>>> getDeployment,
            Action listDeploymentOperations,
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

                if (listDeploymentOperations != null)
                {
                    listDeploymentOperations();
                }

                var getDeploymentTask = getDeployment();

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

        Func<Task<AzureOperationResponse<DeploymentExtended>>> GetDeploymentAction(PSDeploymentCmdletParameters parameters)
        {
            switch (parameters.ScopeType)
            {
                case DeploymentScopeType.Tenant:
                    return () => ResourceManagementClient.Deployments.GetAtTenantScopeWithHttpMessagesAsync(parameters.DeploymentName);

                case DeploymentScopeType.ManagementGroup:
                    return () => ResourceManagementClient.Deployments.GetAtManagementGroupScopeWithHttpMessagesAsync(parameters.ManagementGroupId, parameters.DeploymentName);

                case DeploymentScopeType.ResourceGroup:
                    return () => ResourceManagementClient.Deployments.GetWithHttpMessagesAsync(parameters.ResourceGroupName, parameters.DeploymentName);

                case DeploymentScopeType.Subscription:
                default:
                    return () => ResourceManagementClient.Deployments.GetAtSubscriptionScopeWithHttpMessagesAsync(parameters.DeploymentName);
            }
        }

        private DeploymentValidateResult ValidateDeployment(PSDeploymentCmdletParameters parameters, Deployment deployment)
        {
            var scopedDeployment = new ScopedDeployment { Properties = deployment.Properties, Location = deployment.Location };

            switch (parameters.ScopeType)
            {
                case DeploymentScopeType.Tenant:
                    return ResourceManagementClient.Deployments.ValidateAtTenantScope(parameters.DeploymentName, scopedDeployment);

                case DeploymentScopeType.ManagementGroup:
                    return ResourceManagementClient.Deployments.ValidateAtManagementGroupScope(parameters.ManagementGroupId, parameters.DeploymentName, scopedDeployment);

                case DeploymentScopeType.ResourceGroup:
                    return ResourceManagementClient.Deployments.Validate(parameters.ResourceGroupName, parameters.DeploymentName, deployment);

                case DeploymentScopeType.Subscription:
                default:
                    return ResourceManagementClient.Deployments.ValidateAtSubscriptionScope(parameters.DeploymentName, deployment);
            }
        }

        private List<ErrorResponse> HandleError(Exception ex)
        {
            if (ex == null)
            {
                return null;
            }

            ErrorResponse error = null;
            var innerException = HandleError(ex.InnerException);
            if (ex is CloudException)
            {
                var cloudEx = ex as CloudException;
                error = new ErrorResponse(cloudEx.Body?.Code, cloudEx.Body?.Message, cloudEx.Body?.Target, innerException);
            }
            else
            {
                error = new ErrorResponse(null, ex.Message, null, innerException);
            }

            return new List<ErrorResponse> { error };

        }

        private IPage<DeploymentOperation> ListDeploymentOperations(PSDeploymentCmdletParameters parameters)
        {
            switch (parameters.ScopeType)
            {
                case DeploymentScopeType.Tenant:
                    return ResourceManagementClient.DeploymentOperations.ListAtTenantScope(parameters.DeploymentName);

                case DeploymentScopeType.ManagementGroup:
                    return ResourceManagementClient.DeploymentOperations.ListAtManagementGroupScope(parameters.ManagementGroupId, parameters.DeploymentName);

                case DeploymentScopeType.ResourceGroup:
                    return ResourceManagementClient.DeploymentOperations.List(parameters.ResourceGroupName, parameters.DeploymentName);

                case DeploymentScopeType.Subscription:
                default:
                    return ResourceManagementClient.DeploymentOperations.ListAtSubscriptionScope(parameters.DeploymentName);
            }
        }

        private IPage<DeploymentOperation> ListNextDeploymentOperations(PSDeploymentCmdletParameters parameters, string nextLink)
        {
            switch (parameters.ScopeType)
            {
                case DeploymentScopeType.Tenant:
                    return ResourceManagementClient.DeploymentOperations.ListAtTenantScopeNext(nextLink);

                case DeploymentScopeType.ManagementGroup:
                    return ResourceManagementClient.DeploymentOperations.ListAtManagementGroupScopeNext(nextLink);

                case DeploymentScopeType.ResourceGroup:
                    return ResourceManagementClient.DeploymentOperations.ListNext(nextLink);

                case DeploymentScopeType.Subscription:
                default:
                    return ResourceManagementClient.DeploymentOperations.ListAtSubscriptionScopeNext(nextLink);
            }
        }

        private IPage<DeploymentOperation> ListDeploymentOperationsAtTenantOrManagementGroup(string managementGroupId, string deploymentName)
        {
            return !string.IsNullOrEmpty(managementGroupId)
                ? this.ResourceManagementClient.DeploymentOperations.ListAtManagementGroupScope(managementGroupId, deploymentName, null)
                : this.ResourceManagementClient.DeploymentOperations.ListAtTenantScope(deploymentName, null);
        }

        private IPage<DeploymentOperation> ListNextDeploymentOperationsAtManagementGroup(string managementGroup, string nextLink)
        {
            return this.ResourceManagementClient.DeploymentOperations.ListAtManagementGroupScopeNext(nextLink);
        }

        private IPage<DeploymentOperation> ListDeploymentOperations(string resourceGroupName, string deploymentName)
        {
            return !string.IsNullOrEmpty(resourceGroupName)
                ? this.ResourceManagementClient.DeploymentOperations.List(resourceGroupName, deploymentName, null)
                : this.ResourceManagementClient.DeploymentOperations.ListAtSubscriptionScope(deploymentName, null);
        }

        private IPage<DeploymentOperation> ListDeploymentOperations(string subscriptionId, string resourceGroupName, string deploymentName)
        {
            return !string.IsNullOrEmpty(resourceGroupName)
                ? this.GetResourceManagementClient(subscriptionId).DeploymentOperations.List(resourceGroupName, deploymentName, null)
                : this.GetResourceManagementClient(subscriptionId).DeploymentOperations.ListAtSubscriptionScope(deploymentName, null);
        }

        private IPage<DeploymentOperation> ListNextDeploymentOperations(string resourceGroupName, string nextLink)
        {
            return !string.IsNullOrEmpty(resourceGroupName)
                ? this.ResourceManagementClient.DeploymentOperations.ListNext(nextLink)
                : this.ResourceManagementClient.DeploymentOperations.ListAtSubscriptionScopeNext(nextLink);
        }

        private bool CheckDeploymentExistenceAtTenantOrManagementGroup(string managementGroupId, string deploymentName)
        {
            return !string.IsNullOrEmpty(managementGroupId)
                ? this.ResourceManagementClient.Deployments.CheckExistenceAtManagementGroupScope(managementGroupId, deploymentName)
                : this.ResourceManagementClient.Deployments.CheckExistenceAtTenantScope(deploymentName);
        }

        private bool CheckDeploymentExistence(string subscriptionId, string resourceGroupName, string deploymentName)
        {
            return !string.IsNullOrEmpty(resourceGroupName)
                ? this.GetResourceManagementClient(subscriptionId).Deployments.CheckExistence(resourceGroupName, deploymentName)
                : this.GetResourceManagementClient(subscriptionId).Deployments.CheckExistenceAtSubscriptionScope(deploymentName);
        }

        private void BeginDeployment(PSDeploymentCmdletParameters parameters, Deployment deployment)
        {
            var scopedDeployment = new ScopedDeployment
            {
                Properties = deployment.Properties,
                Location = deployment.Location,
                Tags = deployment?.Tags == null ? null : new Dictionary<string, string>(deployment.Tags)
            };

            switch (parameters.ScopeType)
            {
                case DeploymentScopeType.Tenant:
                    ResourceManagementClient.Deployments.BeginCreateOrUpdateAtTenantScope(parameters.DeploymentName, scopedDeployment);
                    break;

                case DeploymentScopeType.ManagementGroup:
                    ResourceManagementClient.Deployments.BeginCreateOrUpdateAtManagementGroupScope(parameters.ManagementGroupId, parameters.DeploymentName, scopedDeployment);
                    break;

                case DeploymentScopeType.ResourceGroup:
                    ResourceManagementClient.Deployments.BeginCreateOrUpdate(parameters.ResourceGroupName, parameters.DeploymentName, deployment);
                    break;

                case DeploymentScopeType.Subscription:
                default:
                    ResourceManagementClient.Deployments.BeginCreateOrUpdateAtSubscriptionScope(parameters.DeploymentName, deployment);
                    break;
            }
        }

        public string GetDeploymentTemplateAtTenantScope(string deploymentName)
        {
            var exportResult = ResourceManagementClient.Deployments.ExportTemplateAtTenantScope(deploymentName);

            return JToken.FromObject(exportResult.Template).ToString();
        }

        public string GetDeploymentTemplateAtManagementGroup(string managementGroupId, string deploymentName)
        {
            var exportResult = ResourceManagementClient.Deployments.ExportTemplateAtManagementGroupScope(managementGroupId, deploymentName);

            return JToken.FromObject(exportResult.Template).ToString();
        }

        public string GetDeploymentTemplateAtSubscrpitionScope(string deploymentName)
        {
            var exportResult = ResourceManagementClient.Deployments.ExportTemplateAtSubscriptionScope(deploymentName);

            return JToken.FromObject(exportResult.Template).ToString();
        }

        public string GetDeploymentTemplateAtResourceGroup(string resourceGroupName, string deploymentName)
        {
            var exportResult = ResourceManagementClient.Deployments.ExportTemplate(resourceGroupName, deploymentName);

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

        public PSResourceProvider RegisterProvider(string providerName, ProviderRegistrationRequest providerRegistrationRequest = null)
        {
            var response = this.ResourceManagementClient.Providers.Register(providerName, providerRegistrationRequest);

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
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(parameters.Tag, validate: true);

            resourceGroup = ResourceManagementClient.ResourceGroups.Update(resourceGroup.Name,
                new ResourceGroupPatchable
                {
                    Name = resourceGroup.Name,
                    Properties = resourceGroup.Properties,
                    ManagedBy = resourceGroup.ManagedBy,
                    Tags = tagDictionary
                });

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
        /// <param name="subscriptionId"></param>
        /// <returns>The filtered resource groups</returns>
        public virtual List<PSResourceGroup> FilterResourceGroups(string name,Hashtable tag, bool detailed, string location = null, string subscriptionId = null)
        {
            List<PSResourceGroup> result = new List<PSResourceGroup>();

            ODataQuery<ResourceGroupFilter> resourceGroupFilter = null;

            if (tag != null && tag.Count >= 1)
            {
                PSTagValuePair tagValuePair = TagsConversionHelper.Create(tag);
                if (tagValuePair == null || tag.Count > 1)
                {
                    throw new ArgumentException(ProjectResources.InvalidTagFormat);
                }

                resourceGroupFilter = string.IsNullOrEmpty(tagValuePair.Value)
                    ? new ODataQuery<ResourceGroupFilter>(rgFilter => rgFilter.TagName == tagValuePair.Name)
                    : new ODataQuery<ResourceGroupFilter>(rgFilter => rgFilter.TagName == tagValuePair.Name && rgFilter.TagValue == tagValuePair.Value);
            }

            if (string.IsNullOrEmpty(name) || WildcardPattern.ContainsWildcardCharacters(name))
            {
                List<ResourceGroup> resourceGroups = new List<ResourceGroup>();

                var listResult = ResourceManagementClient.ResourceGroups.List(odataQuery: resourceGroupFilter);
                resourceGroups.AddRange(listResult);

                while (!string.IsNullOrEmpty(listResult.NextPageLink))
                {
                    listResult = ResourceManagementClient.ResourceGroups.ListNext(listResult.NextPageLink);
                    resourceGroups.AddRange(listResult);
                }

                if (!string.IsNullOrEmpty(name))
                {
                    WildcardPattern pattern = new WildcardPattern(name, WildcardOptions.IgnoreCase);
                    resourceGroups = resourceGroups.Where(t => pattern.IsMatch(t.Name)).ToList();
                }

                resourceGroups = !string.IsNullOrEmpty(location)
                    ? resourceGroups.Where(resourceGroup => resourceGroup.Location.EqualsAsLocation(location)).ToList()
                    : resourceGroups;

                result.AddRange(resourceGroups.Select(rg => rg.ToPSResourceGroup()));
            }
            else
            {
                try
                {
                    if (!String.IsNullOrEmpty(subscriptionId)) {
                        ResourceManagementClient.SubscriptionId = subscriptionId;
                    }
                    PSResourceGroup resourceGroup = ResourceManagementClient.ResourceGroups.Get(name).ToPSResourceGroup();
                    if (string.IsNullOrEmpty(location) || resourceGroup.Location.EqualsAsLocation(location))
                    {
                        result.Add(resourceGroup);
                    }
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
        /// List deployments at tenant scope.
        /// </summary>
        /// <param name="deploymentName">The deployment name</param>
        private List<DeploymentExtended> ListDeploymentsAtTenantScope(string deploymentName)
        {
            List<DeploymentExtended> deployments = new List<DeploymentExtended>();

            if (!string.IsNullOrEmpty(deploymentName))
            {
                deployments.Add(ResourceManagementClient.Deployments.GetAtTenantScope(deploymentName));
            }
            else
            {
                var result = ResourceManagementClient.Deployments.ListAtTenantScope();

                deployments.AddRange(result);

                while (!string.IsNullOrEmpty(result.NextPageLink))
                {
                    result = ResourceManagementClient.Deployments.ListAtTenantScopeNext(result.NextPageLink);
                    deployments.AddRange(result);
                }
            }

            return deployments;
        }

        /// <summary>
        /// List deployments at a management group.
        /// </summary>
        /// <param name="managementGroupId">The management group id</param>
        /// <param name="deploymentName">The deployment name</param>
        private List<DeploymentExtended> ListDeploymentsAtManagementGroup(string managementGroupId, string deploymentName)
        {
            List<DeploymentExtended> deployments = new List<DeploymentExtended>();

            if (!string.IsNullOrEmpty(deploymentName))
            {
                deployments.Add(ResourceManagementClient.Deployments.GetAtManagementGroupScope(managementGroupId, deploymentName));
            }
            else
            {
                var result = ResourceManagementClient.Deployments.ListAtManagementGroupScope(managementGroupId);

                deployments.AddRange(result);

                while (!string.IsNullOrEmpty(result.NextPageLink))
                {
                    result = ResourceManagementClient.Deployments.ListAtManagementGroupScopeNext(result.NextPageLink);
                    deployments.AddRange(result);
                }
            }

            return deployments;
        }

        /// <summary>
        /// List deployments at subscription scope.
        /// </summary>
        /// <param name="deploymentName">The deployment name</param>
        private List<DeploymentExtended> ListDeploymentsAtSubscription(string deploymentName)
        {
            List<DeploymentExtended> deployments = new List<DeploymentExtended>();

            if (!string.IsNullOrEmpty(deploymentName))
            {
                deployments.Add(ResourceManagementClient.Deployments.GetAtSubscriptionScope(deploymentName));
            }
            else
            {
                var result = ResourceManagementClient.Deployments.ListAtSubscriptionScope();

                deployments.AddRange(result);

                while (!string.IsNullOrEmpty(result.NextPageLink))
                {
                    result = ResourceManagementClient.Deployments.ListAtSubscriptionScopeNext(result.NextPageLink);
                    deployments.AddRange(result);
                }
            }

            return deployments;
        }

        /// <summary>
        /// List deployments at a resource group.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="deploymentName">The deployment name</param>
        private List<DeploymentExtended> ListDeploymentsAtResourceGroup(string resourceGroupName, string deploymentName)
        {
            List<DeploymentExtended> deployments = new List<DeploymentExtended>();

            if (!string.IsNullOrEmpty(deploymentName))
            {
                deployments.Add(ResourceManagementClient.Deployments.Get(resourceGroupName, deploymentName));
            }
            else
            {
                var result = ResourceManagementClient.Deployments.ListByResourceGroup(resourceGroupName, null);

                deployments.AddRange(result);

                while (!string.IsNullOrEmpty(result.NextPageLink))
                {
                    result = ResourceManagementClient.Deployments.ListByResourceGroupNext(result.NextPageLink);
                    deployments.AddRange(result);
                }
            }

            return deployments;
        }

        /// <summary>
        /// Gets the deployment operations at management group scope.
        /// </summary>
        /// <param name="managementGroupId">The management group id</param>
        /// <param name="deploymentName">The deployment name</param>
        /// <param name="operationId">The operation Id</param>
        /// <returns>The deployment operations</returns>
        public virtual List<PSDeploymentOperation> GetDeploymentOperationsAtManagementGroup(string managementGroupId, string deploymentName, string operationId = null)
        {
            List<PSDeploymentOperation> deploymentOperations = new List<PSDeploymentOperation>();

            if (!string.IsNullOrEmpty(operationId))
            {
                deploymentOperations.Add(ResourceManagementClient.DeploymentOperations.GetAtManagementGroupScope(managementGroupId, deploymentName, operationId).ToPSDeploymentOperation());
            }
            else
            {
                var result = ResourceManagementClient.DeploymentOperations.ListAtManagementGroupScope(managementGroupId, deploymentName);

                deploymentOperations.AddRange(result.Select(d => d.ToPSDeploymentOperation()));

                while (!string.IsNullOrEmpty(result.NextPageLink))
                {
                    result = ResourceManagementClient.DeploymentOperations.ListAtManagementGroupScopeNext(result.NextPageLink);
                    deploymentOperations.AddRange(result.Select(d => d.ToPSDeploymentOperation()));
                }
            }

            return deploymentOperations;
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
        /// List deployment operations at tenant scope.
        /// </summary>
        /// <param name="deploymentName">The deployment name</param>
        /// <param name="operationId">The operation Id</param>
        /// <returns>The deployment operations</returns>
        public virtual List<PSDeploymentOperation> ListDeploymentOperationsAtTenantScope(string deploymentName, string operationId = null)
        {
            List<PSDeploymentOperation> deploymentOperations = new List<PSDeploymentOperation>();

            if (!string.IsNullOrEmpty(operationId))
            {
                deploymentOperations.Add(ResourceManagementClient.DeploymentOperations.GetAtTenantScope(deploymentName, operationId).ToPSDeploymentOperation());
            }
            else
            {
                var result = ResourceManagementClient.DeploymentOperations.ListAtTenantScope(deploymentName);

                deploymentOperations.AddRange(result.Select(d => d.ToPSDeploymentOperation()));

                while (!string.IsNullOrEmpty(result.NextPageLink))
                {
                    result = ResourceManagementClient.DeploymentOperations.ListAtTenantScopeNext(result.NextPageLink);
                    deploymentOperations.AddRange(result.Select(d => d.ToPSDeploymentOperation()));
                }
            }

            return deploymentOperations;
        }

        /// <summary>
        /// List deployment operations at management group.
        /// </summary>
        /// <param name="managementGroupId">The management group id</param>
        /// <param name="deploymentName">The deployment name</param>
        /// <param name="operationId">The operation Id</param>
        /// <returns>The deployment operations</returns>
        public virtual List<PSDeploymentOperation> ListDeploymentOperationsAtManagementGroup(string managementGroupId, string deploymentName, string operationId = null)
        {
            List<PSDeploymentOperation> deploymentOperations = new List<PSDeploymentOperation>();

            if (!string.IsNullOrEmpty(operationId))
            {
                deploymentOperations.Add(ResourceManagementClient.DeploymentOperations.GetAtManagementGroupScope(managementGroupId, deploymentName, operationId).ToPSDeploymentOperation());
            }
            else
            {
                var result = ResourceManagementClient.DeploymentOperations.ListAtManagementGroupScope(managementGroupId, deploymentName);

                deploymentOperations.AddRange(result.Select(d => d.ToPSDeploymentOperation()));

                while (!string.IsNullOrEmpty(result.NextPageLink))
                {
                    result = ResourceManagementClient.DeploymentOperations.ListAtManagementGroupScopeNext(result.NextPageLink);
                    deploymentOperations.AddRange(result.Select(d => d.ToPSDeploymentOperation()));
                }
            }

            return deploymentOperations;
        }

        /// <summary>
        /// List deployment operations at subscription scope.
        /// </summary>
        /// <param name="deploymentName">The deployment name</param>
        /// <param name="operationId">The operation Id</param>
        /// <returns>The deployment operations</returns>
        public virtual List<PSDeploymentOperation> ListDeploymentOperationsAtSubscriptionScope(string deploymentName, string operationId = null)
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
        /// List deployment operations at resource group.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="deploymentName">The deployment name</param>
        /// <param name="operationId">The operation Id</param>
        /// <returns>The deployment operations</returns>
        public virtual List<PSDeploymentOperation> ListDeploymentOperationsAtResourceGroup(string resourceGroupName, string deploymentName, string operationId = null)
        {
            List<PSDeploymentOperation> deploymentOperations = new List<PSDeploymentOperation>();

            if (!string.IsNullOrEmpty(operationId))
            {
                deploymentOperations.Add(ResourceManagementClient.DeploymentOperations.Get(resourceGroupName, deploymentName, operationId).ToPSDeploymentOperation());
            }
            else
            {
                var result = ResourceManagementClient.DeploymentOperations.List(resourceGroupName, deploymentName);

                deploymentOperations.AddRange(result.Select(d => d.ToPSDeploymentOperation()));

                while (!string.IsNullOrEmpty(result.NextPageLink))
                {
                    result = ResourceManagementClient.DeploymentOperations.ListNext(result.NextPageLink);
                    deploymentOperations.AddRange(result.Select(d => d.ToPSDeploymentOperation()));
                }
            }

            return deploymentOperations;
        }

        private static string BuildCloudErrorMessage(CloudError cloudError)
        {
            if (cloudError == null)
            {
                return string.Empty;
            }

            IList<string> messages = new List<string>
            {
                $"{cloudError.Code} - {cloudError.Message}"
            };

            foreach (CloudError innerError in cloudError.Details)
            {
                messages.Add(BuildCloudErrorMessage(innerError));
            }

            return string.Join(Environment.NewLine, messages);
        }

        private void DisplayInnerDetailErrorMessage(ErrorResponse error)
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
        /// Deletes a deployment at tenant scope
        /// </summary>
        /// <param name="deploymentName">Deployment name</param>
        public virtual void DeleteDeploymentAtTenantScope(string deploymentName)
        {
            if (!ResourceManagementClient.Deployments.CheckExistenceAtTenantScope(deploymentName))
            {
                throw new ArgumentException(string.Format(ProjectResources.DeploymentDoesntExistAtTenantScope, deploymentName));
            }

            ResourceManagementClient.Deployments.DeleteAtTenantScope(deploymentName);
        }

        /// <summary>
        /// Deletes a deployment at management group
        /// </summary>
        /// <param name="managementGroupId">The management group id</param>
        /// <param name="deploymentName">Deployment name</param>
        public virtual void DeleteDeploymentAtManagementGroup(string managementGroupId, string deploymentName)
        {
            if (!ResourceManagementClient.Deployments.CheckExistenceAtManagementGroupScope(managementGroupId, deploymentName))
            {
                throw new ArgumentException(string.Format(ProjectResources.DeploymentDoesntExistAtManagementGroupScope, deploymentName, managementGroupId));
            }

            ResourceManagementClient.Deployments.DeleteAtManagementGroupScope(managementGroupId, deploymentName);
        }

        /// <summary>
        /// Deletes a deployment at subscription scope
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
        /// Deletes a deployment at resource group
        /// </summary>
        /// <param name="resourceGroup">The resource group name</param>
        /// <param name="deploymentName">Deployment name</param>
        public virtual void DeleteDeploymentAtResourceGroup(string resourceGroup, string deploymentName)
        {
            if (!ResourceManagementClient.Deployments.CheckExistence(resourceGroup, deploymentName))
            {
                throw new ArgumentException(string.Format(ProjectResources.DeploymentDoesntExistInResourceGroup, deploymentName, resourceGroup));
            }

            ResourceManagementClient.Deployments.Delete(resourceGroup, deploymentName);
        }

        /// <summary>
        /// Cancels the active deployment at tenant scope.
        /// </summary>
        /// <param name="deployments">Deployments</param>
        /// <param name="deploymentName">Deployment name</param>
        private void CancelDeploymentAtTenantScope(List<PSDeployment> deployments, string deploymentName)
        {
            if (deployments.Count == 0)
            {
                throw new ArgumentException(string.Format(ProjectResources.NoRunningDeploymentsAtTenantScope, deploymentName));
            }
            else
            {
                ResourceManagementClient.Deployments.CancelAtTenantScope(deployments.First().DeploymentName);
            }
        }

        /// <summary>
        /// Cancels the active deployment at management group.
        /// </summary>
        /// <param name="deployments">Deployments</param>
        /// <param name="managementGroupId">Management group id</param>
        /// <param name="deploymentName">Deployment name</param>
        private void CancelDeploymentAtManagementGroup(List<PSDeployment> deployments, string managementGroupId, string deploymentName)
        {
            if (deployments.Count == 0)
            {
                throw new ArgumentException(string.Format(ProjectResources.NoRunningDeploymentsAtManagementGroup, deploymentName, managementGroupId));
            }
            else
            {
                ResourceManagementClient.Deployments.CancelAtManagementGroupScope(managementGroupId, deployments.First().DeploymentName);
            }
        }

        /// <summary>
        /// Cancels the active deployment at subscription scope.
        /// </summary>
        /// <param name="deployments">Deployments</param>
        /// <param name="deploymentName">Deployment name</param>
        private void CancelDeploymentAtSubscriptionScope(List<PSDeployment> deployments, string deploymentName)
        {
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
        /// Cancels the active deployment at a resource group.
        /// </summary>
        /// <param name="deployments">Deployments</param>
        /// <param name="resourceGroupName">Resource group name</param>
        /// <param name="deploymentName">Deployment name</param>
        private void CancelDeploymentAtResourceGroup(List<PSDeployment> deployments, string resourceGroupName, string deploymentName)
        {
            if (deployments.Count == 0)
            {
                throw new ArgumentException(string.Format(ProjectResources.NoRunningDeploymentsAtResourceGroup, deploymentName, resourceGroupName));
            }
            else
            {
                ResourceManagementClient.Deployments.Cancel(resourceGroupName, deployments.First().DeploymentName);
            }
        }

        public virtual IEnumerable<PSResource> ListResources(Rest.Azure.OData.ODataQuery<GenericResourceFilter> filter = null, ulong first = ulong.MaxValue, ulong skip = ulong.MinValue)
        {
            return new GenericPageEnumerable<GenericResourceExpanded>(
                delegate ()
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
            return new GenericPageEnumerable<GenericResourceExpanded>(
                delegate ()
                {
                    return ResourceManagementClient.Resources.ListByResourceGroup(resourceGroupName, filter);
                }, ResourceManagementClient.Resources.ListByResourceGroupNext, first, skip).Select(r => new PSResource(r));
        }

        public virtual PSResource GetById(string resourceId, string apiVersion)
        {
            var providers = new List<Provider>();
            var resourceIdentifier = new ResourceIdentifier(resourceId);
            var providerNamespace = ResourceIdentifier.GetProviderFromResourceType(resourceIdentifier.ResourceType);
            if (!string.IsNullOrEmpty(providerNamespace))
            {
                var result = ResourceManagementClient.Providers.Get(providerNamespace);
                if (result != null)
                {
                    providers.Add(result);
                }
            }

            if (!providers.Any())
            {
                var result = ResourceManagementClient.Providers.List();
                if (result != null)
                {
                    result.ForEach(p => providers.Add(p));
                    while (!string.IsNullOrEmpty(result.NextPageLink))
                    {
                        result = ResourceManagementClient.Providers.ListNext(result.NextPageLink);
                        result.ForEach(p => providers.Add(p));
                    }
                }
            }

            foreach (var provider in providers)
            {
                var resourceType = provider.ResourceTypes
                                           .Where(t => string.Equals(string.Format("{0}/{1}", provider.NamespaceProperty, t.ResourceType), resourceIdentifier.ResourceType, StringComparison.OrdinalIgnoreCase))
                                           .FirstOrDefault();
                if (resourceType == null)
                {
                    string topLevelResourceType = ResourceTypeUtility.GetTopLevelResourceTypeWithProvider(resourceIdentifier.ResourceType);
                    resourceType = provider.ResourceTypes
                                               .Where(t => string.Equals(t.ResourceType, topLevelResourceType, StringComparison.OrdinalIgnoreCase))
                                               .FirstOrDefault();
                }
                if (resourceType != null)
                {
                    apiVersion = resourceType.ApiVersions.Contains(apiVersion) ? apiVersion : resourceType.ApiVersions.FirstOrDefault();
                    if (!string.IsNullOrEmpty(apiVersion))
                    {
                        return new PSResource(ResourceManagementClient.Resources.GetById(resourceId, apiVersion));
                    }
                }
            }

            return null;
        }
    }
}
