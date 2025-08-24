// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>
    /// Constants used for calculating recommended values of file share provisioning properties.
    /// </summary>
    public partial class FileShareProvisioningConstants :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningConstants,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningConstantsInternal
    {

        /// <summary>Backing field for <see cref="BaseIoPerSec" /> property.</summary>
        private int _baseIoPerSec;

        /// <summary>Base IO per second.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int BaseIoPerSec { get => this._baseIoPerSec; set => this._baseIoPerSec = value; }

        /// <summary>Backing field for <see cref="BaseThroughputMiBPerSec" /> property.</summary>
        private int _baseThroughputMiBPerSec;

        /// <summary>Base throughput in MiB per second.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int BaseThroughputMiBPerSec { get => this._baseThroughputMiBPerSec; set => this._baseThroughputMiBPerSec = value; }

        /// <summary>Backing field for <see cref="ScalarIoPerSec" /> property.</summary>
        private double _scalarIoPerSec;

        /// <summary>Scalar IO per second.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public double ScalarIoPerSec { get => this._scalarIoPerSec; set => this._scalarIoPerSec = value; }

        /// <summary>Backing field for <see cref="ScalarThroughputMiBPerSec" /> property.</summary>
        private double _scalarThroughputMiBPerSec;

        /// <summary>Scalar throughput in MiB per second.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public double ScalarThroughputMiBPerSec { get => this._scalarThroughputMiBPerSec; set => this._scalarThroughputMiBPerSec = value; }

        /// <summary>Creates an new <see cref="FileShareProvisioningConstants" /> instance.</summary>
        public FileShareProvisioningConstants()
        {

        }
    }
    /// Constants used for calculating recommended values of file share provisioning properties.
    public partial interface IFileShareProvisioningConstants :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IJsonSerializable
    {
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
        int BaseIoPerSec { get; set; }
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
        int BaseThroughputMiBPerSec { get; set; }
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
        double ScalarIoPerSec { get; set; }
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
        double ScalarThroughputMiBPerSec { get; set; }

    }
    /// Constants used for calculating recommended values of file share provisioning properties.
    internal partial interface IFileShareProvisioningConstantsInternal

    {
        /// <summary>Base IO per second.</summary>
        int BaseIoPerSec { get; set; }
        /// <summary>Base throughput in MiB per second.</summary>
        int BaseThroughputMiBPerSec { get; set; }
        /// <summary>Scalar IO per second.</summary>
        double ScalarIoPerSec { get; set; }
        /// <summary>Scalar throughput in MiB per second.</summary>
        double ScalarThroughputMiBPerSec { get; set; }

    }
}