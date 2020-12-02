namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The order by expression to be used in the report.</summary>
    public partial class ReportConfigSorting :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSortingInternal
    {

        /// <summary>Backing field for <see cref="Direction" /> property.</summary>
        private string _direction;

        /// <summary>Direction of sort.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Direction { get => this._direction; set => this._direction = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the column to sort.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="ReportConfigSorting" /> instance.</summary>
        public ReportConfigSorting()
        {

        }
    }
    /// The order by expression to be used in the report.
    public partial interface IReportConfigSorting :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>Direction of sort.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Direction of sort.",
        SerializedName = @"direction",
        PossibleTypes = new [] { typeof(string) })]
        string Direction { get; set; }
        /// <summary>The name of the column to sort.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the column to sort.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// The order by expression to be used in the report.
    public partial interface IReportConfigSortingInternal

    {
        /// <summary>Direction of sort.</summary>
        string Direction { get; set; }
        /// <summary>The name of the column to sort.</summary>
        string Name { get; set; }

    }
}