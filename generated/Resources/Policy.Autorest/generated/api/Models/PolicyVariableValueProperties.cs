// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The variable value properties.</summary>
    public partial class PolicyVariableValueProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariableValueProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariableValuePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariableValueColumnValue> _value;

        /// <summary>Variable value column value array.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariableValueColumnValue> Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="PolicyVariableValueProperties" /> instance.</summary>
        public PolicyVariableValueProperties()
        {

        }
    }
    /// The variable value properties.
    public partial interface IPolicyVariableValueProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
        /// <summary>Variable value column value array.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Variable value column value array.",
        SerializedName = @"values",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariableValueColumnValue) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariableValueColumnValue> Value { get; set; }

    }
    /// The variable value properties.
    internal partial interface IPolicyVariableValuePropertiesInternal

    {
        /// <summary>Variable value column value array.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariableValueColumnValue> Value { get; set; }

    }
}