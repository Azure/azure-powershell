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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;
    using System;
    using System.IO;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using Commands.Common.Authentication.Abstractions;

    /// <summary>
    /// Base class for policy cmdlets.
    /// </summary>
    public abstract class PolicyCmdletBase : ResourceManagerCmdletBase
    {
        public enum ListFilter
        {
            None,
            Builtin,
            Custom
        }

        /// <summary>
        /// Parameter set names
        /// </summary>
        protected const string IdParameterSet = "IdParameterSet";
        protected const string NameParameterSet = "NameParameterSet";
        protected const string SubscriptionIdParameterSet = "SubscriptionIdParameterSet";
        protected const string ManagementGroupNameParameterSet = "ManagementGroupNameParameterSet";
        protected const string IncludeDescendentParameterSet = "IncludeDescendentParameterSet";
        protected const string BuiltinFilterParameterSet = "BuiltinFilterParameterSet";
        protected const string CustomFilterParameterSet = "CustomFilterParameterSet";
        protected const string DefaultParameterSet = "DefaultParameterSet";
        protected const string PolicyParameterObjectParameterSet = "PolicyParameterObjectParameterSet";
        protected const string PolicyParameterStringParameterSet = "PolicyParameterStringParameterSet";
        protected const string PolicySetParameterObjectParameterSet = "PolicySetParameterObjectParameterSet";
        protected const string PolicySetParameterStringParameterSet = "PolicySetParameterStringParameterSet";

        /// <summary>
        /// Converts the resource object to specified resource type object.
        /// </summary>
        /// <param name="resourceType">The resource type of the objects to create</param>
        /// <param name="resources">The policy definition resource object.</param>
        protected PSObject[] GetOutputObjects(string resourceType, params JToken[] resources)
        {
            return resources
                .CoalesceEnumerable()
                .Where(resource => resource != null)
                .SelectArray(resource =>
                {
                    var psobject = resource.ToResource().ToPsObject();
                    psobject.Properties.Add(new PSNoteProperty(resourceType, psobject.Properties["ResourceId"].Value));
                    return psobject;
                });
        }

        /// <summary>
        /// Converts the resource object collection to a filtered PSObject array.
        /// </summary>
        /// <param name="resourceType">The resource type of the input objects</param>
        /// <param name="filter">the filter</param>
        /// <param name="resources">The policy definition resource object.</param>
        protected PSObject[] GetFilteredOutputObjects(string resourceType, ListFilter filter, params JObject[] resources)
        {
            Func<PSObject, bool> filterLambda = (result) =>
            {
                if (filter == ListFilter.None)
                {
                    return true;
                }

                var policyType = result.Properties["PolicyType"];
                return policyType == null || string.Equals(policyType.Value.ToString(), filter.ToString(), StringComparison.OrdinalIgnoreCase);
            };

            return resources
                .CoalesceEnumerable()
                .Where(resource => resource != null)
                .SelectArray(resource =>
                {
                    var psobject = resource.ToResource().ToPsObject();
                    psobject.Properties.Add(new PSNoteProperty(resourceType, psobject.Properties["ResourceId"].Value));
                    return psobject;
                })
                .Where(filterLambda).ToArray();
        }

        /// <summary>
        /// Gets the next set of resources using the <paramref name="nextLink"/>
        /// </summary>
        /// <param name="nextLink">The next link.</param>
        protected Task<ResponseWithContinuation<TType[]>> GetNextLink<TType>(string nextLink)
        {
            return this
                .GetResourcesClient()
                .ListNextBatch<TType>(nextLink: nextLink, cancellationToken: this.CancellationToken.Value);
        }

        /// <summary>
        /// Gets the JToken object from parameter
        /// </summary>
        protected JToken GetObjectFromParameter(string parameter)
        {
            Uri outUri = null;
            if (Uri.TryCreate(parameter, UriKind.Absolute, out outUri))
            {
                if(outUri.Scheme == Uri.UriSchemeFile)
                {
                    string filePath = this.TryResolvePath(parameter);
                    if(File.Exists(filePath))
                    {
                        return JToken.FromObject(FileUtilities.DataStore.ReadFileAsText(filePath));
                    }
                    else
                    {
                        throw new PSInvalidOperationException(string.Format(ProjectResources.InvalidFilePath, parameter));
                    }
                }
                else if (outUri.Scheme != Uri.UriSchemeHttp && outUri.Scheme != Uri.UriSchemeHttps)
                {
                    throw new PSInvalidOperationException(ProjectResources.InvalidUriScheme);
                }
                else if (!Uri.IsWellFormedUriString(outUri.AbsoluteUri, UriKind.Absolute))
                {
                    throw new PSInvalidOperationException(string.Format(ProjectResources.InvalidUriString, parameter));
                }
                else
                {
                    string contents = GeneralUtilities.DownloadFile(outUri.AbsoluteUri);
                    if(string.IsNullOrEmpty(contents))
                    {
                        throw new PSInvalidOperationException(string.Format(ProjectResources.InvalidUriContent, parameter));
                    }
                    return JToken.FromObject(contents);
                }
            }

            //for non absolute file paths
            string path = this.TryResolvePath(parameter);

            return File.Exists(path)
                ? JToken.FromObject(FileUtilities.DataStore.ReadFileAsText(path))
                : JToken.FromObject(parameter);
        }

        /// <summary>
        /// Gets the resource Id from the supplied PowerShell parameters.
        /// </summary>
        protected string MakePolicyAssignmentId(string scope, string resourceName)
        {
            return ResourceIdUtility.GetResourceId(
                resourceId: scope,
                extensionResourceType: Constants.MicrosoftAuthorizationPolicyAssignmentType,
                extensionResourceName: resourceName);
        }

        /// <summary>
        /// Returns the policy or policy set definition resource Id given management group name and/or subscription id and/or policy definition name
        /// </summary>
        private string MakeDefinitionId(string managementGroupName, Guid? subscriptionId, string policyDefinitionName, string fullyQualifiedResourceType)
        {
            if (!string.IsNullOrEmpty(managementGroupName) && subscriptionId != null)
            {
                // Note parameter attributes should prevent both of these being provided together: this is just an extra safety check
                throw new PSInvalidOperationException($"Only -ManagementGroupName or -SubscriptionId can be provided, not both.");
            }

            // name is optional in Get operations
            var namePart = string.Empty;
            if (!string.IsNullOrEmpty(policyDefinitionName))
            {
                namePart = $"/{policyDefinitionName}";
            }

            // generate resource Id based on management group
            if (!string.IsNullOrEmpty(managementGroupName))
            {
                return $"/providers/{Constants.MicrosoftManagementGroupDefinitionType}/{managementGroupName}/providers/{fullyQualifiedResourceType}{namePart}";
            }

            // generate resource Id based on given subscription
            if (subscriptionId != null)
            {
                return $"/subscriptions/{subscriptionId}/providers/{fullyQualifiedResourceType}{namePart}";
            }

            // generate resource Id based on current subscription
            return $"/subscriptions/{DefaultContext.Subscription.Id}/providers/{fullyQualifiedResourceType}{namePart}";
        }

        /// <summary>
        /// Returns the policy definition resource Id given management group name and/or subscription id and/or policy definition name
        /// </summary>
        protected string MakePolicyDefinitionId(string managementGroupName, Guid? subscriptionId, string policyDefinitionName)
        {
            return MakeDefinitionId(managementGroupName, subscriptionId, policyDefinitionName, Constants.MicrosoftAuthorizationPolicyDefinitionType);
        }

        /// <summary>
        /// Returns the policy set definition resource Id given management group name and/or subscription id and/or policy set definition name
        /// </summary>
        protected string MakePolicySetDefinitionId(string managementGroupName, Guid? subscriptionId, string policySetDefinitionName)
        {
            return MakeDefinitionId(managementGroupName, subscriptionId, policySetDefinitionName, Constants.MicrosoftAuthorizationPolicySetDefinitionType);
        }

        /// <summary>
        /// Validate and convert input switches into filter type enum
        /// </summary>
        /// <param name="builtin">true if builtin filter was provided</param>
        /// <param name="custom">true if custom filter was provided</param>
        /// <returns>Enum indicating type of list filtering that was requested</returns>
        protected ListFilter GetListFilter(bool builtin, bool custom)
        {
            if (builtin && custom)
            {
                // Note parameter attributes should prevent these switches being provided together: this is just an extra safety check
                throw new PSInvalidOperationException($"Only -Builtin or -Custom can be provided, not both.");
            }

            return builtin ? ListFilter.Builtin : (custom ? ListFilter.Custom : ListFilter.None);
        }

        /// <summary>
        /// Gets a resource.
        /// </summary>
        protected async Task<JObject> GetExistingResource(string resourceId, string apiVersion)
        {
            return await this
                .GetResourcesClient()
                .GetResource<JObject>(
                    resourceId: resourceId,
                    apiVersion: apiVersion,
                    cancellationToken: this.CancellationToken.Value)
                .ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}