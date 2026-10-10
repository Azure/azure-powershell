// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Extensions;

    /// <summary>The template for adding updateable properties.</summary>
    public partial class StorageDiscoveryWorkspacePropertiesUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdateInternal
    {

        /// <summary>The prefix configurations to update for Azure Blob Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfigurationUpdate> AzureBlobStoragePrefixConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesUpdateInternal)Capability).AzureBlobStoragePrefixConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesUpdateInternal)Capability).AzureBlobStoragePrefixConfiguration = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Capability" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesUpdate _capability;

        /// <summary>The capabilities configured for the storage discovery workspace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesUpdate Capability { get => (this._capability = this._capability ?? new Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.StorageDiscoveryCapabilitiesUpdate()); set => this._capability = value; }

        /// <summary>The enablement status to update for the capacity details capability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inlined)]
        public string CapacityDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesUpdateInternal)Capability).CapacityDetailStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesUpdateInternal)Capability).CapacityDetailStatus = value ?? null; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>The description of the storage discovery workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Internal Acessors for AzureBlobStorageCapacityDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetailsUpdate Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdateInternal.AzureBlobStorageCapacityDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesUpdateInternal)Capability).AzureBlobStorageCapacityDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesUpdateInternal)Capability).AzureBlobStorageCapacityDetail = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Capability</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesUpdate Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdateInternal.Capability { get => (this._capability = this._capability ?? new Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.StorageDiscoveryCapabilitiesUpdate()); set { {_capability = value;} } }

        /// <summary>Internal Acessors for CapabilityAzureBlobStorage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityUpdate Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdateInternal.CapabilityAzureBlobStorage { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesUpdateInternal)Capability).AzureBlobStorage; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesUpdateInternal)Capability).AzureBlobStorage = value ?? null /* model class */; }

        /// <summary>Backing field for <see cref="Scope" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope> _scope;

        /// <summary>The scopes of the storage discovery workspace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope> Scope { get => this._scope; set => this._scope = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private string _sku;

        /// <summary>The storage discovery sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        public string Sku { get => this._sku; set => this._sku = value; }

        /// <summary>Backing field for <see cref="WorkspaceRoot" /> property.</summary>
        private System.Collections.Generic.List<string> _workspaceRoot;

        /// <summary>The view level storage discovery data estate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> WorkspaceRoot { get => this._workspaceRoot; set => this._workspaceRoot = value; }

        /// <summary>
        /// Creates an new <see cref="StorageDiscoveryWorkspacePropertiesUpdate" /> instance.
        /// </summary>
        public StorageDiscoveryWorkspacePropertiesUpdate()
        {

        }
    }
    /// The template for adding updateable properties.
    public partial interface IStorageDiscoveryWorkspacePropertiesUpdate :
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
        /// <summary>The description of the storage discovery workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The description of the storage discovery workspace",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The scopes of the storage discovery workspace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The scopes of the storage discovery workspace.",
        SerializedName = @"scopes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope> Scope { get; set; }
        /// <summary>The storage discovery sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The storage discovery sku",
        SerializedName = @"sku",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PSArgumentCompleterAttribute("Standard", "Free")]
        string Sku { get; set; }
        /// <summary>The view level storage discovery data estate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The view level storage discovery data estate",
        SerializedName = @"workspaceRoots",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> WorkspaceRoot { get; set; }

    }
    /// The template for adding updateable properties.
    internal partial interface IStorageDiscoveryWorkspacePropertiesUpdateInternal

    {
        /// <summary>The capacity details configuration to update for Azure Blob Storage.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetailsUpdate AzureBlobStorageCapacityDetail { get; set; }
        /// <summary>The prefix configurations to update for Azure Blob Storage.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfigurationUpdate> AzureBlobStoragePrefixConfiguration { get; set; }
        /// <summary>The capabilities configured for the storage discovery workspace.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryCapabilitiesUpdate Capability { get; set; }
        /// <summary>The Azure Blob Storage capability configuration to update.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IAzureBlobStorageCapabilityUpdate CapabilityAzureBlobStorage { get; set; }
        /// <summary>The enablement status to update for the capacity details capability.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string CapacityDetailStatus { get; set; }
        /// <summary>The description of the storage discovery workspace</summary>
        string Description { get; set; }
        /// <summary>The scopes of the storage discovery workspace.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope> Scope { get; set; }
        /// <summary>The storage discovery sku</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PSArgumentCompleterAttribute("Standard", "Free")]
        string Sku { get; set; }
        /// <summary>The view level storage discovery data estate</summary>
        System.Collections.Generic.List<string> WorkspaceRoot { get; set; }

    }
}