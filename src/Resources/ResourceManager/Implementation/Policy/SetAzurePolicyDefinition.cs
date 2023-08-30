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
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

    using Newtonsoft.Json.Linq;
    using Policy;
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Sets the policy definition.
    /// </summary>
    [CmdletOutputBreakingChangeWithVersion(
        typeof(PsPolicyDefinition), deprecateByAzVersion: "11.0.0", deprecateByVersion: "7.0.0", DeprecatedOutputProperties = new[] { "Properties" },
        NewOutputProperties = new[] { "Description", "DisplayName", "Metadata", "Mode", "Parameters", "PolicyRule", "PolicyType" })]
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PolicyDefinition", DefaultParameterSetName = PolicyCmdletBase.NameParameterSet), OutputType(typeof(PsPolicyDefinition))]
    public class SetAzurePolicyDefinitionCmdlet : PolicyCmdletBase
    {
        /// <summary>
        /// Gets or sets the policy definition name parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyDefinitionNameHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.ManagementGroupNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyDefinitionNameHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.SubscriptionIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyDefinitionNameHelp)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy definition id parameter
        /// </summary>
        [Alias("ResourceId")]
        [Parameter(ParameterSetName = PolicyCmdletBase.IdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyDefinitionIdHelp)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the policy definition display name parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyDefinitionDisplayNameHelp)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the policy definition description parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyDefinitionDescriptionHelp)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the policy rule parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyDefinitionRuleHelp)]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        /// <summary>
        /// Gets or sets the policy definition metadata parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyDefinitionMetadataHelp)]
        [ValidateNotNullOrEmpty]
        public string Metadata { get; set; }

        /// <summary>
        /// Gets or sets the policy definition parameters parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyDefinitionParameterHelp)]
        [ValidateNotNullOrEmpty]
        public string Parameter { get; set; }

        /// <summary>
        /// Gets or sets the policy definition mode parameter.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyDefinitionModeHelp)]
        [PSArgumentCompleter(PolicyDefinitionMode.All, PolicyDefinitionMode.Indexed)]
        [ValidateNotNullOrEmpty]
        public string Mode { get; set; }

        /// <summary>
        /// Gets or sets the policy definition management group name parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.ManagementGroupNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyDefinitionManagementGroupHelp)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupName { get; set; }

        /// <summary>
        /// Gets or sets the policy definition subscription id parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.SubscriptionIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyDefinitionSubscriptionIdHelp)]
        [ValidateNotNullOrEmpty]
        public Guid? SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the policy definition input object parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.InputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyDefinitionInputObjectHelp)]
        public PsPolicyDefinition InputObject { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            string resourceId = this.GetResourceId();
            var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.PolicyDefinitionApiVersion : this.ApiVersion;

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

            this.WriteObject(this.GetOutputPolicyDefinitions(JObject.Parse(result)), enumerateCollection: true);
        }

        /// <summary>
        /// Constructs the policy definition by combining command line parameters and existing policy definition
        /// </summary>
        private JToken GetResource(string resourceId, string apiVersion)
        {
            var resource = this.GetExistingResource(resourceId, apiVersion).Result.ToResource();

            // apply incoming object properties if present
            if (this.InputObject != null)
            {
                resource.Properties = this.InputObject.Properties.ToJToken();
            }

            var policyDefinitionObject = new PolicyDefinition
            {
                Name = this.Name ?? resource.Name,
                Properties = new PolicyDefinitionProperties()
            };

            JObject policyObject = this.Policy != null ? this.GetObjectFromParameter(this.Policy, nameof(this.Policy)) : null;
            if (policyObject != null && policyObject["policyRule"] != null)
            {
                // policy parameter was a full policy object, populate the properties from it, override from other command line parameters
                policyDefinitionObject.Properties.Description = this.Description ?? policyObject["description"]?.ToString() ?? resource.Properties["description"]?.ToString();
                policyDefinitionObject.Properties.DisplayName = this.DisplayName ?? policyObject["displayName"]?.ToString() ?? resource.Properties["displayName"]?.ToString();
                policyDefinitionObject.Properties.PolicyRule = policyObject["policyRule"] as JObject ?? resource.Properties["policyRule"] as JObject;
                policyDefinitionObject.Properties.Metadata = this.Metadata == null
                    ? policyObject["metadata"] as JObject ?? resource.Properties["metadata"] as JObject
                    : this.GetObjectFromParameter(this.Metadata, nameof(this.Metadata));
                policyDefinitionObject.Properties.Parameters = this.Parameter == null
                    ? policyObject["parameters"] as JObject ?? resource.Properties["metadata"] as JObject
                    : this.GetObjectFromParameter(this.Parameter, nameof(this.Parameter));
                policyDefinitionObject.Properties.Mode = string.IsNullOrEmpty(this.Mode)
                    ? policyObject["mode"]?.ToString() ?? resource.Properties["mode"]?.ToString() ?? PolicyDefinitionMode.All
                    : this.Mode;
            }
            else
            {
                // policy parameter was a rule object, populate policy rule from it and the properties from command line parameters
                policyDefinitionObject.Properties.Description = this.Description ?? resource.Properties["description"]?.ToString();
                policyDefinitionObject.Properties.DisplayName = this.DisplayName ?? resource.Properties["displayName"]?.ToString();
                policyDefinitionObject.Properties.PolicyRule = policyObject ?? resource.Properties["policyRule"] as JObject;
                policyDefinitionObject.Properties.Metadata = this.Metadata == null ? resource.Properties["metadata"] as JObject : this.GetObjectFromParameter(this.Metadata, nameof(this.Metadata));
                policyDefinitionObject.Properties.Parameters = this.Parameter == null ? resource.Properties["parameters"] as JObject : this.GetObjectFromParameter(this.Parameter, nameof(this.Parameter));
                policyDefinitionObject.Properties.Mode = string.IsNullOrEmpty(this.Mode) ? resource.Properties["mode"]?.ToString() ?? PolicyDefinitionMode.All : this.Mode;
            }

            return policyDefinitionObject.ToJToken();
        }

        /// <summary>
        /// Gets the resource Id from the supplied PowerShell parameters.
        /// </summary>
        private string GetResourceId()
        {
            return this.Id ?? this.InputObject?.ResourceId ?? this.MakePolicyDefinitionId(this.ManagementGroupName, this.SubscriptionId, this.Name);
        }
    }
}
