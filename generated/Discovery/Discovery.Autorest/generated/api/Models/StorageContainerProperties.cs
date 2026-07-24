// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>Storage Container properties</summary>
    public partial class StorageContainerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageContainerProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageContainerPropertiesInternal
    {

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageContainerPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for StorageStore</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageStore Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageContainerPropertiesInternal.StorageStore { get => (this._storageStore = this._storageStore ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.StorageStore()); set { {_storageStore = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="StorageStore" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageStore _storageStore;

        /// <summary>Storage store properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageStore StorageStore { get => (this._storageStore = this._storageStore ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.StorageStore()); set => this._storageStore = value; }

        /// <summary>The storage store kind.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string StorageStoreKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageStoreInternal)StorageStore).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageStoreInternal)StorageStore).Kind = value ?? null; }

        /// <summary>Creates an new <see cref="StorageContainerProperties" /> instance.</summary>
        public StorageContainerProperties()
        {

        }
    }
    /// Storage Container properties
    public partial interface IStorageContainerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable
    {
        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The status of the last operation.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get;  }
        /// <summary>The storage store kind.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The storage store kind.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("AzureStorageBlob", "AzureNetAppFiles")]
        string StorageStoreKind { get; set; }

    }
    /// Storage Container properties
    internal partial interface IStorageContainerPropertiesInternal

    {
        /// <summary>The status of the last operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get; set; }
        /// <summary>Storage store properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageStore StorageStore { get; set; }
        /// <summary>The storage store kind.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("AzureStorageBlob", "AzureNetAppFiles")]
        string StorageStoreKind { get; set; }

    }
}