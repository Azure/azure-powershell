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
    using Policy;
    using System.Management.Automation;

    /// <summary>
    /// Removes the policy assignment.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PolicyAssignment", SupportsShouldProcess = true, DefaultParameterSetName = PolicyCmdletBase.NameParameterSet), OutputType(typeof(bool))]
    public class RemoveAzurePolicyAssignmentCmdlet : PolicyCmdletBase
    {
        /// <summary>
        /// Gets or sets the policy assignment name parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.RemovePolicyAssignmentNameHelp)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment scope parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.NameParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.RemovePolicyAssignmentScopeHelp)]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment id parameter
        /// </summary>
        [Alias("ResourceId")]
        [Parameter(ParameterSetName = PolicyCmdletBase.IdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.RemovePolicyAssignmentIdHelp)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment input object parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.InputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.RemovePolicyAssignmentInputObjectHelp)]
        public PsPolicyAssignment InputObject { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();

            this.RunCmdlet();
        }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        private void RunCmdlet()
        {
            base.OnProcessRecord();
            string resourceId = this.GetResourceId();
            var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.PolicyAssignmentApiVersion : this.ApiVersion;

            this.ConfirmAction(
                "Deleting the policy assignment...",
                resourceId,
                () =>
                {
                    var operationResult = this.GetResourcesClient()
                        .DeleteResource(
                            resourceId: resourceId,
                            apiVersion: apiVersion,
                            cancellationToken: this.CancellationToken.Value,
                            odataQuery: null)
                        .Result;

                    var managementUri = this.GetResourcesClient()
                        .GetResourceManagementRequestUri(
                            resourceId: resourceId,
                            apiVersion: apiVersion,
                            odataQuery: null);

                    var activity = string.Format("DELETE {0}", managementUri.PathAndQuery);

                    this.GetLongRunningOperationTracker(activityName: activity, isResourceCreateOrUpdate: false)
                        .WaitOnOperation(operationResult: operationResult);

                    this.WriteObject(true);
                });
        }

        /// <summary>
        /// Gets the resource Id from the supplied PowerShell parameters.
        /// </summary>
        private string GetResourceId()
        {
            return this.Id ?? this.InputObject?.ResourceId ?? this.GetPolicyArtifactFullyQualifiedId(this.Scope, Constants.MicrosoftAuthorizationPolicyAssignmentType, this.Name);
        }
    }
}
