// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>The Azure storage blob properties.</summary>
    public partial class AzureStorageBlobStore :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IAzureStorageBlobStore,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IAzureStorageBlobStoreInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageStore" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageStore __storageStore = new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.StorageStore();

        /// <summary>The storage store kind.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Constant]
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Kind { get => "AzureStorageBlob"; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageStoreInternal)__storageStore).Kind = "AzureStorageBlob"; }

        /// <summary>Backing field for <see cref="MountProtocol" /> property.</summary>
        private string _mountProtocol;

        /// <summary>The protocol to use for mounting the storage store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string MountProtocol { get => this._mountProtocol; set => this._mountProtocol = value; }

        /// <summary>Backing field for <see cref="StorageAccountId" /> property.</summary>
        private string _storageAccountId;

        /// <summary>The associated Azure Storage Account ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string StorageAccountId { get => this._storageAccountId; set => this._storageAccountId = value; }

        /// <summary>Creates an new <see cref="AzureStorageBlobStore" /> instance.</summary>
        public AzureStorageBlobStore()
        {
            this.__storageStore.Kind = "AzureStorageBlob";
        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__storageStore), __storageStore);
            await eventListener.AssertObjectIsValid(nameof(__storageStore), __storageStore);
        }
    }
    /// The Azure storage blob properties.
    public partial interface IAzureStorageBlobStore :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageStore
    {
        /// <summary>The protocol to use for mounting the storage store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The protocol to use for mounting the storage store.",
        SerializedName = @"mountProtocol",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("NFS", "BlobfuseCaching")]
        string MountProtocol { get; set; }
        /// <summary>The associated Azure Storage Account ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The associated Azure Storage Account ID.",
        SerializedName = @"storageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountId { get; set; }

    }
    /// The Azure storage blob properties.
    internal partial interface IAzureStorageBlobStoreInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageStoreInternal
    {
        /// <summary>The protocol to use for mounting the storage store.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("NFS", "BlobfuseCaching")]
        string MountProtocol { get; set; }
        /// <summary>The associated Azure Storage Account ID.</summary>
        string StorageAccountId { get; set; }

    }
}