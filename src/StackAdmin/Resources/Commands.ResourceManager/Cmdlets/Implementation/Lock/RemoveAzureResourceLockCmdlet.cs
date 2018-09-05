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
    using System.Management.Automation;

    /// <summary>
    /// The remove azure resource lock cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmResourceLock", SupportsShouldProcess = true, DefaultParameterSetName = ResourceLockManagementCmdletBase.LockIdParameterSet), OutputType(typeof(PSObject))]
    public class RemoveAzureResourceLockCmdlet : ResourceLockManagementCmdletBase
    {
        /// <summary>
        /// Gets or sets the extension resource name parameter.
        /// </summary>
        [Alias("ExtensionResourceName", "Name")]
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.ResourceGroupLevelLock, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the lock.")]
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.ResourceGroupResourceLevelLock, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the lock.")]
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.ScopeLevelLock, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the lock.")]
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.SubscriptionLevelLock, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the lock.")]
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.SubscriptionResourceLevelLock, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the lock.")]
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.TenantResourceLevelLock, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the lock.")]
        [ValidateNotNullOrEmpty]
        public string LockName { get; set; }

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
            var resourceId = this.GetResourceId(this.LockName);
            this.ConfirmAction(
                this.Force,
                string.Format("Are you sure you want to delete the following lock: {0}", resourceId),
                "Deleting the lock...",
                resourceId,
                () =>
                {
                    var operationResult = this.GetResourcesClient()
                        .DeleteResource(
                            resourceId: resourceId,
                            apiVersion: this.LockApiVersion,
                            cancellationToken: this.CancellationToken.Value)
                        .Result;

                    if (operationResult.HttpStatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        throw new PSInvalidOperationException(string.Format("The resource lock '{0}' could not be found.", resourceId));
                    }

                    var managementUri = this.GetResourcesClient()
                        .GetResourceManagementRequestUri(
                            resourceId: resourceId,
                            apiVersion: this.LockApiVersion);

                    var activity = string.Format("DELETE {0}", managementUri.PathAndQuery);

                    var result = this.GetLongRunningOperationTracker(activityName: activity, isResourceCreateOrUpdate: false)
                        .WaitOnOperation(operationResult: operationResult);

                    this.WriteObject(true);
                });
        }
    }
}
