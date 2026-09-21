// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>An abstract representation of storage store kind.</summary>
    public partial class StorageStore :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageStore,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageStoreInternal
    {

        /// <summary>Backing field for <see cref="Kind" /> property.</summary>
        private string _kind;

        /// <summary>The storage store kind.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string Kind { get => this._kind; set => this._kind = value; }

        /// <summary>Creates an new <see cref="StorageStore" /> instance.</summary>
        public StorageStore()
        {

        }
    }
    /// An abstract representation of storage store kind.
    public partial interface IStorageStore :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable
    {
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
        string Kind { get; set; }

    }
    /// An abstract representation of storage store kind.
    internal partial interface IStorageStoreInternal

    {
        /// <summary>The storage store kind.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("AzureStorageBlob", "AzureNetAppFiles")]
        string Kind { get; set; }

    }
}