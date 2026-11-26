// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>
    /// The sharding properties of the cluster. This includes the shard count and scaling options for the cluster.
    /// </summary>
    public partial class ShardingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IShardingProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IShardingPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ShardCount" /> property.</summary>
        private int? _shardCount;

        /// <summary>Number of shards to provision on the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public int? ShardCount { get => this._shardCount; set => this._shardCount = value; }

        /// <summary>Creates an new <see cref="ShardingProperties" /> instance.</summary>
        public ShardingProperties()
        {

        }
    }
    /// The sharding properties of the cluster. This includes the shard count and scaling options for the cluster.
    public partial interface IShardingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>Number of shards to provision on the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Number of shards to provision on the cluster.",
        SerializedName = @"shardCount",
        PossibleTypes = new [] { typeof(int) })]
        int? ShardCount { get; set; }

    }
    /// The sharding properties of the cluster. This includes the shard count and scaling options for the cluster.
    internal partial interface IShardingPropertiesInternal

    {
        /// <summary>Number of shards to provision on the cluster.</summary>
        int? ShardCount { get; set; }

    }
}