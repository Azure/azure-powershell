// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>The response of a FileShareSnapshot list operation.</summary>
    public partial class FileShareSnapshotListResult :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshotListResult,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshotListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link to the next page of items</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshot> _value;

        /// <summary>The FileShareSnapshot items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshot> Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="FileShareSnapshotListResult" /> instance.</summary>
        public FileShareSnapshotListResult()
        {

        }
    }
    /// The response of a FileShareSnapshot list operation.
    public partial interface IFileShareSnapshotListResult :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IJsonSerializable
    {
        /// <summary>The link to the next page of items</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The link to the next page of items",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The FileShareSnapshot items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The FileShareSnapshot items on this page",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshot) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshot> Value { get; set; }

    }
    /// The response of a FileShareSnapshot list operation.
    internal partial interface IFileShareSnapshotListResultInternal

    {
        /// <summary>The link to the next page of items</summary>
        string NextLink { get; set; }
        /// <summary>The FileShareSnapshot items on this page</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshot> Value { get; set; }

    }
}