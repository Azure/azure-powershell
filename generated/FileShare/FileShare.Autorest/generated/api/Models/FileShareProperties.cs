// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>File share properties</summary>
    public partial class FileShareProperties :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProperties,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal
    {

        /// <summary>Backing field for <see cref="HostName" /> property.</summary>
        private string _hostName;

        /// <summary>The host name of the file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public string HostName { get => this._hostName; }

        /// <summary>Backing field for <see cref="IncludedBurstIoPerSec" /> property.</summary>
        private int? _includedBurstIoPerSec;

        /// <summary>
        /// Burst IOPS are extra buffer IOPS enabling you to consume more than your provisioned IOPS for a short period of time, depending
        /// on the burst credits available for your share.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int? IncludedBurstIoPerSec { get => this._includedBurstIoPerSec; }

        /// <summary>Backing field for <see cref="MaxBurstIoPerSecCredit" /> property.</summary>
        private long? _maxBurstIoPerSecCredit;

        /// <summary>
        /// Max burst IOPS credits shows the maximum number of burst credits the share can have at the current IOPS provisioning level.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public long? MaxBurstIoPerSecCredit { get => this._maxBurstIoPerSecCredit; }

        /// <summary>Backing field for <see cref="MediaTier" /> property.</summary>
        private string _mediaTier;

        /// <summary>The storage media tier of the file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public string MediaTier { get => this._mediaTier; set => this._mediaTier = value; }

        /// <summary>Internal Acessors for HostName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal.HostName { get => this._hostName; set { {_hostName = value;} } }

        /// <summary>Internal Acessors for IncludedBurstIoPerSec</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal.IncludedBurstIoPerSec { get => this._includedBurstIoPerSec; set { {_includedBurstIoPerSec = value;} } }

        /// <summary>Internal Acessors for MaxBurstIoPerSecCredit</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal.MaxBurstIoPerSecCredit { get => this._maxBurstIoPerSecCredit; set { {_maxBurstIoPerSecCredit = value;} } }

        /// <summary>Internal Acessors for NfsProtocolProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolProperties Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal.NfsProtocolProperty { get => (this._nfsProtocolProperty = this._nfsProtocolProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.NfsProtocolProperties()); set { {_nfsProtocolProperty = value;} } }

        /// <summary>Internal Acessors for PrivateEndpointConnection</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateEndpointConnection> Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal.PrivateEndpointConnection { get => this._privateEndpointConnection; set { {_privateEndpointConnection = value;} } }

        /// <summary>Internal Acessors for ProvisionedIoPerSecNextAllowedDowngrade</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal.ProvisionedIoPerSecNextAllowedDowngrade { get => this._provisionedIoPerSecNextAllowedDowngrade; set { {_provisionedIoPerSecNextAllowedDowngrade = value;} } }

        /// <summary>Internal Acessors for ProvisionedStorageNextAllowedDowngrade</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal.ProvisionedStorageNextAllowedDowngrade { get => this._provisionedStorageNextAllowedDowngrade; set { {_provisionedStorageNextAllowedDowngrade = value;} } }

        /// <summary>Internal Acessors for ProvisionedThroughputNextAllowedDowngrade</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal.ProvisionedThroughputNextAllowedDowngrade { get => this._provisionedThroughputNextAllowedDowngrade; set { {_provisionedThroughputNextAllowedDowngrade = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for PublicAccessProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPublicAccessProperties Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal.PublicAccessProperty { get => (this._publicAccessProperty = this._publicAccessProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.PublicAccessProperties()); set { {_publicAccessProperty = value;} } }

        /// <summary>Backing field for <see cref="MountName" /> property.</summary>
        private string _mountName;

        /// <summary>
        /// The name of the file share as seen by the end user when mounting the share, such as in a URI or UNC format in their operating
        /// system.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public string MountName { get => this._mountName; set => this._mountName = value; }

        /// <summary>Root squash defines how root users on clients are mapped to the NFS share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public string NfProtocolPropertyRootSquash { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolPropertiesInternal)NfsProtocolProperty).RootSquash; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolPropertiesInternal)NfsProtocolProperty).RootSquash = value ?? null; }

        /// <summary>Backing field for <see cref="NfsProtocolProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolProperties _nfsProtocolProperty;

        /// <summary>Protocol settings specific NFS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolProperties NfsProtocolProperty { get => (this._nfsProtocolProperty = this._nfsProtocolProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.NfsProtocolProperties()); set => this._nfsProtocolProperty = value; }

        /// <summary>Backing field for <see cref="PrivateEndpointConnection" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateEndpointConnection> _privateEndpointConnection;

        /// <summary>The list of associated private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get => this._privateEndpointConnection; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private string _protocol;

        /// <summary>The file sharing protocol for this file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public string Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="ProvisionedIoPerSec" /> property.</summary>
        private int? _provisionedIoPerSec;

        /// <summary>The provisioned IO / sec of the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int? ProvisionedIoPerSec { get => this._provisionedIoPerSec; set => this._provisionedIoPerSec = value; }

        /// <summary>
        /// Backing field for <see cref="ProvisionedIoPerSecNextAllowedDowngrade" /> property.
        /// </summary>
        private global::System.DateTime? _provisionedIoPerSecNextAllowedDowngrade;

        /// <summary>
        /// A date/time value that specifies when the provisioned IOPS for the file share is permitted to be reduced.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public global::System.DateTime? ProvisionedIoPerSecNextAllowedDowngrade { get => this._provisionedIoPerSecNextAllowedDowngrade; }

        /// <summary>Backing field for <see cref="ProvisionedStorageGiB" /> property.</summary>
        private int? _provisionedStorageGiB;

        /// <summary>
        /// The provisioned storage size of the share in GiB (1 GiB is 1024^3 bytes or 1073741824 bytes). A component of the file
        /// share's bill is the provisioned storage, regardless of the amount of used storage.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int? ProvisionedStorageGiB { get => this._provisionedStorageGiB; set => this._provisionedStorageGiB = value; }

        /// <summary>
        /// Backing field for <see cref="ProvisionedStorageNextAllowedDowngrade" /> property.
        /// </summary>
        private global::System.DateTime? _provisionedStorageNextAllowedDowngrade;

        /// <summary>
        /// A date/time value that specifies when the provisioned storage for the file share is permitted to be reduced.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public global::System.DateTime? ProvisionedStorageNextAllowedDowngrade { get => this._provisionedStorageNextAllowedDowngrade; }

        /// <summary>Backing field for <see cref="ProvisionedThroughputMiBPerSec" /> property.</summary>
        private int? _provisionedThroughputMiBPerSec;

        /// <summary>The provisioned throughput / sec of the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int? ProvisionedThroughputMiBPerSec { get => this._provisionedThroughputMiBPerSec; set => this._provisionedThroughputMiBPerSec = value; }

        /// <summary>
        /// Backing field for <see cref="ProvisionedThroughputNextAllowedDowngrade" /> property.
        /// </summary>
        private global::System.DateTime? _provisionedThroughputNextAllowedDowngrade;

        /// <summary>
        /// A date/time value that specifies when the provisioned throughput for the file share is permitted to be reduced.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public global::System.DateTime? ProvisionedThroughputNextAllowedDowngrade { get => this._provisionedThroughputNextAllowedDowngrade; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="PublicAccessProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPublicAccessProperties _publicAccessProperty;

        /// <summary>The set of properties for control public access.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPublicAccessProperties PublicAccessProperty { get => (this._publicAccessProperty = this._publicAccessProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.PublicAccessProperties()); set => this._publicAccessProperty = value; }

        /// <summary>The allowed set of subnets when access is restricted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> PublicAccessPropertyAllowedSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPublicAccessPropertiesInternal)PublicAccessProperty).AllowedSubnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPublicAccessPropertiesInternal)PublicAccessProperty).AllowedSubnet = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="PublicNetworkAccess" /> property.</summary>
        private string _publicNetworkAccess;

        /// <summary>
        /// Gets or sets allow or disallow public network access to azure managed file share
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public string PublicNetworkAccess { get => this._publicNetworkAccess; set => this._publicNetworkAccess = value; }

        /// <summary>Backing field for <see cref="Redundancy" /> property.</summary>
        private string _redundancy;

        /// <summary>The chosen redundancy level of the file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public string Redundancy { get => this._redundancy; set => this._redundancy = value; }

        /// <summary>Creates an new <see cref="FileShareProperties" /> instance.</summary>
        public FileShareProperties()
        {

        }
    }
    /// File share properties
    public partial interface IFileShareProperties :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IJsonSerializable
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
    /// File share properties
    internal partial interface IFileSharePropertiesInternal

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