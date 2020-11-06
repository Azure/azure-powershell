namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Implements the event query parameter.</summary>
    public partial class EventQueryParameter :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameter,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal
    {

        /// <summary>Backing field for <see cref="AffectedObjectCorrelationId" /> property.</summary>
        private string _affectedObjectCorrelationId;

        /// <summary>The affected object correlationId for the events to be queried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AffectedObjectCorrelationId { get => this._affectedObjectCorrelationId; }

        /// <summary>Backing field for <see cref="AffectedObjectFriendlyName" /> property.</summary>
        private string _affectedObjectFriendlyName;

        /// <summary>The affected object name of the events to be queried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AffectedObjectFriendlyName { get => this._affectedObjectFriendlyName; set => this._affectedObjectFriendlyName = value; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>The end time of the time range within which the events are to be queried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Backing field for <see cref="EventCode" /> property.</summary>
        private string _eventCode;

        /// <summary>The source id of the events to be queried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EventCode { get => this._eventCode; set => this._eventCode = value; }

        /// <summary>Backing field for <see cref="EventType" /> property.</summary>
        private string _eventType;

        /// <summary>The type of the events to be queried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EventType { get => this._eventType; set => this._eventType = value; }

        /// <summary>Backing field for <see cref="FabricName" /> property.</summary>
        private string _fabricName;

        /// <summary>The affected object server id of the events to be queried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FabricName { get => this._fabricName; set => this._fabricName = value; }

        /// <summary>Internal Acessors for AffectedObjectCorrelationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal.AffectedObjectCorrelationId { get => this._affectedObjectCorrelationId; set { {_affectedObjectCorrelationId = value;} } }

        /// <summary>Backing field for <see cref="Severity" /> property.</summary>
        private string _severity;

        /// <summary>The severity of the events to be queried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Severity { get => this._severity; set => this._severity = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>The start time of the time range within which the events are to be queried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Creates an new <see cref="EventQueryParameter" /> instance.</summary>
        public EventQueryParameter()
        {

        }
    }
    /// Implements the event query parameter.
    public partial interface IEventQueryParameter :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The affected object correlationId for the events to be queried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The affected object correlationId for the events to be queried.",
        SerializedName = @"affectedObjectCorrelationId",
        PossibleTypes = new [] { typeof(string) })]
        string AffectedObjectCorrelationId { get;  }
        /// <summary>The affected object name of the events to be queried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The affected object name of the events to be queried.",
        SerializedName = @"affectedObjectFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string AffectedObjectFriendlyName { get; set; }
        /// <summary>The end time of the time range within which the events are to be queried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The end time of the time range within which the events are to be queried.",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get; set; }
        /// <summary>The source id of the events to be queried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The source id of the events to be queried.",
        SerializedName = @"eventCode",
        PossibleTypes = new [] { typeof(string) })]
        string EventCode { get; set; }
        /// <summary>The type of the events to be queried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the events to be queried.",
        SerializedName = @"eventType",
        PossibleTypes = new [] { typeof(string) })]
        string EventType { get; set; }
        /// <summary>The affected object server id of the events to be queried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The affected object server id of the events to be queried.",
        SerializedName = @"fabricName",
        PossibleTypes = new [] { typeof(string) })]
        string FabricName { get; set; }
        /// <summary>The severity of the events to be queried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The severity of the events to be queried.",
        SerializedName = @"severity",
        PossibleTypes = new [] { typeof(string) })]
        string Severity { get; set; }
        /// <summary>The start time of the time range within which the events are to be queried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The start time of the time range within which the events are to be queried.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }

    }
    /// Implements the event query parameter.
    internal partial interface IEventQueryParameterInternal

    {
        /// <summary>The affected object correlationId for the events to be queried.</summary>
        string AffectedObjectCorrelationId { get; set; }
        /// <summary>The affected object name of the events to be queried.</summary>
        string AffectedObjectFriendlyName { get; set; }
        /// <summary>The end time of the time range within which the events are to be queried.</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>The source id of the events to be queried.</summary>
        string EventCode { get; set; }
        /// <summary>The type of the events to be queried.</summary>
        string EventType { get; set; }
        /// <summary>The affected object server id of the events to be queried.</summary>
        string FabricName { get; set; }
        /// <summary>The severity of the events to be queried.</summary>
        string Severity { get; set; }
        /// <summary>The start time of the time range within which the events are to be queried.</summary>
        global::System.DateTime? StartTime { get; set; }

    }
}