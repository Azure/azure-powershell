namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>
    /// Result of listing exports. It contains a list of available exports in the scope provided.
    /// </summary>
    public partial class ExportListResult :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportListResult,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportListResultInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExport[] Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExport[] _value;

        /// <summary>The list of exports.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExport[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="ExportListResult" /> instance.</summary>
        public ExportListResult()
        {

        }
    }
    /// Result of listing exports. It contains a list of available exports in the scope provided.
    public partial interface IExportListResult :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>The list of exports.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The list of exports.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExport) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExport[] Value { get;  }

    }
    /// Result of listing exports. It contains a list of available exports in the scope provided.
    public partial interface IExportListResultInternal

    {
        /// <summary>The list of exports.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExport[] Value { get; set; }

    }
}