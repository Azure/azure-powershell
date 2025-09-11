// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>The updatable properties of the FileShare.</summary>
    public partial class FileShareUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal
    {

        /// <summary>Internal Acessors for NfsProtocolProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolProperties Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal.NfsProtocolProperty { get => (this._nfsProtocolProperty = this._nfsProtocolProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.NfsProtocolProperties()); set { {_nfsProtocolProperty = value;} } }

        /// <summary>Internal Acessors for PublicAccessProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPublicAccessProperties Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal.PublicAccessProperty { get => (this._publicAccessProperty = this._publicAccessProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.PublicAccessProperties()); set { {_publicAccessProperty = value;} } }

        /// <summary>Root squash defines how root users on clients are mapped to the NFS share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public string NfProtocolPropertyRootSquash { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolPropertiesInternal)NfsProtocolProperty).RootSquash; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolPropertiesInternal)NfsProtocolProperty).RootSquash = value ?? null; }

        /// <summary>Backing field for <see cref="NfsProtocolProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolProperties _nfsProtocolProperty;

        /// <summary>Protocol settings specific NFS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolProperties NfsProtocolProperty { get => (this._nfsProtocolProperty = this._nfsProtocolProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.NfsProtocolProperties()); set => this._nfsProtocolProperty = value; }

        /// <summary>Backing field for <see cref="ProvisionedIoPerSec" /> property.</summary>
        private int? _provisionedIoPerSec;

        /// <summary>The provisioned IO / sec of the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int? ProvisionedIoPerSec { get => this._provisionedIoPerSec; set => this._provisionedIoPerSec = value; }

        /// <summary>Backing field for <see cref="ProvisionedStorageGiB" /> property.</summary>
        private int? _provisionedStorageGiB;

        /// <summary>
        /// The provisioned storage size of the share in GiB (1 GiB is 1024^3 bytes or 1073741824 bytes). A component of the file
        /// share's bill is the provisioned storage, regardless of the amount of used storage.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int? ProvisionedStorageGiB { get => this._provisionedStorageGiB; set => this._provisionedStorageGiB = value; }

        /// <summary>Backing field for <see cref="ProvisionedThroughputMiBPerSec" /> property.</summary>
        private int? _provisionedThroughputMiBPerSec;

        /// <summary>The provisioned throughput / sec of the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int? ProvisionedThroughputMiBPerSec { get => this._provisionedThroughputMiBPerSec; set => this._provisionedThroughputMiBPerSec = value; }

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

        /// <summary>Creates an new <see cref="FileShareUpdateProperties" /> instance.</summary>
        public FileShareUpdateProperties()
        {

        }
    }
    /// The updatable properties of the FileShare.
    public partial interface IFileShareUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IJsonSerializable
    {
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

    }
    /// The updatable properties of the FileShare.
    internal partial interface IFileShareUpdatePropertiesInternal

    {
        /// <summary>Root squash defines how root users on clients are mapped to the NFS share.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("NoRootSquash", "RootSquash", "AllSquash")]
        string NfProtocolPropertyRootSquash { get; set; }
        /// <summary>Protocol settings specific NFS.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolProperties NfsProtocolProperty { get; set; }
        /// <summary>The provisioned IO / sec of the share.</summary>
        int? ProvisionedIoPerSec { get; set; }
        /// <summary>
        /// The provisioned storage size of the share in GiB (1 GiB is 1024^3 bytes or 1073741824 bytes). A component of the file
        /// share's bill is the provisioned storage, regardless of the amount of used storage.
        /// </summary>
        int? ProvisionedStorageGiB { get; set; }
        /// <summary>The provisioned throughput / sec of the share.</summary>
        int? ProvisionedThroughputMiBPerSec { get; set; }
        /// <summary>The set of properties for control public access.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPublicAccessProperties PublicAccessProperty { get; set; }
        /// <summary>The allowed set of subnets when access is restricted.</summary>
        System.Collections.Generic.List<string> PublicAccessPropertyAllowedSubnet { get; set; }
        /// <summary>
        /// Gets or sets allow or disallow public network access to azure managed file share
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string PublicNetworkAccess { get; set; }

    }
}