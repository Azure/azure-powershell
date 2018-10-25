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
    using Newtonsoft.Json.Linq;
    using Policy;
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Sets the policy definition.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PolicyDefinition", DefaultParameterSetName = PolicyCmdletBase.NameParameterSet), OutputType(typeof(PSObject))]
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
        /// Gets or sets the new policy definition mode parameter.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyDefinitionModeHelp)]
        [ValidateNotNullOrEmpty]
        public PolicyDefinitionMode? Mode { get; set; }

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

            this.WriteObject(this.GetOutputObjects("PolicyDefinitionId", JObject.Parse(result)), enumerateCollection: true);
        }

        /// <summary>
        /// Constructs the resource
        /// </summary>
        private JToken GetResource(string resourceId, string apiVersion)
        {
            var resource = this.GetExistingResource(resourceId, apiVersion).Result.ToResource();

            var policyRuleJson = string.IsNullOrEmpty(this.Policy) ? resource.Properties["policyRule"]?.ToString() : GetObjectFromParameter(this.Policy).ToString();
            var metaDataJson = string.IsNullOrEmpty(this.Metadata) ? resource.Properties["metadata"]?.ToString() : GetObjectFromParameter(this.Metadata).ToString();
            var parameterJson = string.IsNullOrEmpty(this.Parameter) ? resource.Properties["parameters"]?.ToString() : GetObjectFromParameter(this.Parameter).ToString();

            PolicyDefinitionMode tempMode;
            PolicyDefinitionMode? existingMode = null;
            if (Enum.TryParse(resource.Properties["mode"]?.ToString(), true, out tempMode))
            {
                existingMode = tempMode;
            }

            var policyDefinitionObject = new PolicyDefinition
            {
                Name = this.Name ?? resource.Name,
                Properties = new PolicyDefinitionProperties
                {
                    Description = this.Description ?? resource.Properties["description"]?.ToString(),
                    DisplayName = this.DisplayName ?? resource.Properties["displayName"]?.ToString(),
                    PolicyRule = string.IsNullOrEmpty(policyRuleJson) ? null : JObject.Parse(policyRuleJson),
                    Metadata = string.IsNullOrEmpty(metaDataJson) ? null : JObject.Parse(metaDataJson),
                    Parameters = string.IsNullOrEmpty(parameterJson) ? null : JObject.Parse(parameterJson),
                    Mode = this.Mode ?? existingMode
                }
            };

            return policyDefinitionObject.ToJToken();
        }

        /// <summary>
        /// Gets the resource Id from the supplied PowerShell parameters.
        /// </summary>
        private string GetResourceId()
        {
            return this.Id ?? this.MakePolicyDefinitionId(this.ManagementGroupName, this.SubscriptionId, this.Name);
        }
    }
}
