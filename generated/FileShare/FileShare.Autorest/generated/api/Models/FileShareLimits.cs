// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>File share-related limits in the specified subscription/location.</summary>
    public partial class FileShareLimits :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimits,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal
    {

        /// <summary>Backing field for <see cref="MaxFileShare" /> property.</summary>
        private int _maxFileShare;

        /// <summary>The maximum number of file shares that can be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int MaxFileShare { get => this._maxFileShare; set => this._maxFileShare = value; }

        /// <summary>
        /// Backing field for <see cref="MaxFileSharePrivateEndpointConnection" /> property.
        /// </summary>
        private int _maxFileSharePrivateEndpointConnection;

        /// <summary>The maximum number of private endpoint connections allowed for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int MaxFileSharePrivateEndpointConnection { get => this._maxFileSharePrivateEndpointConnection; set => this._maxFileSharePrivateEndpointConnection = value; }

        /// <summary>Backing field for <see cref="MaxFileShareSnapshot" /> property.</summary>
        private int _maxFileShareSnapshot;

        /// <summary>The maximum number of snapshots allowed per file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int MaxFileShareSnapshot { get => this._maxFileShareSnapshot; set => this._maxFileShareSnapshot = value; }

        /// <summary>Backing field for <see cref="MaxFileShareSubnet" /> property.</summary>
        private int _maxFileShareSubnet;

        /// <summary>The maximum number of subnets that can be associated with a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int MaxFileShareSubnet { get => this._maxFileShareSubnet; set => this._maxFileShareSubnet = value; }

        /// <summary>Backing field for <see cref="MaxProvisionedIoPerSec" /> property.</summary>
        private int _maxProvisionedIoPerSec;

        /// <summary>
        /// The maximum provisioned IOPS (Input/Output Operations Per Second) for a file share.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int MaxProvisionedIoPerSec { get => this._maxProvisionedIoPerSec; set => this._maxProvisionedIoPerSec = value; }

        /// <summary>Backing field for <see cref="MaxProvisionedStorageGiB" /> property.</summary>
        private int _maxProvisionedStorageGiB;

        /// <summary>The maximum provisioned storage in GiB for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int MaxProvisionedStorageGiB { get => this._maxProvisionedStorageGiB; set => this._maxProvisionedStorageGiB = value; }

        /// <summary>Backing field for <see cref="MaxProvisionedThroughputMiBPerSec" /> property.</summary>
        private int _maxProvisionedThroughputMiBPerSec;

        /// <summary>The maximum provisioned throughput in MiB/s for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int MaxProvisionedThroughputMiBPerSec { get => this._maxProvisionedThroughputMiBPerSec; set => this._maxProvisionedThroughputMiBPerSec = value; }

        /// <summary>Backing field for <see cref="MinProvisionedIoPerSec" /> property.</summary>
        private int _minProvisionedIoPerSec;

        /// <summary>
        /// The minimum provisioned IOPS (Input/Output Operations Per Second) for a file share.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int MinProvisionedIoPerSec { get => this._minProvisionedIoPerSec; set => this._minProvisionedIoPerSec = value; }

        /// <summary>Backing field for <see cref="MinProvisionedStorageGiB" /> property.</summary>
        private int _minProvisionedStorageGiB;

        /// <summary>The minimum provisioned storage in GiB for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int MinProvisionedStorageGiB { get => this._minProvisionedStorageGiB; set => this._minProvisionedStorageGiB = value; }

        /// <summary>Backing field for <see cref="MinProvisionedThroughputMiBPerSec" /> property.</summary>
        private int _minProvisionedThroughputMiBPerSec;

        /// <summary>The minimum provisioned throughput in MiB/s for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int MinProvisionedThroughputMiBPerSec { get => this._minProvisionedThroughputMiBPerSec; set => this._minProvisionedThroughputMiBPerSec = value; }

        /// <summary>Creates an new <see cref="FileShareLimits" /> instance.</summary>
        public FileShareLimits()
        {

        }
    }
    /// File share-related limits in the specified subscription/location.
    public partial interface IFileShareLimits :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IJsonSerializable
    {
        /// <summary>The maximum number of file shares that can be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum number of file shares that can be created.",
        SerializedName = @"maxFileShares",
        PossibleTypes = new [] { typeof(int) })]
        int MaxFileShare { get; set; }
        /// <summary>The maximum number of private endpoint connections allowed for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum number of private endpoint connections allowed for a file share.",
        SerializedName = @"maxFileSharePrivateEndpointConnections",
        PossibleTypes = new [] { typeof(int) })]
        int MaxFileSharePrivateEndpointConnection { get; set; }
        /// <summary>The maximum number of snapshots allowed per file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum number of snapshots allowed per file share.",
        SerializedName = @"maxFileShareSnapshots",
        PossibleTypes = new [] { typeof(int) })]
        int MaxFileShareSnapshot { get; set; }
        /// <summary>The maximum number of subnets that can be associated with a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum number of subnets that can be associated with a file share.",
        SerializedName = @"maxFileShareSubnets",
        PossibleTypes = new [] { typeof(int) })]
        int MaxFileShareSubnet { get; set; }
        /// <summary>
        /// The maximum provisioned IOPS (Input/Output Operations Per Second) for a file share.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum provisioned IOPS (Input/Output Operations Per Second) for a file share.",
        SerializedName = @"maxProvisionedIOPerSec",
        PossibleTypes = new [] { typeof(int) })]
        int MaxProvisionedIoPerSec { get; set; }
        /// <summary>The maximum provisioned storage in GiB for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum provisioned storage in GiB for a file share.",
        SerializedName = @"maxProvisionedStorageGiB",
        PossibleTypes = new [] { typeof(int) })]
        int MaxProvisionedStorageGiB { get; set; }
        /// <summary>The maximum provisioned throughput in MiB/s for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum provisioned throughput in MiB/s for a file share.",
        SerializedName = @"maxProvisionedThroughputMiBPerSec",
        PossibleTypes = new [] { typeof(int) })]
        int MaxProvisionedThroughputMiBPerSec { get; set; }
        /// <summary>
        /// The minimum provisioned IOPS (Input/Output Operations Per Second) for a file share.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The minimum provisioned IOPS (Input/Output Operations Per Second) for a file share.",
        SerializedName = @"minProvisionedIOPerSec",
        PossibleTypes = new [] { typeof(int) })]
        int MinProvisionedIoPerSec { get; set; }
        /// <summary>The minimum provisioned storage in GiB for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The minimum provisioned storage in GiB for a file share.",
        SerializedName = @"minProvisionedStorageGiB",
        PossibleTypes = new [] { typeof(int) })]
        int MinProvisionedStorageGiB { get; set; }
        /// <summary>The minimum provisioned throughput in MiB/s for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The minimum provisioned throughput in MiB/s for a file share.",
        SerializedName = @"minProvisionedThroughputMiBPerSec",
        PossibleTypes = new [] { typeof(int) })]
        int MinProvisionedThroughputMiBPerSec { get; set; }

    }
    /// File share-related limits in the specified subscription/location.
    internal partial interface IFileShareLimitsInternal

    {
        /// <summary>The maximum number of file shares that can be created.</summary>
        int MaxFileShare { get; set; }
        /// <summary>The maximum number of private endpoint connections allowed for a file share.</summary>
        int MaxFileSharePrivateEndpointConnection { get; set; }
        /// <summary>The maximum number of snapshots allowed per file share.</summary>
        int MaxFileShareSnapshot { get; set; }
        /// <summary>The maximum number of subnets that can be associated with a file share.</summary>
        int MaxFileShareSubnet { get; set; }
        /// <summary>
        /// The maximum provisioned IOPS (Input/Output Operations Per Second) for a file share.
        /// </summary>
        int MaxProvisionedIoPerSec { get; set; }
        /// <summary>The maximum provisioned storage in GiB for a file share.</summary>
        int MaxProvisionedStorageGiB { get; set; }
        /// <summary>The maximum provisioned throughput in MiB/s for a file share.</summary>
        int MaxProvisionedThroughputMiBPerSec { get; set; }
        /// <summary>
        /// The minimum provisioned IOPS (Input/Output Operations Per Second) for a file share.
        /// </summary>
        int MinProvisionedIoPerSec { get; set; }
        /// <summary>The minimum provisioned storage in GiB for a file share.</summary>
        int MinProvisionedStorageGiB { get; set; }
        /// <summary>The minimum provisioned throughput in MiB/s for a file share.</summary>
        int MinProvisionedThroughputMiBPerSec { get; set; }

    }
}