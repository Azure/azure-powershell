namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>Result of listing the execution history of an export.</summary>
    public partial class ExportExecutionListResult :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResult,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResultInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] _value;

        /// <summary>A list of export executions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="ExportExecutionListResult" /> instance.</summary>
        public ExportExecutionListResult()
        {

        }
    }
    /// Result of listing the execution history of an export.
    public partial interface IExportExecutionListResult :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>A list of export executions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of export executions.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] Value { get;  }

    }
    /// Result of listing the execution history of an export.
    public partial interface IExportExecutionListResultInternal

    {
        /// <summary>A list of export executions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] Value { get; set; }

    }
}