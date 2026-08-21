// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>Hardware settings resource.</summary>
    public partial class HardwareSetting :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IProxyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ProxyResource();

        /// <summary>The unique Id of the device</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string DeviceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).DeviceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).DeviceId = value ?? null; }

        /// <summary>The disk space in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public int? DiskSpaceInGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).DiskSpaceInGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).DiskSpaceInGb = value ?? default(int); }

        /// <summary>The hardware SKU</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string HardwareSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).HardwareSku; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).HardwareSku = value ?? null; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Id; }

        /// <summary>The memory in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public int? MemoryInGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).MemoryInGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).MemoryInGb = value ?? default(int); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingProperties Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.HardwareSettingProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).ProvisioningState = value ?? null; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Type = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Name; }

        /// <summary>The number of nodes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public int? Node { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).Node; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).Node = value ?? default(int); }

        /// <summary>The OEM</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string Oem { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).Oem; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).Oem = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.HardwareSettingProperties()); set => this._property = value; }

        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>The solution builder extension at registration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string SolutionBuilderExtension { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).SolutionBuilderExtension; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).SolutionBuilderExtension = value ?? null; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType; }

        /// <summary>The total number of cores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public int? TotalCore { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).TotalCore; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).TotalCore = value ?? default(int); }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Type; }

        /// <summary>The active version at registration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string VersionAtRegistration { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).VersionAtRegistration; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal)Property).VersionAtRegistration = value ?? null; }

        /// <summary>Creates an new <see cref="HardwareSetting" /> instance.</summary>
        public HardwareSetting()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyResource), __proxyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyResource), __proxyResource);
        }
    }
    /// Hardware settings resource.
    public partial interface IHardwareSetting :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IProxyResource
    {
        /// <summary>The unique Id of the device</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The unique Id of the device",
        SerializedName = @"deviceId",
        PossibleTypes = new [] { typeof(string) })]
        string DeviceId { get; set; }
        /// <summary>The disk space in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The disk space in GB",
        SerializedName = @"diskSpaceInGb",
        PossibleTypes = new [] { typeof(int) })]
        int? DiskSpaceInGb { get; set; }
        /// <summary>The hardware SKU</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The hardware SKU",
        SerializedName = @"hardwareSku",
        PossibleTypes = new [] { typeof(string) })]
        string HardwareSku { get; set; }
        /// <summary>The memory in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The memory in GB",
        SerializedName = @"memoryInGb",
        PossibleTypes = new [] { typeof(int) })]
        int? MemoryInGb { get; set; }
        /// <summary>The number of nodes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The number of nodes",
        SerializedName = @"nodes",
        PossibleTypes = new [] { typeof(int) })]
        int? Node { get; set; }
        /// <summary>The OEM</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The OEM",
        SerializedName = @"oem",
        PossibleTypes = new [] { typeof(string) })]
        string Oem { get; set; }
        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource provisioning state",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get;  }
        /// <summary>The solution builder extension at registration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The solution builder extension at registration",
        SerializedName = @"solutionBuilderExtension",
        PossibleTypes = new [] { typeof(string) })]
        string SolutionBuilderExtension { get; set; }
        /// <summary>The total number of cores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The total number of cores",
        SerializedName = @"totalCores",
        PossibleTypes = new [] { typeof(int) })]
        int? TotalCore { get; set; }
        /// <summary>The active version at registration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The active version at registration",
        SerializedName = @"versionAtRegistration",
        PossibleTypes = new [] { typeof(string) })]
        string VersionAtRegistration { get; set; }

    }
    /// Hardware settings resource.
    internal partial interface IHardwareSettingInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IProxyResourceInternal
    {
        /// <summary>The unique Id of the device</summary>
        string DeviceId { get; set; }
        /// <summary>The disk space in GB</summary>
        int? DiskSpaceInGb { get; set; }
        /// <summary>The hardware SKU</summary>
        string HardwareSku { get; set; }
        /// <summary>The memory in GB</summary>
        int? MemoryInGb { get; set; }
        /// <summary>The number of nodes</summary>
        int? Node { get; set; }
        /// <summary>The OEM</summary>
        string Oem { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingProperties Property { get; set; }
        /// <summary>The resource provisioning state</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get; set; }
        /// <summary>The solution builder extension at registration</summary>
        string SolutionBuilderExtension { get; set; }
        /// <summary>The total number of cores</summary>
        int? TotalCore { get; set; }
        /// <summary>The active version at registration</summary>
        string VersionAtRegistration { get; set; }

    }
}