using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkExtensions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

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
        public ResourceManagerSdkClient(AzureContext context)
            : this(
                AzureSession.ClientFactory.CreateArmClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
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

            var result = ResourceManagementClient.DeploymentOperations.List(resourceGroup, deploymentName, null);
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

                    if (detailedMessage != null)
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
            params ProvisioningState[] status)
        {
            DeploymentExtended deployment;

            do
            {
                if (job != null)
                {
                    job(resourceGroup, deploymentName, basicDeployment);
                }

                deployment = ResourceManagementClient.Deployments.Get(resourceGroup, deploymentName);
                TestMockSupport.Delay(10000);

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
                        List<DeploymentOperation> newNestedOperations = new List<DeploymentOperation>();

                        var result = ResourceManagementClient.DeploymentOperations.List(
                            resourceGroupName: ResourceIdUtility.GetResourceGroupName(operation.Properties.TargetResource.Id),
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

        private Deployment CreateBasicDeployment(ValidatePSResourceGroupDeploymentParameters parameters, DeploymentMode deploymentMode, string debugSetting)
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
                deployment.Properties.Parameters = JObject.Parse(GetDeploymentParameters(parameters.TemplateParameterObject));
            }

            return deployment;
        }

        private TemplateValidationInfo CheckBasicDeploymentErrors(string resourceGroup, string deploymentName, Deployment deployment)
        {
            DeploymentValidateResult validationResult = ResourceManagementClient.Deployments.Validate(
                resourceGroup,
                deploymentName,
                deployment);

            return new TemplateValidationInfo(validationResult);
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
                    PSResourceProviderResourceType operationsResourceType = providerResourceTypes.Where(r => r != null && r.ResourceTypeName == ResourceManagerSdkClient.Operations).FirstOrDefault();
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

                            if (isTestApiVersion == false && !nonTestApiVersions.Contains(apiVersion))
                            {
                                nonTestApiVersions.Add(apiVersion);
                            }
                        }

                        if (nonTestApiVersions.Any())
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
            Task<IPage<ResourceProviderOperationDefinition>> task;

            if (identities != null)
            {
                foreach (var identity in identities)
                {
                    try
                    {
                        task = this.ResourceManagementClient.ResourceProviderOperationDetails.ListAsync(identity.ResourceProviderNamespace, identity.ResourceProviderApiVersion);
                        task.Wait(10000);

                        // Add operations for this provider.
                        if (task.IsCompleted)
                        {
                            allProviderOperations.AddRange(task.Result.Select(op => op.ToPSResourceProviderOperation()));
                        }
                    }
                    catch (AggregateException ae)
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

        /// <summary>
        /// Creates a new resource group
        /// </summary>
        /// <param name="parameters">The create parameters</param>
        public virtual PSResourceGroup CreatePSResourceGroup(CreatePSResourceGroupParameters parameters)
        {
            bool resourceExists = ResourceManagementClient.ResourceGroups.CheckExistence(parameters.ResourceGroupName).Value;

            ResourceGroup resourceGroup = null;
            Action createOrUpdateResourceGroup = () =>
            {
                resourceGroup = CreateOrUpdateResourceGroup(parameters.ResourceGroupName, parameters.Location, parameters.Tag);
                WriteVerbose(string.Format("Created resource group '{0}' in location '{1}'", resourceGroup.Name, resourceGroup.Location));
            };

            if (resourceExists && !parameters.Force)
            {
                parameters.ConfirmAction(parameters.Force,
                    ProjectResources.ResourceGroupAlreadyExists,
                    ProjectResources.NewResourceGroupMessage,
                    parameters.DeploymentName,
                    createOrUpdateResourceGroup);
                resourceGroup = ResourceManagementClient.ResourceGroups.Get(parameters.ResourceGroupName);
            }
            else
            {
                createOrUpdateResourceGroup();
            }

            return resourceGroup.ToPSResourceGroup();
        }

        /// <summary>
        /// Updates a resource group.
        /// </summary>
        /// <param name="parameters">The create parameters</param>
        public virtual PSResourceGroup UpdatePSResourceGroup(UpdatePSResourceGroupParameters parameters)
        {
            ResourceGroup resourceGroup = ResourceManagementClient.ResourceGroups.Get(parameters.ResourceGroupName);

            resourceGroup = CreateOrUpdateResourceGroup(parameters.ResourceGroupName, resourceGroup.Location, parameters.Tag);
            WriteVerbose(string.Format("Updated resource group '{0}' in location '{1}'", resourceGroup.Name, resourceGroup.Location));

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

            if (string.IsNullOrEmpty(name))
            {
                var response = ResourceManagementClient.ResourceGroups.List(null);
                List<ResourceGroup> resourceGroups = ResourceManagementClient.ResourceGroups.List(null).ToList();

                while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    resourceGroups.AddRange(response);
                }

                resourceGroups = !string.IsNullOrEmpty(location)
                    ? resourceGroups.Where(resourceGroup => this.NormalizeLetterOrDigitToUpperInvariant(resourceGroup.Location).Equals(this.NormalizeLetterOrDigitToUpperInvariant(location))).ToList()
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
                    throw new ArgumentException(ProjectResources.ResourceGroupDoesntExists);
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
            if (!ResourceManagementClient.ResourceGroups.CheckExistence(name).Value)
            {
                throw new ArgumentException(ProjectResources.ResourceGroupDoesntExists);
            }

            ResourceManagementClient.ResourceGroups.Delete(name);
        }

        /// <summary>
        /// Filters the resource group deployments
        /// </summary>
        /// <param name="options">The filtering options</param>
        /// <returns>The filtered list of deployments</returns>
        public virtual List<PSResourceGroupDeployment> FilterResourceGroupDeployments(FilterResourceGroupDeploymentOptions options)
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
                var result = ResourceManagementClient.Deployments.List(resourceGroup, null);

                deployments.AddRange(result.Select(d => d.ToPSResourceGroupDeployment(options.ResourceGroupName)));

                while (!string.IsNullOrEmpty(result.NextPageLink))
                {
                    result = ResourceManagementClient.Deployments.ListNext(result.NextPageLink);
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
        /// Creates new deployment
        /// </summary>
        /// <param name="parameters">The create deployment parameters</param>
        public virtual PSResourceGroupDeployment ExecuteDeployment(CreatePSResourceGroupDeploymentParameters parameters)
        {
            parameters.DeploymentName = GenerateDeploymentName(parameters);
            Deployment deployment = CreateBasicDeployment(parameters, parameters.DeploymentMode, parameters.DeploymentDebugLogLevel);

            TemplateValidationInfo validationInfo = CheckBasicDeploymentErrors(parameters.ResourceGroupName, parameters.DeploymentName, deployment);

            if (validationInfo.Errors.Count != 0)
            {
                int counter = 1;
                string errorFormat = "Error {0}: Code={1}; Message={2}\r\n";
                StringBuilder errorsString = new StringBuilder();
                validationInfo.Errors.ForEach(e => errorsString.AppendFormat(errorFormat, counter++, e.Code, e.Message));
                throw new ArgumentException(errorsString.ToString());
            }
            else
            {
                WriteVerbose(ProjectResources.TemplateValid);
            }

            ResourceManagementClient.Deployments.CreateOrUpdate(parameters.ResourceGroupName, parameters.DeploymentName, deployment);
            WriteVerbose(string.Format("Create template deployment '{0}'.", parameters.DeploymentName));
            DeploymentExtended result = ProvisionDeploymentStatus(parameters.ResourceGroupName, parameters.DeploymentName, deployment);

            return result.ToPSResourceGroupDeployment(parameters.ResourceGroupName);
        }

        private string GenerateDeploymentName(CreatePSResourceGroupDeploymentParameters parameters)
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
        /// <param name="resourceGroup">The resource group name</param>
        /// <param name="deploymentName">Deployment name</param>
        public virtual void DeleteDeployment(string resourceGroup, string deploymentName)
        {
            if (!ResourceManagementClient.Deployments.CheckExistence(resourceGroup, deploymentName).Value)
            {
                throw new ArgumentException(string.Format(ProjectResources.DeploymentDoesntExist, deploymentName, resourceGroup));
            }

            ResourceManagementClient.Deployments.Delete(resourceGroup, deploymentName);
        }

        /// <summary>
        /// Cancels the active deployment.
        /// </summary>
        /// <param name="resourceGroup">The resource group name</param>
        /// <param name="deploymentName">Deployment name</param>
        public virtual void CancelDeployment(string resourceGroup, string deploymentName)
        {
            FilterResourceGroupDeploymentOptions options = new FilterResourceGroupDeploymentOptions
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
                    throw new ArgumentException(string.Format("There is no deployment called '{0}' to cancel", deploymentName));
                }
                else
                {
                    throw new ArgumentException(string.Format("There are no running deployments under resource group '{0}'", resourceGroup));
                }
            }
            else if (deployments.Count == 1)
            {
                ResourceManagementClient.Deployments.Cancel(resourceGroup, deployments.First().DeploymentName);
            }
            else
            {
                throw new ArgumentException("There are more than one running deployment please specify one");
            }
        }

        /// <summary>
        /// Validates a given deployment.
        /// </summary>
        /// <param name="parameters">The deployment create options</param>
        /// <returns>True if valid, false otherwise.</returns>
        public virtual List<PSResourceManagerError> ValidatePSResourceGroupDeployment(ValidatePSResourceGroupDeploymentParameters parameters, DeploymentMode deploymentMode)
        {
            Deployment deployment = CreateBasicDeployment(parameters, deploymentMode, null);
            TemplateValidationInfo validationInfo = CheckBasicDeploymentErrors(parameters.ResourceGroupName, Guid.NewGuid().ToString(), deployment);

            if (validationInfo.Errors.Count == 0)
            {
                WriteVerbose(ProjectResources.TemplateValid);
            }
            return validationInfo.Errors.Select(e => e.ToPSResourceManagerError()).ToList();
        }
    }
}
