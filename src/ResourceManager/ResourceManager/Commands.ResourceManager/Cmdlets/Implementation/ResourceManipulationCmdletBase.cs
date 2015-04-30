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
    using Microsoft.Azure.Commands.ResourceManager.Clients.Components;

    /// <summary>
    /// The base class for manipulating resources.
    /// </summary>
    public abstract class ResourceManipulationCmdletBase : ResourceManagerCmdletBase
    {
        /// <summary>
        /// The subscription level parameter set.
        /// </summary>
        internal const string SubscriptionLevelResoruce = "Resource that resides at the subscription level.";

        /// <summary>
        /// The tenant level parameter set.
        /// </summary>
        internal const string TenantLevelResoruce = "Resource that resides at the tenant level.";

        /// <summary>
        /// Gets or sets the extension resource name parameter.
        /// </summary>
        [Alias("Name")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource name. e.g. to specify a database MyServer/MyDatabase.")]
        [ValidateNotNullOrEmpty]
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the resource type parameter.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource type. e.g. Microsoft.Sql/Servers/Databases.")]
        [ValidateNotNullOrEmpty]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the deprecated parent resource parameter.
        /// </summary>
        [Parameter(ParameterSetName = ResourceManipulationCmdletBase.SubscriptionLevelResoruce, Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The parent resource type. e.g. Servers/myServer.")]
        [ValidateNotNullOrEmpty]
        [Obsolete("This parameter is obsolete and will be removed in future releases. Please use the -ResourceType and -ResourceName parameters instead.")]
        public string ParentResource { get; set; }

        /// <summary>
        /// Gets or sets the extension resource name parameter.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The extension resource name. e.g. to specify a database MyServer/MyDatabase.")]
        [ValidateNotNullOrEmpty]
        public string ExtensionResourceName { get; set; }

        /// <summary>
        /// Gets or sets the extension resource type parameter.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The extension resource type. e.g. Microsoft.Sql/Servers/Databases.")]
        [ValidateNotNullOrEmpty]
        public string ExtensionResourceType { get; set; }

        /// <summary>
        /// Gets or sets the OData query parameter.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "An OData style filter which will be appended to the request in addition to any other filters.")]
        [ValidateNotNullOrEmpty]
        public string ODataQuery { get; set; }

        /// <summary>
        /// Gets or sets the subscription id parameter.
        /// </summary>
        [Parameter(ParameterSetName = ResourceManipulationCmdletBase.SubscriptionLevelResoruce, Mandatory = false, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The subscription to use.")]
        [ValidateNotNullOrEmpty]
        public Guid? SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the resource group name parameter.
        /// </summary>
        [Parameter(ParameterSetName = ResourceManipulationCmdletBase.SubscriptionLevelResoruce, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the tenant level parameter.
        /// </summary>
        [Parameter(ParameterSetName = ResourceManipulationCmdletBase.TenantLevelResoruce, Mandatory = true, HelpMessage = "Indicates that this is a tenant level operation.")]
        public SwitchParameter TenantLevel { get; set; }

        /// <summary>
        /// Gets or sets the force parameter.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Initializes the default subscription id if needed.
        /// </summary>
        protected override void OnProcessRecord()
        {
            if (!this.TenantLevel && this.SubscriptionId == null)
            {
                this.SubscriptionId = this.Profile.DefaultSubscription.Id;
            }

            base.OnProcessRecord();
        }

        /// <summary>
        /// Gets the resource Id from the supplied PowerShell parameters.
        /// </summary>
        protected string GetResourceId()
        {
#pragma warning disable 618

            return !this.TenantLevel && string.IsNullOrWhiteSpace(this.ParentResource)
                ? this.GetResourceIdWithoutParentResource()
                : this.GetResourceIdWithParentResource();

#pragma warning restore 618
        }

        /// <summary>
        /// Gets the resource Id from the supplied PowerShell parameters.
        /// </summary>
        private string GetResourceIdWithoutParentResource()
        {
            return ResourceIdUtility.GetResourceId(
                subscriptionId: this.SubscriptionId,
                resourceGroupName: this.ResourceGroupName,
                resourceType: this.ResourceType,
                resourceName: this.ResourceName,
                extensionResourceType: this.ExtensionResourceType,
                extensionResourceName: this.ExtensionResourceName);
        }

        /// <summary>
        /// Gets the resource Id using the <c>ParentResource</c>.
        /// </summary>
        private string GetResourceIdWithParentResource()
        {
#pragma warning disable 618

            return ResourceIdUtility.GetResourceId(
                subscriptionId: this.SubscriptionId.Value,
                resourceGroupName: this.ResourceGroupName,
                 parentResource: this.ParentResource,
                 resourceType: this.ResourceType,
                resourceName: this.ResourceName);

#pragma warning restore 618
        }
    }
}