// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>FileShareSnapshot properties</summary>
    public partial class FileShareSnapshotProperties :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshotProperties,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshotPropertiesInternal
    {

        /// <summary>Backing field for <see cref="InitiatorId" /> property.</summary>
        private string _initiatorId;

        /// <summary>The initiator of the FileShareSnapshot. This is a user-defined value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public string InitiatorId { get => this._initiatorId; }

        /// <summary>Backing field for <see cref="Metadata" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags _metadata;

        /// <summary>The metadata</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags Metadata { get => (this._metadata = this._metadata ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.Tags()); set => this._metadata = value; }

        /// <summary>Internal Acessors for InitiatorId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshotPropertiesInternal.InitiatorId { get => this._initiatorId; set { {_initiatorId = value;} } }

        /// <summary>Internal Acessors for SnapshotTime</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareSnapshotPropertiesInternal.SnapshotTime { get => this._snapshotTime; set { {_snapshotTime = value;} } }

        /// <summary>Backing field for <see cref="SnapshotTime" /> property.</summary>
        private string _snapshotTime;

        /// <summary>The FileShareSnapshot time in UTC in string representation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public string SnapshotTime { get => this._snapshotTime; }

        /// <summary>Creates an new <see cref="FileShareSnapshotProperties" /> instance.</summary>
        public FileShareSnapshotProperties()
        {

        }
    }
    /// FileShareSnapshot properties
    public partial interface IFileShareSnapshotProperties :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IJsonSerializable
    {
        /// <summary>The initiator of the FileShareSnapshot. This is a user-defined value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The initiator of the FileShareSnapshot. This is a user-defined value.",
        SerializedName = @"initiatorId",
        PossibleTypes = new [] { typeof(string) })]
        string InitiatorId { get;  }
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
        /// <summary>The FileShareSnapshot time in UTC in string representation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The FileShareSnapshot time in UTC in string representation",
        SerializedName = @"snapshotTime",
        PossibleTypes = new [] { typeof(string) })]
        string SnapshotTime { get;  }

    }
    /// FileShareSnapshot properties
    internal partial interface IFileShareSnapshotPropertiesInternal

    {
        /// <summary>The initiator of the FileShareSnapshot. This is a user-defined value.</summary>
        string InitiatorId { get; set; }
        /// <summary>The metadata</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags Metadata { get; set; }
        /// <summary>The FileShareSnapshot time in UTC in string representation</summary>
        string SnapshotTime { get; set; }

    }
}