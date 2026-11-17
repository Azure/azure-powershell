// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>Parameters used for replica operations.</summary>
    public partial class MongoClusterReplicaParameters :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterReplicaParameters,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterReplicaParametersInternal
    {

        /// <summary>Backing field for <see cref="SourceLocation" /> property.</summary>
        private string _sourceLocation;

        /// <summary>The location of the source cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string SourceLocation { get => this._sourceLocation; set => this._sourceLocation = value; }

        /// <summary>Backing field for <see cref="SourceResourceId" /> property.</summary>
        private string _sourceResourceId;

        /// <summary>The id of the replication source cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string SourceResourceId { get => this._sourceResourceId; set => this._sourceResourceId = value; }

        /// <summary>Creates an new <see cref="MongoClusterReplicaParameters" /> instance.</summary>
        public MongoClusterReplicaParameters()
        {

        }
    }
    /// Parameters used for replica operations.
    public partial interface IMongoClusterReplicaParameters :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>The location of the source cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The location of the source cluster",
        SerializedName = @"sourceLocation",
        PossibleTypes = new [] { typeof(string) })]
        string SourceLocation { get; set; }
        /// <summary>The id of the replication source cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The id of the replication source cluster.",
        SerializedName = @"sourceResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceResourceId { get; set; }

    }
    /// Parameters used for replica operations.
    internal partial interface IMongoClusterReplicaParametersInternal

    {
        /// <summary>The location of the source cluster</summary>
        string SourceLocation { get; set; }
        /// <summary>The id of the replication source cluster.</summary>
        string SourceResourceId { get; set; }

    }
}