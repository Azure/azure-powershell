namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>The list Kusto data connection validation result.</summary>
    public partial class DataConnectionValidationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDataConnectionValidationListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDataConnectionValidationListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDataConnectionValidationResult[] _value;

        /// <summary>The list of Kusto data connection validation errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDataConnectionValidationResult[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="DataConnectionValidationListResult" /> instance.</summary>
        public DataConnectionValidationListResult()
        {

        }
    }
    /// The list Kusto data connection validation result.
    public partial interface IDataConnectionValidationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The list of Kusto data connection validation errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of Kusto data connection validation errors.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDataConnectionValidationResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDataConnectionValidationResult[] Value { get; set; }

    }
    /// The list Kusto data connection validation result.
    internal partial interface IDataConnectionValidationListResultInternal

    {
        /// <summary>The list of Kusto data connection validation errors.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDataConnectionValidationResult[] Value { get; set; }

    }
}