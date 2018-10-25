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
    /// Creates the new policy definition.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PolicyDefinition", DefaultParameterSetName = PolicyCmdletBase.NameParameterSet), OutputType(typeof(PSObject))]
    public class NewAzurePolicyDefinitionCmdlet : PolicyCmdletBase
    {
        /// <summary>
        /// Gets or sets the new policy definition name parameter.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyDefinitionNameHelp)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the new policy definition display name parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyDefinitionDisplayNameHelp)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the new policy definition description parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyDefinitionDescriptionHelp)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the new policy definition policy rule parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyDefinitionRuleHelp)]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        /// <summary>
        /// Gets or sets the new policy definition metadata parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyDefinitionMetadataHelp)]
        [ValidateNotNullOrEmpty]
        public string Metadata { get; set; }

        /// <summary>
        /// Gets or sets the new policy definition parameters parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyDefinitionParameterHelp)]
        [ValidateNotNullOrEmpty]
        public string Parameter { get; set; }

        /// <summary>
        /// Gets or sets the new policy definition mode parameter.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyDefinitionModeHelp)]
        [ValidateNotNullOrEmpty]
        public PolicyDefinitionMode? Mode { get; set; }

        /// <summary>
        /// Gets or sets the new policy definition management group name parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.ManagementGroupNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyDefinitionManagementGroupHelp)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupName { get; set; }

        /// <summary>
        /// Gets or sets the new policy definition subscription is parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.SubscriptionIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyDefinitionSubscriptionIdHelp)]
        [ValidateNotNullOrEmpty]
        public Guid? SubscriptionId { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            string resourceId = GetResourceId();

            var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.PolicyDefinitionApiVersion : this.ApiVersion;

            var operationResult = this.GetResourcesClient()
                .PutResource(
                    resourceId: resourceId,
                    apiVersion: apiVersion,
                    resource: this.GetResource(),
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
        /// Gets the resource Id
        /// </summary>
        private string GetResourceId()
        {
            return this.MakePolicyDefinitionId(this.ManagementGroupName, this.SubscriptionId, this.Name);
        }

        /// <summary>
        /// Constructs the resource
        /// </summary>
        private JToken GetResource()
        {
            var policyDefinitionObject = new PolicyDefinition
            {
                Name = this.Name,
                Properties = new PolicyDefinitionProperties
                {
                    Description = this.Description ?? null,
                    DisplayName = this.DisplayName ?? null,
                    PolicyRule = JObject.Parse(this.GetObjectFromParameter(this.Policy).ToString()),
                    Metadata = this.Metadata == null ? null : JObject.Parse(this.GetObjectFromParameter(this.Metadata).ToString()),
                    Parameters = this.Parameter == null ? null : JObject.Parse(this.GetObjectFromParameter(this.Parameter).ToString()),
                    Mode = this.Mode.HasValue ? this.Mode : PolicyDefinitionMode.All
                }
            };

            return policyDefinitionObject.ToJToken();
        }
    }
}
