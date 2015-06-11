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
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;

    /// <summary>
    /// The remove azure resource lock cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureResourceLock", SupportsShouldProcess = true), OutputType(typeof(PSObject))]
    public class RemoveAzureResourceLockCmdlet : ResourceManagerCmdletBase 
    {
        /// <summary> 
        /// The resource group level resource lock. 
        /// </summary> 
        internal const string ScopeAndName = "A lock, by the scope and name."; 

        /// <summary> 
        /// The resource group level resource lock. 
        /// </summary> 
        internal const string ResourceGroupResourceLevelLock = "A lock at the resource group resource scope."; 

        /// <summary> 
        /// The subscription level resource lock. 
        /// </summary> 
        internal const string SubscriptionResourceLevelLock = "A lock at the subscription resource scope."; 

        /// <summary> 
        /// The tenant level resource lock patameter set. 
        /// </summary> 
        internal const string TenantResourceLevelLock = "A lock at the tenant resource scope."; 

        /// <summary> 
        /// The resource group lock parametere set. 
        /// </summary> 
        internal const string ResourceGroupLevelLock = "A lock at the resource group scope."; 

        /// <summary> 
        /// The subscription lock parameter set. 
        /// </summary> 
        internal const string SubscriptionLevelLock = "A lock at the subscription scope."; 

        /// <summary> 
        /// Gets or sets the lock Id. 
        /// </summary> 
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.ScopeAndName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Id of the lock. e.g. '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaserName}', to specify a resoruce group: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}'")] 
        [ValidateNotNullOrEmpty] 
        public string Scope { get; set; } 

        /// <summary> 
        /// Gets or sets the extension resource name parameter. 
        /// </summary> 
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.ResourceGroupResourceLevelLock, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource name. e.g. to specify a database MyServer/MyDatabase.")] 
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.SubscriptionResourceLevelLock, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource name. e.g. to specify a database MyServer/MyDatabase.")] 
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.TenantResourceLevelLock, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource name. e.g. to specify a database MyServer/MyDatabase.")] 
        [ValidateNotNullOrEmpty] 
        public string ResourceName { get; set; } 

        /// <summary> 
        /// Gets or sets the resource type parameter. 
        /// </summary> 
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.ResourceGroupResourceLevelLock, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource type. e.g. Microsoft.Sql/Servers/Databases.")] 
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.SubscriptionResourceLevelLock, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource type. e.g. Microsoft.Sql/Servers/Databases.")] 
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.TenantResourceLevelLock, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource type. e.g. Microsoft.Sql/Servers/Databases.")] 
        [ValidateNotNullOrEmpty] 
        public string ResourceType { get; set; } 

        /// <summary> 
        /// Gets or sets the subscription id parameter. 
        /// </summary> 
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.ResourceGroupResourceLevelLock, Mandatory = false, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The subscription to use.")] 
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.ResourceGroupLevelLock, Mandatory = false, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The subscription to use.")] 
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.SubscriptionLevelLock, Mandatory = false, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The subscription to use.")] 
        [ValidateNotNullOrEmpty] 
        public Guid? SubscriptionId { get; set; } 

        /// <summary> 
        /// Gets or sets the resource group name parameter. 
        /// </summary> 
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.ResourceGroupResourceLevelLock, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")] 
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.ResourceGroupLevelLock, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")] 
        [ValidateNotNullOrEmpty] 
        public string ResourceGroupName { get; set; } 

        /// <summary> 
        /// Gets or sets the tenant level parameter. 
        /// </summary> 
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.TenantResourceLevelLock, Mandatory = true, HelpMessage = "Indicates that this is a tenant level operation.")] 
        public SwitchParameter TenantLevel { get; set; }

        /// <summary> 
        /// Gets or sets the extension resource name parameter. 
        /// </summary> 
        [Alias("ExtensionResourceName")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the lock.")]
        [ValidateNotNullOrEmpty] 
        public string LockName { get; set; } 
        
        /// <summary> 
        /// Initializes the default subscription id if needed. 
        /// </summary> 
        protected override void OnProcessRecord() 
        { 
            if (string.IsNullOrWhiteSpace(this.Scope) && this.SubscriptionId == null && !this.TenantLevel) 
            { 
                this.SubscriptionId = this.Profile.Context.Subscription.Id; 
            } 

            base.OnProcessRecord(); 
        }
        
        /// <summary> 
        /// Gets the resource Id from the supplied PowerShell parameters. 
        /// </summary> 
        protected string GetResourceId() 
        { 
            return !string.IsNullOrWhiteSpace(this.Scope) 
                ? ResourceIdUtility.GetResourceId( 
                    resourceId: this.Scope, 
                    extensionResourceType: Constants.MicrosoftAuthorizationLocksType, 
                    extensionResourceName: this.LockName) 
                : ResourceIdUtility.GetResourceId( 
                    subscriptionId: this.SubscriptionId, 
                    resourceGroupName: this.ResourceGroupName, 
                    resourceType: this.ResourceType, 
                    resourceName: this.ResourceName, 
                    extensionResourceType: Constants.MicrosoftAuthorizationLocksType, 
                    extensionResourceName: this.LockName); 
        }
        
        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();

            var resourceId = this.GetResourceId();

            this.ConfirmAction(
                this.Force,
                string.Format("Are you sure you want to delete the following lock: {0}", resourceId),
                "Deleting the lock...",
                resourceId,
                () =>
                {
                    var apiVersion = this.DetermineApiVersion(resourceId: resourceId).Result;

                    var operationResult = this.GetResourcesClient()
                        .DeleteResource(
                            resourceId: resourceId,
                            apiVersion: apiVersion,
                            cancellationToken: this.CancellationToken.Value)
                        .Result;

                    var managementUri = this.GetResourcesClient()
                        .GetResourceManagementRequestUri(
                            resourceId: resourceId,
                            apiVersion: apiVersion);

                    var activity = string.Format("DELETE {0}", managementUri.PathAndQuery);

                    var result = this.GetLongRunningOperationTracker(activityName: activity, isResourceCreateOrUpdate: false)
                        .WaitOnOperation(operationResult: operationResult);

                    this.WriteObject(result, ResourceObjectFormat.New);
                });
        }
    }
}
