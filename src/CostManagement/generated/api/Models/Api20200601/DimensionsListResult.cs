namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>Result of listing dimensions. It contains a list of available dimensions.</summary>
    public partial class DimensionsListResult :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionsListResult,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionsListResultInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimension[] Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionsListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimension[] _value;

        /// <summary>The list of dimensions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimension[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="DimensionsListResult" /> instance.</summary>
        public DimensionsListResult()
        {

        }
    }
    /// Result of listing dimensions. It contains a list of available dimensions.
    public partial interface IDimensionsListResult :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>The list of dimensions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The list of dimensions.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimension) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimension[] Value { get;  }

    }
    /// Result of listing dimensions. It contains a list of available dimensions.
    public partial interface IDimensionsListResultInternal

    {
        /// <summary>The list of dimensions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimension[] Value { get; set; }

    }
}