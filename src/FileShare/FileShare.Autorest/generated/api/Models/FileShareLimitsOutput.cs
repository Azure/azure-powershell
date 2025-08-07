// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>File share limits API result.</summary>
    public partial class FileShareLimitsOutput :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutput,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal
    {

        /// <summary>Backing field for <see cref="Limit" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimits _limit;

        /// <summary>The limits for the file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimits Limit { get => (this._limit = this._limit ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareLimits()); set => this._limit = value; }

        /// <summary>The maximum number of file shares that can be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMaxFileShare { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MaxFileShare; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MaxFileShare = value ; }

        /// <summary>The maximum number of private endpoint connections allowed for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMaxFileSharePrivateEndpointConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MaxFileSharePrivateEndpointConnection; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MaxFileSharePrivateEndpointConnection = value ; }

        /// <summary>The maximum number of snapshots allowed per file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMaxFileShareSnapshot { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MaxFileShareSnapshot; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MaxFileShareSnapshot = value ; }

        /// <summary>The maximum number of subnets that can be associated with a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMaxFileShareSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MaxFileShareSubnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MaxFileShareSubnet = value ; }

        /// <summary>
        /// The maximum provisioned IOPS (Input/Output Operations Per Second) for a file share.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMaxProvisionedIoPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MaxProvisionedIoPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MaxProvisionedIoPerSec = value ; }

        /// <summary>The maximum provisioned storage in GiB for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMaxProvisionedStorageGiB { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MaxProvisionedStorageGiB; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MaxProvisionedStorageGiB = value ; }

        /// <summary>The maximum provisioned throughput in MiB/s for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMaxProvisionedThroughputMiBPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MaxProvisionedThroughputMiBPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MaxProvisionedThroughputMiBPerSec = value ; }

        /// <summary>
        /// The minimum provisioned IOPS (Input/Output Operations Per Second) for a file share.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMinProvisionedIoPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MinProvisionedIoPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MinProvisionedIoPerSec = value ; }

        /// <summary>The minimum provisioned storage in GiB for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMinProvisionedStorageGiB { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MinProvisionedStorageGiB; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MinProvisionedStorageGiB = value ; }

        /// <summary>The minimum provisioned throughput in MiB/s for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMinProvisionedThroughputMiBPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MinProvisionedThroughputMiBPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)Limit).MinProvisionedThroughputMiBPerSec = value ; }

        /// <summary>Internal Acessors for Limit</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimits Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal.Limit { get => (this._limit = this._limit ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareLimits()); set { {_limit = value;} } }

        /// <summary>Internal Acessors for ProvisioningConstant</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningConstants Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal.ProvisioningConstant { get => (this._provisioningConstant = this._provisioningConstant ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareProvisioningConstants()); set { {_provisioningConstant = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningConstant" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningConstants _provisioningConstant;

        /// <summary>The provisioning constants for the file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningConstants ProvisioningConstant { get => (this._provisioningConstant = this._provisioningConstant ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareProvisioningConstants()); set => this._provisioningConstant = value; }

        /// <summary>Base IO per second.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int ProvisioningConstantBaseIoPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningConstantsInternal)ProvisioningConstant).BaseIoPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningConstantsInternal)ProvisioningConstant).BaseIoPerSec = value ; }

        /// <summary>Base throughput in MiB per second.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int ProvisioningConstantBaseThroughputMiBPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningConstantsInternal)ProvisioningConstant).BaseThroughputMiBPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningConstantsInternal)ProvisioningConstant).BaseThroughputMiBPerSec = value ; }

        /// <summary>Scalar IO per second.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public double ProvisioningConstantScalarIoPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningConstantsInternal)ProvisioningConstant).ScalarIoPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningConstantsInternal)ProvisioningConstant).ScalarIoPerSec = value ; }

        /// <summary>Scalar throughput in MiB per second.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public double ProvisioningConstantScalarThroughputMiBPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningConstantsInternal)ProvisioningConstant).ScalarThroughputMiBPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningConstantsInternal)ProvisioningConstant).ScalarThroughputMiBPerSec = value ; }

        /// <summary>Creates an new <see cref="FileShareLimitsOutput" /> instance.</summary>
        public FileShareLimitsOutput()
        {

        }
    }
    /// File share limits API result.
    public partial interface IFileShareLimitsOutput :
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
        int LimitMaxFileShare { get; set; }
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
        int LimitMaxFileSharePrivateEndpointConnection { get; set; }
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
        int LimitMaxFileShareSnapshot { get; set; }
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
        int LimitMaxFileShareSubnet { get; set; }
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
        int LimitMaxProvisionedIoPerSec { get; set; }
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
        int LimitMaxProvisionedStorageGiB { get; set; }
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
        int LimitMaxProvisionedThroughputMiBPerSec { get; set; }
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
        int LimitMinProvisionedIoPerSec { get; set; }
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
        int LimitMinProvisionedStorageGiB { get; set; }
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
        int LimitMinProvisionedThroughputMiBPerSec { get; set; }
        /// <summary>Base IO per second.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Base IO per second.",
        SerializedName = @"baseIOPerSec",
        PossibleTypes = new [] { typeof(int) })]
        int ProvisioningConstantBaseIoPerSec { get; set; }
        /// <summary>Base throughput in MiB per second.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Base throughput in MiB per second.",
        SerializedName = @"baseThroughputMiBPerSec",
        PossibleTypes = new [] { typeof(int) })]
        int ProvisioningConstantBaseThroughputMiBPerSec { get; set; }
        /// <summary>Scalar IO per second.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Scalar IO per second.",
        SerializedName = @"scalarIOPerSec",
        PossibleTypes = new [] { typeof(double) })]
        double ProvisioningConstantScalarIoPerSec { get; set; }
        /// <summary>Scalar throughput in MiB per second.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Scalar throughput in MiB per second.",
        SerializedName = @"scalarThroughputMiBPerSec",
        PossibleTypes = new [] { typeof(double) })]
        double ProvisioningConstantScalarThroughputMiBPerSec { get; set; }

    }
    /// File share limits API result.
    internal partial interface IFileShareLimitsOutputInternal

    {
        /// <summary>The limits for the file share.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimits Limit { get; set; }
        /// <summary>The maximum number of file shares that can be created.</summary>
        int LimitMaxFileShare { get; set; }
        /// <summary>The maximum number of private endpoint connections allowed for a file share.</summary>
        int LimitMaxFileSharePrivateEndpointConnection { get; set; }
        /// <summary>The maximum number of snapshots allowed per file share.</summary>
        int LimitMaxFileShareSnapshot { get; set; }
        /// <summary>The maximum number of subnets that can be associated with a file share.</summary>
        int LimitMaxFileShareSubnet { get; set; }
        /// <summary>
        /// The maximum provisioned IOPS (Input/Output Operations Per Second) for a file share.
        /// </summary>
        int LimitMaxProvisionedIoPerSec { get; set; }
        /// <summary>The maximum provisioned storage in GiB for a file share.</summary>
        int LimitMaxProvisionedStorageGiB { get; set; }
        /// <summary>The maximum provisioned throughput in MiB/s for a file share.</summary>
        int LimitMaxProvisionedThroughputMiBPerSec { get; set; }
        /// <summary>
        /// The minimum provisioned IOPS (Input/Output Operations Per Second) for a file share.
        /// </summary>
        int LimitMinProvisionedIoPerSec { get; set; }
        /// <summary>The minimum provisioned storage in GiB for a file share.</summary>
        int LimitMinProvisionedStorageGiB { get; set; }
        /// <summary>The minimum provisioned throughput in MiB/s for a file share.</summary>
        int LimitMinProvisionedThroughputMiBPerSec { get; set; }
        /// <summary>The provisioning constants for the file share.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningConstants ProvisioningConstant { get; set; }
        /// <summary>Base IO per second.</summary>
        int ProvisioningConstantBaseIoPerSec { get; set; }
        /// <summary>Base throughput in MiB per second.</summary>
        int ProvisioningConstantBaseThroughputMiBPerSec { get; set; }
        /// <summary>Scalar IO per second.</summary>
        double ProvisioningConstantScalarIoPerSec { get; set; }
        /// <summary>Scalar throughput in MiB per second.</summary>
        double ProvisioningConstantScalarThroughputMiBPerSec { get; set; }

    }
}