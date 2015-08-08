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
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
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

        public GalleryTemplatesClient GalleryTemplatesClient { get; set; }

        // TODO: http://vstfrd:8080/Azure/RD/_workitems#_a=edit&id=3247094
        //public IEventsClient EventsClient { get; set; }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        /// <summary>
        /// Creates new ResourceManagementClient
        /// </summary>
        /// <param name="profile">Profile containing resources to manipulate</param>
        public ResourcesClient(AzureProfile profile)
            : this(
                AzureSession.ClientFactory.CreateClient<ResourceManagementClient>(profile, AzureEnvironment.Endpoint.ResourceManager),
                new GalleryTemplatesClient(profile.Context),
                // TODO: http://vstfrd:8080/Azure/RD/_workitems#_a=edit&id=3247094
                //AzureSession.ClientFactory.CreateClient<EventsClient>(context, AzureEnvironment.Endpoint.ResourceManager),
                AzureSession.ClientFactory.CreateClient<AuthorizationManagementClient>(profile.Context, AzureEnvironment.Endpoint.ResourceManager))
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
            // TODO: http://vstfrd:8080/Azure/RD/_workitems#_a=edit&id=3247094
            //IEventsClient eventsClient,
            IAuthorizationManagementClient authorizationManagementClient)
        {
            GalleryTemplatesClient = galleryTemplatesClient;
            // TODO: http://vstfrd:8080/Azure/RD/_workitems#_a=edit&id=3247094
            //EventsClient = eventsClient;
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

            if (response.Provider == null)
            {
                throw new KeyNotFoundException(string.Format(ProjectResources.ResourceProviderUnregistrationFailed, providerName));
            }

            return response.Provider.ToPSResourceProvider();
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

        private ResourceGroupExtended CreateOrUpdateResourceGroup(string name, string location, Hashtable[] tags)
        {
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(tags, validate: true);

            var result = ResourceManagementClient.ResourceGroups.CreateOrUpdate(name,
                new ResourceGroup
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

        private DeploymentExtended ProvisionDeploymentStatus(string resourceGroup, string deploymentName, Deployment deployment)
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

        private Deployment CreateBasicDeployment(ValidatePSResourceGroupDeploymentParameters parameters, DeploymentMode deploymentMode)
        {
            Deployment deployment = new Deployment
            {
                Properties = new DeploymentProperties {
                    Mode = deploymentMode,
                    Template = GetTemplate(parameters.TemplateFile, parameters.GalleryTemplateIdentity),
                    Parameters = GetDeploymentParameters(parameters.TemplateParameterObject)
                }
            };

            return deployment;
        }

        private TemplateValidationInfo CheckBasicDeploymentErrors(string resourceGroup, string deploymentName, Deployment deployment)
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

        public virtual PSResourceProvider[] ListPSResourceProviders(string providerName = null)
        {
            return this.ListResourceProviders(providerName: providerName, listAvailable: false)
                .Select(provider => provider.ToPSResourceProvider())
                .ToArray();
        }

        public virtual PSResourceProvider[] ListPSResourceProviders(bool listAvailable)
        {
            return this.ListResourceProviders(providerName: null, listAvailable: listAvailable)
                .Select(provider => provider.ToPSResourceProvider())
                .ToArray();
        }

        public virtual List<Provider> ListResourceProviders(string providerName = null, bool listAvailable = true)
        {
            if (!string.IsNullOrEmpty(providerName))
            {
                var provider = this.ResourceManagementClient.Providers.Get(providerName).Provider;

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
                returnList.AddRange(tempResult.Providers);

                while (!string.IsNullOrWhiteSpace(tempResult.NextLink))
                {
                    tempResult = this.ResourceManagementClient.Providers.ListNext(tempResult.NextLink);
                    returnList.AddRange(tempResult.Providers);
                }

                return listAvailable
                    ? returnList
                    : returnList.Where(this.IsProviderRegistered).ToList();
            }
        }

        private bool IsProviderRegistered(Provider provider)
        {
            return string.Equals(
                ResourcesClient.RegisteredStateName,
                provider.RegistrationState,
                StringComparison.InvariantCultureIgnoreCase);
        }

        public PSResourceProvider RegisterProvider(string providerName)
        {
            var response = this.ResourceManagementClient.Providers.Register(providerName);

            if (response.Provider == null)
            {
                throw new KeyNotFoundException(string.Format(ProjectResources.ResourceProviderRegistrationFailed, providerName));
            }

            return response.Provider.ToPSResourceProvider();
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
        /// Get a mapping of Resource providers that support the operations API (/operations) to the operations api-version supported for that RP 
        /// (Current logic is to prefer the latest "non-test' api-version. If there are no such version, choose the latest one)
        /// </summary>
        public Dictionary<string, string> GetResourceProvidersWithOperationsSupport()
        {
            PSResourceProvider[] allProviders = this.ListPSResourceProviders(listAvailable: true);

            Dictionary<string, string> providersSupportingOperations = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
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
                                if (apiVersion.EndsWith(testPrefix, StringComparison.InvariantCultureIgnoreCase))
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

        /// <summary>
        /// Get the list of resource provider operations for every provider specified by the identities list
        /// </summary>
        public IList<PSResourceProviderOperation> ListPSProviderOperations(IList<ResourceIdentity> identities)
        {
            var allProviderOperations = new List<PSResourceProviderOperation>();
            Task<ResourceProviderOperationDetailListResult> task;

            if(identities != null)
            {
                foreach (var identity in identities)
                {
                    try
                    {
                        task = this.ResourceManagementClient.ResourceProviderOperationDetails.ListAsync(identity);
                        task.Wait(10000);

                        // Add operations for this provider.
                        if (task.IsCompleted)
                        {
                            allProviderOperations.AddRange(task.Result.ResourceProviderOperationDetails.Select(op => op.ToPSResourceProviderOperation()));
                        }
                    }
                    catch(AggregateException ae)
                    {
                         AggregateException flattened = ae.Flatten();
                         foreach (Exception inner in flattened.InnerExceptions)
                         {
                             // Do nothing for now - this is just a mitigation against one provider which hasn't implemented the operations API correctly
                             //WriteWarning(inner.ToString());
                         }
                    }
                }
            }
              
            return allProviderOperations;
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