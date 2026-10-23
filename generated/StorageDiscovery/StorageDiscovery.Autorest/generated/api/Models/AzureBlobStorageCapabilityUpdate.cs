// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Extensions;

    /// <summary>The Azure Blob Storage capability configuration that can be updated.</summary>
    public partial class AzureBlobStorageCapabilityUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityUpdateInternal
    {

        /// <summary>Backing field for <see cref="CapacityDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetailsUpdate _capacityDetail;

        /// <summary>The capacity details configuration to update for Azure Blob Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetailsUpdate CapacityDetail { get => (this._capacityDetail = this._capacityDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.CapacityDetailsUpdate()); set => this._capacityDetail = value; }

        /// <summary>The enablement status to update for the capacity details capability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inlined)]
        public string CapacityDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetailsUpdateInternal)CapacityDetail).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetailsUpdateInternal)CapacityDetail).Status = value ?? null; }

        /// <summary>Internal Acessors for CapacityDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetailsUpdate Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityUpdateInternal.CapacityDetail { get => (this._capacityDetail = this._capacityDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.CapacityDetailsUpdate()); set { {_capacityDetail = value;} } }

        /// <summary>Backing field for <see cref="PrefixConfiguration" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfigurationUpdate> _prefixConfiguration;

        /// <summary>The prefix configurations to update for Azure Blob Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfigurationUpdate> PrefixConfiguration { get => this._prefixConfiguration; set => this._prefixConfiguration = value; }

        /// <summary>Creates an new <see cref="AzureBlobStorageCapabilityUpdate" /> instance.</summary>
        public AzureBlobStorageCapabilityUpdate()
        {

        }
    }
    /// The Azure Blob Storage capability configuration that can be updated.
    public partial interface IAzureBlobStorageCapabilityUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.IJsonSerializable
    {
        /// <summary>The enablement status to update for the capacity details capability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The enablement status to update for the capacity details capability.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string CapacityDetailStatus { get; set; }
        /// <summary>The prefix configurations to update for Azure Blob Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The prefix configurations to update for Azure Blob Storage.",
        SerializedName = @"prefixConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfigurationUpdate) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfigurationUpdate> PrefixConfiguration { get; set; }

    }
    /// The Azure Blob Storage capability configuration that can be updated.
    internal partial interface IAzureBlobStorageCapabilityUpdateInternal

    {
        /// <summary>The capacity details configuration to update for Azure Blob Storage.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetailsUpdate CapacityDetail { get; set; }
        /// <summary>The enablement status to update for the capacity details capability.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string CapacityDetailStatus { get; set; }
        /// <summary>The prefix configurations to update for Azure Blob Storage.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfigurationUpdate> PrefixConfiguration { get; set; }

    }
}