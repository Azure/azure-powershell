// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>Replica properties of the mongo cluster.</summary>
    public partial class ReplicationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicationPropertiesInternal
    {

        /// <summary>Internal Acessors for ReplicationState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicationPropertiesInternal.ReplicationState { get => this._replicationState; set { {_replicationState = value;} } }

        /// <summary>Internal Acessors for Role</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicationPropertiesInternal.Role { get => this._role; set { {_role = value;} } }

        /// <summary>Internal Acessors for SourceResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicationPropertiesInternal.SourceResourceId { get => this._sourceResourceId; set { {_sourceResourceId = value;} } }

        /// <summary>Backing field for <see cref="ReplicationState" /> property.</summary>
        private string _replicationState;

        /// <summary>The replication link state of the replica cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string ReplicationState { get => this._replicationState; }

        /// <summary>Backing field for <see cref="Role" /> property.</summary>
        private string _role;

        /// <summary>The replication role of the cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string Role { get => this._role; }

        /// <summary>Backing field for <see cref="SourceResourceId" /> property.</summary>
        private string _sourceResourceId;

        /// <summary>The resource id the source cluster for the replica cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string SourceResourceId { get => this._sourceResourceId; }

        /// <summary>Creates an new <see cref="ReplicationProperties" /> instance.</summary>
        public ReplicationProperties()
        {

        }
    }
    /// Replica properties of the mongo cluster.
    public partial interface IReplicationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>The replication link state of the replica cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The replication link state of the replica cluster.",
        SerializedName = @"replicationState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Active", "Catchup", "Provisioning", "Updating", "Broken", "Reconfiguring")]
        string ReplicationState { get;  }
        /// <summary>The replication role of the cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The replication role of the cluster",
        SerializedName = @"role",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Primary", "AsyncReplica", "GeoAsyncReplica")]
        string Role { get;  }
        /// <summary>The resource id the source cluster for the replica cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource id the source cluster for the replica cluster.",
        SerializedName = @"sourceResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceResourceId { get;  }

    }
    /// Replica properties of the mongo cluster.
    internal partial interface IReplicationPropertiesInternal

    {
        /// <summary>The replication link state of the replica cluster.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Active", "Catchup", "Provisioning", "Updating", "Broken", "Reconfiguring")]
        string ReplicationState { get; set; }
        /// <summary>The replication role of the cluster</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Primary", "AsyncReplica", "GeoAsyncReplica")]
        string Role { get; set; }
        /// <summary>The resource id the source cluster for the replica cluster.</summary>
        string SourceResourceId { get; set; }

    }
}