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
    using System.Management.Automation;

    /// <summary>
    /// Creates a policy assignment.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmPolicyAssignment"), OutputType(typeof(PSObject))]
    public class NewAzurePolicyAssignmentCmdlet : PolicyAssignmentCmdletBase
    {
        /// <summary>
        /// Gets or sets the policy assignment name parameter.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The policy assignment name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment scope parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The scope for policy assignment.")]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment display name parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The description for policy assignment.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment policy definition parameter.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The pollicy definition object.")]
        public PSObject PolicyDefinition { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            if (this.PolicyDefinition.Properties["policyDefinitionId"] == null)
            {
                throw new PSInvalidOperationException("The supplied PolicyDefinition object is invalid.");
            }
            string resourceId = GetResourceId();

            var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.PolicyApiVersion : this.ApiVersion;

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

            this.WriteObject(this.GetOutputObjects(JObject.Parse(result)), enumerateCollection: true);
        }

        /// <summary>
        /// Gets the resource Id
        /// </summary>
        private string GetResourceId()
        {
            return ResourceIdUtility.GetResourceId(
                resourceId: this.Scope,
                extensionResourceType: Constants.MicrosoftAuthorizationPolicyAssignmentType,
                extensionResourceName: this.Name);
        }

        /// <summary>
        /// Constructs the resource
        /// </summary>
        private JToken GetResource()
        {
            var policyassignmentObject = new PolicyAssignment
            {
                Name = this.Name,
                Properties = new PolicyAssignmentProperties
                {
                    DisplayName = this.DisplayName ?? null,
                    PolicyDefinitionId = this.PolicyDefinition.Properties["policyDefinitionId"].Value.ToString(),
                    Scope = this.Scope
                }
            };

            return policyassignmentObject.ToJToken();
        }
    }
}