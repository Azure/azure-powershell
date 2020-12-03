namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>defines the type of alert</summary>
    public partial class AlertPropertiesDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDefinitionInternal
    {

        /// <summary>Backing field for <see cref="Category" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory? _category;

        /// <summary>Alert category</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory? Category { get => this._category; set => this._category = value; }

        /// <summary>Backing field for <see cref="Criterion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria? _criterion;

        /// <summary>Criteria that triggered alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria? Criterion { get => this._criterion; set => this._criterion = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType? _type;

        /// <summary>type of alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="AlertPropertiesDefinition" /> instance.</summary>
        public AlertPropertiesDefinition()
        {

        }
    }
    /// defines the type of alert
    public partial interface IAlertPropertiesDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>Alert category</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Alert category",
        SerializedName = @"category",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory? Category { get; set; }
        /// <summary>Criteria that triggered alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Criteria that triggered alert",
        SerializedName = @"criteria",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria? Criterion { get; set; }
        /// <summary>type of alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"type of alert",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType? Type { get; set; }

    }
    /// defines the type of alert
    public partial interface IAlertPropertiesDefinitionInternal

    {
        /// <summary>Alert category</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory? Category { get; set; }
        /// <summary>Criteria that triggered alert</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria? Criterion { get; set; }
        /// <summary>type of alert</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType? Type { get; set; }

    }
}