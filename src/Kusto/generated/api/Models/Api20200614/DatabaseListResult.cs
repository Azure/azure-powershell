namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>The list Kusto databases operation response.</summary>
    public partial class DatabaseListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabase[] _value;

        /// <summary>The list of Kusto databases.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabase[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="DatabaseListResult" /> instance.</summary>
        public DatabaseListResult()
        {

        }
    }
    /// The list Kusto databases operation response.
    public partial interface IDatabaseListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The list of Kusto databases.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of Kusto databases.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabase) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabase[] Value { get; set; }

    }
    /// The list Kusto databases operation response.
    internal partial interface IDatabaseListResultInternal

    {
        /// <summary>The list of Kusto databases.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabase[] Value { get; set; }

    }
}