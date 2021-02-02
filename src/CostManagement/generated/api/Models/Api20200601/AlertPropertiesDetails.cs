namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>Alert details</summary>
    public partial class AlertPropertiesDetails :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal
    {

        /// <summary>Backing field for <see cref="Amount" /> property.</summary>
        private decimal? _amount;

        /// <summary>budget threshold amount</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public decimal? Amount { get => this._amount; set => this._amount = value; }

        /// <summary>Backing field for <see cref="ContactEmail" /> property.</summary>
        private string[] _contactEmail;

        /// <summary>list of emails to contact</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string[] ContactEmail { get => this._contactEmail; set => this._contactEmail = value; }

        /// <summary>Backing field for <see cref="ContactGroup" /> property.</summary>
        private string[] _contactGroup;

        /// <summary>list of action groups to broadcast to</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string[] ContactGroup { get => this._contactGroup; set => this._contactGroup = value; }

        /// <summary>Backing field for <see cref="ContactRole" /> property.</summary>
        private string[] _contactRole;

        /// <summary>list of contact roles</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string[] ContactRole { get => this._contactRole; set => this._contactRole = value; }

        /// <summary>Backing field for <see cref="CurrentSpend" /> property.</summary>
        private decimal? _currentSpend;

        /// <summary>current spend</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public decimal? CurrentSpend { get => this._currentSpend; set => this._currentSpend = value; }

        /// <summary>Backing field for <see cref="MeterFilter" /> property.</summary>
        private string[] _meterFilter;

        /// <summary>array of meters to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string[] MeterFilter { get => this._meterFilter; set => this._meterFilter = value; }

        /// <summary>Backing field for <see cref="Operator" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator? _operator;

        /// <summary>operator used to compare currentSpend with amount</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator? Operator { get => this._operator; set => this._operator = value; }

        /// <summary>Backing field for <see cref="OverridingAlert" /> property.</summary>
        private string _overridingAlert;

        /// <summary>overriding alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string OverridingAlert { get => this._overridingAlert; set => this._overridingAlert = value; }

        /// <summary>Backing field for <see cref="PeriodStartDate" /> property.</summary>
        private string _periodStartDate;

        /// <summary>datetime of periodStartDate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string PeriodStartDate { get => this._periodStartDate; set => this._periodStartDate = value; }

        /// <summary>Backing field for <see cref="ResourceFilter" /> property.</summary>
        private string[] _resourceFilter;

        /// <summary>array of resources to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string[] ResourceFilter { get => this._resourceFilter; set => this._resourceFilter = value; }

        /// <summary>Backing field for <see cref="ResourceGroupFilter" /> property.</summary>
        private string[] _resourceGroupFilter;

        /// <summary>array of resourceGroups to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string[] ResourceGroupFilter { get => this._resourceGroupFilter; set => this._resourceGroupFilter = value; }

        /// <summary>Backing field for <see cref="TagFilter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny _tagFilter;

        /// <summary>tags to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny TagFilter { get => (this._tagFilter = this._tagFilter ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Any()); set => this._tagFilter = value; }

        /// <summary>Backing field for <see cref="Threshold" /> property.</summary>
        private decimal? _threshold;

        /// <summary>notification threshold percentage as a decimal which activated this alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public decimal? Threshold { get => this._threshold; set => this._threshold = value; }

        /// <summary>Backing field for <see cref="TimeGrainType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType? _timeGrainType;

        /// <summary>Type of timegrain cadence</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType? TimeGrainType { get => this._timeGrainType; set => this._timeGrainType = value; }

        /// <summary>Backing field for <see cref="TriggeredBy" /> property.</summary>
        private string _triggeredBy;

        /// <summary>notificationId that triggered this alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string TriggeredBy { get => this._triggeredBy; set => this._triggeredBy = value; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit;

        /// <summary>unit of currency being used</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; set => this._unit = value; }

        /// <summary>Creates an new <see cref="AlertPropertiesDetails" /> instance.</summary>
        public AlertPropertiesDetails()
        {

        }
    }
    /// Alert details
    public partial interface IAlertPropertiesDetails :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>budget threshold amount</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"budget threshold amount",
        SerializedName = @"amount",
        PossibleTypes = new [] { typeof(decimal) })]
        decimal? Amount { get; set; }
        /// <summary>list of emails to contact</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"list of emails to contact",
        SerializedName = @"contactEmails",
        PossibleTypes = new [] { typeof(string) })]
        string[] ContactEmail { get; set; }
        /// <summary>list of action groups to broadcast to</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"list of action groups to broadcast to",
        SerializedName = @"contactGroups",
        PossibleTypes = new [] { typeof(string) })]
        string[] ContactGroup { get; set; }
        /// <summary>list of contact roles</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"list of contact roles",
        SerializedName = @"contactRoles",
        PossibleTypes = new [] { typeof(string) })]
        string[] ContactRole { get; set; }
        /// <summary>current spend</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"current spend",
        SerializedName = @"currentSpend",
        PossibleTypes = new [] { typeof(decimal) })]
        decimal? CurrentSpend { get; set; }
        /// <summary>array of meters to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"array of meters to filter by",
        SerializedName = @"meterFilter",
        PossibleTypes = new [] { typeof(string) })]
        string[] MeterFilter { get; set; }
        /// <summary>operator used to compare currentSpend with amount</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"operator used to compare currentSpend with amount",
        SerializedName = @"operator",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator? Operator { get; set; }
        /// <summary>overriding alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"overriding alert",
        SerializedName = @"overridingAlert",
        PossibleTypes = new [] { typeof(string) })]
        string OverridingAlert { get; set; }
        /// <summary>datetime of periodStartDate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"datetime of periodStartDate",
        SerializedName = @"periodStartDate",
        PossibleTypes = new [] { typeof(string) })]
        string PeriodStartDate { get; set; }
        /// <summary>array of resources to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"array of resources to filter by",
        SerializedName = @"resourceFilter",
        PossibleTypes = new [] { typeof(string) })]
        string[] ResourceFilter { get; set; }
        /// <summary>array of resourceGroups to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"array of resourceGroups to filter by",
        SerializedName = @"resourceGroupFilter",
        PossibleTypes = new [] { typeof(string) })]
        string[] ResourceGroupFilter { get; set; }
        /// <summary>tags to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"tags to filter by",
        SerializedName = @"tagFilter",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny TagFilter { get; set; }
        /// <summary>notification threshold percentage as a decimal which activated this alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"notification threshold percentage as a decimal which activated this alert",
        SerializedName = @"threshold",
        PossibleTypes = new [] { typeof(decimal) })]
        decimal? Threshold { get; set; }
        /// <summary>Type of timegrain cadence</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of timegrain cadence",
        SerializedName = @"timeGrainType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType? TimeGrainType { get; set; }
        /// <summary>notificationId that triggered this alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"notificationId that triggered this alert",
        SerializedName = @"triggeredBy",
        PossibleTypes = new [] { typeof(string) })]
        string TriggeredBy { get; set; }
        /// <summary>unit of currency being used</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"unit of currency being used",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get; set; }

    }
    /// Alert details
    public partial interface IAlertPropertiesDetailsInternal

    {
        /// <summary>budget threshold amount</summary>
        decimal? Amount { get; set; }
        /// <summary>list of emails to contact</summary>
        string[] ContactEmail { get; set; }
        /// <summary>list of action groups to broadcast to</summary>
        string[] ContactGroup { get; set; }
        /// <summary>list of contact roles</summary>
        string[] ContactRole { get; set; }
        /// <summary>current spend</summary>
        decimal? CurrentSpend { get; set; }
        /// <summary>array of meters to filter by</summary>
        string[] MeterFilter { get; set; }
        /// <summary>operator used to compare currentSpend with amount</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator? Operator { get; set; }
        /// <summary>overriding alert</summary>
        string OverridingAlert { get; set; }
        /// <summary>datetime of periodStartDate</summary>
        string PeriodStartDate { get; set; }
        /// <summary>array of resources to filter by</summary>
        string[] ResourceFilter { get; set; }
        /// <summary>array of resourceGroups to filter by</summary>
        string[] ResourceGroupFilter { get; set; }
        /// <summary>tags to filter by</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny TagFilter { get; set; }
        /// <summary>notification threshold percentage as a decimal which activated this alert</summary>
        decimal? Threshold { get; set; }
        /// <summary>Type of timegrain cadence</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType? TimeGrainType { get; set; }
        /// <summary>notificationId that triggered this alert</summary>
        string TriggeredBy { get; set; }
        /// <summary>unit of currency being used</summary>
        string Unit { get; set; }

    }
}