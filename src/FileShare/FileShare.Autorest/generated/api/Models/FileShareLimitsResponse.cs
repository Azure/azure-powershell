// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>Response structure for file share limits API.</summary>
    public partial class FileShareLimitsResponse :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponse,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal
    {

        /// <summary>The maximum number of file shares that can be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMaxFileShare { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMaxFileShare; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMaxFileShare = value ; }

        /// <summary>The maximum number of private endpoint connections allowed for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMaxFileSharePrivateEndpointConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMaxFileSharePrivateEndpointConnection; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMaxFileSharePrivateEndpointConnection = value ; }

        /// <summary>The maximum number of snapshots allowed per file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMaxFileShareSnapshot { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMaxFileShareSnapshot; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMaxFileShareSnapshot = value ; }

        /// <summary>The maximum number of subnets that can be associated with a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMaxFileShareSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMaxFileShareSubnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMaxFileShareSubnet = value ; }

        /// <summary>
        /// The maximum provisioned IOPS (Input/Output Operations Per Second) for a file share.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMaxProvisionedIoPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMaxProvisionedIoPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMaxProvisionedIoPerSec = value ; }

        /// <summary>The maximum provisioned storage in GiB for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMaxProvisionedStorageGiB { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMaxProvisionedStorageGiB; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMaxProvisionedStorageGiB = value ; }

        /// <summary>The maximum provisioned throughput in MiB/s for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMaxProvisionedThroughputMiBPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMaxProvisionedThroughputMiBPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMaxProvisionedThroughputMiBPerSec = value ; }

        /// <summary>
        /// The minimum provisioned IOPS (Input/Output Operations Per Second) for a file share.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMinProvisionedIoPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMinProvisionedIoPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMinProvisionedIoPerSec = value ; }

        /// <summary>The minimum provisioned storage in GiB for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMinProvisionedStorageGiB { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMinProvisionedStorageGiB; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMinProvisionedStorageGiB = value ; }

        /// <summary>The minimum provisioned throughput in MiB/s for a file share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LimitMinProvisionedThroughputMiBPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMinProvisionedThroughputMiBPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).LimitMinProvisionedThroughputMiBPerSec = value ; }

        /// <summary>Internal Acessors for Limit</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimits Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal.Limit { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).Limit; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).Limit = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutput Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareLimitsOutput()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningConstant</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningConstants Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal.ProvisioningConstant { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).ProvisioningConstant; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).ProvisioningConstant = value ?? null /* model class */; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutput _property;

        /// <summary>The properties of the file share limits.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutput Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareLimitsOutput()); set => this._property = value; }

        /// <summary>Base IO per second.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int ProvisioningConstantBaseIoPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).ProvisioningConstantBaseIoPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).ProvisioningConstantBaseIoPerSec = value ; }

        /// <summary>Base throughput in MiB per second.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int ProvisioningConstantBaseThroughputMiBPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).ProvisioningConstantBaseThroughputMiBPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).ProvisioningConstantBaseThroughputMiBPerSec = value ; }

        /// <summary>Scalar IO per second.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public double ProvisioningConstantScalarIoPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).ProvisioningConstantScalarIoPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).ProvisioningConstantScalarIoPerSec = value ; }

        /// <summary>Scalar throughput in MiB per second.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public double ProvisioningConstantScalarThroughputMiBPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).ProvisioningConstantScalarThroughputMiBPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutputInternal)Property).ProvisioningConstantScalarThroughputMiBPerSec = value ; }

        /// <summary>Creates an new <see cref="FileShareLimitsResponse" /> instance.</summary>
        public FileShareLimitsResponse()
        {

        }
    }
    /// Response structure for file share limits API.
    public partial interface IFileShareLimitsResponse :
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
    /// Response structure for file share limits API.
    internal partial interface IFileShareLimitsResponseInternal

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
        /// <summary>The properties of the file share limits.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutput Property { get; set; }
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