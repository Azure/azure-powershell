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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;
    using System;
    using System.Collections;
    using System.IO;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using Commands.Common.Authentication.Abstractions;

    /// <summary>
    /// Base class for policy cmdlets.
    /// </summary>
    public abstract class PolicyCmdletBase : ResourceManagerCmdletBaseWithApiVersion
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
        protected const string InputObjectParameterSet = "InputObjectParameterSet";
        protected const string ManagementGroupNameParameterSet = "ManagementGroupNameParameterSet";
        protected const string IncludeDescendentParameterSet = "IncludeDescendentParameterSet";
        protected const string BuiltinFilterParameterSet = "BuiltinFilterParameterSet";
        protected const string CustomFilterParameterSet = "CustomFilterParameterSet";
        protected const string DefaultParameterSet = "DefaultParameterSet";
        protected const string PolicyParameterObjectParameterSet = "PolicyParameterObjectParameterSet";
        protected const string PolicyParameterStringParameterSet = "PolicyParameterStringParameterSet";
        protected const string PolicySetParameterObjectParameterSet = "PolicySetParameterObjectParameterSet";
        protected const string PolicySetParameterStringParameterSet = "PolicySetParameterStringParameterSet";
        protected const string PolicyParameterNameObjectParameterSet = "PolicyParameterNameObjectParameterSet";
        protected const string PolicyParameterNameStringParameterSet = "PolicyParameterNameStringParameterSet";
        protected const string PolicyParameterIdObjectParameterSet = "PolicyParameterIdObjectParameterSet";
        protected const string PolicyParameterIdStringParameterSet = "PolicyParameterIdStringParameterSet";

        /// <summary>
        /// The policy type OData filter format
        /// </summary>
        protected const string PolicyTypeFilterFormat = "$filter=PolicyType eq '{0}'";

        /// <summary>
        /// Converts the resource object collection to a PsPolicyAssignment collection.
        /// </summary>
        /// <param name="resources">The policy definition resource object.</param>
        protected PsPolicyAssignment[] GetOutputPolicyAssignments(params JToken[] resources)
        {
            return resources
                .CoalesceEnumerable()
                .Where(resource => resource != null)
                .SelectArray(resource => new PsPolicyAssignment(resource));
        }

        /// <summary>
        /// Converts the resource object collection to a PsPolicyDefinition collection.
        /// </summary>
        /// <param name="resources">The policy definition resource object.</param>
        protected PsPolicyDefinition[] GetOutputPolicyDefinitions(params JToken[] resources)
        {
            return resources
                .CoalesceEnumerable()
                .Where(resource => resource != null)
                .SelectArray(resource => new PsPolicyDefinition(resource));
        }

        /// <summary>
        /// Converts the resource object collection to a PsPolicySetDefinition collection.
        /// </summary>
        /// <param name="resources">The policy definition resource object.</param>
        protected PsPolicySetDefinition[] GetOutputPolicySetDefinitions(params JToken[] resources)
        {
            return resources
                .CoalesceEnumerable()
                .Where(resource => resource != null)
                .SelectArray(resource => new PsPolicySetDefinition(resource));
        }

        /// <summary>
        /// Converts the resource object collection to a PsPolicyExemption collection.
        /// </summary>
        /// <param name="resources">The policy definition resource object.</param>
        protected PsPolicyExemption[] GetOutputPolicyExemptions(params JToken[] resources)
        {
            return resources
                .CoalesceEnumerable()
                .Where(resource => resource != null)
                .SelectArray(resource => new PsPolicyExemption(resource));
        }

        /// <summary>
        /// Converts the resource object collection to a filtered PsPolicyDefinition array.
        /// </summary>
        /// <param name="filter">the filter</param>
        /// <param name="resources">The policy definition resource object.</param>
        protected PsPolicyDefinition[] GetFilteredOutputPolicyDefinitions(ListFilter filter, params JToken[] resources)
        {
            Func<PsPolicyDefinition, bool> filterLambda = (result) =>
            {
                if (filter == ListFilter.None)
                {
                    return true;
                }

                var policyType = result.Properties.PolicyType;
                return string.Equals(policyType.ToString(), filter.ToString(), StringComparison.OrdinalIgnoreCase);
            };

            return resources
                .CoalesceEnumerable()
                .Where(resource => resource != null)
                .SelectArray(resource => new PsPolicyDefinition(resource))
                .Where(filterLambda).ToArray();
        }

        /// <summary>
        /// Converts the resource object collection to a filtered PsPolicySetDefinition array.
        /// </summary>
        /// <param name="filter">the filter</param>
        /// <param name="resources">The policy definition resource object.</param>
        protected PsPolicySetDefinition[] GetFilteredOutputPolicySetDefinitions(ListFilter filter, params JObject[] resources)
        {
            Func<PsPolicySetDefinition, bool> filterLambda = (result) =>
            {
                if (filter == ListFilter.None)
                {
                    return true;
                }

                var policyType = result.Properties.PolicyType;
                return string.Equals(policyType.ToString(), filter.ToString(), StringComparison.OrdinalIgnoreCase);
            };

            return resources
                .CoalesceEnumerable()
                .Where(resource => resource != null)
                .SelectArray(resource => new PsPolicySetDefinition(resource))
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
        /// Gets a JObject from a parameter value
        /// </summary>
        /// <param name="parameter">The parameter value.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns></returns>
        protected JObject GetObjectFromParameter(string parameter, string parameterName)
        {
            var result = this.GetTokenFromParameter(parameter) as JObject;
            if (result == null)
            {
                throw new PSArgumentException(string.Format(ProjectResources.JsonObjectExpected, parameterName), parameterName);
            }

            return result;
        }

        /// <summary>
        /// Gets a JArray from a parameter value
        /// </summary>
        /// <param name="parameter">The parameter value.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns></returns>
        protected JArray GetArrayFromParameter(string parameter, string parameterName)
        {
            var result = this.GetTokenFromParameter(parameter) as JArray;
            if (result == null)
            {
                throw new PSArgumentException(string.Format(ProjectResources.JsonArrayExpected, parameterName), parameterName);
            }

            return result;
        }

        /// <summary>
        /// Gets the resource Id from the supplied PowerShell parameters.
        /// </summary>
        protected string GetPolicyArtifactFullyQualifiedId(string scope, string resourceType, string resourceName)
        {
            return ResourceIdUtility.GetResourceId(
                resourceId: scope ?? $"/{Constants.Subscriptions}/{DefaultContext.Subscription.Id}",
                extensionResourceType: resourceType,
                extensionResourceName: resourceName);
        }

        /// <summary>
        /// Gets the JToken from parameter
        /// </summary>
        /// <param name="parameter">The parameter to be parsed.</param>
        private JToken GetTokenFromParameter(string parameter)
        {
            Uri outUri = null;

            if (Uri.TryCreate(parameter, UriKind.Absolute, out outUri))
            {
                if (outUri.Scheme == Uri.UriSchemeFile)
                {
                    string filePath = this.TryResolvePath(parameter);
                    if (File.Exists(filePath))
                    {
                        return JToken.Parse(FileUtilities.DataStore.ReadFileAsText(filePath));
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
                    if (string.IsNullOrEmpty(contents))
                    {
                        throw new PSInvalidOperationException(string.Format(ProjectResources.InvalidUriContent, parameter));
                    }

                    return JToken.Parse(contents);
                }
            }

            //for non absolute file paths
            string path = this.TryResolvePath(parameter);

            return File.Exists(path)
                ? JToken.Parse(FileUtilities.DataStore.ReadFileAsText(path))
                : JToken.Parse(parameter);
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
                return $"{Constants.ManagementGroupIdPrefix}{managementGroupName}/providers/{fullyQualifiedResourceType}{namePart}";
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

        /// <summary>
        /// Resolve given input parameters into JSON parameter object for put
        /// </summary>
        /// <param name="policyParameter"></param>
        /// <param name="policyParameterObject"></param>
        /// <returns></returns>
        protected JObject GetParameters(string policyParameter, Hashtable policyParameterObject)
        {
            // Load parameters from local file or literal
            if (policyParameter != null)
            {
                string policyParameterFilePath = this.TryResolvePath(policyParameter);
                return FileUtilities.DataStore.FileExists(policyParameterFilePath)
                    ? JObject.Parse(FileUtilities.DataStore.ReadFileAsText(policyParameterFilePath))
                    : JObject.Parse(policyParameter);
            }

            // Load from PS object
            if (policyParameterObject != null)
            {
                return policyParameterObject.ToJObjectWithValue();
            }

            // Load dynamic parameters
            var parameters = PowerShellUtilities.GetUsedDynamicParameters(AsJobDynamicParameters, MyInvocation);
            if (parameters.Count() > 0)
            {
                return MyInvocation.BoundParameters.ToJObjectWithValue(parameters.Select(p => p.Name));
            }

            return null;
        }
    }
}