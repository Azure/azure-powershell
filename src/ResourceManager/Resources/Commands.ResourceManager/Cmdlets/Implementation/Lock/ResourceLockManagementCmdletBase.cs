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
    using Newtonsoft.Json.Linq;
    using System;
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// Base class for resource lock management cmdlets.
    /// </summary>
    public abstract class ResourceLockManagementCmdletBase : ResourceManagerCmdletBase
    {
        /// <summary> 
        /// The Id parameter set. 
        /// </summary> 
        internal const string LockIdParameterSet = "A lock, by Id.";

        /// <summary>
        /// The resource group level resource lock.
        /// </summary>
        internal const string ScopeLevelLock = "A lock at the specified scope.";

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
        /// Gets or sets the scope.
        /// </summary>
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.ScopeLevelLock, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The scope. e.g. to specify a database '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaserName}', to specify a resoruce group: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}'")]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the resource name parameter.
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
        /// The Id of the lock.
        /// </summary>
        [Alias("Id", "ResourceId")]
        [Parameter(ParameterSetName = ResourceLockManagementCmdletBase.LockIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Id of the lock.")]
        [ValidateNotNullOrEmpty]
        public string LockId { get; set; }

        /// <summary>
        /// Determines the api version to be used
        /// </summary>
        public string LockApiVersion { get; set; }

        public ResourceLockManagementCmdletBase()
        {
            this.LockApiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.LockApiVersion : this.ApiVersion;
        }

        /// <summary> 
        /// Gets the resource Id from the supplied PowerShell parameters. 
        /// </summary> 
        /// <param name="lockName">The name of the lock.</param>
        protected string GetResourceId(string lockName)
        {
            if (!string.IsNullOrWhiteSpace(this.LockId))
            {
                var resourceType = ResourceIdUtility.GetResourceType(this.LockId);
                var extensionResourceType = ResourceIdUtility.GetExtensionResourceType(this.LockId);

                if ((resourceType.EqualsInsensitively(Constants.MicrosoftAuthorizationLocksType) &&
                    string.IsNullOrWhiteSpace(extensionResourceType)) ||
                    extensionResourceType.EqualsInsensitively(Constants.MicrosoftAuthorizationLocksType))
                {
                    return this.LockId;
                }

                throw new InvalidOperationException(string.Format("The Id '{0}' does not belong to a lock.", this.LockId));
            }

            return !string.IsNullOrWhiteSpace(this.Scope)
                ? ResourceIdUtility.GetResourceId(
                    resourceId: this.Scope,
                    extensionResourceType: Constants.MicrosoftAuthorizationLocksType,
                    extensionResourceName: lockName)
                : ResourceIdUtility.GetResourceId(
                    subscriptionId: this.DefaultContext.Subscription.Id,
                    resourceGroupName: this.ResourceGroupName,
                    resourceType: this.ResourceType,
                    resourceName: this.ResourceName,
                    extensionResourceType: Constants.MicrosoftAuthorizationLocksType,
                    extensionResourceName: lockName);
        }

        /// <summary>
        /// Converts the resource object to output that can be piped to the lock cmdlets.
        /// </summary>
        /// <param name="resources">The lock resource object.</param>
        protected PSObject[] GetOutputObjects(params JToken[] resources)
        {
            return resources
                .CoalesceEnumerable()
                .Where(resource => resource != null)
                .SelectArray(resource =>
                {
                    var psobject = resource.ToResource().ToPsObject();
                    psobject.Properties.Add(new PSNoteProperty("LockId", psobject.Properties["ResourceId"].Value));
                    return psobject;
                });
        }
    }
}