// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>Parameters used for restore operations</summary>
    public partial class MongoClusterRestoreParameters :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterRestoreParameters,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterRestoreParametersInternal
    {

        /// <summary>Backing field for <see cref="PointInTimeUtc" /> property.</summary>
        private global::System.DateTime? _pointInTimeUtc;

        /// <summary>UTC point in time to restore a mongo cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public global::System.DateTime? PointInTimeUtc { get => this._pointInTimeUtc; set => this._pointInTimeUtc = value; }

        /// <summary>Backing field for <see cref="SourceResourceId" /> property.</summary>
        private string _sourceResourceId;

        /// <summary>Resource ID to locate the source cluster to restore</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string SourceResourceId { get => this._sourceResourceId; set => this._sourceResourceId = value; }

        /// <summary>Creates an new <see cref="MongoClusterRestoreParameters" /> instance.</summary>
        public MongoClusterRestoreParameters()
        {

        }
    }
    /// Parameters used for restore operations
    public partial interface IMongoClusterRestoreParameters :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>UTC point in time to restore a mongo cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"UTC point in time to restore a mongo cluster",
        SerializedName = @"pointInTimeUTC",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? PointInTimeUtc { get; set; }
        /// <summary>Resource ID to locate the source cluster to restore</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Resource ID to locate the source cluster to restore",
        SerializedName = @"sourceResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceResourceId { get; set; }

    }
    /// Parameters used for restore operations
    internal partial interface IMongoClusterRestoreParametersInternal

    {
        /// <summary>UTC point in time to restore a mongo cluster</summary>
        global::System.DateTime? PointInTimeUtc { get; set; }
        /// <summary>Resource ID to locate the source cluster to restore</summary>
        string SourceResourceId { get; set; }

    }
}