namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>User-defined filters to return data which will be purged from the table.</summary>
    public partial class ComponentPurgeBodyFilters :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFilters,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFiltersInternal
    {

        /// <summary>Backing field for <see cref="Column" /> property.</summary>
        private string _column;

        /// <summary>The column of the table over which the given query should run</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Column { get => this._column; set => this._column = value; }

        /// <summary>Backing field for <see cref="Key" /> property.</summary>
        private string _key;

        /// <summary>
        /// When filtering over custom dimensions, this key will be used as the name of the custom dimension.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Key { get => this._key; set => this._key = value; }

        /// <summary>Backing field for <see cref="Operator" /> property.</summary>
        private string _operator;

        /// <summary>
        /// A query operator to evaluate over the provided column and value(s). Supported operators are ==, =~, in, in~, >, >=, <,
        /// <=, between, and have the same behavior as they would in a KQL query.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Operator { get => this._operator; set => this._operator = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>
        /// the value for the operator to function over. This can be a number (e.g., > 100), a string (timestamp >= '2017-09-01')
        /// or array of values.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ComponentPurgeBodyFilters" /> instance.</summary>
        public ComponentPurgeBodyFilters()
        {

        }
    }
    /// User-defined filters to return data which will be purged from the table.
    public partial interface IComponentPurgeBodyFilters :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The column of the table over which the given query should run</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The column of the table over which the given query should run",
        SerializedName = @"column",
        PossibleTypes = new [] { typeof(string) })]
        string Column { get; set; }
        /// <summary>
        /// When filtering over custom dimensions, this key will be used as the name of the custom dimension.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"When filtering over custom dimensions, this key will be used as the name of the custom dimension.",
        SerializedName = @"key",
        PossibleTypes = new [] { typeof(string) })]
        string Key { get; set; }
        /// <summary>
        /// A query operator to evaluate over the provided column and value(s). Supported operators are ==, =~, in, in~, >, >=, <,
        /// <=, between, and have the same behavior as they would in a KQL query.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A query operator to evaluate over the provided column and value(s). Supported operators are ==, =~, in, in~, >, >=, <, <=, between, and have the same behavior as they would in a KQL query.",
        SerializedName = @"operator",
        PossibleTypes = new [] { typeof(string) })]
        string Operator { get; set; }
        /// <summary>
        /// the value for the operator to function over. This can be a number (e.g., > 100), a string (timestamp >= '2017-09-01')
        /// or array of values.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the value for the operator to function over. This can be a number (e.g., > 100), a string (timestamp >= '2017-09-01') or array of values.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// User-defined filters to return data which will be purged from the table.
    internal partial interface IComponentPurgeBodyFiltersInternal

    {
        /// <summary>The column of the table over which the given query should run</summary>
        string Column { get; set; }
        /// <summary>
        /// When filtering over custom dimensions, this key will be used as the name of the custom dimension.
        /// </summary>
        string Key { get; set; }
        /// <summary>
        /// A query operator to evaluate over the provided column and value(s). Supported operators are ==, =~, in, in~, >, >=, <,
        /// <=, between, and have the same behavior as they would in a KQL query.
        /// </summary>
        string Operator { get; set; }
        /// <summary>
        /// the value for the operator to function over. This can be a number (e.g., > 100), a string (timestamp >= '2017-09-01')
        /// or array of values.
        /// </summary>
        string Value { get; set; }

    }
}