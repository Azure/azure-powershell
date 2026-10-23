// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Extensions;

    /// <summary>The Azure Blob Storage capability configuration.</summary>
    public partial class AzureBlobStorageCapability :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapability,
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityInternal
    {

        /// <summary>Backing field for <see cref="CapacityDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetails _capacityDetail;

        /// <summary>The capacity details configuration for Azure Blob Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetails CapacityDetail { get => (this._capacityDetail = this._capacityDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.CapacityDetails()); set => this._capacityDetail = value; }

        /// <summary>The enablement status of the capacity details capability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inlined)]
        public string CapacityDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetailsInternal)CapacityDetail).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetailsInternal)CapacityDetail).Status = value ; }

        /// <summary>Internal Acessors for CapacityDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetails Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityInternal.CapacityDetail { get => (this._capacityDetail = this._capacityDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.CapacityDetails()); set { {_capacityDetail = value;} } }

        /// <summary>Backing field for <see cref="PrefixConfiguration" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfiguration> _prefixConfiguration;

        /// <summary>
        /// The prefix configurations that scope the capacity details to specific storage accounts, containers, and prefixes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfiguration> PrefixConfiguration { get => this._prefixConfiguration; set => this._prefixConfiguration = value; }

        /// <summary>Creates an new <see cref="AzureBlobStorageCapability" /> instance.</summary>
        public AzureBlobStorageCapability()
        {

        }
    }
    /// The Azure Blob Storage capability configuration.
    public partial interface IAzureBlobStorageCapability :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.IJsonSerializable
    {
        /// <summary>The enablement status of the capacity details capability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The enablement status of the capacity details capability.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string CapacityDetailStatus { get; set; }
        /// <summary>
        /// The prefix configurations that scope the capacity details to specific storage accounts, containers, and prefixes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The prefix configurations that scope the capacity details to specific storage accounts, containers, and prefixes.",
        SerializedName = @"prefixConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfiguration) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfiguration> PrefixConfiguration { get; set; }

    }
    /// The Azure Blob Storage capability configuration.
    internal partial interface IAzureBlobStorageCapabilityInternal

    {
        /// <summary>The capacity details configuration for Azure Blob Storage.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetails CapacityDetail { get; set; }
        /// <summary>The enablement status of the capacity details capability.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string CapacityDetailStatus { get; set; }
        /// <summary>
        /// The prefix configurations that scope the capacity details to specific storage accounts, containers, and prefixes.
        /// </summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfiguration> PrefixConfiguration { get; set; }

    }
}