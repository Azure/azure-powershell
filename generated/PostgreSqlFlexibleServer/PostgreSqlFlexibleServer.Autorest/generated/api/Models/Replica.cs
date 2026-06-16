// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Replica properties of a server.</summary>
    public partial class Replica :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplica,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplicaInternal
    {

        /// <summary>Backing field for <see cref="Capacity" /> property.</summary>
        private int? _capacity;

        /// <summary>Maximum number of read replicas allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? Capacity { get => this._capacity; }

        /// <summary>Internal Acessors for Capacity</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplicaInternal.Capacity { get => this._capacity; set { {_capacity = value;} } }

        /// <summary>Internal Acessors for TionState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplicaInternal.TionState { get => this._tionState; set { {_tionState = value;} } }

        /// <summary>Backing field for <see cref="PromoteMode" /> property.</summary>
        private string _promoteMode;

        /// <summary>
        /// Type of operation to apply on the read replica. This property is write only. Standalone means that the read replica will
        /// be promoted to a standalone server, and will become a completely independent entity from the replication set. Switchover
        /// means that the read replica will roles with the primary server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string PromoteMode { get => this._promoteMode; set => this._promoteMode = value; }

        /// <summary>Backing field for <see cref="PromoteOption" /> property.</summary>
        private string _promoteOption;

        /// <summary>
        /// Data synchronization option to use when processing the operation specified in the promoteMode property. This property
        /// is write only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string PromoteOption { get => this._promoteOption; set => this._promoteOption = value; }

        /// <summary>Backing field for <see cref="Role" /> property.</summary>
        private string _role;

        /// <summary>Role of the server in a replication set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Role { get => this._role; set => this._role = value; }

        /// <summary>Backing field for <see cref="TionState" /> property.</summary>
        private string _tionState;

        /// <summary>
        /// Indicates the replication state of a read replica. This property is returned only when the target server is a read replica.
        /// Possible values are Active, Broken, Catchup, Provisioning, Reconfiguring, and Updating
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string TionState { get => this._tionState; }

        /// <summary>Creates an new <see cref="Replica" /> instance.</summary>
        public Replica()
        {

        }
    }
    /// Replica properties of a server.
    public partial interface IReplica :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Maximum number of read replicas allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Maximum number of read replicas allowed for a server.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? Capacity { get;  }
        /// <summary>
        /// Type of operation to apply on the read replica. This property is write only. Standalone means that the read replica will
        /// be promoted to a standalone server, and will become a completely independent entity from the replication set. Switchover
        /// means that the read replica will roles with the primary server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = false,
        Update = true,
        Description = @"Type of operation to apply on the read replica. This property is write only. Standalone means that the read replica will be promoted to a standalone server, and will become a completely independent entity from the replication set. Switchover means that the read replica will roles with the primary server.",
        SerializedName = @"promoteMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Standalone", "Switchover")]
        string PromoteMode { get; set; }
        /// <summary>
        /// Data synchronization option to use when processing the operation specified in the promoteMode property. This property
        /// is write only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = false,
        Update = true,
        Description = @"Data synchronization option to use when processing the operation specified in the promoteMode property. This property is write only.",
        SerializedName = @"promoteOption",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Planned", "Forced")]
        string PromoteOption { get; set; }
        /// <summary>Role of the server in a replication set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Role of the server in a replication set.",
        SerializedName = @"role",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("None", "Primary", "AsyncReplica", "GeoAsyncReplica")]
        string Role { get; set; }
        /// <summary>
        /// Indicates the replication state of a read replica. This property is returned only when the target server is a read replica.
        /// Possible values are Active, Broken, Catchup, Provisioning, Reconfiguring, and Updating
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates the replication state of a read replica. This property is returned only when the target server is a read replica. Possible  values are Active, Broken, Catchup, Provisioning, Reconfiguring, and Updating",
        SerializedName = @"replicationState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Active", "Catchup", "Provisioning", "Updating", "Broken", "Reconfiguring")]
        string TionState { get;  }

    }
    /// Replica properties of a server.
    internal partial interface IReplicaInternal

    {
        /// <summary>Maximum number of read replicas allowed for a server.</summary>
        int? Capacity { get; set; }
        /// <summary>
        /// Type of operation to apply on the read replica. This property is write only. Standalone means that the read replica will
        /// be promoted to a standalone server, and will become a completely independent entity from the replication set. Switchover
        /// means that the read replica will roles with the primary server.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Standalone", "Switchover")]
        string PromoteMode { get; set; }
        /// <summary>
        /// Data synchronization option to use when processing the operation specified in the promoteMode property. This property
        /// is write only.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Planned", "Forced")]
        string PromoteOption { get; set; }
        /// <summary>Role of the server in a replication set.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("None", "Primary", "AsyncReplica", "GeoAsyncReplica")]
        string Role { get; set; }
        /// <summary>
        /// Indicates the replication state of a read replica. This property is returned only when the target server is a read replica.
        /// Possible values are Active, Broken, Catchup, Provisioning, Reconfiguring, and Updating
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Active", "Catchup", "Provisioning", "Updating", "Broken", "Reconfiguring")]
        string TionState { get; set; }

    }
}