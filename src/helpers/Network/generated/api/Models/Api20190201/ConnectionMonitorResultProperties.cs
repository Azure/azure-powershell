namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Describes the properties of a connection monitor.</summary>
    public partial class ConnectionMonitorResultProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorResultProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorResultPropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParameters"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParameters __connectionMonitorParameters = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorParameters();

        /// <summary>Determines if the connection monitor will start automatically once created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public bool? AutoStart { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).AutoStart; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).AutoStart = value; }

        /// <summary>Describes the destination of connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorDestination Destination { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).Destination; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).Destination = value; }

        /// <summary>Address of the connection monitor destination (IP or domain name).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string DestinationAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).DestinationAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).DestinationAddress = value; }

        /// <summary>The destination port used by connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public int? DestinationPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).DestinationPort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).DestinationPort = value; }

        /// <summary>The ID of the resource used as the destination by connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string DestinationResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).DestinationResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).DestinationResourceId = value; }

        /// <summary>Monitoring interval in seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public int? MonitoringIntervalInSeconds { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).MonitoringIntervalInSeconds; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).MonitoringIntervalInSeconds = value; }

        /// <summary>Backing field for <see cref="MonitoringStatus" /> property.</summary>
        private string _monitoringStatus;

        /// <summary>The monitoring status of the connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string MonitoringStatus { get => this._monitoringStatus; set => this._monitoringStatus = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioning state of the connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Describes the source of connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorSource Source { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).Source; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).Source = value; }

        /// <summary>The source port used by connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public int? SourcePort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).SourcePort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).SourcePort = value; }

        /// <summary>The ID of the resource used as the source by connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string SourceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).SourceResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)__connectionMonitorParameters).SourceResourceId = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>The date and time when the connection monitor was started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Creates an new <see cref="ConnectionMonitorResultProperties" /> instance.</summary>
        public ConnectionMonitorResultProperties()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__connectionMonitorParameters), __connectionMonitorParameters);
            await eventListener.AssertObjectIsValid(nameof(__connectionMonitorParameters), __connectionMonitorParameters);
        }
    }
    /// Describes the properties of a connection monitor.
    public partial interface IConnectionMonitorResultProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParameters
    {
        /// <summary>The monitoring status of the connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The monitoring status of the connection monitor.",
        SerializedName = @"monitoringStatus",
        PossibleTypes = new [] { typeof(string) })]
        string MonitoringStatus { get; set; }
        /// <summary>The provisioning state of the connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the connection monitor.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The date and time when the connection monitor was started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The date and time when the connection monitor was started.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }

    }
    /// Describes the properties of a connection monitor.
    internal partial interface IConnectionMonitorResultPropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal
    {
        /// <summary>The monitoring status of the connection monitor.</summary>
        string MonitoringStatus { get; set; }
        /// <summary>The provisioning state of the connection monitor.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The date and time when the connection monitor was started.</summary>
        global::System.DateTime? StartTime { get; set; }

    }
}