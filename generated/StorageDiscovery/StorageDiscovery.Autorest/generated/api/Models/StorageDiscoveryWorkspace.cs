// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Extensions;

    /// <summary>
    /// A Storage Discovery Workspace resource. This resource configures the collection of storage account metrics.
    /// </summary>
    public partial class StorageDiscoveryWorkspace :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspace,
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.TrackedResource();

        /// <summary>The description of the storage discovery workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesInternal)Property).Description = value ?? null; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).Id; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ITrackedResourceInternal)__trackedResource).Location = value ?? null; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).Type = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceProperties Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.StorageDiscoveryWorkspaceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesInternal)Property).ProvisioningState = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.StorageDiscoveryWorkspaceProperties()); set => this._property = value; }

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesInternal)Property).ProvisioningState; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>The scopes of the storage discovery workspace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope> Scope { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesInternal)Property).Scope; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesInternal)Property).Scope = value ?? null /* arrayOf */; }

        /// <summary>The storage discovery sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inlined)]
        public string Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesInternal)Property).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesInternal)Property).Sku = value ?? null; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inherited)]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ITags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ITrackedResourceInternal)__trackedResource).Tag = value ?? null /* model class */; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IResourceInternal)__trackedResource).Type; }

        /// <summary>The view level storage discovery data estate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> WorkspaceRoot { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesInternal)Property).WorkspaceRoot; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesInternal)Property).WorkspaceRoot = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="StorageDiscoveryWorkspace" /> instance.</summary>
        public StorageDiscoveryWorkspace()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// A Storage Discovery Workspace resource. This resource configures the collection of storage account metrics.
    public partial interface IStorageDiscoveryWorkspace :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ITrackedResource
    {
        /// <summary>The description of the storage discovery workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The description of the storage discovery workspace",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The status of the last operation.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get;  }
        /// <summary>The scopes of the storage discovery workspace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The scopes of the storage discovery workspace.",
        SerializedName = @"scopes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope> Scope { get; set; }
        /// <summary>The storage discovery sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The storage discovery sku",
        SerializedName = @"sku",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PSArgumentCompleterAttribute("Standard", "Free")]
        string Sku { get; set; }
        /// <summary>The view level storage discovery data estate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The view level storage discovery data estate",
        SerializedName = @"workspaceRoots",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> WorkspaceRoot { get; set; }

    }
    /// A Storage Discovery Workspace resource. This resource configures the collection of storage account metrics.
    internal partial interface IStorageDiscoveryWorkspaceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ITrackedResourceInternal
    {
        /// <summary>The description of the storage discovery workspace</summary>
        string Description { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceProperties Property { get; set; }
        /// <summary>The status of the last operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get; set; }
        /// <summary>The scopes of the storage discovery workspace.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope> Scope { get; set; }
        /// <summary>The storage discovery sku</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PSArgumentCompleterAttribute("Standard", "Free")]
        string Sku { get; set; }
        /// <summary>The view level storage discovery data estate</summary>
        System.Collections.Generic.List<string> WorkspaceRoot { get; set; }

    }
}