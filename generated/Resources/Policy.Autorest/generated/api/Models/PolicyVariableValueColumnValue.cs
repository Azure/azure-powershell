// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The name value tuple for this variable value column.</summary>
    public partial class PolicyVariableValueColumnValue :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariableValueColumnValue,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyVariableValueColumnValueInternal
    {

        /// <summary>Backing field for <see cref="ColumnName" /> property.</summary>
        private string _columnName;

        /// <summary>Column name for the variable value</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string ColumnName { get => this._columnName; set => this._columnName = value; }

        /// <summary>Backing field for <see cref="ColumnValue" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny _columnValue;

        /// <summary>
        /// Column value for the variable value; this can be an integer, double, boolean, null or a string.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny ColumnValue { get => (this._columnValue = this._columnValue ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Any()); set => this._columnValue = value; }

        /// <summary>Creates an new <see cref="PolicyVariableValueColumnValue" /> instance.</summary>
        public PolicyVariableValueColumnValue()
        {

        }
    }
    /// The name value tuple for this variable value column.
    public partial interface IPolicyVariableValueColumnValue :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
        /// <summary>Column name for the variable value</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Column name for the variable value",
        SerializedName = @"columnName",
        PossibleTypes = new [] { typeof(string) })]
        string ColumnName { get; set; }
        /// <summary>
        /// Column value for the variable value; this can be an integer, double, boolean, null or a string.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Column value for the variable value; this can be an integer, double, boolean, null or a string.",
        SerializedName = @"columnValue",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny ColumnValue { get; set; }

    }
    /// The name value tuple for this variable value column.
    internal partial interface IPolicyVariableValueColumnValueInternal

    {
        /// <summary>Column name for the variable value</summary>
        string ColumnName { get; set; }
        /// <summary>
        /// Column value for the variable value; this can be an integer, double, boolean, null or a string.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny ColumnValue { get; set; }

    }
}