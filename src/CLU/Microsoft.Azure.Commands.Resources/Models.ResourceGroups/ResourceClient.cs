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

using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

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
        
        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public IDataStore DataStore { get; set; }

        /// <summary>
        /// Creates new ResourceManagementClient
        /// </summary>
        /// <param name="clientFactory">Factory for management clients</param>
        /// <param name="context">Profile containing resources to manipulate</param>
        public ResourcesClient(IClientFactory clientFactory, AzureContext context, IDataStore dataStore)
            : this(
                clientFactory.CreateArmClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager),
                clientFactory.CreateArmClient<AuthorizationManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
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
            IAuthorizationManagementClient authorizationManagementClient)
        {
            AuthorizationManagementClient = authorizationManagementClient;
            this.ResourceManagementClient = resourceManagementClient;
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

        public virtual PSResourceProvider UnregisterProvider(string providerName)
        {
            var response = this.ResourceManagementClient.Providers.Unregister(providerName);

            if (response == null)
            {
                throw new KeyNotFoundException(string.Format(ProjectResources.ResourceProviderUnregistrationFailed, providerName));
            }

            return response.ToPSResourceProvider();
        }
        
        private ResourceGroup CreateOrUpdateResourceGroup(string name, string location, Hashtable[] tags)
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

        private DeploymentExtended ProvisionDeploymentStatus(string resourceGroup, string deploymentName, Deployment deployment)
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
            IPage<DeploymentOperation> result;

            result = ResourceManagementClient.DeploymentOperations.List(resourceGroup, deploymentName, null);
            newOperations = GetNewOperations(operations, result.ToList());
            operations.AddRange(newOperations);

            while (!string.IsNullOrEmpty(result.NextPageLink))
            {
                result = ResourceManagementClient.DeploymentOperations.ListNext(result.NextPageLink);
                newOperations = GetNewOperations(operations, result.ToList());
                operations.AddRange(newOperations);
            }

            foreach (DeploymentOperation operation in newOperations)
            {
                string statusMessage;

                if (operation.Properties.ProvisioningState != "Failed")
                {
                    statusMessage = string.Format(normalStatusFormat,
                        operation.Properties.TargetResource.ResourceType,
                        operation.Properties.TargetResource.ResourceName,
                        operation.Properties.ProvisioningState.ToLower());

                    WriteVerbose(statusMessage);
                }
                else
                {
                    string errorMessage = operation.Properties.StatusMessage.ToString();

                    statusMessage = string.Format(failureStatusFormat,
                        operation.Properties.TargetResource.ResourceType,
                        operation.Properties.TargetResource.ResourceName,
                        errorMessage);

                    WriteError(statusMessage);

                    List<string> detailedMessage = ParseDetailErrorMessage(operation.Properties.StatusMessage.ToString());

                    if (detailedMessage != null)
                    {
                        detailedMessage.ForEach(s => WriteError(s));
                    }
                }
            }
        }
        
        public static List<string> ParseDetailErrorMessage(string statusMessage)
        {
            if(!string.IsNullOrEmpty(statusMessage))
            {
                List<string> detailedMessage = new List<string>();
                dynamic errorMessage = JsonConvert.DeserializeObject(statusMessage);
                if(errorMessage.error != null && errorMessage.error.details !=null)
                {
                    foreach(var detail in errorMessage.error.details)
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

            do
            {
                if (job != null)
                {
                    job(resourceGroup, deploymentName, basicDeployment);
                }

                deployment = ResourceManagementClient.Deployments.Get(resourceGroup, deploymentName);
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

                //If nested deployment, get the operations under those deployments as well
                if(operation.Properties.TargetResource.ResourceType.Equals(Constants.MicrosoftResourcesDeploymentType, StringComparison.OrdinalIgnoreCase))
                {
                    List<DeploymentOperation> newNestedOperations = new List<DeploymentOperation>();
                    IPage<DeploymentOperation> result;

                    result = ResourceManagementClient.DeploymentOperations.List(
                        resourceGroupName: ResourceIdUtility.GetResourceGroupName(operation.Properties.TargetResource.Id),
                        deploymentName: operation.Properties.TargetResource.ResourceName);

                    newNestedOperations = GetNewOperations(operations, result.ToList());
                    newOperations.AddRange(newNestedOperations);
                }
            }

            return newOperations;
        }

        private Deployment CreateBasicDeployment(ValidatePSResourceGroupDeploymentParameters parameters, DeploymentMode deploymentMode)
        {
            Deployment deployment = new Deployment
            {
                Properties = new DeploymentProperties {
                    Mode = deploymentMode
                }
            };

            if (Uri.IsWellFormedUriString(parameters.TemplateFile, UriKind.Absolute))
            {
                deployment.Properties.TemplateLink = new TemplateLink
                {
                    Uri = parameters.TemplateFile
                };
            }
            else
            {
                var textData = DataStore.ReadFileAsText(parameters.TemplateFile);
                deployment.Properties.Template = string.IsNullOrEmpty(textData) ?
                    (object)textData : JObject.Parse(DataStore.ReadFileAsText(parameters.TemplateFile));
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
                var deploymentParameters = GetDeploymentParameters(parameters.TemplateParameterObject);
                deployment.Properties.Parameters = string.IsNullOrEmpty(deploymentParameters) ?
                    (object) deploymentParameters : JObject.Parse(deploymentParameters);
            }

            return deployment;
        }

        private TemplateValidationInfo CheckBasicDeploymentErrors(string resourceGroup, string deploymentName, Deployment deployment)
        {
            var validationResult = ResourceManagementClient.Deployments.ValidateWithHttpMessagesAsync(
                resourceGroup,
                deploymentName,
                deployment).ConfigureAwait(false).GetAwaiter().GetResult();

            return new TemplateValidationInfo(
                validationResult.Body, 
                validationResult.Response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        internal List<PSPermission> GetResourcePermissions(ResourceIdentifier identity)
        {
            var permissionsResult = AuthorizationManagementClient.Permissions.ListForResource(
                    identity.ResourceGroupName,
                    "",
                    identity.ParentResource,
                    identity.ResourceType,
                    identity.ResourceName);

            if (permissionsResult != null)
            {
                return permissionsResult.Select(p => p.ToPSPermission()).ToList();
            }

            return null;
        }

        public virtual PSResourceProvider[] ListPSResourceProviders(string providerName = null, bool listAvailable = false, string location = null)
        {
            var providers = this.ListResourceProviders(providerName: providerName, listAvailable: listAvailable);

            if (string.IsNullOrEmpty(location))
            {
                return providers
                    .Select(provider => provider.ToPSResourceProvider())
                    .ToArray();
            }

            foreach (var provider in providers)
            {
                provider.ResourceTypes = provider.ResourceTypes
                    .Where(type => !type.Locations.Any() || this.ContainsNormalizedLocation(type.Locations.ToArray(), location))
                    .ToList();
            }

            return providers
                .Where(provider => provider.ResourceTypes.Any())
                .Select(provider => provider.ToPSResourceProvider())
                .ToArray();
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

                return new List<Provider> {provider};
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

        private bool ContainsNormalizedLocation(string[] locations, string location)
        {
            return locations.Any(existingLocation => this.NormalizeLetterOrDigitToUpperInvariant(existingLocation).Equals(this.NormalizeLetterOrDigitToUpperInvariant(location)));
        }

        private string NormalizeLetterOrDigitToUpperInvariant(string value)
        {
            return value != null ? new string(value.Where(c => char.IsLetterOrDigit(c)).ToArray()).ToUpperInvariant() : null;
        }

        private bool IsProviderRegistered(Provider provider)
        {
            return string.Equals(
                ResourcesClient.RegisteredStateName,
                provider.RegistrationState,
                StringComparison.OrdinalIgnoreCase);
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
                !string.Equals("subscriptions", splitResourceId[0], StringComparison.OrdinalIgnoreCase) ||
                !string.Equals("resourceGroups", splitResourceId[2], StringComparison.OrdinalIgnoreCase) ||
                !string.Equals("providers", splitResourceId[4], StringComparison.OrdinalIgnoreCase)))
            {
                throw new System.Management.Automation.PSArgumentException(ProjectResources.InvalidFormatOfResourceId);
            }

            return resourceIds
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Select(resourceId => new ResourceIdentifier(resourceId))
                .ToArray();
        }

        /// <summary>
        /// Get a mapping of Resource providers that support the operations API (/operations) to the operations api-version supported for that RP 
        /// (Current logic is to prefer the latest "non-test' api-version. If there are no such version, choose the latest one)
        /// </summary>
        public Dictionary<string, string> GetResourceProvidersWithOperationsSupport()
        {
            PSResourceProvider[] allProviders = this.ListPSResourceProviders(listAvailable: true);

            Dictionary<string, string> providersSupportingOperations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            PSResourceProviderResourceType[] providerResourceTypes = null;

            foreach (PSResourceProvider provider in allProviders)
            {
                providerResourceTypes = provider.ResourceTypes;
                if (providerResourceTypes != null && providerResourceTypes.Any())
                {
                    PSResourceProviderResourceType operationsResourceType = providerResourceTypes.Where(r => r != null && r.ResourceTypeName == ResourcesClient.Operations).FirstOrDefault();
                    if (operationsResourceType != null &&
                        operationsResourceType.ApiVersions != null &&
                        operationsResourceType.ApiVersions.Any())
                    {
                        string[] allowedTestPrefixes = new[] { "-preview", "-alpha", "-beta", "-rc", "-privatepreview" };
                        List<string> nonTestApiVersions = new List<string>();
                        
                        foreach (string apiVersion in operationsResourceType.ApiVersions) 
                        {
                            bool isTestApiVersion = false;
                            foreach (string testPrefix in allowedTestPrefixes)
                            {
                                if (apiVersion.EndsWith(testPrefix, StringComparison.OrdinalIgnoreCase))
                                {
                                    isTestApiVersion = true;
                                    break;
                                }
                            }

                            if(isTestApiVersion == false && !nonTestApiVersions.Contains(apiVersion))
                            {
                                nonTestApiVersions.Add(apiVersion);
                            }
                        }

                        if(nonTestApiVersions.Any())
                        {
                            string latestNonTestApiVersion = nonTestApiVersions.OrderBy(o => o).Last();
                            providersSupportingOperations.Add(provider.ProviderNamespace, latestNonTestApiVersion);
                        }
                        else
                        {
                            providersSupportingOperations.Add(provider.ProviderNamespace, operationsResourceType.ApiVersions.OrderBy(o => o).Last());
                        }
                    }
                }
            }

            return providersSupportingOperations;
        }
        
        public ProviderOperationsMetadata GetProviderOperationsMetadata(string providerNamespace)
        {
            return this.AuthorizationManagementClient.ProviderOperationsMetadata.Get(providerNamespace, this.ResourceManagementClient.ApiVersion);
        }

        public IEnumerable<ProviderOperationsMetadata> ListProviderOperationsMetadata()
        {
           return this.AuthorizationManagementClient.ProviderOperationsMetadata.List(this.ResourceManagementClient.ApiVersion);
        }
    }
}