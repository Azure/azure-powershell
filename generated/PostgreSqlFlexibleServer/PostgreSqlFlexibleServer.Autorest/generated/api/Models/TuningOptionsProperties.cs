// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Properties of a tuning option.</summary>
    public partial class TuningOptionsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITuningOptionsProperties,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITuningOptionsPropertiesInternal
    {

        /// <summary>Internal Acessors for State</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITuningOptionsPropertiesInternal.State { get => this._state; set { {_state = value;} } }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string _state;

        /// <summary>State of the tuning option.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string State { get => this._state; }

        /// <summary>Creates an new <see cref="TuningOptionsProperties" /> instance.</summary>
        public TuningOptionsProperties()
        {

        }
    }
    /// Properties of a tuning option.
    public partial interface ITuningOptionsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>State of the tuning option.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"State of the tuning option.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string State { get;  }

    }
    /// Properties of a tuning option.
    internal partial interface ITuningOptionsPropertiesInternal

    {
        /// <summary>State of the tuning option.</summary>
        string State { get; set; }

    }
}