namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The request payload to update an alert</summary>
    public partial class DismissAlertPayload :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDismissAlertPayload,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDismissAlertPayloadInternal
    {

        /// <summary>dateTime in which alert was closed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string CloseTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).CloseTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).CloseTime = value ?? null; }

        /// <summary>related budget</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string CostEntityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).CostEntityId; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).CostEntityId = value ?? null; }

        /// <summary>dateTime in which alert was created</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string CreationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).CreationTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).CreationTime = value ?? null; }

        /// <summary>Alert category</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory? DefinitionCategory { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DefinitionCategory; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DefinitionCategory = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory)""); }

        /// <summary>Criteria that triggered alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria? DefinitionCriterion { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DefinitionCriterion; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DefinitionCriterion = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria)""); }

        /// <summary>type of alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType? DefinitionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DefinitionType; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DefinitionType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType)""); }

        /// <summary>Alert description</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).Description = value ?? null; }

        /// <summary>budget threshold amount</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public decimal? DetailAmount { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailAmount; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailAmount = value ?? default(decimal); }

        /// <summary>list of emails to contact</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] DetailContactEmail { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailContactEmail; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailContactEmail = value ?? null /* arrayOf */; }

        /// <summary>list of action groups to broadcast to</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] DetailContactGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailContactGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailContactGroup = value ?? null /* arrayOf */; }

        /// <summary>list of contact roles</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] DetailContactRole { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailContactRole; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailContactRole = value ?? null /* arrayOf */; }

        /// <summary>current spend</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public decimal? DetailCurrentSpend { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailCurrentSpend; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailCurrentSpend = value ?? default(decimal); }

        /// <summary>array of meters to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] DetailMeterFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailMeterFilter; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailMeterFilter = value ?? null /* arrayOf */; }

        /// <summary>operator used to compare currentSpend with amount</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator? DetailOperator { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailOperator; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailOperator = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator)""); }

        /// <summary>overriding alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DetailOverridingAlert { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailOverridingAlert; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailOverridingAlert = value ?? null; }

        /// <summary>datetime of periodStartDate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DetailPeriodStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailPeriodStartDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailPeriodStartDate = value ?? null; }

        /// <summary>array of resources to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] DetailResourceFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailResourceFilter; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailResourceFilter = value ?? null /* arrayOf */; }

        /// <summary>array of resourceGroups to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] DetailResourceGroupFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailResourceGroupFilter; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailResourceGroupFilter = value ?? null /* arrayOf */; }

        /// <summary>tags to filter by</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny DetailTagFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailTagFilter; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailTagFilter = value ?? null /* model class */; }

        /// <summary>notification threshold percentage as a decimal which activated this alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public decimal? DetailThreshold { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailThreshold; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailThreshold = value ?? default(decimal); }

        /// <summary>Type of timegrain cadence</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType? DetailTimeGrainType { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailTimeGrainType; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailTimeGrainType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType)""); }

        /// <summary>notificationId that triggered this alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DetailTriggeredBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailTriggeredBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailTriggeredBy = value ?? null; }

        /// <summary>unit of currency being used</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DetailUnit { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailUnit; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).DetailUnit = value ?? null; }

        /// <summary>Internal Acessors for Definition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDefinition Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDismissAlertPayloadInternal.Definition { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).Definition; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).Definition = value; }

        /// <summary>Internal Acessors for Detail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDismissAlertPayloadInternal.Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).Detail; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).Detail = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertProperties Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDismissAlertPayloadInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertProperties()); set { {_property = value;} } }

        /// <summary>dateTime in which alert was last modified</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string ModificationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).ModificationTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).ModificationTime = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertProperties _property;

        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertProperties()); set => this._property = value; }

        /// <summary>Source of alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertSource? Source { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).Source; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).Source = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertSource)""); }

        /// <summary>alert status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertStatus? Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).Status = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertStatus)""); }

        /// <summary>dateTime in which the alert status was last modified</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string StatusModificationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).StatusModificationTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).StatusModificationTime = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string StatusModificationUserName { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).StatusModificationUserName; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)Property).StatusModificationUserName = value ?? null; }

        /// <summary>Creates an new <see cref="DismissAlertPayload" /> instance.</summary>
        public DismissAlertPayload()
        {

        }
    }
    /// The request payload to update an alert
    public partial interface IDismissAlertPayload :
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
    /// The request payload to update an alert
    public partial interface IDismissAlertPayloadInternal

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

        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertProperties Property { get; set; }
        /// <summary>Source of alert</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertSource? Source { get; set; }
        /// <summary>alert status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertStatus? Status { get; set; }
        /// <summary>dateTime in which the alert status was last modified</summary>
        string StatusModificationTime { get; set; }

        string StatusModificationUserName { get; set; }

    }
}