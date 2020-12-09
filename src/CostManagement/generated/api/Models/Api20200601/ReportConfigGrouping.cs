namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The group by expression to be used in the report.</summary>
    public partial class ReportConfigGrouping :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGroupingInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The name of the column to group. This version supports subscription lowest possible grain.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportConfigColumnType _type;

        /// <summary>Has type of the column to group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportConfigColumnType Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ReportConfigGrouping" /> instance.</summary>
        public ReportConfigGrouping()
        {

        }
    }
    /// The group by expression to be used in the report.
    public partial interface IReportConfigGrouping :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The name of the column to group. This version supports subscription lowest possible grain.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the column to group. This version supports subscription lowest possible grain.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Has type of the column to group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Has type of the column to group.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportConfigColumnType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportConfigColumnType Type { get; set; }

    }
    /// The group by expression to be used in the report.
    public partial interface IReportConfigGroupingInternal

    {
        /// <summary>
        /// The name of the column to group. This version supports subscription lowest possible grain.
        /// </summary>
        string Name { get; set; }
        /// <summary>Has type of the column to group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportConfigColumnType Type { get; set; }

    }
}