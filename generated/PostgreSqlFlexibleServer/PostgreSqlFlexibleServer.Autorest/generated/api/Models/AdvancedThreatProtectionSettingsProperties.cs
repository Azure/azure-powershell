// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Properties of advanced threat protection state for a server.</summary>
    public partial class AdvancedThreatProtectionSettingsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdvancedThreatProtectionSettingsProperties,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdvancedThreatProtectionSettingsPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CreationTime" /> property.</summary>
        private global::System.DateTime? _creationTime;

        /// <summary>Specifies the creation time (UTC) of the policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? CreationTime { get => this._creationTime; }

        /// <summary>Internal Acessors for CreationTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdvancedThreatProtectionSettingsPropertiesInternal.CreationTime { get => this._creationTime; set { {_creationTime = value;} } }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string _state;

        /// <summary>
        /// Specifies the state of the advanced threat protection, whether it is enabled, disabled, or a state has not been applied
        /// yet on the server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string State { get => this._state; set => this._state = value; }

        /// <summary>
        /// Creates an new <see cref="AdvancedThreatProtectionSettingsProperties" /> instance.
        /// </summary>
        public AdvancedThreatProtectionSettingsProperties()
        {

        }
    }
    /// Properties of advanced threat protection state for a server.
    public partial interface IAdvancedThreatProtectionSettingsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Specifies the creation time (UTC) of the policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Specifies the creation time (UTC) of the policy.",
        SerializedName = @"creationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreationTime { get;  }
        /// <summary>
        /// Specifies the state of the advanced threat protection, whether it is enabled, disabled, or a state has not been applied
        /// yet on the server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the state of the advanced threat protection, whether it is enabled, disabled, or a state has not been applied yet on the server.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string State { get; set; }

    }
    /// Properties of advanced threat protection state for a server.
    internal partial interface IAdvancedThreatProtectionSettingsPropertiesInternal

    {
        /// <summary>Specifies the creation time (UTC) of the policy.</summary>
        global::System.DateTime? CreationTime { get; set; }
        /// <summary>
        /// Specifies the state of the advanced threat protection, whether it is enabled, disabled, or a state has not been applied
        /// yet on the server.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string State { get; set; }

    }
}