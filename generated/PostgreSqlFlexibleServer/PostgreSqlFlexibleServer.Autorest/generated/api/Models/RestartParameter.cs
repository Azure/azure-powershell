// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>PostgreSQL database engine restart parameters.</summary>
    public partial class RestartParameter :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IRestartParameter,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IRestartParameterInternal
    {

        /// <summary>Backing field for <see cref="FailoverMode" /> property.</summary>
        private string _failoverMode;

        /// <summary>Failover mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string FailoverMode { get => this._failoverMode; set => this._failoverMode = value; }

        /// <summary>Backing field for <see cref="RestartWithFailover" /> property.</summary>
        private bool? _restartWithFailover;

        /// <summary>
        /// Indicates if restart the PostgreSQL database engine should failover or switch over from primary to standby. This only
        /// works if server has high availability enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public bool? RestartWithFailover { get => this._restartWithFailover; set => this._restartWithFailover = value; }

        /// <summary>Creates an new <see cref="RestartParameter" /> instance.</summary>
        public RestartParameter()
        {

        }
    }
    /// PostgreSQL database engine restart parameters.
    public partial interface IRestartParameter :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Failover mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Failover mode.",
        SerializedName = @"failoverMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("PlannedFailover", "ForcedFailover", "PlannedSwitchover", "ForcedSwitchover")]
        string FailoverMode { get; set; }
        /// <summary>
        /// Indicates if restart the PostgreSQL database engine should failover or switch over from primary to standby. This only
        /// works if server has high availability enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates if restart the PostgreSQL database engine should failover or switch over from primary to standby. This only works if server has high availability enabled.",
        SerializedName = @"restartWithFailover",
        PossibleTypes = new [] { typeof(bool) })]
        bool? RestartWithFailover { get; set; }

    }
    /// PostgreSQL database engine restart parameters.
    internal partial interface IRestartParameterInternal

    {
        /// <summary>Failover mode.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("PlannedFailover", "ForcedFailover", "PlannedSwitchover", "ForcedSwitchover")]
        string FailoverMode { get; set; }
        /// <summary>
        /// Indicates if restart the PostgreSQL database engine should failover or switch over from primary to standby. This only
        /// works if server has high availability enabled.
        /// </summary>
        bool? RestartWithFailover { get; set; }

    }
}