namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The properties of a monitoring event.</summary>
    public partial class EventProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AffectedObjectCorrelationId" /> property.</summary>
        private string _affectedObjectCorrelationId;

        /// <summary>The affected object correlationId for the event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AffectedObjectCorrelationId { get => this._affectedObjectCorrelationId; }

        /// <summary>Backing field for <see cref="AffectedObjectFriendlyName" /> property.</summary>
        private string _affectedObjectFriendlyName;

        /// <summary>
        /// The friendly name of the source of the event on which it is raised (for example, VM, VMM etc).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AffectedObjectFriendlyName { get => this._affectedObjectFriendlyName; set => this._affectedObjectFriendlyName = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>The event name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="EventCode" /> property.</summary>
        private string _eventCode;

        /// <summary>The Id of the monitoring event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EventCode { get => this._eventCode; set => this._eventCode = value; }

        /// <summary>Backing field for <see cref="EventSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventSpecificDetails _eventSpecificDetail;

        /// <summary>The event specific settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventSpecificDetails EventSpecificDetail { get => (this._eventSpecificDetail = this._eventSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventSpecificDetails()); set => this._eventSpecificDetail = value; }

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string EventSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventSpecificDetailsInternal)EventSpecificDetail).InstanceType; }

        /// <summary>Backing field for <see cref="EventType" /> property.</summary>
        private string _eventType;

        /// <summary>The type of the event. for example: VM Health, Server Health, Job Failure etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EventType { get => this._eventType; set => this._eventType = value; }

        /// <summary>Backing field for <see cref="FabricId" /> property.</summary>
        private string _fabricId;

        /// <summary>The ARM ID of the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FabricId { get => this._fabricId; set => this._fabricId = value; }

        /// <summary>Backing field for <see cref="HealthError" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] _healthError;

        /// <summary>The list of errors / warnings capturing details associated with the issue(s).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthError { get => this._healthError; set => this._healthError = value; }

        /// <summary>Internal Acessors for AffectedObjectCorrelationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventPropertiesInternal.AffectedObjectCorrelationId { get => this._affectedObjectCorrelationId; set { {_affectedObjectCorrelationId = value;} } }

        /// <summary>Internal Acessors for EventSpecificDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventSpecificDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventPropertiesInternal.EventSpecificDetail { get => (this._eventSpecificDetail = this._eventSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventSpecificDetails()); set { {_eventSpecificDetail = value;} } }

        /// <summary>Internal Acessors for EventSpecificDetailInstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventPropertiesInternal.EventSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventSpecificDetailsInternal)EventSpecificDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventSpecificDetailsInternal)EventSpecificDetail).InstanceType = value; }

        /// <summary>Internal Acessors for ProviderSpecificDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventPropertiesInternal.ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventProviderSpecificDetails()); set { {_providerSpecificDetail = value;} } }

        /// <summary>Internal Acessors for ProviderSpecificDetailInstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventPropertiesInternal.ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal)ProviderSpecificDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal)ProviderSpecificDetail).InstanceType = value; }

        /// <summary>Backing field for <see cref="ProviderSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetails _providerSpecificDetail;

        /// <summary>The provider specific settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetails ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventProviderSpecificDetails()); set => this._providerSpecificDetail = value; }

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal)ProviderSpecificDetail).InstanceType; }

        /// <summary>Backing field for <see cref="Severity" /> property.</summary>
        private string _severity;

        /// <summary>The severity of the event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Severity { get => this._severity; set => this._severity = value; }

        /// <summary>Backing field for <see cref="TimeOfOccurrence" /> property.</summary>
        private global::System.DateTime? _timeOfOccurrence;

        /// <summary>The time of occurrence of the event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? TimeOfOccurrence { get => this._timeOfOccurrence; set => this._timeOfOccurrence = value; }

        /// <summary>Creates an new <see cref="EventProperties" /> instance.</summary>
        public EventProperties()
        {

        }
    }
    /// The properties of a monitoring event.
    public partial interface IEventProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The affected object correlationId for the event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The affected object correlationId for the event.",
        SerializedName = @"affectedObjectCorrelationId",
        PossibleTypes = new [] { typeof(string) })]
        string AffectedObjectCorrelationId { get;  }
        /// <summary>
        /// The friendly name of the source of the event on which it is raised (for example, VM, VMM etc).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The friendly name of the source of the event on which it is raised (for example, VM, VMM etc).",
        SerializedName = @"affectedObjectFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string AffectedObjectFriendlyName { get; set; }
        /// <summary>The event name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The event name.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The Id of the monitoring event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Id of the monitoring event.",
        SerializedName = @"eventCode",
        PossibleTypes = new [] { typeof(string) })]
        string EventCode { get; set; }
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the class type. Overridden in derived classes.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string EventSpecificDetailInstanceType { get;  }
        /// <summary>The type of the event. for example: VM Health, Server Health, Job Failure etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the event. for example: VM Health, Server Health, Job Failure etc.",
        SerializedName = @"eventType",
        PossibleTypes = new [] { typeof(string) })]
        string EventType { get; set; }
        /// <summary>The ARM ID of the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM ID of the fabric.",
        SerializedName = @"fabricId",
        PossibleTypes = new [] { typeof(string) })]
        string FabricId { get; set; }
        /// <summary>The list of errors / warnings capturing details associated with the issue(s).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of errors / warnings capturing details associated with the issue(s).",
        SerializedName = @"healthErrors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthError { get; set; }
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the class type. Overridden in derived classes.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderSpecificDetailInstanceType { get;  }
        /// <summary>The severity of the event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The severity of the event.",
        SerializedName = @"severity",
        PossibleTypes = new [] { typeof(string) })]
        string Severity { get; set; }
        /// <summary>The time of occurrence of the event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time of occurrence of the event.",
        SerializedName = @"timeOfOccurrence",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TimeOfOccurrence { get; set; }

    }
    /// The properties of a monitoring event.
    internal partial interface IEventPropertiesInternal

    {
        /// <summary>The affected object correlationId for the event.</summary>
        string AffectedObjectCorrelationId { get; set; }
        /// <summary>
        /// The friendly name of the source of the event on which it is raised (for example, VM, VMM etc).
        /// </summary>
        string AffectedObjectFriendlyName { get; set; }
        /// <summary>The event name.</summary>
        string Description { get; set; }
        /// <summary>The Id of the monitoring event.</summary>
        string EventCode { get; set; }
        /// <summary>The event specific settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventSpecificDetails EventSpecificDetail { get; set; }
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        string EventSpecificDetailInstanceType { get; set; }
        /// <summary>The type of the event. for example: VM Health, Server Health, Job Failure etc.</summary>
        string EventType { get; set; }
        /// <summary>The ARM ID of the fabric.</summary>
        string FabricId { get; set; }
        /// <summary>The list of errors / warnings capturing details associated with the issue(s).</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthError { get; set; }
        /// <summary>The provider specific settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetails ProviderSpecificDetail { get; set; }
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        string ProviderSpecificDetailInstanceType { get; set; }
        /// <summary>The severity of the event.</summary>
        string Severity { get; set; }
        /// <summary>The time of occurrence of the event.</summary>
        global::System.DateTime? TimeOfOccurrence { get; set; }

    }
}