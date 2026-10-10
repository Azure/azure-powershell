// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Extensions;

    /// <summary>The capabilities that can be updated for a storage discovery workspace.</summary>
    public partial class StorageDiscoveryCapabilitiesUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesUpdateInternal
    {

        /// <summary>Backing field for <see cref="AzureBlobStorage" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityUpdate _azureBlobStorage;

        /// <summary>The Azure Blob Storage capability configuration to update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityUpdate AzureBlobStorage { get => (this._azureBlobStorage = this._azureBlobStorage ?? new Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.AzureBlobStorageCapabilityUpdate()); set => this._azureBlobStorage = value; }

        /// <summary>The prefix configurations to update for Azure Blob Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfigurationUpdate> AzureBlobStoragePrefixConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityUpdateInternal)AzureBlobStorage).PrefixConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityUpdateInternal)AzureBlobStorage).PrefixConfiguration = value ?? null /* arrayOf */; }

        /// <summary>The enablement status to update for the capacity details capability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inlined)]
        public string CapacityDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityUpdateInternal)AzureBlobStorage).CapacityDetailStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityUpdateInternal)AzureBlobStorage).CapacityDetailStatus = value ?? null; }

        /// <summary>Internal Acessors for AzureBlobStorage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityUpdate Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesUpdateInternal.AzureBlobStorage { get => (this._azureBlobStorage = this._azureBlobStorage ?? new Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.AzureBlobStorageCapabilityUpdate()); set { {_azureBlobStorage = value;} } }

        /// <summary>Internal Acessors for AzureBlobStorageCapacityDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetailsUpdate Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesUpdateInternal.AzureBlobStorageCapacityDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityUpdateInternal)AzureBlobStorage).CapacityDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityUpdateInternal)AzureBlobStorage).CapacityDetail = value ?? null /* model class */; }

        /// <summary>Creates an new <see cref="StorageDiscoveryCapabilitiesUpdate" /> instance.</summary>
        public StorageDiscoveryCapabilitiesUpdate()
        {

        }
    }
    /// The capabilities that can be updated for a storage discovery workspace.
    public partial interface IStorageDiscoveryCapabilitiesUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.IJsonSerializable
    {
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
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfigurationUpdate> AzureBlobStoragePrefixConfiguration { get; set; }
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

    }
    /// The capabilities that can be updated for a storage discovery workspace.
    internal partial interface IStorageDiscoveryCapabilitiesUpdateInternal

    {
        /// <summary>The Azure Blob Storage capability configuration to update.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityUpdate AzureBlobStorage { get; set; }
        /// <summary>The capacity details configuration to update for Azure Blob Storage.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetailsUpdate AzureBlobStorageCapacityDetail { get; set; }
        /// <summary>The prefix configurations to update for Azure Blob Storage.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfigurationUpdate> AzureBlobStoragePrefixConfiguration { get; set; }
        /// <summary>The enablement status to update for the capacity details capability.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string CapacityDetailStatus { get; set; }

    }
}