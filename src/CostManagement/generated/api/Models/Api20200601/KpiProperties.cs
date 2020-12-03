namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>Each KPI must contain a 'type' and 'enabled' key.</summary>
    public partial class KpiProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IKpiProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IKpiPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool? _enabled;

        /// <summary>show the KPI in the UI?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public bool? Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>ID of resource related to metric (budget).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.KpiType? _type;

        /// <summary>KPI type (Forecast, Budget).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.KpiType? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="KpiProperties" /> instance.</summary>
        public KpiProperties()
        {

        }
    }
    /// Each KPI must contain a 'type' and 'enabled' key.
    public partial interface IKpiProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>show the KPI in the UI?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"show the KPI in the UI?",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Enabled { get; set; }
        /// <summary>ID of resource related to metric (budget).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ID of resource related to metric (budget).",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>KPI type (Forecast, Budget).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"KPI type (Forecast, Budget).",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.KpiType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.KpiType? Type { get; set; }

    }
    /// Each KPI must contain a 'type' and 'enabled' key.
    public partial interface IKpiPropertiesInternal

    {
        /// <summary>show the KPI in the UI?</summary>
        bool? Enabled { get; set; }
        /// <summary>ID of resource related to metric (budget).</summary>
        string Id { get; set; }
        /// <summary>KPI type (Forecast, Budget).</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.KpiType? Type { get; set; }

    }
}