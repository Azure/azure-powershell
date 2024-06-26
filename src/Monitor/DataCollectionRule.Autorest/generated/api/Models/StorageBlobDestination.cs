// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Runtime.Extensions;

    public partial class StorageBlobDestination :
        Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IStorageBlobDestination,
        Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IStorageBlobDestinationInternal
    {

        /// <summary>Backing field for <see cref="ContainerName" /> property.</summary>
        private string _containerName;

        /// <summary>The container name of the Storage Blob.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Origin(Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.PropertyOrigin.Owned)]
        public string ContainerName { get => this._containerName; set => this._containerName = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// A friendly name for the destination.
        /// This name should be unique across all destinations (regardless of type) within the data collection rule.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Origin(Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="StorageAccountResourceId" /> property.</summary>
        private string _storageAccountResourceId;

        /// <summary>The resource ID of the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Origin(Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.PropertyOrigin.Owned)]
        public string StorageAccountResourceId { get => this._storageAccountResourceId; set => this._storageAccountResourceId = value; }

        /// <summary>Creates an new <see cref="StorageBlobDestination" /> instance.</summary>
        public StorageBlobDestination()
        {

        }
    }
    public partial interface IStorageBlobDestination :
        Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Runtime.IJsonSerializable
    {
        /// <summary>The container name of the Storage Blob.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The container name of the Storage Blob.",
        SerializedName = @"containerName",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerName { get; set; }
        /// <summary>
        /// A friendly name for the destination.
        /// This name should be unique across all destinations (regardless of type) within the data collection rule.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A friendly name for the destination.
        This name should be unique across all destinations (regardless of type) within the data collection rule.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The resource ID of the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The resource ID of the storage account.",
        SerializedName = @"storageAccountResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountResourceId { get; set; }

    }
    internal partial interface IStorageBlobDestinationInternal

    {
        /// <summary>The container name of the Storage Blob.</summary>
        string ContainerName { get; set; }
        /// <summary>
        /// A friendly name for the destination.
        /// This name should be unique across all destinations (regardless of type) within the data collection rule.
        /// </summary>
        string Name { get; set; }
        /// <summary>The resource ID of the storage account.</summary>
        string StorageAccountResourceId { get; set; }

    }
}