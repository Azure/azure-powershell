// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The variable column.</summary>
    public partial class PolicyVariableColumn :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariableColumn,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariableColumnInternal
    {

        /// <summary>Backing field for <see cref="ColumnName" /> property.</summary>
        private string _columnName;

        /// <summary>The name of this policy variable column.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string ColumnName { get => this._columnName; set => this._columnName = value; }

        /// <summary>Creates an new <see cref="PolicyVariableColumn" /> instance.</summary>
        public PolicyVariableColumn()
        {

        }
    }
    /// The variable column.
    public partial interface IPolicyVariableColumn :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
        /// <summary>The name of this policy variable column.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of this policy variable column.",
        SerializedName = @"columnName",
        PossibleTypes = new [] { typeof(string) })]
        string ColumnName { get; set; }

    }
    /// The variable column.
    internal partial interface IPolicyVariableColumnInternal

    {
        /// <summary>The name of this policy variable column.</summary>
        string ColumnName { get; set; }

    }
}