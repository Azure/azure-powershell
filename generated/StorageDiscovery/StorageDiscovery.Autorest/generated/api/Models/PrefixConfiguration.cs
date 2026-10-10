// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Extensions;

    /// <summary>
    /// A prefix configuration that scopes capacity details to a specific storage account, container, and prefix.
    /// </summary>
    public partial class PrefixConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IPrefixConfigurationInternal
    {

        /// <summary>Backing field for <see cref="ContainerName" /> property.</summary>
        private string _containerName;

        /// <summary>The name of the blob container within the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        public string ContainerName { get => this._containerName; set => this._containerName = value; }

        /// <summary>Backing field for <see cref="Prefix" /> property.</summary>
        private string _prefix;

        /// <summary>
        /// The blob prefix within the container to scope capacity details to. An empty value scopes to the entire container. Must
        /// not start with a '/'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        public string Prefix { get => this._prefix; set => this._prefix = value; }

        /// <summary>Backing field for <see cref="StorageAccountName" /> property.</summary>
        private string _storageAccountName;

        /// <summary>The name of the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        public string StorageAccountName { get => this._storageAccountName; set => this._storageAccountName = value; }

        /// <summary>Creates an new <see cref="PrefixConfiguration" /> instance.</summary>
        public PrefixConfiguration()
        {

        }
    }
    /// A prefix configuration that scopes capacity details to a specific storage account, container, and prefix.
    public partial interface IPrefixConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.IJsonSerializable
    {
        /// <summary>The name of the blob container within the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the blob container within the storage account.",
        SerializedName = @"containerName",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerName { get; set; }
        /// <summary>
        /// The blob prefix within the container to scope capacity details to. An empty value scopes to the entire container. Must
        /// not start with a '/'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The blob prefix within the container to scope capacity details to. An empty value scopes to the entire container. Must not start with a '/'.",
        SerializedName = @"prefix",
        PossibleTypes = new [] { typeof(string) })]
        string Prefix { get; set; }
        /// <summary>The name of the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the storage account.",
        SerializedName = @"storageAccountName",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountName { get; set; }

    }
    /// A prefix configuration that scopes capacity details to a specific storage account, container, and prefix.
    internal partial interface IPrefixConfigurationInternal

    {
        /// <summary>The name of the blob container within the storage account.</summary>
        string ContainerName { get; set; }
        /// <summary>
        /// The blob prefix within the container to scope capacity details to. An empty value scopes to the entire container. Must
        /// not start with a '/'.
        /// </summary>
        string Prefix { get; set; }
        /// <summary>The name of the storage account.</summary>
        string StorageAccountName { get; set; }

    }
}