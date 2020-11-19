namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Model class for event details of a VMwareAzureV2 event.</summary>
    public partial class InMageAzureV2EventDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2EventDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2EventDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetails __eventProviderSpecificDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventProviderSpecificDetails();

        /// <summary>Backing field for <see cref="Category" /> property.</summary>
        private string _category;

        /// <summary>InMage Event Category.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Category { get => this._category; set => this._category = value; }

        /// <summary>Backing field for <see cref="Component" /> property.</summary>
        private string _component;

        /// <summary>InMage Event Component.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Component { get => this._component; set => this._component = value; }

        /// <summary>Backing field for <see cref="CorrectiveAction" /> property.</summary>
        private string _correctiveAction;

        /// <summary>Corrective Action string for the event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string CorrectiveAction { get => this._correctiveAction; set => this._correctiveAction = value; }

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private string _detail;

        /// <summary>InMage Event Details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Detail { get => this._detail; set => this._detail = value; }

        /// <summary>Backing field for <see cref="EventType" /> property.</summary>
        private string _eventType;

        /// <summary>
        /// InMage Event type. Takes one of the values of {InMageDataContract.InMageMonitoringEventType}.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EventType { get => this._eventType; set => this._eventType = value; }

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal)__eventProviderSpecificDetails).InstanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal)__eventProviderSpecificDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal)__eventProviderSpecificDetails).InstanceType = value; }

        /// <summary>Backing field for <see cref="SiteName" /> property.</summary>
        private string _siteName;

        /// <summary>VMware Site name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SiteName { get => this._siteName; set => this._siteName = value; }

        /// <summary>Backing field for <see cref="Summary" /> property.</summary>
        private string _summary;

        /// <summary>InMage Event Summary.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Summary { get => this._summary; set => this._summary = value; }

        /// <summary>Creates an new <see cref="InMageAzureV2EventDetails" /> instance.</summary>
        public InMageAzureV2EventDetails()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__eventProviderSpecificDetails), __eventProviderSpecificDetails);
            await eventListener.AssertObjectIsValid(nameof(__eventProviderSpecificDetails), __eventProviderSpecificDetails);
        }
    }
    /// Model class for event details of a VMwareAzureV2 event.
    public partial interface IInMageAzureV2EventDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetails
    {
        /// <summary>InMage Event Category.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"InMage Event Category.",
        SerializedName = @"category",
        PossibleTypes = new [] { typeof(string) })]
        string Category { get; set; }
        /// <summary>InMage Event Component.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"InMage Event Component.",
        SerializedName = @"component",
        PossibleTypes = new [] { typeof(string) })]
        string Component { get; set; }
        /// <summary>Corrective Action string for the event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Corrective Action string for the event.",
        SerializedName = @"correctiveAction",
        PossibleTypes = new [] { typeof(string) })]
        string CorrectiveAction { get; set; }
        /// <summary>InMage Event Details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"InMage Event Details.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(string) })]
        string Detail { get; set; }
        /// <summary>
        /// InMage Event type. Takes one of the values of {InMageDataContract.InMageMonitoringEventType}.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"InMage Event type. Takes one of the values of {InMageDataContract.InMageMonitoringEventType}.",
        SerializedName = @"eventType",
        PossibleTypes = new [] { typeof(string) })]
        string EventType { get; set; }
        /// <summary>VMware Site name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VMware Site name.",
        SerializedName = @"siteName",
        PossibleTypes = new [] { typeof(string) })]
        string SiteName { get; set; }
        /// <summary>InMage Event Summary.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"InMage Event Summary.",
        SerializedName = @"summary",
        PossibleTypes = new [] { typeof(string) })]
        string Summary { get; set; }

    }
    /// Model class for event details of a VMwareAzureV2 event.
    internal partial interface IInMageAzureV2EventDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal
    {
        /// <summary>InMage Event Category.</summary>
        string Category { get; set; }
        /// <summary>InMage Event Component.</summary>
        string Component { get; set; }
        /// <summary>Corrective Action string for the event.</summary>
        string CorrectiveAction { get; set; }
        /// <summary>InMage Event Details.</summary>
        string Detail { get; set; }
        /// <summary>
        /// InMage Event type. Takes one of the values of {InMageDataContract.InMageMonitoringEventType}.
        /// </summary>
        string EventType { get; set; }
        /// <summary>VMware Site name.</summary>
        string SiteName { get; set; }
        /// <summary>InMage Event Summary.</summary>
        string Summary { get; set; }

    }
}