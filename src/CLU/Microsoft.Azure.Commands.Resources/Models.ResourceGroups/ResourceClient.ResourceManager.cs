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

using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.Resources.Models
{
    public partial class ResourcesClient
    {
        public const string ResourceGroupTypeName = "ResourceGroup";

        public static List<string> KnownLocations = new List<string>
        {
            "East Asia", "South East Asia", "East US", "West US", "North Central US", 
            "South Central US", "Central US", "North Europe", "West Europe"
        };

        internal static List<string> KnownLocationsNormalized = KnownLocations
            .Select(loc => loc.ToLower().Replace(" ", "")).ToList();

        /// <summary>
        /// Creates a new resource.
        /// </summary>
        /// <param name="parameters">The create parameters</param>
        /// <returns>The created resource</returns>
        public virtual PSResource CreatePSResource(CreatePSResourceParameters parameters)
        {
            ResourceIdentifier resourceIdentity = parameters.ToResourceIdentity();

            var exists = ResourceManagementClient.ResourceGroups.CheckExistence(parameters.ResourceGroupName);

            if (exists != null && exists.Value)
            {
                WriteVerbose(string.Format("Resource group \"{0}\" is found.", parameters.ResourceGroupName));
            }
            else
            {
                parameters.ConfirmAction(parameters.Force,
                                             ProjectResources.ResourceGroupDoesntExistsAdd,
                                             ProjectResources.AddingResourceGroup,
                                             parameters.Name,
                                             () => CreateOrUpdateResourceGroup(parameters.ResourceGroupName, parameters.Location, null));

                exists = ResourceManagementClient.ResourceGroups.CheckExistence(parameters.ResourceGroupName);
                if (exists == null || !exists.Value)
                {
                    throw new ArgumentException(ProjectResources.ResourceGroupDoesntExists);
                }
                else
                {
                    WriteVerbose(string.Format("Created resource group '{0}' in location '{1}'", parameters.Name, parameters.Location));
                }
            }

            var resourceExists = ResourceManagementClient.Resources.CheckExistence(
                parameters.ResourceGroupName, 
                "",
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                ResourceManagementClient.ApiVersion);

            Action createOrUpdateResource = () =>
                {
                    WriteVerbose(string.Format("Creating resource \"{0}\" started.", parameters.Name));

                    Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(parameters.Tag, validate: true);
                    
                    var createOrUpdateResult = ResourceManagementClient.Resources.CreateOrUpdate(
                        parameters.ResourceGroupName,
                        "",
                        resourceIdentity.ParentResource,
                        resourceIdentity.ResourceType,
                        resourceIdentity.ResourceName,
                        ResourceManagementClient.ApiVersion,
                        new GenericResource
                            {
                                Location = parameters.Location,
                                Properties = SerializeHashtable(parameters.PropertyObject, addValueLayer: false),
                                Tags = tagDictionary
                            });

                    if (createOrUpdateResult != null)
                    {
                        WriteVerbose(string.Format("Creating resource \"{0}\" complete.", parameters.Name));
                    }
                };
            
            if (resourceExists != null && resourceExists.Value && !parameters.Force)
            {
                parameters.ConfirmAction(parameters.Force,
                                         ProjectResources.ResourceAlreadyExists,
                                         ProjectResources.NewResourceMessage,
                                         parameters.Name,
                                         createOrUpdateResource);
            }
            else
            {
                createOrUpdateResource();
            }
            
            var getResult = ResourceManagementClient.Resources.Get(
                parameters.ResourceGroupName, 
                "",
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                ResourceManagementClient.ApiVersion);

            return getResult.ToPSResource(this, false);
        }

        /// <summary>
        /// Updates an existing resource.
        /// </summary>
        /// <param name="parameters">The update parameters</param>
        /// <returns>The updated resource</returns>
        public virtual PSResource UpdatePSResource(UpdatePSResourceParameters parameters)
        {
            var resourceIdentity = parameters.ToResourceIdentity();

            GenericResource getResource;

            try
            {
                getResource = ResourceManagementClient.Resources.Get(
                    parameters.ResourceGroupName,
                    "", 
                    resourceIdentity.ParentResource,
                    resourceIdentity.ResourceType,
                    resourceIdentity.ResourceName,
                    ResourceManagementClient.ApiVersion);
            }
            catch (CloudException)
            {
                throw new ArgumentException(ProjectResources.ResourceDoesntExists);
            }

            string newProperty = SerializeHashtable(parameters.PropertyObject,
                                                    addValueLayer: false);

            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(parameters.Tag, validate: true);

            ResourceManagementClient.Resources.CreateOrUpdate(
                parameters.ResourceGroupName,
                "",
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                ResourceManagementClient.ApiVersion,
                new GenericResource
                    {
                        Location = getResource.Location,
                        Properties = newProperty,
                        Tags = tagDictionary
                    });

            var getResult = ResourceManagementClient.Resources.Get(
                parameters.ResourceGroupName, 
                "",
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                ResourceManagementClient.ApiVersion);

            return getResult.ToPSResource(this, false);
        }

        /// <summary>
        /// Get an existing resource or resources.
        /// </summary>
        /// <param name="parameters">The get parameters</param>
        /// <returns>List of resources</returns>
        public virtual List<PSResource> FilterPSResources(BasePSResourceParameters parameters)
        {
            List<PSResource> resources = new List<PSResource>();

            if (!string.IsNullOrEmpty(parameters.Name))
            {
                var resourceIdentity = parameters.ToResourceIdentity();

                GenericResource getResult;

                try
                {
                    getResult = ResourceManagementClient.Resources.Get(
                        parameters.ResourceGroupName,
                        "",
                        resourceIdentity.ParentResource,
                        resourceIdentity.ResourceType,
                        resourceIdentity.ResourceName,
                        ResourceManagementClient.ApiVersion);
                }
                catch (CloudException)
                {
                    throw new ArgumentException(ProjectResources.ResourceDoesntExists);
                }

                resources.Add(getResult.ToPSResource(this, false));
            }
            else
            {
                PSTagValuePair tagValuePair = new PSTagValuePair();
                if (parameters.Tag != null && parameters.Tag.Length == 1 && parameters.Tag[0] != null)
                {
                    tagValuePair = TagsConversionHelper.Create(parameters.Tag[0]);
                    if (tagValuePair == null)
                    {
                        throw new ArgumentException(ProjectResources.InvalidTagFormat);
                    }
                }
                var listResult = ResourceManagementClient.Resources.List( 
                            new ODataQuery<GenericResourceFilter>( f => 
                                f.ResourceType == parameters.ResourceType &&
                                f.Tagname == tagValuePair.Name &&
                                f.Tagvalue == tagValuePair.Value));

                if (listResult != null)
                {
                    resources.AddRange(listResult.Select(r => r.ToPSResource(this, false)));
                }
            }
            return resources;
        }

        /// <summary>
        /// Creates a new resource group and deployment using the passed template file option which
        /// can be user customized or from gallery templates.
        /// </summary>
        /// <param name="parameters">The create parameters</param>
        /// <returns>The created resource group</returns>
        public virtual PSResourceGroup CreatePSResourceGroup(CreatePSResourceGroupParameters parameters)
        {
            bool createDeployment = !string.IsNullOrEmpty(parameters.TemplateFile);
            bool? resourceExists = ResourceManagementClient.ResourceGroups.CheckExistence(parameters.ResourceGroupName);

            ResourceGroup resourceGroup = null;
            Action createOrUpdateResourceGroup = () =>
            {
                resourceGroup = CreateOrUpdateResourceGroup(parameters.ResourceGroupName, parameters.Location, parameters.Tag);
                WriteVerbose(string.Format("Created resource group '{0}' in location '{1}'", resourceGroup.Name, resourceGroup.Location));

                if (createDeployment)
                {
                    ExecuteDeployment(parameters);
                }
            };

            if (resourceExists != null && resourceExists.Value && !parameters.Force)
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

            return resourceGroup.ToPSResourceGroup(this, true);
        }

        /// <summary>
        /// Updates a resource group.
        /// </summary>
        /// <param name="parameters">The create parameters</param>
        /// <returns>The created resource group</returns>
        public virtual PSResourceGroup UpdatePSResourceGroup(UpdatePSResourceGroupParameters parameters)
        {
            ResourceGroup resourceGroup = ResourceManagementClient.ResourceGroups.Get(parameters.ResourceGroupName);

            resourceGroup = CreateOrUpdateResourceGroup(parameters.ResourceGroupName, resourceGroup.Location, parameters.Tag);
            WriteVerbose(string.Format("Updated resource group '{0}' in location '{1}'", resourceGroup.Name, resourceGroup.Location));

            return resourceGroup.ToPSResourceGroup(this, true);
        }

        /// <summary>
        /// Filters a given resource group resources.
        /// </summary>
        /// <param name="options">The filtering options</param>
        /// <returns>The filtered set of resources matching the filter criteria</returns>
        public virtual List<GenericResource> FilterResources(FilterResourcesOptions options)
        {
            List<GenericResource> resources = new List<GenericResource>();

            if (!string.IsNullOrEmpty(options.ResourceGroup) && !string.IsNullOrEmpty(options.Name))
            {
                resources.Add(ResourceManagementClient.Resources.Get(
                    options.ResourceGroup,
                    "",
                    "",
                    "",
                    options.Name,
                    ResourceManagementClient.ApiVersion));
            }
            else
            {
                IPage<GenericResource> result;
                if (options != null && options.ResourceType != null)
                {
                    result = ResourceManagementClient.Resources.List(
                        new ODataQuery<GenericResourceFilter>( f => f.ResourceType == options.ResourceType));
                }
                else
                {
                    result = ResourceManagementClient.Resources.List();
                }

                resources.AddRange(result);

                while (!string.IsNullOrEmpty(result.NextPageLink))
                {
                    result = ResourceManagementClient.Resources.ListNext(result.NextPageLink);
                    resources.AddRange(result);
                }
            }

            return resources;
        }

        /// <summary>
        /// Creates new deployment using the passed template file which can be user customized or
        /// from gallery templates.
        /// </summary>
        /// <param name="parameters">The create deployment parameters</param>
        /// <returns>The created deployment instance</returns>
        public virtual PSResourceGroupDeployment ExecuteDeployment(CreatePSResourceGroupDeploymentParameters parameters)
        {
            parameters.DeploymentName = GenerateDeploymentName(parameters);
            Deployment deployment = CreateBasicDeployment(parameters, parameters.DeploymentMode);

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
                var resourceGroups = ResourceManagementClient.ResourceGroups.List().ToList();

                while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    resourceGroups.AddRange(response);
                }

                resourceGroups = !string.IsNullOrEmpty(location)
                    ? resourceGroups.Where(resourceGroup => this.NormalizeLetterOrDigitToUpperInvariant(resourceGroup.Location).Equals(
                        this.NormalizeLetterOrDigitToUpperInvariant(location))).ToList()
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
                result.AddRange(resourceGroups.Select(rg => rg.ToPSResourceGroup(this, detailed)));
            }
            else
            {
                try
                {
                    result.Add(ResourceManagementClient.ResourceGroups.Get(name).ToPSResourceGroup(this, detailed));
                }
                catch (CloudException)
                {
                    throw new ArgumentException(ProjectResources.ResourceGroupDoesntExists);
                }
            }

            return result;
        }

        /// <summary>
        /// Deletes a given resource
        /// </summary>
        /// <param name="parameters">The resource identification</param>
        public virtual void DeleteResource(BasePSResourceParameters parameters)
        {
            ResourceIdentifier resourceIdentity = parameters.ToResourceIdentity();
            var exists = ResourceManagementClient.Resources.CheckExistence(
                parameters.ResourceGroupName,
                "",
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                ResourceManagementClient.ApiVersion);

            if (exists == null || !exists.Value)
            {
                throw new ArgumentException(ProjectResources.ResourceDoesntExists);
            }

            ResourceManagementClient.Resources.Delete(
                parameters.ResourceGroupName,
                "",
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                ResourceManagementClient.ApiVersion);
        }

        /// <summary>
        /// Moves a number of resources from one resource group to another
        /// </summary>
        /// <param name="sourceResourceGroupName"></param>
        /// <param name="destinationResourceGroup"></param>
        /// <param name="resourceIds"></param>
        public virtual void MoveResources(string sourceResourceGroupName, string destinationResourceGroup, string[] resourceIds)
        {
            var resourcesMoveInfo = new ResourcesMoveInfo
            {
                Resources = resourceIds,
                TargetResourceGroup = destinationResourceGroup,
            };

            ResourceManagementClient.Resources.MoveResources(sourceResourceGroupName, resourcesMoveInfo);
        }

        /// <summary>
        /// Deletes a given resource group
        /// </summary>
        /// <param name="name">The resource group name</param>
        public virtual void DeleteResourceGroup(string name)
        {
            var exists = ResourceManagementClient.ResourceGroups.CheckExistence(name);

            if (exists == null || !exists.Value)
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

            if(excludedProvisioningStates.Count > 0)
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
                    "Failed",
                    "Succeeded"
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
        /// Deletes a deployment
        /// </summary>
        /// <param name="resourceGroup">The resource group name</param>
        /// <param name="deploymentName">Deployment name</param>
        public virtual void DeleteDeployment(string resourceGroup, string deploymentName)
        {
            var exists = ResourceManagementClient.Deployments.CheckExistence(resourceGroup, deploymentName);

            if (exists == null || !exists.Value)
            {
                throw new ArgumentException(string.Format(ProjectResources.DeploymentDoesntExist, deploymentName, resourceGroup));
            }

            ResourceManagementClient.Deployments.Delete(resourceGroup, deploymentName);
        }

        /// <summary>
        /// Validates a given deployment.
        /// </summary>
        /// <param name="parameters">The deployment create options</param>
        /// <returns>True if valid, false otherwise.</returns>
        public virtual List<PSResourceManagerError> ValidatePSResourceGroupDeployment(ValidatePSResourceGroupDeploymentParameters parameters, DeploymentMode deploymentMode)
        {
            Deployment deployment = CreateBasicDeployment(parameters, deploymentMode);
            TemplateValidationInfo validationInfo = CheckBasicDeploymentErrors(parameters.ResourceGroupName, Guid.NewGuid().ToString(), deployment);

            if (validationInfo.Errors.Count == 0)
            {
                WriteVerbose(ProjectResources.TemplateValid);
            }
            return validationInfo.Errors.Select(e => e.ToPSResourceManagerError()).ToList();
        }

        /// <summary>
        /// Gets available locations for the specified resource type.
        /// </summary>
        /// <param name="resourceTypes">The resource types</param>
        /// <returns>Mapping between each resource type and its available locations</returns>
        public virtual List<PSResourceProviderLocationInfo> GetLocations(params string[] resourceTypes)
        {
            if (resourceTypes == null)
            {
                resourceTypes = new string[0];
            }
            List<string> providerNames = resourceTypes.Select(r => r.Split('/').First()).ToList();
            List<PSResourceProviderLocationInfo> result = new List<PSResourceProviderLocationInfo>();
            List<Provider> providers = new List<Provider>();

            if (resourceTypes.Length == 0 || resourceTypes.Any(r => r.Equals(ResourceGroupTypeName, StringComparison.OrdinalIgnoreCase)))
            {
                result.Add(new ProviderResourceType
                {
                    ResourceType = ResourceGroupTypeName,
                    Locations = KnownLocations
                }.ToPSResourceProviderLocationInfo(null));
            }

            if (resourceTypes.Length > 0)
            {
                providers.AddRange(ListResourceProviders()
                    .Where(p => providerNames.Any(pn => pn.Equals(p.NamespaceProperty, StringComparison.OrdinalIgnoreCase))));
            }
            else
            {
                providers.AddRange(ListResourceProviders());
            }

            result.AddRange(providers.SelectMany(p => p.ResourceTypes
                .Select(r => r.ToPSResourceProviderLocationInfo(p.NamespaceProperty)))
                .Where(r => r.Locations != null && r.Locations.Count > 0));

            return result;
        }
    }
}
