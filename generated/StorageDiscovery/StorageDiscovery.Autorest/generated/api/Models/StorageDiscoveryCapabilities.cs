// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Extensions;

    /// <summary>The capabilities configured for a storage discovery workspace.</summary>
    public partial class StorageDiscoveryCapabilities :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilities,
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesInternal
    {

        /// <summary>Backing field for <see cref="AzureBlobStorage" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapability _azureBlobStorage;

        /// <summary>
        /// The Azure Blob Storage capability configuration for the storage discovery workspace.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapability AzureBlobStorage { get => (this._azureBlobStorage = this._azureBlobStorage ?? new Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.AzureBlobStorageCapability()); set => this._azureBlobStorage = value; }

        /// <summary>
        /// The prefix configurations that scope the capacity details to specific storage accounts, containers, and prefixes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfiguration> AzureBlobStoragePrefixConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityInternal)AzureBlobStorage).PrefixConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityInternal)AzureBlobStorage).PrefixConfiguration = value ?? null /* arrayOf */; }

        /// <summary>The enablement status of the capacity details capability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inlined)]
        public string CapacityDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityInternal)AzureBlobStorage).CapacityDetailStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityInternal)AzureBlobStorage).CapacityDetailStatus = value ; }

        /// <summary>Internal Acessors for AzureBlobStorage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapability Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesInternal.AzureBlobStorage { get => (this._azureBlobStorage = this._azureBlobStorage ?? new Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.AzureBlobStorageCapability()); set { {_azureBlobStorage = value;} } }

        /// <summary>Internal Acessors for AzureBlobStorageCapacityDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetails Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesInternal.AzureBlobStorageCapacityDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityInternal)AzureBlobStorage).CapacityDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityInternal)AzureBlobStorage).CapacityDetail = value ?? null /* model class */; }

        /// <summary>Creates an new <see cref="StorageDiscoveryCapabilities" /> instance.</summary>
        public StorageDiscoveryCapabilities()
        {

        }
    }
    /// The capabilities configured for a storage discovery workspace.
    public partial interface IStorageDiscoveryCapabilities :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.IJsonSerializable
    {
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
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfiguration> AzureBlobStoragePrefixConfiguration { get; set; }
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

    }
    /// The capabilities configured for a storage discovery workspace.
    internal partial interface IStorageDiscoveryCapabilitiesInternal

    {
        /// <summary>
        /// The Azure Blob Storage capability configuration for the storage discovery workspace.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapability AzureBlobStorage { get; set; }
        /// <summary>The capacity details configuration for Azure Blob Storage.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetails AzureBlobStorageCapacityDetail { get; set; }
        /// <summary>
        /// The prefix configurations that scope the capacity details to specific storage accounts, containers, and prefixes.
        /// </summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfiguration> AzureBlobStoragePrefixConfiguration { get; set; }
        /// <summary>The enablement status of the capacity details capability.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string CapacityDetailStatus { get; set; }

    }
}