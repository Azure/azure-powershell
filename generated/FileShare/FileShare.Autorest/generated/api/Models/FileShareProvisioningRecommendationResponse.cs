// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>Response structure for file share provisioning parameters recommendation API.</summary>
    public partial class FileShareProvisioningRecommendationResponse :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationResponse,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationResponseInternal
    {

        /// <summary>Redundancy options for the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> AvailableRedundancyOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationOutputInternal)Property).AvailableRedundancyOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationOutputInternal)Property).AvailableRedundancyOption = value ; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationOutput Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationResponseInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareProvisioningRecommendationOutput()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationOutput _property;

        /// <summary>The properties of the file share provisioning recommendation output.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationOutput Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareProvisioningRecommendationOutput()); set => this._property = value; }

        /// <summary>The recommended value of provisioned IO / sec of the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int ProvisionedIoPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationOutputInternal)Property).ProvisionedIoPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationOutputInternal)Property).ProvisionedIoPerSec = value ; }

        /// <summary>The recommended value of provisioned throughput / sec of the share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int ProvisionedThroughputMiBPerSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationOutputInternal)Property).ProvisionedThroughputMiBPerSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationOutputInternal)Property).ProvisionedThroughputMiBPerSec = value ; }

        /// <summary>
        /// Creates an new <see cref="FileShareProvisioningRecommendationResponse" /> instance.
        /// </summary>
        public FileShareProvisioningRecommendationResponse()
        {

        }
    }
    /// Response structure for file share provisioning parameters recommendation API.
    public partial interface IFileShareProvisioningRecommendationResponse :
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
    /// Response structure for file share provisioning parameters recommendation API.
    internal partial interface IFileShareProvisioningRecommendationResponseInternal

    {
        /// <summary>Redundancy options for the share.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("Local", "Zone")]
        System.Collections.Generic.List<string> AvailableRedundancyOption { get; set; }
        /// <summary>The properties of the file share provisioning recommendation output.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationOutput Property { get; set; }
        /// <summary>The recommended value of provisioned IO / sec of the share.</summary>
        int ProvisionedIoPerSec { get; set; }
        /// <summary>The recommended value of provisioned throughput / sec of the share.</summary>
        int ProvisionedThroughputMiBPerSec { get; set; }

    }
}