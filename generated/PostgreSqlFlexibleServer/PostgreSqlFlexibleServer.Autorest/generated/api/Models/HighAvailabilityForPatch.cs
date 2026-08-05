// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>High availability properties of a server.</summary>
    public partial class HighAvailabilityForPatch :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailabilityForPatch,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailabilityForPatchInternal
    {

        /// <summary>Internal Acessors for State</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailabilityForPatchInternal.State { get => this._state; set { {_state = value;} } }

        /// <summary>Backing field for <see cref="Mode" /> property.</summary>
        private string _mode;

        /// <summary>High availability mode for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Mode { get => this._mode; set => this._mode = value; }

        /// <summary>Backing field for <see cref="StandbyAvailabilityZone" /> property.</summary>
        private string _standbyAvailabilityZone;

        /// <summary>
        /// Availability zone associated to the standby server created when high availability is set to SameZone or ZoneRedundant.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string StandbyAvailabilityZone { get => this._standbyAvailabilityZone; set => this._standbyAvailabilityZone = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string _state;

        /// <summary>
        /// Possible states of the standby server created when high availability is set to SameZone or ZoneRedundant.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string State { get => this._state; }

        /// <summary>Creates an new <see cref="HighAvailabilityForPatch" /> instance.</summary>
        public HighAvailabilityForPatch()
        {

        }
    }
    /// High availability properties of a server.
    public partial interface IHighAvailabilityForPatch :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>High availability mode for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"High availability mode for a server.",
        SerializedName = @"mode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Disabled", "ZoneRedundant", "SameZone")]
        string Mode { get; set; }
        /// <summary>
        /// Availability zone associated to the standby server created when high availability is set to SameZone or ZoneRedundant.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Availability zone associated to the standby server created when high availability is set to SameZone or ZoneRedundant.",
        SerializedName = @"standbyAvailabilityZone",
        PossibleTypes = new [] { typeof(string) })]
        string StandbyAvailabilityZone { get; set; }
        /// <summary>
        /// Possible states of the standby server created when high availability is set to SameZone or ZoneRedundant.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Possible states of the standby server created when high availability is set to SameZone or ZoneRedundant.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("NotEnabled", "CreatingStandby", "ReplicatingData", "FailingOver", "Healthy", "RemovingStandby", "RecreatingStandby", "ComputeUpdatingByFailover")]
        string State { get;  }

    }
    /// High availability properties of a server.
    internal partial interface IHighAvailabilityForPatchInternal

    {
        /// <summary>High availability mode for a server.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Disabled", "ZoneRedundant", "SameZone")]
        string Mode { get; set; }
        /// <summary>
        /// Availability zone associated to the standby server created when high availability is set to SameZone or ZoneRedundant.
        /// </summary>
        string StandbyAvailabilityZone { get; set; }
        /// <summary>
        /// Possible states of the standby server created when high availability is set to SameZone or ZoneRedundant.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("NotEnabled", "CreatingStandby", "ReplicatingData", "FailingOver", "Healthy", "RemovingStandby", "RecreatingStandby", "ComputeUpdatingByFailover")]
        string State { get; set; }

    }
}