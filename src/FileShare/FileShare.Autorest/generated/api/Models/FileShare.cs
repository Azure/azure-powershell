// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>File share resource</summary>
    public partial class FileShare :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShare,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareInternal,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITrackedResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.TrackedResource();

        /// <summary>The host name of the file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public string HostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).HostName; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).Id; }

        /// <summary>
        /// Burst IOPS are extra buffer IOPS enabling you to consume more than your provisioned IOPS for a short period of time, depending
        /// on the burst credits available for your share.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int? IncludedBurstIoPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).IncludedBurstIoPerSec; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITrackedResourceInternal)__trackedResource).Location = value ?? null; }

        /// <summary>
        /// Max burst IOPS credits shows the maximum number of burst credits the share can have at the current IOPS provisioning level.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public long? MaxBurstIoPerSecCredit { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).MaxBurstIoPerSecCredit; }

        /// <summary>The storage media tier of the file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public string MediaTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).MediaTier; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).MediaTier = value ?? null; }

        /// <summary>Internal Acessors for HostName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareInternal.HostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).HostName; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).HostName = value ?? null; }

        /// <summary>Internal Acessors for IncludedBurstIoPerSec</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareInternal.IncludedBurstIoPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).IncludedBurstIoPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).IncludedBurstIoPerSec = value ?? default(int); }

        /// <summary>Internal Acessors for MaxBurstIoPerSecCredit</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareInternal.MaxBurstIoPerSecCredit { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).MaxBurstIoPerSecCredit; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).MaxBurstIoPerSecCredit = value ?? default(long); }

        /// <summary>Internal Acessors for NfsProtocolProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolProperties Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareInternal.NfsProtocolProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).NfsProtocolProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).NfsProtocolProperty = value ?? null /* model class */; }

        /// <summary>Internal Acessors for PrivateEndpointConnection</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateEndpointConnection> Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareInternal.PrivateEndpointConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).PrivateEndpointConnection; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).PrivateEndpointConnection = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProperties Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisionedIoPerSecNextAllowedDowngrade</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareInternal.ProvisionedIoPerSecNextAllowedDowngrade { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisionedIoPerSecNextAllowedDowngrade; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisionedIoPerSecNextAllowedDowngrade = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for ProvisionedStorageNextAllowedDowngrade</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareInternal.ProvisionedStorageNextAllowedDowngrade { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisionedStorageNextAllowedDowngrade; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisionedStorageNextAllowedDowngrade = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for ProvisionedThroughputNextAllowedDowngrade</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareInternal.ProvisionedThroughputNextAllowedDowngrade { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisionedThroughputNextAllowedDowngrade; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisionedThroughputNextAllowedDowngrade = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisioningState = value ?? null; }

        /// <summary>Internal Acessors for PublicAccessProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPublicAccessProperties Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareInternal.PublicAccessProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).PublicAccessProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).PublicAccessProperty = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).Type = value ?? null; }

        /// <summary>
        /// The name of the file share as seen by the end user when mounting the share, such as in a URI or UNC format in their operating
        /// system.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public string MountName { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).MountName; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).MountName = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).Name; }

        /// <summary>Root squash defines how root users on clients are mapped to the NFS share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public string NfProtocolPropertyRootSquash { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).NfProtocolPropertyRootSquash; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).NfProtocolPropertyRootSquash = value ?? null; }

        /// <summary>The list of associated private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).PrivateEndpointConnection; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareProperties()); set => this._property = value; }

        /// <summary>The file sharing protocol for this file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public string Protocol { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).Protocol; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).Protocol = value ?? null; }

        /// <summary>The provisioned IO / sec of the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int? ProvisionedIoPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisionedIoPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisionedIoPerSec = value ?? default(int); }

        /// <summary>
        /// A date/time value that specifies when the provisioned IOPS for the file share is permitted to be reduced.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public global::System.DateTime? ProvisionedIoPerSecNextAllowedDowngrade { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisionedIoPerSecNextAllowedDowngrade; }

        /// <summary>
        /// The provisioned storage size of the share in GiB (1 GiB is 1024^3 bytes or 1073741824 bytes). A component of the file
        /// share's bill is the provisioned storage, regardless of the amount of used storage.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int? ProvisionedStorageGiB { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisionedStorageGiB; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisionedStorageGiB = value ?? default(int); }

        /// <summary>
        /// A date/time value that specifies when the provisioned storage for the file share is permitted to be reduced.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public global::System.DateTime? ProvisionedStorageNextAllowedDowngrade { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisionedStorageNextAllowedDowngrade; }

        /// <summary>The provisioned throughput / sec of the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int? ProvisionedThroughputMiBPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisionedThroughputMiBPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisionedThroughputMiBPerSec = value ?? default(int); }

        /// <summary>
        /// A date/time value that specifies when the provisioned throughput for the file share is permitted to be reduced.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public global::System.DateTime? ProvisionedThroughputNextAllowedDowngrade { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisionedThroughputNextAllowedDowngrade; }

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).ProvisioningState; }

        /// <summary>The allowed set of subnets when access is restricted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> PublicAccessPropertyAllowedSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).PublicAccessPropertyAllowedSubnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).PublicAccessPropertyAllowedSubnet = value ?? null /* arrayOf */; }

        /// <summary>
        /// Gets or sets allow or disallow public network access to azure managed file share
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public string PublicNetworkAccess { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).PublicNetworkAccess; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).PublicNetworkAccess = value ?? null; }

        /// <summary>The chosen redundancy level of the file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public string Redundancy { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).Redundancy; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)Property).Redundancy = value ?? null; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITrackedResourceInternal)__trackedResource).Tag = value ?? null /* model class */; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__trackedResource).Type; }

        /// <summary>Creates an new <see cref="FileShare" /> instance.</summary>
        public FileShare()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// File share resource
    public partial interface IFileShare :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITrackedResource
    {
        /// <summary>The host name of the file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The host name of the file share.",
        SerializedName = @"hostName",
        PossibleTypes = new [] { typeof(string) })]
        string HostName { get;  }
        /// <summary>
        /// Burst IOPS are extra buffer IOPS enabling you to consume more than your provisioned IOPS for a short period of time, depending
        /// on the burst credits available for your share.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Burst IOPS are extra buffer IOPS enabling you to consume more than your provisioned IOPS for a short period of time, depending on the burst credits available for your share.",
        SerializedName = @"includedBurstIOPerSec",
        PossibleTypes = new [] { typeof(int) })]
        int? IncludedBurstIoPerSec { get;  }
        /// <summary>
        /// Max burst IOPS credits shows the maximum number of burst credits the share can have at the current IOPS provisioning level.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Max burst IOPS credits shows the maximum number of burst credits the share can have at the current IOPS provisioning level.",
        SerializedName = @"maxBurstIOPerSecCredits",
        PossibleTypes = new [] { typeof(long) })]
        long? MaxBurstIoPerSecCredit { get;  }
        /// <summary>The storage media tier of the file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The storage media tier of the file share.",
        SerializedName = @"mediaTier",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("SSD")]
        string MediaTier { get; set; }
        /// <summary>
        /// The name of the file share as seen by the end user when mounting the share, such as in a URI or UNC format in their operating
        /// system.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The name of the file share as seen by the end user when mounting the share, such as in a URI or UNC format in their operating system.",
        SerializedName = @"mountName",
        PossibleTypes = new [] { typeof(string) })]
        string MountName { get; set; }
        /// <summary>Root squash defines how root users on clients are mapped to the NFS share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Root squash defines how root users on clients are mapped to the NFS share.",
        SerializedName = @"rootSquash",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("NoRootSquash", "RootSquash", "AllSquash")]
        string NfProtocolPropertyRootSquash { get; set; }
        /// <summary>The list of associated private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The list of associated private endpoint connections.",
        SerializedName = @"privateEndpointConnections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateEndpointConnection) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get;  }
        /// <summary>The file sharing protocol for this file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The file sharing protocol for this file share.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("NFS")]
        string Protocol { get; set; }
        /// <summary>The provisioned IO / sec of the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The provisioned IO / sec of the share.",
        SerializedName = @"provisionedIOPerSec",
        PossibleTypes = new [] { typeof(int) })]
        int? ProvisionedIoPerSec { get; set; }
        /// <summary>
        /// A date/time value that specifies when the provisioned IOPS for the file share is permitted to be reduced.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"A date/time value that specifies when the provisioned IOPS for the file share is permitted to be reduced.",
        SerializedName = @"provisionedIOPerSecNextAllowedDowngrade",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ProvisionedIoPerSecNextAllowedDowngrade { get;  }
        /// <summary>
        /// The provisioned storage size of the share in GiB (1 GiB is 1024^3 bytes or 1073741824 bytes). A component of the file
        /// share's bill is the provisioned storage, regardless of the amount of used storage.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The provisioned storage size of the share in GiB (1 GiB is 1024^3 bytes or 1073741824 bytes). A component of the file share's bill is the provisioned storage, regardless of the amount of used storage.",
        SerializedName = @"provisionedStorageGiB",
        PossibleTypes = new [] { typeof(int) })]
        int? ProvisionedStorageGiB { get; set; }
        /// <summary>
        /// A date/time value that specifies when the provisioned storage for the file share is permitted to be reduced.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"A date/time value that specifies when the provisioned storage for the file share is permitted to be reduced.",
        SerializedName = @"provisionedStorageNextAllowedDowngrade",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ProvisionedStorageNextAllowedDowngrade { get;  }
        /// <summary>The provisioned throughput / sec of the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The provisioned throughput / sec of the share.",
        SerializedName = @"provisionedThroughputMiBPerSec",
        PossibleTypes = new [] { typeof(int) })]
        int? ProvisionedThroughputMiBPerSec { get; set; }
        /// <summary>
        /// A date/time value that specifies when the provisioned throughput for the file share is permitted to be reduced.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"A date/time value that specifies when the provisioned throughput for the file share is permitted to be reduced.",
        SerializedName = @"provisionedThroughputNextAllowedDowngrade",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ProvisionedThroughputNextAllowedDowngrade { get;  }
        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The status of the last operation.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Provisioning", "Updating", "Deleting", "Accepted", "Created", "TransientFailure", "Creating", "Patching", "Posting")]
        string ProvisioningState { get;  }
        /// <summary>The allowed set of subnets when access is restricted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The allowed set of subnets when access is restricted.",
        SerializedName = @"allowedSubnets",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> PublicAccessPropertyAllowedSubnet { get; set; }
        /// <summary>
        /// Gets or sets allow or disallow public network access to azure managed file share
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Gets or sets allow or disallow public network access to azure managed file share",
        SerializedName = @"publicNetworkAccess",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string PublicNetworkAccess { get; set; }
        /// <summary>The chosen redundancy level of the file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The chosen redundancy level of the file share.",
        SerializedName = @"redundancy",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("Local", "Zone")]
        string Redundancy { get; set; }

    }
    /// File share resource
    internal partial interface IFileShareInternal :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITrackedResourceInternal
    {
        /// <summary>The host name of the file share.</summary>
        string HostName { get; set; }
        /// <summary>
        /// Burst IOPS are extra buffer IOPS enabling you to consume more than your provisioned IOPS for a short period of time, depending
        /// on the burst credits available for your share.
        /// </summary>
        int? IncludedBurstIoPerSec { get; set; }
        /// <summary>
        /// Max burst IOPS credits shows the maximum number of burst credits the share can have at the current IOPS provisioning level.
        /// </summary>
        long? MaxBurstIoPerSecCredit { get; set; }
        /// <summary>The storage media tier of the file share.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("SSD")]
        string MediaTier { get; set; }
        /// <summary>
        /// The name of the file share as seen by the end user when mounting the share, such as in a URI or UNC format in their operating
        /// system.
        /// </summary>
        string MountName { get; set; }
        /// <summary>Root squash defines how root users on clients are mapped to the NFS share.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("NoRootSquash", "RootSquash", "AllSquash")]
        string NfProtocolPropertyRootSquash { get; set; }
        /// <summary>Protocol settings specific NFS.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolProperties NfsProtocolProperty { get; set; }
        /// <summary>The list of associated private endpoint connections.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProperties Property { get; set; }
        /// <summary>The file sharing protocol for this file share.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("NFS")]
        string Protocol { get; set; }
        /// <summary>The provisioned IO / sec of the share.</summary>
        int? ProvisionedIoPerSec { get; set; }
        /// <summary>
        /// A date/time value that specifies when the provisioned IOPS for the file share is permitted to be reduced.
        /// </summary>
        global::System.DateTime? ProvisionedIoPerSecNextAllowedDowngrade { get; set; }
        /// <summary>
        /// The provisioned storage size of the share in GiB (1 GiB is 1024^3 bytes or 1073741824 bytes). A component of the file
        /// share's bill is the provisioned storage, regardless of the amount of used storage.
        /// </summary>
        int? ProvisionedStorageGiB { get; set; }
        /// <summary>
        /// A date/time value that specifies when the provisioned storage for the file share is permitted to be reduced.
        /// </summary>
        global::System.DateTime? ProvisionedStorageNextAllowedDowngrade { get; set; }
        /// <summary>The provisioned throughput / sec of the share.</summary>
        int? ProvisionedThroughputMiBPerSec { get; set; }
        /// <summary>
        /// A date/time value that specifies when the provisioned throughput for the file share is permitted to be reduced.
        /// </summary>
        global::System.DateTime? ProvisionedThroughputNextAllowedDowngrade { get; set; }
        /// <summary>The status of the last operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Provisioning", "Updating", "Deleting", "Accepted", "Created", "TransientFailure", "Creating", "Patching", "Posting")]
        string ProvisioningState { get; set; }
        /// <summary>The set of properties for control public access.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPublicAccessProperties PublicAccessProperty { get; set; }
        /// <summary>The allowed set of subnets when access is restricted.</summary>
        System.Collections.Generic.List<string> PublicAccessPropertyAllowedSubnet { get; set; }
        /// <summary>
        /// Gets or sets allow or disallow public network access to azure managed file share
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string PublicNetworkAccess { get; set; }
        /// <summary>The chosen redundancy level of the file share.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("Local", "Zone")]
        string Redundancy { get; set; }

    }
}