// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>The type used for update operations of the FileShareSnapshot.</summary>
    public partial class FileShareSnapshotUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshotUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshotUpdateInternal
    {

        /// <summary>The metadata</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags Metadata { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshotUpdatePropertiesInternal)Property).Metadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshotUpdatePropertiesInternal)Property).Metadata = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshotUpdateProperties Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshotUpdateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareSnapshotUpdateProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshotUpdateProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshotUpdateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareSnapshotUpdateProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="FileShareSnapshotUpdate" /> instance.</summary>
        public FileShareSnapshotUpdate()
        {

        }
    }
    /// The type used for update operations of the FileShareSnapshot.
    public partial interface IFileShareSnapshotUpdate :
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
    /// The type used for update operations of the FileShareSnapshot.
    internal partial interface IFileShareSnapshotUpdateInternal

    {
        /// <summary>The metadata</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags Metadata { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshotUpdateProperties Property { get; set; }

    }
}