// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The hardware setting properties</summary>
    public partial class HardwareSettingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DeviceId" /> property.</summary>
        private string _deviceId;

        /// <summary>The unique Id of the device</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string DeviceId { get => this._deviceId; set => this._deviceId = value; }

        /// <summary>Backing field for <see cref="DiskSpaceInGb" /> property.</summary>
        private int _diskSpaceInGb;

        /// <summary>The disk space in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public int DiskSpaceInGb { get => this._diskSpaceInGb; set => this._diskSpaceInGb = value; }

        /// <summary>Backing field for <see cref="HardwareSku" /> property.</summary>
        private string _hardwareSku;

        /// <summary>The hardware SKU</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string HardwareSku { get => this._hardwareSku; set => this._hardwareSku = value; }

        /// <summary>Backing field for <see cref="MemoryInGb" /> property.</summary>
        private int _memoryInGb;

        /// <summary>The memory in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public int MemoryInGb { get => this._memoryInGb; set => this._memoryInGb = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="Node" /> property.</summary>
        private int _node;

        /// <summary>The number of nodes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public int Node { get => this._node; set => this._node = value; }

        /// <summary>Backing field for <see cref="Oem" /> property.</summary>
        private string _oem;

        /// <summary>The OEM</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string Oem { get => this._oem; set => this._oem = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="SolutionBuilderExtension" /> property.</summary>
        private string _solutionBuilderExtension;

        /// <summary>The solution builder extension at registration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string SolutionBuilderExtension { get => this._solutionBuilderExtension; set => this._solutionBuilderExtension = value; }

        /// <summary>Backing field for <see cref="TotalCore" /> property.</summary>
        private int _totalCore;

        /// <summary>The total number of cores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public int TotalCore { get => this._totalCore; set => this._totalCore = value; }

        /// <summary>Backing field for <see cref="VersionAtRegistration" /> property.</summary>
        private string _versionAtRegistration;

        /// <summary>The active version at registration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string VersionAtRegistration { get => this._versionAtRegistration; set => this._versionAtRegistration = value; }

        /// <summary>Creates an new <see cref="HardwareSettingProperties" /> instance.</summary>
        public HardwareSettingProperties()
        {

        }
    }
    /// The hardware setting properties
    public partial interface IHardwareSettingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IJsonSerializable
    {
        /// <summary>The unique Id of the device</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = true,
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
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The disk space in GB",
        SerializedName = @"diskSpaceInGb",
        PossibleTypes = new [] { typeof(int) })]
        int DiskSpaceInGb { get; set; }
        /// <summary>The hardware SKU</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = true,
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
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The memory in GB",
        SerializedName = @"memoryInGb",
        PossibleTypes = new [] { typeof(int) })]
        int MemoryInGb { get; set; }
        /// <summary>The number of nodes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The number of nodes",
        SerializedName = @"nodes",
        PossibleTypes = new [] { typeof(int) })]
        int Node { get; set; }
        /// <summary>The OEM</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = true,
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
        Required = true,
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
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The total number of cores",
        SerializedName = @"totalCores",
        PossibleTypes = new [] { typeof(int) })]
        int TotalCore { get; set; }
        /// <summary>The active version at registration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The active version at registration",
        SerializedName = @"versionAtRegistration",
        PossibleTypes = new [] { typeof(string) })]
        string VersionAtRegistration { get; set; }

    }
    /// The hardware setting properties
    internal partial interface IHardwareSettingPropertiesInternal

    {
        /// <summary>The unique Id of the device</summary>
        string DeviceId { get; set; }
        /// <summary>The disk space in GB</summary>
        int DiskSpaceInGb { get; set; }
        /// <summary>The hardware SKU</summary>
        string HardwareSku { get; set; }
        /// <summary>The memory in GB</summary>
        int MemoryInGb { get; set; }
        /// <summary>The number of nodes</summary>
        int Node { get; set; }
        /// <summary>The OEM</summary>
        string Oem { get; set; }
        /// <summary>The resource provisioning state</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get; set; }
        /// <summary>The solution builder extension at registration</summary>
        string SolutionBuilderExtension { get; set; }
        /// <summary>The total number of cores</summary>
        int TotalCore { get; set; }
        /// <summary>The active version at registration</summary>
        string VersionAtRegistration { get; set; }

    }
}