// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The variable properties.</summary>
    public partial class PolicyVariableProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariableProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariablePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Column" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariableColumn> _column;

        /// <summary>Variable column definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariableColumn> Column { get => this._column; set => this._column = value; }

        /// <summary>Creates an new <see cref="PolicyVariableProperties" /> instance.</summary>
        public PolicyVariableProperties()
        {

        }
    }
    /// The variable properties.
    public partial interface IPolicyVariableProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
        /// <summary>Variable column definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Variable column definitions.",
        SerializedName = @"columns",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariableColumn) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariableColumn> Column { get; set; }

    }
    /// The variable properties.
    internal partial interface IPolicyVariablePropertiesInternal

    {
        /// <summary>Variable column definitions.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariableColumn> Column { get; set; }

    }
}