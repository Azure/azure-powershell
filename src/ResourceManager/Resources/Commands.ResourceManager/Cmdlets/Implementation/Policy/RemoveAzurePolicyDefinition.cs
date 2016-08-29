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
    using System.Management.Automation;

    /// <summary>
    /// Removes the policy definition.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmPolicyDefinition", SupportsShouldProcess = true,
        DefaultParameterSetName = RemoveAzurePolicyDefinitionCmdlet.PolicyDefinitionNameParameterSet), 
        OutputType(typeof(bool))]
    public class RemoveAzurePolicyDefinitionCmdlet : PolicyDefinitionCmdletBase
    {
        /// <summary>
        /// The policy Id parameter set.
        /// </summary>
        internal const string PolicyDefinitionIdParameterSet = "The policy definition Id parameter set.";

        /// <summary>
        /// The policy name parameter set.
        /// </summary>
        internal const string PolicyDefinitionNameParameterSet = "The policy definition name parameter set.";

        /// <summary>
        /// Gets or sets the policy definition name parameter.
        /// </summary>
        [Parameter(ParameterSetName = RemoveAzurePolicyDefinitionCmdlet.PolicyDefinitionNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The policy definition name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy definition id parameter
        /// </summary>
        [Alias("ResourceId")]
        [Parameter(ParameterSetName = RemoveAzurePolicyDefinitionCmdlet.PolicyDefinitionIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The fully qualified policy definition Id, including the subscription. e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the force parameter.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

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
            string resourceId = this.Id ?? this.GetResourceId();
            var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.PolicyApiVersion : this.ApiVersion;

            this.ConfirmAction(
                this.Force,
                string.Format("Are you sure you want to delete the following policy definition: {0}", resourceId),
                "Deleting the policy definition...",
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
        protected string GetResourceId()
        {
            var subscriptionId = DefaultContext.Subscription.Id;
            return string.Format("/subscriptions/{0}/providers/{1}/{2}",
                subscriptionId.ToString(),
                Constants.MicrosoftAuthorizationPolicyDefinitionType,
                this.Name);
        }
    }
}
