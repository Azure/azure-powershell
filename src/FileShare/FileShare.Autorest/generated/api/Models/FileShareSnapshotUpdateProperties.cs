// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>The updatable properties of the FileShareSnapshot.</summary>
    public partial class FileShareSnapshotUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshotUpdateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshotUpdatePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Metadata" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags _metadata;

        /// <summary>The metadata</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags Metadata { get => (this._metadata = this._metadata ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.Tags()); set => this._metadata = value; }

        /// <summary>Creates an new <see cref="FileShareSnapshotUpdateProperties" /> instance.</summary>
        public FileShareSnapshotUpdateProperties()
        {

        }
    }
    /// The updatable properties of the FileShareSnapshot.
    public partial interface IFileShareSnapshotUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IJsonSerializable
    {
        /// <summary>The metadata</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The metadata",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags) })]
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags Metadata { get; set; }

    }
    /// The updatable properties of the FileShareSnapshot.
    internal partial interface IFileShareSnapshotUpdatePropertiesInternal

    {
        /// <summary>The metadata</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags Metadata { get; set; }

    }
}