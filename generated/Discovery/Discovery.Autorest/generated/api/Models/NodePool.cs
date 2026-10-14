// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>NodePool tracked resource</summary>
    public partial class NodePool :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePool,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.TrackedResource();

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Id; }

        /// <summary>
        /// The percent of disk usage before which image garbage collection is never run. This cannot be set higher than imageCacheUpperThreshold.
        /// The default is 40%
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public int? ImageCacheLowerThreshold { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).ImageCacheLowerThreshold; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).ImageCacheLowerThreshold = value ?? default(int); }

        /// <summary>
        /// The percent of disk usage after which image garbage collection is guaranteed to run. The default is 60%
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public int? ImageCacheUpperThreshold { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).ImageCacheUpperThreshold; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).ImageCacheUpperThreshold = value ?? default(int); }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Location = value ?? null; }

        /// <summary>The maximum number of nodes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public int? MaxNodeCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).MaxNodeCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).MaxNodeCount = value ?? default(int); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolProperties Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.NodePoolProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).ProvisioningState = value ?? null; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Type = value ?? null; }

        /// <summary>The minimum number of nodes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public int? MinNodeCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).MinNodeCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).MinNodeCount = value ?? default(int); }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Name; }

        /// <summary>The size of the OS disk in GB. If not specified, the default is 120 GB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public int? OSDiskSizeGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).OSDiskSizeGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).OSDiskSizeGb = value ?? default(int); }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.NodePoolProperties()); set => this._property = value; }

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>
        /// The Virtual Machine Scale Set priority. If not specified, the default is 'Regular'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ScaleSetPriority { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).ScaleSetPriority; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).ScaleSetPriority = value ?? null; }

        /// <summary>The node pool subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string SubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).SubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).SubnetId = value ?? null; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Tag = value ?? null /* model class */; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Type; }

        /// <summary>The size of the underlying Azure VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string VMSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).VMSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)Property).VMSize = value ?? null; }

        /// <summary>Creates an new <see cref="NodePool" /> instance.</summary>
        public NodePool()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// NodePool tracked resource
    public partial interface INodePool :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResource
    {
        /// <summary>
        /// The percent of disk usage before which image garbage collection is never run. This cannot be set higher than imageCacheUpperThreshold.
        /// The default is 40%
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The percent of disk usage before which image garbage collection is never run. This cannot be set higher than imageCacheUpperThreshold. The default is 40%",
        SerializedName = @"imageCacheLowerThreshold",
        PossibleTypes = new [] { typeof(int) })]
        int? ImageCacheLowerThreshold { get; set; }
        /// <summary>
        /// The percent of disk usage after which image garbage collection is guaranteed to run. The default is 60%
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The percent of disk usage after which image garbage collection is guaranteed to run. The default is 60%",
        SerializedName = @"imageCacheUpperThreshold",
        PossibleTypes = new [] { typeof(int) })]
        int? ImageCacheUpperThreshold { get; set; }
        /// <summary>The maximum number of nodes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum number of nodes.",
        SerializedName = @"maxNodeCount",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxNodeCount { get; set; }
        /// <summary>The minimum number of nodes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The minimum number of nodes.",
        SerializedName = @"minNodeCount",
        PossibleTypes = new [] { typeof(int) })]
        int? MinNodeCount { get; set; }
        /// <summary>The size of the OS disk in GB. If not specified, the default is 120 GB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The size of the OS disk in GB. If not specified, the default is 120 GB.",
        SerializedName = @"osDiskSizeGb",
        PossibleTypes = new [] { typeof(int) })]
        int? OSDiskSizeGb { get; set; }
        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The status of the last operation.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get;  }
        /// <summary>
        /// The Virtual Machine Scale Set priority. If not specified, the default is 'Regular'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The Virtual Machine Scale Set priority. If not specified, the default is 'Regular'.",
        SerializedName = @"scaleSetPriority",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Regular", "Spot")]
        string ScaleSetPriority { get; set; }
        /// <summary>The node pool subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The node pool subnet.",
        SerializedName = @"subnetId",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetId { get; set; }
        /// <summary>The size of the underlying Azure VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The size of the underlying Azure VM.",
        SerializedName = @"vmSize",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Standard_NC24ads_A100_v4", "Standard_NC48ads_A100_v4", "Standard_NC96ads_A100_v4", "Standard_NC4as_T4_v3", "Standard_NC8as_T4_v3", "Standard_NC16as_T4_v3", "Standard_NC64as_T4_v3", "Standard_NV6ads_A10_v5", "Standard_NV12ads_A10_v5", "Standard_NV24ads_A10_v5", "Standard_NV36ads_A10_v5", "Standard_NV36adms_A10_v5", "Standard_NV72ads_A10_v5", "Standard_ND40rs_v2")]
        string VMSize { get; set; }

    }
    /// NodePool tracked resource
    internal partial interface INodePoolInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal
    {
        /// <summary>
        /// The percent of disk usage before which image garbage collection is never run. This cannot be set higher than imageCacheUpperThreshold.
        /// The default is 40%
        /// </summary>
        int? ImageCacheLowerThreshold { get; set; }
        /// <summary>
        /// The percent of disk usage after which image garbage collection is guaranteed to run. The default is 60%
        /// </summary>
        int? ImageCacheUpperThreshold { get; set; }
        /// <summary>The maximum number of nodes.</summary>
        int? MaxNodeCount { get; set; }
        /// <summary>The minimum number of nodes.</summary>
        int? MinNodeCount { get; set; }
        /// <summary>The size of the OS disk in GB. If not specified, the default is 120 GB.</summary>
        int? OSDiskSizeGb { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolProperties Property { get; set; }
        /// <summary>The status of the last operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get; set; }
        /// <summary>
        /// The Virtual Machine Scale Set priority. If not specified, the default is 'Regular'.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Regular", "Spot")]
        string ScaleSetPriority { get; set; }
        /// <summary>The node pool subnet.</summary>
        string SubnetId { get; set; }
        /// <summary>The size of the underlying Azure VM.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Standard_NC24ads_A100_v4", "Standard_NC48ads_A100_v4", "Standard_NC96ads_A100_v4", "Standard_NC4as_T4_v3", "Standard_NC8as_T4_v3", "Standard_NC16as_T4_v3", "Standard_NC64as_T4_v3", "Standard_NV6ads_A10_v5", "Standard_NV12ads_A10_v5", "Standard_NV24ads_A10_v5", "Standard_NV36ads_A10_v5", "Standard_NV36adms_A10_v5", "Standard_NV72ads_A10_v5", "Standard_ND40rs_v2")]
        string VMSize { get; set; }

    }
}