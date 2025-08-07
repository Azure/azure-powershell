// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>The type used for update operations of the FileShare.</summary>
    public partial class FileShareUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal
    {

        /// <summary>Internal Acessors for NfsProtocolProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolProperties Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal.NfsProtocolProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal)Property).NfsProtocolProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal)Property).NfsProtocolProperty = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateProperties Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareUpdateProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for PublicAccessProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPublicAccessProperties Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal.PublicAccessProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal)Property).PublicAccessProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal)Property).PublicAccessProperty = value ?? null /* model class */; }

        /// <summary>Root squash defines how root users on clients are mapped to the NFS share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public string NfProtocolPropertyRootSquash { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal)Property).NfProtocolPropertyRootSquash; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal)Property).NfProtocolPropertyRootSquash = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareUpdateProperties()); set => this._property = value; }

        /// <summary>The provisioned IO / sec of the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int? ProvisionedIoPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal)Property).ProvisionedIoPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal)Property).ProvisionedIoPerSec = value ?? default(int); }

        /// <summary>
        /// The provisioned storage size of the share in GiB (1 GiB is 1024^3 bytes or 1073741824 bytes). A component of the file
        /// share's bill is the provisioned storage, regardless of the amount of used storage.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int? ProvisionedStorageGiB { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal)Property).ProvisionedStorageGiB; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal)Property).ProvisionedStorageGiB = value ?? default(int); }

        /// <summary>The provisioned throughput / sec of the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int? ProvisionedThroughputMiBPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal)Property).ProvisionedThroughputMiBPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal)Property).ProvisionedThroughputMiBPerSec = value ?? default(int); }

        /// <summary>The allowed set of subnets when access is restricted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> PublicAccessPropertyAllowedSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal)Property).PublicAccessPropertyAllowedSubnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal)Property).PublicAccessPropertyAllowedSubnet = value ?? null /* arrayOf */; }

        /// <summary>
        /// Gets or sets allow or disallow public network access to azure managed file share
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public string PublicNetworkAccess { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal)Property).PublicNetworkAccess; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdatePropertiesInternal)Property).PublicNetworkAccess = value ?? null; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.Tags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="FileShareUpdate" /> instance.</summary>
        public FileShareUpdate()
        {

        }
    }
    /// The type used for update operations of the FileShare.
    public partial interface IFileShareUpdate :
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
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags) })]
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags Tag { get; set; }

    }
    /// The type used for update operations of the FileShare.
    internal partial interface IFileShareUpdateInternal

    {
        /// <summary>Root squash defines how root users on clients are mapped to the NFS share.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("NoRootSquash", "RootSquash", "AllSquash")]
        string NfProtocolPropertyRootSquash { get; set; }
        /// <summary>Protocol settings specific NFS.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolProperties NfsProtocolProperty { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateProperties Property { get; set; }
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
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags Tag { get; set; }

    }
}