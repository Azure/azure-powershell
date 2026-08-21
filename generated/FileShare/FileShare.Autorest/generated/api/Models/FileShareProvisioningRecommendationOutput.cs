// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>File share provisioning parameters recommendation API result.</summary>
    public partial class FileShareProvisioningRecommendationOutput :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationOutput,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationOutputInternal
    {

        /// <summary>Backing field for <see cref="AvailableRedundancyOption" /> property.</summary>
        private System.Collections.Generic.List<string> _availableRedundancyOption;

        /// <summary>Redundancy options for the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> AvailableRedundancyOption { get => this._availableRedundancyOption; set => this._availableRedundancyOption = value; }

        /// <summary>Backing field for <see cref="ProvisionedIoPerSec" /> property.</summary>
        private int _provisionedIoPerSec;

        /// <summary>The recommended value of provisioned IO / sec of the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int ProvisionedIoPerSec { get => this._provisionedIoPerSec; set => this._provisionedIoPerSec = value; }

        /// <summary>Backing field for <see cref="ProvisionedThroughputMiBPerSec" /> property.</summary>
        private int _provisionedThroughputMiBPerSec;

        /// <summary>The recommended value of provisioned throughput / sec of the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int ProvisionedThroughputMiBPerSec { get => this._provisionedThroughputMiBPerSec; set => this._provisionedThroughputMiBPerSec = value; }

        /// <summary>
        /// Creates an new <see cref="FileShareProvisioningRecommendationOutput" /> instance.
        /// </summary>
        public FileShareProvisioningRecommendationOutput()
        {

        }
    }
    /// File share provisioning parameters recommendation API result.
    public partial interface IFileShareProvisioningRecommendationOutput :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IJsonSerializable
    {
        /// <summary>Redundancy options for the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Redundancy options for the share.",
        SerializedName = @"availableRedundancyOptions",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("Local", "Zone")]
        System.Collections.Generic.List<string> AvailableRedundancyOption { get; set; }
        /// <summary>The recommended value of provisioned IO / sec of the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The recommended value of provisioned IO / sec of the share.",
        SerializedName = @"provisionedIOPerSec",
        PossibleTypes = new [] { typeof(int) })]
        int ProvisionedIoPerSec { get; set; }
        /// <summary>The recommended value of provisioned throughput / sec of the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The recommended value of provisioned throughput / sec of the share.",
        SerializedName = @"provisionedThroughputMiBPerSec",
        PossibleTypes = new [] { typeof(int) })]
        int ProvisionedThroughputMiBPerSec { get; set; }

    }
    /// File share provisioning parameters recommendation API result.
    internal partial interface IFileShareProvisioningRecommendationOutputInternal

    {
        /// <summary>Redundancy options for the share.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("Local", "Zone")]
        System.Collections.Generic.List<string> AvailableRedundancyOption { get; set; }
        /// <summary>The recommended value of provisioned IO / sec of the share.</summary>
        int ProvisionedIoPerSec { get; set; }
        /// <summary>The recommended value of provisioned throughput / sec of the share.</summary>
        int ProvisionedThroughputMiBPerSec { get; set; }

    }
}