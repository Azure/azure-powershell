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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

    using Newtonsoft.Json.Linq;
    using Policy;
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Sets the policy definition.
    /// </summary>
    [CmdletOutputBreakingChangeWithVersion(
        typeof(PsPolicySetDefinition), deprecateByAzVersion: "11.0.0", deprecateByVersion: "7.0.0", DeprecatedOutputProperties = new[] { "Properties" },
        NewOutputProperties = new[] { "Description", "DisplayName", "Metadata", "Parameters", "PolicyDefinitionGroups", "PolicyDefinitions", "PolicyType" })]
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PolicySetDefinition", DefaultParameterSetName = PolicyCmdletBase.NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PsPolicySetDefinition))]
    public class SetAzurePolicySetDefinitionCmdlet : PolicyCmdletBase
    {
        /// <summary>
        /// Gets or sets the policy set definition name parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionNameHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.ManagementGroupNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionNameHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.SubscriptionIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionNameHelp)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy set definition id parameter
        /// </summary>
        [Alias("ResourceId")]
        [Parameter(ParameterSetName = PolicyCmdletBase.IdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionIdHelp)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the policy set definition display name parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionDisplayNameHelp)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the policy set definition description parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionDescriptionHelp)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the policy definition parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionPolicyDefinitionHelp)]
        [ValidateNotNullOrEmpty]
        public string PolicyDefinition { get; set; }

        /// <summary>
        /// Gets or sets the policy definition metadata parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionMetadataHelp)]
        [ValidateNotNullOrEmpty]
        public string Metadata { get; set; }

        /// <summary>
        /// Gets or sets the policy definition parameters parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionParameterHelp)]
        [ValidateNotNullOrEmpty]
        public string Parameter { get; set; }

        /// <summary>
        /// Gets or sets the policy set definition management group name parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.ManagementGroupNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionManagementGroupHelp)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupName { get; set; }

        /// <summary>
        /// Gets or sets the policy set definition subscription id parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.SubscriptionIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionSubscriptionIdHelp)]
        [ValidateNotNullOrEmpty]
        public Guid? SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the policy set definition input object parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.InputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionInputObjectHelp)]
        public PsPolicySetDefinition InputObject { get; set; }

        /// <summary>
        /// Gets or sets the policy definition groups parameter of the new policy set definition
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionGroupDefinitionHelp)]
        [ValidateNotNullOrEmpty]
        public string GroupDefinition { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            if (this.ShouldProcess(this.Name, "Update Policy Set Definition"))
            {
                string resourceId = this.GetResourceId();
                var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.PolicySetDefintionApiVersion : this.ApiVersion;

                var operationResult = this.GetResourcesClient()
                            .PutResource(
                                resourceId: resourceId,
                                apiVersion: apiVersion,
                                resource: this.GetResource(resourceId, apiVersion),
                                cancellationToken: this.CancellationToken.Value,
                                odataQuery: null)
                            .Result;

                var managementUri = this.GetResourcesClient()
                  .GetResourceManagementRequestUri(
                      resourceId: resourceId,
                      apiVersion: apiVersion,
                      odataQuery: null);

                var activity = string.Format("PUT {0}", managementUri.PathAndQuery);
                var result = this.GetLongRunningOperationTracker(activityName: activity, isResourceCreateOrUpdate: true)
                    .WaitOnOperation(operationResult: operationResult);

                this.WriteObject(this.GetOutputPolicySetDefinitions(JObject.Parse(result)), enumerateCollection: true);
            }
        }

        /// <summary>
        /// Constructs the resource
        /// </summary>
        private JToken GetResource(string resourceId, string apiVersion)
        {
            var resource = this.GetExistingResource(resourceId, apiVersion).Result.ToResource();

            // apply incoming object properties if present
            if (this.InputObject != null)
            {
                resource.Properties = this.InputObject.Properties.ToJToken();
            }

            var metaDataJson = string.IsNullOrEmpty(this.Metadata) ? resource.Properties["metadata"]?.ToString() : this.GetObjectFromParameter(this.Metadata, nameof(this.Metadata)).ToString();
            var parameterJson = string.IsNullOrEmpty(this.Parameter) ? resource.Properties["parameters"]?.ToString() : this.GetObjectFromParameter(this.Parameter, nameof(this.Parameter)).ToString();
            var groupsJson = string.IsNullOrEmpty(this.GroupDefinition) ? resource.Properties["policyDefinitionGroups"]?.ToString() : this.GetArrayFromParameter(this.GroupDefinition, nameof(this.GroupDefinition)).ToString();

            var policySetDefinitionObject = new PolicySetDefinition
            {
                Name = this.Name ?? resource.Name,
                Properties = new PolicySetDefinitionProperties
                {
                    Description = this.Description ?? resource.Properties["description"]?.ToString(),
                    DisplayName = this.DisplayName ?? resource.Properties["displayName"]?.ToString(),
                    PolicyDefinitions = string.IsNullOrEmpty(this.PolicyDefinition) ? resource.Properties["policyDefinitions"] as JArray : this.GetArrayFromParameter(this.PolicyDefinition, nameof(this.PolicyDefinition)),
                    Metadata = string.IsNullOrEmpty(metaDataJson) ?  null : JObject.Parse(metaDataJson),
                    Parameters = string.IsNullOrEmpty(parameterJson) ? null : JObject.Parse(parameterJson),
                    PolicyDefinitionGroups = string.IsNullOrEmpty(groupsJson) ? null : JArray.Parse(groupsJson)
                }
            };

            return policySetDefinitionObject.ToJToken();
        }

        /// <summary>
        /// Gets the resource Id from the supplied PowerShell parameters.
        /// </summary>
        private string GetResourceId()
        {
            return this.Id ?? this.InputObject?.ResourceId ?? this.MakePolicySetDefinitionId(this.ManagementGroupName, this.SubscriptionId, this.Name);
        }
    }
}
