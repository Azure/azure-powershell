namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    public partial class AlertProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CloseTime" /> property.</summary>
        private string _closeTime;

        /// <summary>dateTime in which alert was closed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string CloseTime { get => this._closeTime; set => this._closeTime = value; }

        /// <summary>Backing field for <see cref="CostEntityId" /> property.</summary>
        private string _costEntityId;

        /// <summary>related budget</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string CostEntityId { get => this._costEntityId; set => this._costEntityId = value; }

        /// <summary>Backing field for <see cref="CreationTime" /> property.</summary>
        private string _creationTime;

        /// <summary>dateTime in which alert was created</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string CreationTime { get => this._creationTime; set => this._creationTime = value; }

        /// <summary>Backing field for <see cref="Definition" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDefinition _definition;

        /// <summary>defines the type of alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDefinition Definition { get => (this._definition = this._definition ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDefinition()); set => this._definition = value; }

        /// <summary>Alert category</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory? DefinitionCategory { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDefinitionInternal)Definition).Category; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDefinitionInternal)Definition).Category = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory)""); }

        /// <summary>Criteria that triggered alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria? DefinitionCriterion { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDefinitionInternal)Definition).Criterion; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDefinitionInternal)Definition).Criterion = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria)""); }

        /// <summary>type of alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType? DefinitionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDefinitionInternal)Definition).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDefinitionInternal)Definition).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType)""); }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Alert description</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails _detail;

        /// <summary>Alert details</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails Detail { get => (this._detail = this._detail ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDetails()); set => this._detail = value; }

        /// <summary>budget threshold amount</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public decimal? DetailAmount { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).Amount; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).Amount = value ?? default(decimal); }

        /// <summary>list of emails to contact</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] DetailContactEmail { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).ContactEmail; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).ContactEmail = value ?? null /* arrayOf */; }

        /// <summary>list of action groups to broadcast to</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] DetailContactGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).ContactGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).ContactGroup = value ?? null /* arrayOf */; }

        /// <summary>list of contact roles</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] DetailContactRole { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).ContactRole; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).ContactRole = value ?? null /* arrayOf */; }

        /// <summary>current spend</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public decimal? DetailCurrentSpend { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).CurrentSpend; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).CurrentSpend = value ?? default(decimal); }

        /// <summary>array of meters to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] DetailMeterFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).MeterFilter; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).MeterFilter = value ?? null /* arrayOf */; }

        /// <summary>operator used to compare currentSpend with amount</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator? DetailOperator { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).Operator; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).Operator = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator)""); }

        /// <summary>overriding alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DetailOverridingAlert { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).OverridingAlert; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).OverridingAlert = value ?? null; }

        /// <summary>datetime of periodStartDate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DetailPeriodStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).PeriodStartDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).PeriodStartDate = value ?? null; }

        /// <summary>array of resources to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] DetailResourceFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).ResourceFilter; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).ResourceFilter = value ?? null /* arrayOf */; }

        /// <summary>array of resourceGroups to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] DetailResourceGroupFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).ResourceGroupFilter; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).ResourceGroupFilter = value ?? null /* arrayOf */; }

        /// <summary>tags to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny DetailTagFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).TagFilter; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).TagFilter = value ?? null /* model class */; }

        /// <summary>notification threshold percentage as a decimal which activated this alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public decimal? DetailThreshold { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).Threshold; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).Threshold = value ?? default(decimal); }

        /// <summary>Type of timegrain cadence</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType? DetailTimeGrainType { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).TimeGrainType; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).TimeGrainType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType)""); }

        /// <summary>notificationId that triggered this alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DetailTriggeredBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).TriggeredBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).TriggeredBy = value ?? null; }

        /// <summary>unit of currency being used</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DetailUnit { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).Unit; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)Detail).Unit = value ?? null; }

        /// <summary>Internal Acessors for Definition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDefinition Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal.Definition { get => (this._definition = this._definition ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDefinition()); set { {_definition = value;} } }

        /// <summary>Internal Acessors for Detail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal.Detail { get => (this._detail = this._detail ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDetails()); set { {_detail = value;} } }

        /// <summary>Backing field for <see cref="ModificationTime" /> property.</summary>
        private string _modificationTime;

        /// <summary>dateTime in which alert was last modified</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string ModificationTime { get => this._modificationTime; set => this._modificationTime = value; }

        /// <summary>Backing field for <see cref="Source" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertSource? _source;

        /// <summary>Source of alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertSource? Source { get => this._source; set => this._source = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertStatus? _status;

        /// <summary>alert status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertStatus? Status { get => this._status; set => this._status = value; }

        /// <summary>Backing field for <see cref="StatusModificationTime" /> property.</summary>
        private string _statusModificationTime;

        /// <summary>dateTime in which the alert status was last modified</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string StatusModificationTime { get => this._statusModificationTime; set => this._statusModificationTime = value; }

        /// <summary>Backing field for <see cref="StatusModificationUserName" /> property.</summary>
        private string _statusModificationUserName;

        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string StatusModificationUserName { get => this._statusModificationUserName; set => this._statusModificationUserName = value; }

        /// <summary>Creates an new <see cref="AlertProperties" /> instance.</summary>
        public AlertProperties()
        {

        }
    }
    public partial interface IAlertProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>dateTime in which alert was closed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"dateTime in which alert was closed",
        SerializedName = @"closeTime",
        PossibleTypes = new [] { typeof(string) })]
        string CloseTime { get; set; }
        /// <summary>related budget</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"related budget",
        SerializedName = @"costEntityId",
        PossibleTypes = new [] { typeof(string) })]
        string CostEntityId { get; set; }
        /// <summary>dateTime in which alert was created</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"dateTime in which alert was created",
        SerializedName = @"creationTime",
        PossibleTypes = new [] { typeof(string) })]
        string CreationTime { get; set; }
        /// <summary>Alert category</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Alert category",
        SerializedName = @"category",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory? DefinitionCategory { get; set; }
        /// <summary>Criteria that triggered alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Criteria that triggered alert",
        SerializedName = @"criteria",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria? DefinitionCriterion { get; set; }
        /// <summary>type of alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"type of alert",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType? DefinitionType { get; set; }
        /// <summary>Alert description</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Alert description",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>budget threshold amount</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"budget threshold amount",
        SerializedName = @"amount",
        PossibleTypes = new [] { typeof(decimal) })]
        decimal? DetailAmount { get; set; }
        /// <summary>list of emails to contact</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"list of emails to contact",
        SerializedName = @"contactEmails",
        PossibleTypes = new [] { typeof(string) })]
        string[] DetailContactEmail { get; set; }
        /// <summary>list of action groups to broadcast to</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"list of action groups to broadcast to",
        SerializedName = @"contactGroups",
        PossibleTypes = new [] { typeof(string) })]
        string[] DetailContactGroup { get; set; }
        /// <summary>list of contact roles</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"list of contact roles",
        SerializedName = @"contactRoles",
        PossibleTypes = new [] { typeof(string) })]
        string[] DetailContactRole { get; set; }
        /// <summary>current spend</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"current spend",
        SerializedName = @"currentSpend",
        PossibleTypes = new [] { typeof(decimal) })]
        decimal? DetailCurrentSpend { get; set; }
        /// <summary>array of meters to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"array of meters to filter by",
        SerializedName = @"meterFilter",
        PossibleTypes = new [] { typeof(string) })]
        string[] DetailMeterFilter { get; set; }
        /// <summary>operator used to compare currentSpend with amount</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"operator used to compare currentSpend with amount",
        SerializedName = @"operator",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator? DetailOperator { get; set; }
        /// <summary>overriding alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"overriding alert",
        SerializedName = @"overridingAlert",
        PossibleTypes = new [] { typeof(string) })]
        string DetailOverridingAlert { get; set; }
        /// <summary>datetime of periodStartDate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"datetime of periodStartDate",
        SerializedName = @"periodStartDate",
        PossibleTypes = new [] { typeof(string) })]
        string DetailPeriodStartDate { get; set; }
        /// <summary>array of resources to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"array of resources to filter by",
        SerializedName = @"resourceFilter",
        PossibleTypes = new [] { typeof(string) })]
        string[] DetailResourceFilter { get; set; }
        /// <summary>array of resourceGroups to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"array of resourceGroups to filter by",
        SerializedName = @"resourceGroupFilter",
        PossibleTypes = new [] { typeof(string) })]
        string[] DetailResourceGroupFilter { get; set; }
        /// <summary>tags to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"tags to filter by",
        SerializedName = @"tagFilter",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny DetailTagFilter { get; set; }
        /// <summary>notification threshold percentage as a decimal which activated this alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"notification threshold percentage as a decimal which activated this alert",
        SerializedName = @"threshold",
        PossibleTypes = new [] { typeof(decimal) })]
        decimal? DetailThreshold { get; set; }
        /// <summary>Type of timegrain cadence</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of timegrain cadence",
        SerializedName = @"timeGrainType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType? DetailTimeGrainType { get; set; }
        /// <summary>notificationId that triggered this alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"notificationId that triggered this alert",
        SerializedName = @"triggeredBy",
        PossibleTypes = new [] { typeof(string) })]
        string DetailTriggeredBy { get; set; }
        /// <summary>unit of currency being used</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"unit of currency being used",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string DetailUnit { get; set; }
        /// <summary>dateTime in which alert was last modified</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"dateTime in which alert was last modified",
        SerializedName = @"modificationTime",
        PossibleTypes = new [] { typeof(string) })]
        string ModificationTime { get; set; }
        /// <summary>Source of alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Source of alert",
        SerializedName = @"source",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertSource) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertSource? Source { get; set; }
        /// <summary>alert status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"alert status",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertStatus? Status { get; set; }
        /// <summary>dateTime in which the alert status was last modified</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"dateTime in which the alert status was last modified",
        SerializedName = @"statusModificationTime",
        PossibleTypes = new [] { typeof(string) })]
        string StatusModificationTime { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"statusModificationUserName",
        PossibleTypes = new [] { typeof(string) })]
        string StatusModificationUserName { get; set; }

    }
    public partial interface IAlertPropertiesInternal

    {
        /// <summary>dateTime in which alert was closed</summary>
        string CloseTime { get; set; }
        /// <summary>related budget</summary>
        string CostEntityId { get; set; }
        /// <summary>dateTime in which alert was created</summary>
        string CreationTime { get; set; }
        /// <summary>defines the type of alert</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDefinition Definition { get; set; }
        /// <summary>Alert category</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory? DefinitionCategory { get; set; }
        /// <summary>Criteria that triggered alert</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria? DefinitionCriterion { get; set; }
        /// <summary>type of alert</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType? DefinitionType { get; set; }
        /// <summary>Alert description</summary>
        string Description { get; set; }
        /// <summary>Alert details</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails Detail { get; set; }
        /// <summary>budget threshold amount</summary>
        decimal? DetailAmount { get; set; }
        /// <summary>list of emails to contact</summary>
        string[] DetailContactEmail { get; set; }
        /// <summary>list of action groups to broadcast to</summary>
        string[] DetailContactGroup { get; set; }
        /// <summary>list of contact roles</summary>
        string[] DetailContactRole { get; set; }
        /// <summary>current spend</summary>
        decimal? DetailCurrentSpend { get; set; }
        /// <summary>array of meters to filter by</summary>
        string[] DetailMeterFilter { get; set; }
        /// <summary>operator used to compare currentSpend with amount</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator? DetailOperator { get; set; }
        /// <summary>overriding alert</summary>
        string DetailOverridingAlert { get; set; }
        /// <summary>datetime of periodStartDate</summary>
        string DetailPeriodStartDate { get; set; }
        /// <summary>array of resources to filter by</summary>
        string[] DetailResourceFilter { get; set; }
        /// <summary>array of resourceGroups to filter by</summary>
        string[] DetailResourceGroupFilter { get; set; }
        /// <summary>tags to filter by</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny DetailTagFilter { get; set; }
        /// <summary>notification threshold percentage as a decimal which activated this alert</summary>
        decimal? DetailThreshold { get; set; }
        /// <summary>Type of timegrain cadence</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType? DetailTimeGrainType { get; set; }
        /// <summary>notificationId that triggered this alert</summary>
        string DetailTriggeredBy { get; set; }
        /// <summary>unit of currency being used</summary>
        string DetailUnit { get; set; }
        /// <summary>dateTime in which alert was last modified</summary>
        string ModificationTime { get; set; }
        /// <summary>Source of alert</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertSource? Source { get; set; }
        /// <summary>alert status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertStatus? Status { get; set; }
        /// <summary>dateTime in which the alert status was last modified</summary>
        string StatusModificationTime { get; set; }

        string StatusModificationUserName { get; set; }

    }
}